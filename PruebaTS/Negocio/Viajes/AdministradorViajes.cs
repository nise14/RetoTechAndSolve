using AccesoDatos.Servicios;
using Negocio.Parametros;
using Negocio.Traza;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Utilidades.Excepciones;

namespace Negocio.Viajes
{
    public class AdministradorViajes : IAdministradorViajes
    {
        private readonly IbaseServicio<AccesoDatos.Modelos.Viajes> administrador;
        private readonly IAdministradorParametros administradorParametros;
        private readonly IAdministradorTraza administradorTraza;

        /// <summary>
        /// Constructor administrador viajes
        /// </summary>
        /// <param name="administrador">intermediario para llegar al repositorio</param>
        /// <param name="administradorParametros">acceder a los metodos expuestos para consultar parametros</param>
        public AdministradorViajes(IbaseServicio<AccesoDatos.Modelos.Viajes> administrador, IAdministradorParametros administradorParametros, IAdministradorTraza administradorTraza)
        {
            this.administrador = administrador;
            this.administradorParametros = administradorParametros;
            this.administradorTraza = administradorTraza;
        }

        /// <summary>
        /// Procesa el archivo y la cantidad de viajes
        /// </summary>
        /// <param name="viajes">lista viajes</param>
        /// <returns>salida del archivo .txt</returns>
        public string ProcesarViajes(List<int> viajes)
        {
            var resultado = string.Empty;

            administradorParametros.ReiniciarParametros();
            administradorParametros.ObtenerParametros();

            try
            {
                if (viajes.Any())
                {
                    //Regla 1 ≤ T ≤ 500
                    if (1 <= viajes[0] && viajes[0] <= administradorParametros.TotalDiasTrabajar())
                    {
                        var resultadoViajes = CalcularTotalViajes(viajes);

                        if (resultadoViajes.Any())
                        {
                            resultado = Salida(resultadoViajes);
                            InsertarRegistroTraza(resultado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error procesando viajes", ex);
            }

            return resultado;
        }

        /// <summary>
        /// Calcula el total de viajes
        /// </summary>
        /// <param name="viajes">listado de viajes</param>
        /// <returns>Calcula el total de viajes que realiza</returns>
        private List<int> CalcularTotalViajes(List<int> viajes)
        {
            try
            {
                var diasDeTrabajo = viajes[0];
                viajes.RemoveAt(0);
                var totalViajes = 1;
                var contadorViajes = 0;
                var totalCargas = new List<AccesoDatos.Modelos.Viajes>();
                for (var i = 0; i < diasDeTrabajo; i++)
                {
                    var listado = new List<int>();
                    int cantViajes = viajes[contadorViajes];
                    for (var j = 1; j <= cantViajes; j++)
                    {
                        listado.Add(viajes[totalViajes + i]);
                        totalViajes = totalViajes + 1;
                    }
                    var viaje = new AccesoDatos.Modelos.Viajes
                    {
                        Cantidad = cantViajes,
                        Pesos = listado.OrderBy(x => x).Reverse().ToList()
                    };

                    totalCargas.Add(viaje);
                    contadorViajes += cantViajes + 1;
                }
                List<int> totalFinal = ObtenerCantidadViajes(totalCargas);

                return totalFinal;
            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error calculado total viajes", ex);
            }
        }

        /// <summary>
        /// Cantidad de viajes
        /// </summary>
        /// <param name="viajes">listado de viajes</param>
        /// <returns></returns>
        private List<int> ObtenerCantidadViajes(List<AccesoDatos.Modelos.Viajes> viajes)
        {
            try
            {
                var totalViajes = new List<int>();

                for (var i = 0; i < viajes.Count; i++)
                {
                    //Regla 1 ≤ N ≤ 100
                    if ((1 <= viajes[i].Cantidad) && (viajes[i].Cantidad <= administradorParametros.TotalElementos()))
                    {
                        var viajesRealizados = ViajesPosibles(viajes[i].Pesos);
                        totalViajes.Add(viajesRealizados);
                    }
                    else
                    {
                        throw new ExcepcionNegocio("Cantidad de elementos inválidos");
                    }
                }
                return totalViajes;
            }
            catch (Exception e)
            {
                throw new ExcepcionNegocio("Error Obteniendo el total de viajes", e);
            }
        }

        /// <summary>
        /// Cantidad de viajes posibles
        /// </summary>
        /// <param name="pesos">listado de pesos</param>
        /// <returns></returns>
        private int ViajesPosibles(List<int> pesos)
        {
            try
            {
                var elemento = 1;
                var totalViajes = 0;
                var numeroViajes = pesos.Count;
                var totalViajesRealizar = pesos.Count;

                for (var i = 0; i < pesos.Count; i++)
                {
                    //Regla 1 ≤ Wi ≤ 100
                    if (!(1 > pesos[i]) && (pesos[i] <= administradorParametros.TotalPeso()))
                    {
                        if (pesos[i] >= 50)
                        {
                            totalViajes++;
                            numeroViajes--;
                        }
                        else
                        {
                            if (elemento <= numeroViajes)
                            {
                                while (elemento <= numeroViajes)
                                {
                                    if ((pesos[i] * elemento) >= administradorParametros.PesoXViaje())
                                    {
                                        totalViajes++;
                                        break;
                                    }
                                    elemento++;
                                }
                                numeroViajes = numeroViajes - elemento;
                            }
                        }
                    }
                    else
                    {
                        throw new ExcepcionNegocio("Error calculando el peso");
                    }

                }

                return totalViajes;
            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error calculado los viajes posibles", ex);
            }
        }

        /// <summary>
        /// Metodo que genera la salida el string de salida en el formato indicado
        /// </summary>
        /// <param name="lstResultado">Lista de valores a escribir en el archivo de salida</param>
        /// <returns>String con el formato indicado</returns>
        private string Salida(List<int> resultado)
        {
            int count = 1;
            var cadena = new StringBuilder();
            for (var i = 0; i < resultado.Count; i++)
            {
                cadena.AppendLine(string.Format("CASE #{0}: {1}", count, resultado[i]));
                count++;
            }
            return cadena.ToString();
        }

        /// <summary>
        /// Escribir el archivo de texto de salida
        /// </summary>
        /// <param name="ruta">ruta donde esta el archivo</param>
        /// <param name="contenido">contenido del archivo</param>
        /// <returns>escribir el archivo de texto</returns>
        public bool EscribirArchivo(string ruta, string contenido)
        {
            try
            {
                if (File.Exists(@ruta))
                {
                    File.Delete(@ruta);
                }

                File.Create(@ruta).Dispose();

                using (var escribir = new StreamWriter(@ruta))
                {
                    escribir.WriteLine(contenido);
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error creando el archivo", ex);
            }

            return true;
        }

        /// <summary>
        /// Inserta unr registro de traza
        /// </summary>
        /// <param name="texto">texto de la traza</param>
        /// <returns>insecion exitosa/fallida traza</returns>
        private bool InsertarRegistroTraza(string texto)
        {
            var traza = new AccesoDatos.Modelos.Traza();
            traza.Archivo = texto;
            traza.FechaCreacion = DateTime.Now;
            traza.UsuarioCreaId = 3;

            return administradorTraza.CrearTraza(traza);
        }
    }
}
