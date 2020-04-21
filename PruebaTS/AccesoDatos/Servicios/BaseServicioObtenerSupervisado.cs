using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using System;
using System.Collections.Generic;

namespace AccesoDatos.Servicios
{
    public class BaseServicioObtenerSupervisado : IBaseServicioBusqueda<ObtenerSupervisado>
    {
        private readonly IBaseRepositorioBusqueda<ObtenerSupervisado> repositorio;

        public BaseServicioObtenerSupervisado(IBaseRepositorioBusqueda<ObtenerSupervisado> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<ObtenerSupervisado> EjecutarProcedimiento(string nombreProcedimiento, params object[] parametros)
        {
            return repositorio.EjecutarProcedimiento(nombreProcedimiento, parametros);
        }

        public List<ObtenerSupervisado> EjecutarVistas(params object[] parametros)
        {
            throw new NotImplementedException();
        }

        public List<ObtenerSupervisado> ObtenerListado()
        {
            throw new NotImplementedException();
        }

        public List<ObtenerSupervisado> ObtenerRegistros(int id)
        {
            throw new NotImplementedException();
        }
    }
}
