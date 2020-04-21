using System;
using System.Collections.Generic;

namespace AccesoDatos.Modelos
{
    public partial class Cargo
    {
        public Cargo()
        {
            UsuarioCargo = new HashSet<UsuarioCargo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<UsuarioCargo> UsuarioCargo { get; set; }
    }
}
