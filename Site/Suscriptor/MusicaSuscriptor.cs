using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Site.Suscriptor
{
    public class MusicaSuscriptor
    {
        public int guardar()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:29121/");
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = cliente.GetAsync("Operacion/sumar?numeroUno=5&numeroDos=2").Result;
            return response.Content.ReadAsAsync<int>().Result;
        }
    }
}