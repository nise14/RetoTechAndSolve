using Microsoft.AspNetCore.Mvc;
using Negocio.Parametros;
using System.Collections.Generic;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosController : ControllerBase
    {
        IAdministradorParametros administrador;

        /// <summary>
        /// Controlador parametros
        /// </summary>
        /// <param name="administrador">administrador parametros</param>
        public ParametrosController(IAdministradorParametros administrador) {
            this.administrador = administrador;
        }

        /// <summary>
        /// Listado de parametros
        /// </summary>
        /// <returns>lista de parametros</returns>
        [HttpGet]
        [Route("ObtenerParametros")]
        public List<AccesoDatos.Modelos.Parametros> ObtenerParametros()
        {
            return administrador.ObtenerParametros();
        }

        /// <summary>
        /// Reiniciar parametros
        /// </summary>
        /// <returns>se reinicio correctamente los parametros</returns>
        [HttpGet]
        [Route("ReiniciarParametros")]
        public bool ReiniciarParametros()
        {
            return administrador.ReiniciarParametros();
        }
    }
}