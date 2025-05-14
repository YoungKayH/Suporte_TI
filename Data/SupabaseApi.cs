using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Supabase;
using Supabase.Postgrest;
using Newtonsoft.Json;
using Suporte_TI.Models;


namespace Suporte_TI.Data
{
    internal class SupabaseApi
    {
        private static readonly string baseUrl = "https://hivvlcsadegvepolpxqg.supabase.co";
        private static readonly string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImhpdnZsY3NhZGVndmVwb2xweHFnIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTc0NzE5Mjg1MywiZXhwIjoyMDYyNzY4ODUzfQ.c5s7g8jJYj0zJOb_IoAo3L61diM4vu3QMnuMU41ILrg";
        private static readonly string tabela = "mensagens";
        private static readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        public List<Suporte_TI.Models.MensagemSupabase> ObterMensagens(int chamadoId)
        {
            var mensagens = new List<Suporte_TI.Models.MensagemSupabase>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.DefaultRequestHeaders.Add("apikey", apiKey);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                string endpoint = $"{tabela}?cham_id=eq.{chamadoId}&order=data_envio.asc";

                HttpResponseMessage response = client.GetAsync(endpoint).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    mensagens = JsonConvert.DeserializeObject<List<Suporte_TI.Models.MensagemSupabase>>(json);
                }
            }

            return mensagens;
        }
        public bool EnviarMensagem(MensagemSupabase mensagem)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.DefaultRequestHeaders.Add("apikey", apiKey);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Prefer", "return=representation");

                string json = JsonConvert.SerializeObject(mensagem);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(tabela, content).Result;

                return response.IsSuccessStatusCode;
            }
        }
    }
}
