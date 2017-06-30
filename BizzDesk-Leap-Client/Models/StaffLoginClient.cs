using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace BizzDesk_Leap_Client.Models
{
    public class StaffLoginClient
    {
        private string BASE_URL = "http://localhost:61040/api/";

        public bool Login(string EmployeeID)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("stafflogin/{0}", EmployeeID).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}