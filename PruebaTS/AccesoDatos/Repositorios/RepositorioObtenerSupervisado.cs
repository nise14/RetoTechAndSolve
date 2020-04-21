using AccesoDatos.Contexto;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AccesoDatos.Repositorios
{
    public class RepositorioObtenerSupervisado : IRepositorioObtenerSupervisado
    {
        private readonly DataContext contexto;

        public RepositorioObtenerSupervisado(DataContext contexto)
        {
            this.contexto = contexto;
        }

        /// <summary>
        /// Ejecutar procedimiento
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public List<ObtenerSupervisado> EjecutarProcedimiento(string nombreProcedimiento, params object[] parametros)
        {
            var supervisados = new List<ObtenerSupervisado>();

            using (var context = this.contexto.Database.GetDbConnection())
            {
                using (var comando = context.CreateCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = nombreProcedimiento;
                    comando.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@Identificacion",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = Convert.ToInt32(parametros[0])
                    });

                    comando.Connection = context;
                    context.Open();

                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read()) {
                            var supervisado = new ObtenerSupervisado();
                            supervisado.UsuarioSupervisaId = Convert.ToInt32(lector["UsuarioSupervisaId"]);
                            supervisado.UsuarioSupervisaNombre = Convert.ToString(lector["UsuarioSupervisaNombre"]);
                            supervisado.UsuarioSupervisadoId = Convert.ToInt32(lector["UsuarioSupervisadoId"]);
                            supervisado.UsuarioSupervisadoNombre = Convert.ToString(lector["UsuarioSupervisadoNombre"]);
                            supervisados.Add(supervisado);
                        }
                    }
                }

            }

            return supervisados;
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
