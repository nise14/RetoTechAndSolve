using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AccesoDatos.Servicios
{
    public interface IBaseServicioBusqueda<T> where T:class
    {
        /// <summary>
        /// Obtener listado completo
        /// </summary>
        /// <returns>lista completa</returns>
        List<T> ObtenerListado();

        /// <summary>
        /// Obtener unico registro
        /// </summary>
        /// <param name="id">identificador a buscar</param>
        /// <returns></returns>
        List<T> ObtenerRegistros(int id);

        /// <summary>
        /// Ejecutar procedimiento
        /// </summary>
        /// <param name="parametros">lista parametros</param>
        /// <returns>ejecución procedimiento</returns>
        List<T> EjecutarProcedimiento(string nombreProcedimiento, params object[] parametros);
    }
}
