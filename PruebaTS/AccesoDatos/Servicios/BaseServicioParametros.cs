using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using System.Collections.Generic;

namespace AccesoDatos.Servicios
{
    public class BaseServicioParametros : IBaseServicioBusqueda<Parametros>
    {
        private readonly IBaseRepositorioBusqueda<Parametros> repositorio;

        public BaseServicioParametros(IBaseRepositorioBusqueda<Parametros> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Parametros> ObtenerListado()
        {
            return repositorio.ObtenerListado();
        }

        public List<Parametros> ObtenerRegistros(int id)
        {
            return repositorio.ObtenerRegistros(id);
        }

        public List<Parametros> EjecutarProcedimiento(string nombreProcedimiento, params object[] parametros)
        {
            return repositorio.EjecutarProcedimiento(nombreProcedimiento,parametros);
        }
    }
}
