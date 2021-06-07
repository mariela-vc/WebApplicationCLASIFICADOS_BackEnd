using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationCLASIFICADOS_BackEnd.Models
{
    public partial class Anuncio
    {
        public int IdAnuncio { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public float? Precio { get; set; }
        public string Imagen { get; set; }
    }
}
