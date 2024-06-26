﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ISSLab.Domain;
using ISSLab.Domain.MarketplacePosts;
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
            httpClient.BaseAddress = new Uri("https://localhost:32770/");
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

        public async Task<Uri> AddMarketplacePostAsync(MarketplacePost post)
        {
            try
            {
                var data = new
                {
                    post.GroupId,
                    post.AuthorId,
                    post.Title,
                    post.Description,
                    post.MediaContent,
                    post.Location,
                    post.CreationDate,
                    post.EndDate,
                    post.IsPromoted,
                    post.IsActive,
                    post.Type
                };
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/MarketPlacePost", data);
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
        public async Task<List<Group>> GetGroupsAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("api/Group");
                response.EnsureSuccessStatusCode();
                List<Group> groups = await response.Content.ReadFromJsonAsync<List<Group>>();
                return groups;
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Http error: {exception.Message}"); // should use the logger we implemented
                return new List<Group> { };
            }
            catch (JsonException exception)
            {
                Console.WriteLine($"Json error: {exception.Message}");
                return new List<Group> { };
            }
        }

        public async Task<User> GetUserById(Guid userId)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/User/{userId}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<User>();
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Http error: {exception.Message}"); // should use the logger we implemented
                return new User { };
            }
            catch (JsonException exception)
            {
                Console.WriteLine($"Json error: {exception.Message}");
                return new User { };
            }
        }

        public async Task<List<User>> GetGroupMembers(Guid groupId)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/Group/{groupId}/members");
                response.EnsureSuccessStatusCode();
                List<User> groupMembers =
                    await response.Content.ReadFromJsonAsync<List<User>>();
                return groupMembers;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http error: {ex.Message}"); // should use the logger we implemented
                return new List<User> { };
            }
            catch (JsonException exception)
            {
                Console.WriteLine($"Json error: {exception.Message}");
                return new List<User> { };
            }
        }

        public async Task<List<MarketplacePost>> GetPostsFromCart(Guid userId)
        {
            try
            {
                HttpResponseMessage response =
                    await httpClient.GetAsync($"api/User/{userId}/cart");
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

        public async Task<Uri> AddPostToCart(Guid postId, Guid userId)
        {
            try
            {
                var data = new
                {
                    userId,
                    postId
                };

                HttpResponseMessage response = await httpClient.PostAsJsonAsync($"api/User/{userId}/cart/{postId}", data);
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
        public async Task<Uri> AddPostToFavorite(Guid postId, Guid userId)
        {
            try
            {
                var data = new
                {
                    userId,
                    postId
                };

                HttpResponseMessage response = await httpClient.PostAsJsonAsync($"api/User/{userId}/favoritePosts/{postId}", data);
                response.EnsureSuccessStatusCode();

                Uri uri = response.Headers.Location;

                Console.WriteLine($"Post added to favorite successfully. URI: {uri}");

                return uri;
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Http error: {exception.Message}");
                Console.WriteLine("Failed to add post to favorite.");

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
                HttpResponseMessage response = await httpClient.GetAsync($"api/Group/{groupId}/posts");
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
                HttpResponseMessage response = await httpClient.GetAsync($"api/Group/{groupId}/join-requests");
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

        public async Task<List<MarketplacePost>> GetFavouritePosts(Guid userId)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/User/{userId}/favoritePosts");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<MarketplacePost>>();
            }
            catch (HttpRequestException exception)
            {
                // logger call here
                return new List<MarketplacePost> { };
            }
            catch (JsonException exception)
            {
                // logger call here
                return new List<MarketplacePost> { };
            }
        }
        public async Task<List<MarketplacePost>> GetMarketplacePosts()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("api/MarketplacePost");
                response.EnsureSuccessStatusCode();

                List<MarketplacePost> posts = await response.Content.ReadFromJsonAsync<List<MarketplacePost>>();
                return posts;
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


