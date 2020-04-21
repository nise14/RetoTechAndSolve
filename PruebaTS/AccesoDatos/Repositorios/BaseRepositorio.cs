using AccesoDatos.Contexto;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Repositorios
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : class
    {
        private readonly DataContext contexto;
        private readonly DbSet<T> entidades;

        public BaseRepositorio(DataContext contexto)
        {
            this.contexto = contexto;
            entidades = contexto.Set<T>();
        }

        /// <summary>
        /// Actualizar un registro
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Actualizar(T entidad)
        {
            contexto.SaveChanges();

            return true;
        }
        
        /// <summary>
        /// Eliminar la entidad
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Eliminar(T entidad)
        {
            entidades.Remove(entidad);
            contexto.SaveChanges();

            return true;
        }

        /// <summary>
        /// Insertar la entidad
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Insertar(T entidad)
        {
            entidades.Add(entidad);
            contexto.SaveChanges();
            return true;
        }
    }
}
