using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccesoDatos.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Supervisor;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupervisorController : ControllerBase
    {
        IAdministradorObtenerSupervisado administrador;

        /// <summary>
        /// Controlador de supervisor
        /// </summary>
        /// <param name="administrador">inyección IAdministradorObtenerSupervisado</param>
        public SupervisorController(IAdministradorObtenerSupervisado administrador)
        {
            this.administrador = administrador;
        }

        /// <summary>
        /// Llamar procedimiento almacenado
        /// </summary>
        /// <param name="id">identificación a buscar</param>
        /// <returns>datos del supervisor y a quien supervisa</returns>
        [HttpGet]
        [Route("ObtenerSupervisado/{id}")]
        public List<ObtenerSupervisado> ObtenerSupervisado(int id) {
            return administrador.ObtenerSupervisado(id);
        }
    }
}