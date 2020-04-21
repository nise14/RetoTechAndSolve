using System.Collections.Generic;

namespace Negocio.Parametros
{
    public interface IAdministradorParametros
    {
        bool ReiniciarParametros();

        List<AccesoDatos.Modelos.Parametros> ObtenerParametros();

        /// <summary>
        /// Total dias a trabajar
        /// </summary>
        /// <returns></returns>
        int TotalDiasTrabajar();

        /// <summary>
        /// Obtiene el total de elementos
        /// </summary>
        /// <returns>dias a trabajar</returns>
        int TotalElementos();

        /// <summary>
        /// Total peso
        /// </summary>
        /// <returns></returns>
        int TotalPeso();

        /// <summary>
        /// Peso maximo por viaje
        /// </summary>
        /// <returns></returns>
        int PesoXViaje();
    }
}
