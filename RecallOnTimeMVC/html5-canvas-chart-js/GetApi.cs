using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace RecallOnTimeMVC.html5_canvas_chart_js
{
    public class GetApi
    {
        /// <summary>
        /// 封装
        /// </summary>
        /// <param name="verbs"></param>
        /// <param name="actionname"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Getapiresult(string verbs, string actionname, object obj = null)
        {
            string json = "";

            Task<HttpResponseMessage> task = null;

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5646/api/Zhizhi/");

            switch (verbs)
            {
                case "get":
                    task = client.GetAsync(actionname);
                    break;
                case "post":
                    task = client.PostAsJsonAsync(actionname, obj);
                    break;
                case "put":
                    task = client.PutAsJsonAsync(actionname, obj);
                    break;
                case "delete":
                    task = client.DeleteAsync(actionname);
                    break;

            }

            task.Wait();

            var response = task.Result;

            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();

                read.Wait();

                json = read.Result;
            }
            return json;

        }
    }
}