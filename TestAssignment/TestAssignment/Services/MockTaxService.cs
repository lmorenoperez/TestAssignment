using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.Models;
using TestAssignment.Services;


namespace TestAssignment.Services
{
    public class MockTaxService : ITaxService
    {

        public async Task<TaxRateModel> GetRate(string city)
        {
            string json = "{    \"rate\": {  \"city\": \"SANTA MONICA\", \"city_rate\": \"0.0\", \"combined_district_rate\": \"0.03\",  \"combined_rate\": \"0.1055\",        \"country\": \"US\",        \"country_rate\": \"0.0\",        \"county\": \"LOS ANGELES\",        \"county_rate\": \"0.01\",        \"freight_taxable\": false,        \"state\": \"CA\",        \"state_rate\": \"0.0625\",        \"zip\": \"90404\"    }        }";
            return await Task.Run(() => JsonConvert.DeserializeObject<TaxRateModel>(json));
        }

    }
}
