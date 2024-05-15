using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
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

