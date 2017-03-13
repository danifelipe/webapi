using ClassLibrary.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace web.Controllers
{

    public class OperacionController : ApiController
    {
        // GET: api/Operacion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Operacion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Operacion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Operacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Operacion/5
        public void Delete(int id)
        {
        }
        [AllowAnonymous]

        [Route("Operacion/sumar", Name = "sumar")]
        [HttpGet]
        public int sumar(int numeroUno, int numeroDos)
        {
            // int numeroUno = 0; int numeroDos=0;
            return numeroUno + numeroDos;
        }
        [AllowAnonymous]
        [Route("Operacion/musicaGet",Name = "musicaGet")]
        [HttpGet]
        public List<Musica> musicaGet()
        {
           List<Musica>a = new List<Musica>() ;
            a.Add(new Musica { id = 1, nombre = "aa" });

            return (a);
        }
        [AllowAnonymous]
        [Route("Operacion/sumar", Name = "sumarPost")]
       [HttpPost()]
        public int sumarPost([FromBody]int numeroUno, [FromBody]int numeroDos)
        {
            // int numeroUno = 0; int numeroDos=0;
            return numeroUno + numeroDos;
        }
    }
}
