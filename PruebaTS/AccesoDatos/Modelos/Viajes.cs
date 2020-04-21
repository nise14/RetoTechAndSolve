using System;
using System.Collections.Generic;

namespace AccesoDatos.Modelos
{
    public class Viajes
    {
        /// <summary>
        /// Cantidad de viajes que realiza
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Listado de pesos
        /// </summary>
        public List<int> Pesos { get; set; }
    }
}
