using System;
using System.Collections.Generic;

namespace AccesoDatos.Modelos
{
    public partial class Supervisor
    {
        public int Id { get; set; }
        public int? UsuarioSupervisa { get; set; }
        public int? UsuarioSupervisado { get; set; }

        public Usuarios UsuarioSupervisaNavigation { get; set; }
        public Usuarios UsuarioSupervisadoNavigation { get; set; }
    }
}
