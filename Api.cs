using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace TOTDBot
{
    internal class Api
    {
        string UserAgent = "TOTDBot";

        public Api() { }
        public async Task<Rootobject> Totd(string url)
        {
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            
            var maps = JsonConvert.DeserializeObject<Rootobject>(content);
            return maps;

        }
    }
}
