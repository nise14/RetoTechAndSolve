using AccesoDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilidades.Excepciones;

namespace Negocio.Parametros
{
    public class AdministradorParametros : IAdministradorParametros
    {
        private readonly IBaseServicioBusqueda<AccesoDatos.Modelos.Parametros> servicio;

        public static List<AccesoDatos.Modelos.Parametros> parametros = new List<AccesoDatos.Modelos.Parametros>();

        public AdministradorParametros(IBaseServicioBusqueda<AccesoDatos.Modelos.Parametros> servicio)
        {
            this.servicio = servicio;
        }

        /// <summary>
        /// Obtener parametros
        /// </summary>
        /// <returns></returns>
        public List<AccesoDatos.Modelos.Parametros> ObtenerParametros()
        {
            parametros = servicio.ObtenerListado();

            return parametros;
        }

        public bool ReiniciarParametros()
        {
            parametros = new List<AccesoDatos.Modelos.Parametros>();
            return true;
        }

        /// <summary>
        /// Obtiene el total de dias a trabajar
        /// </summary>
        /// <returns>dias a trabajar</returns>
        public int TotalDiasTrabajar()
        {
            var totalDias = 0;

            try
            {
                if (parametros.Any(e => e.Id == 1))
                {
                    totalDias =parametros.First(e => e.Id == 1).Valor.GetValueOrDefault();
                }

            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error no existe el parámetro TotalDiasTrabajar", ex);
            }

            return totalDias;
        }

        /// <summary>
        /// Obtiene el total de elementos
        /// </summary>
        /// <returns>dias a trabajar</returns>
        public int TotalElementos()
        {
            var totalElementos = 0;

            try
            {
                if (parametros.Any(e => e.Id == 2))
                {
                    totalElementos = parametros.First(e => e.Id == 2).Valor.GetValueOrDefault();
                }

            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error no existe el parámetro TotalElementos", ex);
            }

            return totalElementos;
        }

        /// <summary>
        /// Total de pesos
        /// </summary>
        /// <returns></returns>
        public int TotalPeso()
        {
            var totalPeso = 0;

            try
            {
                if (parametros.Any(e => e.Id == 3))
                {
                    totalPeso = parametros.First(e => e.Id == 3).Valor.GetValueOrDefault();
                }

            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error no existe el parámetro TotalPeso", ex);
            }

            return totalPeso;
        }

        /// <summary>
        /// Peso x viaje
        /// </summary>
        /// <returns></returns>
        public int PesoXViaje()
        {
            var pesoViaje = 0;

            try
            {
                if (parametros.Any(e => e.Id == 4))
                {
                    pesoViaje =parametros.First(e => e.Id == 4).Valor.GetValueOrDefault();
                }

            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error no existe el parámetro PesoXViaje", ex);
            }

            return pesoViaje;
        }
    }
}
