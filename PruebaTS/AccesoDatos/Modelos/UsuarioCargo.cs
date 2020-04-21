using System;
using System.Collections.Generic;

namespace AccesoDatos.Modelos
{
    public partial class UsuarioCargo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CargoId { get; set; }

        public Cargo Cargo { get; set; }
    }
}
