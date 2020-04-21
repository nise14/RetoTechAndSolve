using System;
using System.Collections.Generic;

namespace AccesoDatos.Modelos
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            SupervisorUsuarioSupervisaNavigation = new HashSet<Supervisor>();
            SupervisorUsuarioSupervisadoNavigation = new HashSet<Supervisor>();
            Traza = new HashSet<Traza>();
        }

        public int Identificacion { get; set; }
        public string Nombre { get; set; }

        public ICollection<Supervisor> SupervisorUsuarioSupervisaNavigation { get; set; }
        public ICollection<Supervisor> SupervisorUsuarioSupervisadoNavigation { get; set; }
        public ICollection<Traza> Traza { get; set; }
    }
}
