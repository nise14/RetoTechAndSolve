using System;
using System.Collections.Generic;

namespace AccesoDatos.Modelos
{
    public partial class Traza
    {
        public int Id { get; set; }
        public int? UsuarioCreaId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Archivo { get; set; }

        public Usuarios UsuarioCrea { get; set; }
    }
}
