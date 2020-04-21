using System;
using System.Collections.Generic;

namespace AccesoDatos.Modelos
{
    public partial class Parametros
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Valor { get; set; }
        public int? UsuarioCrea { get; set; }
        public int? UsuarioModifica { get; set; }
        public DateTime? FechaCrea { get; set; }
        public DateTime? FechaModifica { get; set; }
    }
}
