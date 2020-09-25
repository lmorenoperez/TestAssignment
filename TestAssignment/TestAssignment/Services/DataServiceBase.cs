using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace TestAssignment.Services
{
    public class DataServiceBase
    {
        static RestClient client = new RestClient(new Uri($"{App.BackendUrl}/"));
        static bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async static Task<IRestResponse> GetDataAsync(string methodname, Dictionary<string, string> paramts)
        {
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            if (App.access_token != null && App.access_token.Length > 0)
                request.AddHeader("Authorization", "Bearer " + App.access_token);

            request.AddHeader("Content-Type", "application/json");
            if (paramts != null && paramts.Count > 0)
            {
                foreach (var vparm in paramts)
                    request.AddParameter(vparm.Key, vparm.Value);
            }
            request.Resource = methodname;
            return await client.ExecuteGetAsync(request);
        }
       
        public async static Task<IRestResponse> PostDataAsync(string methodname, string jSon)
        {
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            if (App.access_token != null && App.access_token.Length > 0)
                request.AddHeader("Authorization", "Bearer " + App.access_token);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(jSon);
            request.Resource = methodname;
            return await client.ExecutePostAsync(request);
        }


    }
}
