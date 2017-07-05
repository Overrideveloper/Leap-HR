using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace BizzDesk_Leap_Client.Areas.Employee.Models
{
    public class RequestClient
    {
        private string BASE_URL = "http://localhost:61040/api/";

        public IEnumerable<Request> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("request").Result;
                return response.Content.ReadAsAsync<IEnumerable<Request>>().Result;

                //if (response.IsSuccessStatusCode)
                    
                //return null;
            }
            catch
            {
                return null;
            }
        }

        public Request find(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("request/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Request>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool Create(Request request)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("request/create", request).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Request request)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("request/" + request.ID, request).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}