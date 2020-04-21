using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Viajes
{
    public interface IAdministradorViajes
    {
        /// <summary>
        /// Procesar los viajes que hace wilson
        /// </summary>
        /// <param name="viajes"></param>
        /// <returns></returns>
        string ProcesarViajes(List<int> viajes);

        /// <summary>
        /// Metodo para escribir el texto de salida
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="contenido"></param>
        bool EscribirArchivo(string ruta, string contenido);
    }
}
