using AccesoDatos.Repositorios;

namespace AccesoDatos.Servicios
{
    public class BaseServicio<T> : IbaseServicio<T> where T : class
    {
        private readonly IBaseRepositorio<T> repositorio;
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseServicio(IBaseRepositorio<T> repositorio)
        {
            this.repositorio = repositorio;
        }

        /// <summary>
        /// Actualizar servicio
        /// </summary>
        /// <param name="entidad">entidad actualizar</param>
        /// <returns>actualizacion exitosa/fallida</returns>
        public bool Actualizar(T entidad)
        {
            return repositorio.Actualizar(entidad);
        }

        /// <summary>
        /// Eliminar entidad
        /// </summary>
        /// <param name="entidad">entidad a eliminar</param>
        /// <returns>eliminacion exitosa/fallida</returns>
        public bool Eliminar(T entidad)
        {
            return repositorio.Eliminar(entidad);
        }

        /// <summary>
        /// Insercion entidad
        /// </summary>
        /// <param name="entidad">entidad a insertar</param>
        /// <returns>insercion exitosa/fallida</returns>
        public bool Insertar(T entidad)
        {
            return repositorio.Insertar(entidad);
        }
    }
}
