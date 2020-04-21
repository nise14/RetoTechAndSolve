using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Supervisor
{
    public interface IAdministradorObtenerSupervisado
    {
        List<ObtenerSupervisado> ObtenerSupervisado(int identificacion);
    }
}
