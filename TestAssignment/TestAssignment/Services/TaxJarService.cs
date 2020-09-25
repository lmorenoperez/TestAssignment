using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.Models;
using TestAssignment.Services;
using Xamarin.Forms;

namespace TestAssignment.Services
{
    
    public class TaxJarService : ITaxService
    {
        public TaxJarService()
        {

        }
        public async Task<TaxRateModel> GetRate(string city)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            keyValues.Add("city", city);
            string json = "";
            var response = await DataServiceBase.GetDataAsync("rates/90404", keyValues);
            if (response.IsSuccessful)
            {
                json = response.Content;
            }
            return await Task.Run(() => JsonConvert.DeserializeObject<TaxRateModel>(json));
        }
    }
}
