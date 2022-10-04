using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace YG.Common.Models
{

    public class MyTypedClient
    {
        public HttpClient Client { get; set; }
        private IHttpClientFactory _client { get; }
        public MyTypedClient(HttpClient client, IHttpClientFactory _client)
        {
            this._client = _client;
            client.BaseAddress = new Uri("https://localhost:1234");
            this.Client = client;
        }

        public UploadImagesResponse PostImgAndGetData(List<IFormFile> files, Guid IDBaiViet)
        {
            var httpClient = _client.CreateClient();
            var content = new MultipartFormDataContent();
            foreach (var file in files)
            {
                if (file.Length <= 0)
                    continue;

                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                content.Add(new StreamContent(file.OpenReadStream())
                {
                    Headers =
                    {

                        ContentLength = file.Length,
                        ContentType = new MediaTypeHeaderValue(file.ContentType)
                    }
                }, "File", fileName);
               
            }
            var response = httpClient.PostAsync("http://localhost:1234/api/home/UploadFile" + $"?ID={IDBaiViet}", content).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<UploadImagesResponse>(json);

            return obj;
        }
    }

}
