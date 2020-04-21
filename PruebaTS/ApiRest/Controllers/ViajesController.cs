using AccesoDatos.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Negocio.Viajes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private readonly IAdministradorViajes administrador;
        private IConfiguration configuracion;

        public ViajesController(IAdministradorViajes administrador, IConfiguration configuracion)
        {
            this.administrador = administrador;
            this.configuracion = configuracion;
        }

        /// <summary>
        /// Metodo para cargar el archivo
        /// </summary>
        /// <param name="ifile">el archivo</param>
        /// <returns>archivo procesado</returns>
        [HttpPost, DisableRequestSizeLimit]
        [Route("GuardarArchivo")]
        public IActionResult GuardarArchivo(IFormFile ifile)
        {
            var files = Request.Form.Files;
            var exito = false;

            if (files.Any())
            {

                var file = files[0];

                var viajes = new List<int>();

                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        viajes.Add(Convert.ToInt32(reader.ReadLine()));
                    }
                }

                var salida = administrador.ProcesarViajes(viajes);

                var ruta = string.Format("{0}{1}", configuracion.GetValue<string>("RutaSalida"), configuracion.GetValue<string>("NombreArchivoSalida"));

                exito = administrador.EscribirArchivo(ruta, salida);
            }
            else
            {
                return new CreatedAtRouteResult("File", new { Exito = exito ? "ok" : "error", Mensaje = "Archivo no existe" });
            }

            return new CreatedAtRouteResult("File", new { Exito = exito ? "ok" : "error", Mensaje = "Creacion exitosa" });
        }

        /// <summary>
        /// Descargar el archivo
        /// </summary>
        /// <returns>archivo a descargar</returns>
        [HttpGet]
        [Route("Descargar")]
        public FileStream Descargar()
        {
            var ruta = string.Format("{0}{1}", configuracion.GetValue<string>("RutaSalida"), configuracion.GetValue<string>("NombreArchivoSalida"));
            
            return new FileStream(ruta, FileMode.Open, FileAccess.Read);
        }
    }
}