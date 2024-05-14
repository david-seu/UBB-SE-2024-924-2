using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model.Entities;

namespace ISSLab.Services
{
    public class ApiService
    {
        // All operations should use the same instance of HttpClient; CAREFUL with how we use them in VM
        private static readonly HttpClient HttpClient;

        static ApiService()
        {
            // Initialize HttpClient only once
            HttpClient = new HttpClient();
            // TODO: Use actual server port number here
            HttpClient.BaseAddress = new Uri("http://localhost:64195/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); // Setting this header tells the server to send data in JSON format.
        }
        public static async Task<Uri> AddPostAsync(MarketplacePost post)
        {
            // might need to use this in the hardcoded posts functions as well
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/addPost", post);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }
        public static void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}
