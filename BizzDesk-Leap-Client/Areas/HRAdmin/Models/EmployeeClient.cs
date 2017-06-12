using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Models
{
    public class EmployeeClient
    {
        private string BASE_URL = "http://localhost:61040/api/";

        public IEnumerable<Employee> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("employee").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool Create(Employee employee)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("employee", employee).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

    }
}