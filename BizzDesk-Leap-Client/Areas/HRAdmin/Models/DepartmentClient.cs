using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Net.Http.Formatting;
using System.Web;
using System.Threading.Tasks;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Models
{
    public class DepartmentClient
    {
        private string BASE_URL = "http://localhost:61040/api/";

        public IEnumerable<Department> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("department/readall").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Department>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Department find(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("department/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Department>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool Create(Department department)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("department/create", department).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Department department)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("department/" + department.ID, department).Result;

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
                HttpResponseMessage response = client.DeleteAsync("department/" + id).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public Task<List<Department>> Search(string searchString)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(this.BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = client.GetAsync(string.Format("department/search/{0}", searchString)).Result;

                return result.Content.ReadAsAsync<List<Department>>();
            }
            catch
            {
                return null;
            }
        }

    }
}