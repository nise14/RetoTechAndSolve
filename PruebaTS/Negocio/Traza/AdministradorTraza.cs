using AccesoDatos.Servicios;
using System;
using Utilidades.Excepciones;

namespace Negocio.Traza
{
    public class AdministradorTraza : IAdministradorTraza
    {
        private readonly IbaseServicio<AccesoDatos.Modelos.Traza> administrador;

        public AdministradorTraza(IbaseServicio<AccesoDatos.Modelos.Traza> administrador)
        {
            this.administrador = administrador;
        }

        /// <summary>
        /// Crear registro traza
        /// </summary>
        /// <param name="traza">traza a crear</param>
        /// <returns>registro exitoso/fallido</returns>
        public bool CrearTraza(AccesoDatos.Modelos.Traza traza)
        {
            var exito = false;

            try
            {
                exito = administrador.Insertar(traza);
            }
            catch (Exception ex) {
                throw new ExcepcionNegocio("Error al crear la traza", ex);
            }

            return exito;
        }
    }
}
