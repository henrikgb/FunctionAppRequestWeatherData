using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using System.IO;

namespace WeatherFunctionApp
{
    public static class WeatherFunction
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string storageConnectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
        private static readonly BlobServiceClient blobServiceClient = new BlobServiceClient(storageConnectionString);
        private static readonly BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("weatherdata");
       

        [FunctionName("FetchWeatherData")]
        public static async Task Run(
            [TimerTrigger("0 10 * * * *")] TimerInfo myTimer,
            ILogger log)
        {

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            string apiKey = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY");
            string latitude = "58.81231852222533";
            string longitude = "5.546945324943648";
            string url = $"https://api.openweathermap.org/data/3.0/onecall?lat={latitude}&lon={longitude}&appid={apiKey}";


            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {

                string content = await response.Content.ReadAsStringAsync();
                log.LogInformation($"Received weather data: {content}");

                // Save data to Azure Blob Storage
                string blobName = "latestWeatherData.json"; // Fixed name for the blob
                BlobClient blobClient = containerClient.GetBlobClient(blobName);

                using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content)))
                {
                    await blobClient.UploadAsync(stream, overwrite: true);
                    log.LogInformation($"Weather data uploaded to Blob storage as blob: {blobName}");
                }
            }
            else
            {
                log.LogError($"Failed to fetch weather data. Status Code: {response.StatusCode}");
            }
        }
    }
}
