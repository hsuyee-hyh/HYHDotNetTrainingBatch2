using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYHDotnetTrainingBatch2.ConsoleClientApp
{
    public class HttpClientService
    {
        public async Task RunAsync()
        {
            //await ReadAsync();
            //await CreateAsync();
            await UpdateAsync();
            //await DeleteAsync();
        }

        public async Task ReadAsync()
        {
            HttpClient client = new HttpClient();
            //api
            var response = await client.GetAsync("https://localhost:7167/api/blog/1/10");
            if (response.IsSuccessStatusCode)
            {
                // convert JSON to string
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
        }

        public async Task CreateAsync()
        {
            var item = new Blog
            {
                Title = "Http Title",
                Description = "Http Description",
                Author = "Http Author",
                DeleteFlag = false,
            };

            // convert C# obj to JSON string (using newton.soft)
            string jsonStr = JsonConvert.SerializeObject(item);

            // make StringContent for HttpContent
            StringContent strContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");


            HttpClient client = new HttpClient();
            var response = await client.PostAsync("https://localhost:7167/api/blog", strContent);
            
            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
        }

        public async Task UpdateAsync()
        {
            var item = new Blog
            {
                Id = 3,
                Title = "Http Update Title",
                Description = "Http Update Description",
                Author = "Http Update Author",
                DeleteFlag = false,
            };

            // convert to json string
            string jsonStr = JsonConvert.SerializeObject(item);

            // cover to stringcontent
            StringContent strContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");


            HttpClient client = new HttpClient();
            var response = await client.PutAsync($"https://localhost:7167/api/blog/{item.Id}", strContent);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
        }

        public async Task DeleteAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync("https://localhost:7167/api/blog/6");

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
        }
    }

   

    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Author { get; set; } = null!;

        public bool DeleteFlag { get; set; }
    }

}
