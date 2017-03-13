using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Modelo
{
    public class Imagen
    {
        public int id { get; set; }

        public string imagenBase64 { get; set; }
        public byte[] imagen { get; set; }
        public List<Musica> musica { get; set; }
    }
}
