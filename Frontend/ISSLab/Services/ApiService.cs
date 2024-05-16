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
                new MediaTypeWithQualityHeaderValue(
                    "application/json")); // Setting this header tells the server to send data in JSON format
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
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/addPost", post);
                response.EnsureSuccessStatusCode();

                Uri uri = response.Headers.Location;

                Console.WriteLine($"Post added successfully. URI: {uri}");

                return uri;
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Http error: {exception.Message}");
                Console.WriteLine("Failed to add post.");

                return null;
            }
            catch (JsonException exception)
            {
                Console.WriteLine($"Json error: {exception.Message}");
                Console.WriteLine("Failed to add post to cart due to JSON parsing error.");

                return null;
            }
        }

        public async Task<List<Post>> GetPosts()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/getPosts");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<Post>>();
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Http error: {exception.Message}");
                return new List<Post> { };
            }
            catch (JsonException exception)
            {
                Console.WriteLine($"Json error: {exception.Message}");
                return new List<Post> { };
            }
        }
        
      public async Task<List<GroupNonMarketplace>> GetGroupsAsync()
        {
            // TODO: Change to Domain entities
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("api/groups");
                response.EnsureSuccessStatusCode();
                List<GroupNonMarketplace> groups = await response.Content.ReadFromJsonAsync<List<GroupNonMarketplace>>();
                return groups;
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Http error: {exception.Message}"); // should use the logger we implemented
                return new List<GroupNonMarketplace> { };
            }
            catch (JsonException exception)
            {
                Console.WriteLine($"Json error: {exception.Message}");
                return new List<GroupNonMarketplace> { };
            }
        }

        public async Task<List<GroupMember>> GetGroupMembers(Guid groupId)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/groupMembers?groupId={groupId}");
                response.EnsureSuccessStatusCode();
                List<GroupMember> groupMembers =
                    await response.Content.ReadFromJsonAsync<List<GroupMember>>();
                return groupMembers;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http error: {ex.Message}"); // should use the logger we implemented
                return new List<GroupMember> { };
            }
            catch (JsonException exception)
            {
                Console.WriteLine($"Json error: {exception.Message}");
                return new List<GroupMember> { };
            }
        }

        public async Task<List<MarketplacePost>> GetPostsFromCart(Guid userId, Guid groupId)
        {
            try
            {
                HttpResponseMessage response =
                    await httpClient.GetAsync($"api/getPostsFromCart?userId={userId}&groupId={groupId}");
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

                HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/addPostToCart", data);
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
        }
        public async Task<List<Request>> GetRequestsToJoinGroup(Guid groupId)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/getGroupPolls?groupId={groupId}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<Request>>();
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Http error: {exception.Message}");
                return new List<Request> { };
            }
            catch (JsonException exception)
            {
                Console.WriteLine($"Json error: {exception.Message}");
                return new List<Request> { };
            }
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
        public async Task<List<MarketplacePost>> GetMarketplacePosts()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("api/getMarketplacePosts");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<MarketplacePost>>();
            }
            catch (HttpRequestException exception)
            {
                // call logger
                return new List<MarketplacePost> { };
            }
            catch (JsonException exception)
            {
                // call logger
                return new List<MarketplacePost> { };
            }
        }

        public void Dispose()
        {
                httpClient.Dispose();
        }
    }
}


