using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationCLASIFICADOS_BackEnd.Models
{
    public partial class Correos
    {
        public int IdCorreo { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Mensaje { get; set; }
    }
}
