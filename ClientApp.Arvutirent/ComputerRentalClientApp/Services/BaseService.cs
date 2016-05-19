using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRentalClientApp.Services
{
    public class BaseService
    {
        private HttpClient _client;

        public BaseService(string serviceUrl)
        {
            this._client = new HttpClient();
            _client.BaseAddress = new Uri(serviceUrl);
        }

        public async Task<T> getData<T>(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> postData<T>(string url, T obj)
        {
            var response = await _client.PostAsJsonAsync<T>(url, obj);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

        public async void updateData(string url, object obj)
        {
            var response = await _client.PutAsJsonAsync(url, obj);
            response.EnsureSuccessStatusCode();

        }

        public async void deleteData(string url)
        {
            var response = await _client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
