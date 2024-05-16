using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ISSLab.Model.Entities;
using ISSLab.Services;

namespace ISSLab.Services
{
    public class ApiService
    {
        // All operations should use the same instance of HttpClient (Singleton)
        private static ApiService instance;
        private readonly HttpClient httpClient;

        private ApiService()
        {
            httpClient = new HttpClient();
            // TODO: Use actual server port number here
            httpClient.BaseAddress = new Uri("http://localhost:64195/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); // Setting this header tells the server to send data in JSON format
        }

        public static ApiService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiService();
                }
                return instance;
            }
        }

        public async Task<Uri> AddPostAsync(MarketplacePost post)
        {
            // might need to use this in the hardcoded posts functions as well
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/addPost", post);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync("api/groups");
            response.EnsureSuccessStatusCode();
            IEnumerable<Group> groups = await response.Content.ReadAsAsync<IEnumerable<Group>>();
            return groups;
        }

        public async Task<IEnumerable<GroupMember>> GetGroupMembers(Guid groupId)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"api/groupMembers?groupId={groupId}");
            response.EnsureSuccessStatusCode();
            IEnumerable<GroupMember> groupMembers = await response.Content.ReadAsAsync<IEnumerable<GroupMember>>();
            return groupMembers;
        }

        public async Task<List<MarketplacePost>> GetPostsFromCart(Guid userId, Guid groupId)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/getPostsFromCart?userId={userId}&groupId={groupId}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<MarketplacePost>>();
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Http error: {exception.Message}"); // should use the logger we implemented
                return new List<MarketplacePost> { };
            }
            catch (JsonException exception)
            {
                Console.WriteLine($"Json error: {exception.Message}");
                return new List<MarketplacePost> { };
            }
        }

        public async Task<Uri> AddPostToCart(Guid groupId, Guid postId, Guid userId)
        {
            try
            {
                var data = new
                {
                    groupId,
                    postId,
                    userId
                };

                var json = JsonSerializer.Serialize(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync("api/addPostToCart", content);
                response.EnsureSuccessStatusCode();

                Uri uri = response.Headers.Location;

                Console.WriteLine($"Post added to cart successfully. URI: {uri}");

                return uri;
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Http error: {exception.Message}");
                Console.WriteLine("Failed to add post to cart.");

                return null;
            }
            catch (JsonException exception)
            {
                Console.WriteLine($"Json error: {exception.Message}");
                Console.WriteLine("Failed to add post to cart due to JSON parsing error.");

                return null;
            }
        }

        public async Task<List<GroupPost>> GetGroupPosts(Guid groupId)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/getGroupPosts?groupId={groupId}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<GroupPost>>();
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Http error: {exception.Message}");
                return new List<GroupPost> { };
            }
            catch (JsonException exception)
            {
                Console.WriteLine($"Json error: {exception.Message}");
                return new List<GroupPost> { };
            }
        }
        public async Task<List<Poll>> GetGroupPolls(Guid groupId)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/getGroupPolls?groupId={groupId}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<Poll>>();
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Http error: {exception.Message}");
                return new List<Poll> { };
            }
            catch (JsonException exception)
            {
                Console.WriteLine($"Json error: {exception.Message}");
                return new List<Poll> { };
            }
        public async Task<List<Post>> GetFavouritePosts(Guid userId)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/getFavouritePosts?userId={userId}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<Post>>();
            }
            catch (HttpRequestException exception)
            {
                // logger call here
                return new List<Post> { };
            }
            catch (JsonException exception)
            {
                // logger call here
                return new List<Post> { };
            }

        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}

