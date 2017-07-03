using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Models
{
    public class RankClient
    {

        private string BASE_URL = "http://localhost:61040/api/";

        public IEnumerable<Rank> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("rank/readall").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Rank>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Rank find(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("rank/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Rank>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool Create(Rank rank)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("rank/create", rank).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Rank rank)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("rank/" + rank.ID, rank).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("rank/" + id).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<Rank>> Search(string searchString)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(this.BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = client.GetAsync(string.Format("rank/search/{0}", searchString)).Result;

                return result.Content.ReadAsAsync<List<Rank>>();
            }
            catch
            {
                return null;
            }
        }
    }
}