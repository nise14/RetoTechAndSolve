using AccesoDatos.Modelos;
using AccesoDatos.Servicios;
using System.Collections.Generic;

namespace Negocio.Supervisor
{
    public class AdministradorObtenerSupervisado : IAdministradorObtenerSupervisado
    {
        private readonly IBaseServicioBusqueda<ObtenerSupervisado> servicio;
        public AdministradorObtenerSupervisado(IBaseServicioBusqueda<ObtenerSupervisado> servicio)
        {
            this.servicio = servicio;
        }

        public List<ObtenerSupervisado> ObtenerSupervisado(int identificacion)
        {
            return servicio.EjecutarProcedimiento("ObtenerSupervisado", identificacion);
        }
    }
}
