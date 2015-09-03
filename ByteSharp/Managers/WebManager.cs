using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Web;
using ByteSharp.Interfaces;

namespace ByteSharp.Managers
{
    public class WebManager : IWebManager
    {
        public WebManager(string authToken = null)
        {
            AuthenticationToken = authToken;
        }

        public bool IsNetworkAvailable => NetworkInterface.GetIsNetworkAvailable();

        public static string AuthenticationToken { get; set; }
        public async Task<Result> PostData(Uri uri, MultipartContent header, StringContent content)
        {
            var httpClient = new HttpClient();
            try
            {
                if (!string.IsNullOrEmpty(AuthenticationToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationToken);
                }
                HttpResponseMessage response;
                if (header == null)
                {
                    if (content == null) content = new StringContent(string.Empty);
                    response = await httpClient.PostAsync(uri, content);
                }
                else
                {
                    response = await httpClient.PostAsync(uri, header);
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                return new Result(response.IsSuccessStatusCode, responseContent);
            }
            catch (Exception ex)
            {
                throw new WebException("Byte API Error: Service error", ex);
            }
        }

        public async Task<Result> PutData(Uri uri, StringContent json)
        {
            var httpClient = new HttpClient();
            try
            {
                if (!string.IsNullOrEmpty(AuthenticationToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationToken);
                }
                if (json == null) json = new StringContent(string.Empty);
                var response = await httpClient.PutAsync(uri, json);
                var responseContent = await response.Content.ReadAsStringAsync();
                return new Result(response.IsSuccessStatusCode, responseContent);
            }
            catch (Exception ex)
            {
                throw new WebException("Byte API Error: Service error", ex);
            }
        }

        public async Task<Result> DeleteData(Uri uri, StringContent json)
        {
            var httpClient = new HttpClient();
            try
            {
                if (!string.IsNullOrEmpty(AuthenticationToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationToken);
                }
                if (json == null) json = new StringContent(string.Empty);
                var response = await httpClient.DeleteAsync(uri);
                var responseContent = await response.Content.ReadAsStringAsync();
                return new Result(response.IsSuccessStatusCode, responseContent);
            }
            catch (Exception ex)
            {
                throw new WebException("Byte API Error: Service error", ex);
            }
        }

        public async Task<Result> GetData(Uri uri)
        {
            var httpClient = new HttpClient();

            try
            {
                if (!string.IsNullOrEmpty(AuthenticationToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationToken);
                }
                var response = await httpClient.GetAsync(uri);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new WebException("Byte API Error: Service not found.");
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                return string.IsNullOrEmpty(responseContent) ? new Result(response.IsSuccessStatusCode, string.Empty) : new Result(response.IsSuccessStatusCode, responseContent);
            }
            catch (Exception ex)
            {

                throw new WebException("Byte API Error: Service error", ex);
            }
        }

        public async Task<Result> PutData(Uri uri, MultipartContent p, StringContent stringContent)
        {
            var httpClient = new HttpClient();
            try
            {
                if (!string.IsNullOrEmpty(AuthenticationToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationToken);
                }
                HttpResponseMessage response;
                if (p == null)
                {
                    if (stringContent == null) stringContent = new StringContent(string.Empty);
                    response = await httpClient.PutAsync(uri, stringContent);
                }
                else
                {
                    response = await httpClient.PutAsync(uri, p);
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                return new Result(response.IsSuccessStatusCode, responseContent);
            }
            catch (Exception ex)
            {
                throw new WebException("Byte API Error: Service error", ex);
            }
        }
    }
}
