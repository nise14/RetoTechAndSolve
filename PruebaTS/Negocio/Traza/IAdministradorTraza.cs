using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Traza
{
    public interface IAdministradorTraza
    {
        /// <summary>
        /// Crea un registro de traza
        /// </summary>
        /// <param name="traza">traza a crear</param>
        /// <returns>registro exito/fallido</returns>
        bool CrearTraza(AccesoDatos.Modelos.Traza traza);
    }
}
