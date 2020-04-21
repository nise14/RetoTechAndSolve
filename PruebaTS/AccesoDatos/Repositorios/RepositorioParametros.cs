using AccesoDatos.Contexto;
using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Repositorios
{
    /// <summary>
    /// Repositorio busqueda parametros
    /// </summary>
    public class RepositorioParametros : IBaseRepositorioBusqueda<Parametros>
    {
        private readonly DataContext contexto;

        /// <summary>
        /// </summary>
        /// <param name="contexto"></param>
        public RepositorioParametros(DataContext contexto)
        {
            this.contexto = contexto;
        }

        public List<Parametros> EjecutarProcedimiento(string nombreProcedimiento, params object[] parametros)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtener listado parametros
        /// </summary>
        /// <returns></returns>
        public List<Parametros> ObtenerListado()
        {
            return contexto.Parametros.ToList();
        }

        /// <summary>
        /// Obtiene listado registros parametros
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Parametros> ObtenerRegistros(int id)
        {
            return contexto.Parametros.Where(e => e.Id == id).ToList();
        }
    }
}
