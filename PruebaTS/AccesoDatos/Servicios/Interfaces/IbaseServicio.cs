using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Servicios
{
    public interface IbaseServicio<T> where T : class
    {
        /// <summary>
        /// Insertar
        /// </summary>
        /// <param name="entidad">entidad a buscar</param>
        /// <returns>Inserción exitosa/fallida</returns>
        bool Insertar(T entidad);

        /// <summary>
        /// Actualizar entidad
        /// </summary>
        /// <param name="entidad">entidad a modificar</param>
        /// <returns>actualizacion exitosa/fallida</returns>
        bool Actualizar(T entidad);

        /// <summary>
        /// Eliminar entidad
        /// </summary>
        /// <param name="entidad">entidad a eliminar</param>
        /// <returns>eliminación exitosa/fallida</returns>
        bool Eliminar(T entidad);
    }
}
