using System;

namespace Utilidades.Excepciones
{
    public class ExcepcionNegocio : Exception
    {
        private string Mensaje { get; set; }

        public ExcepcionNegocio()
          : base()
        { }

        public ExcepcionNegocio(string mensaje)
             : base(mensaje)
        {
            Mensaje = Mensaje;

        }
        public ExcepcionNegocio(string mensaje, Exception innerException)
              : base(mensaje, innerException)
        {
            Mensaje = mensaje;

        }
    }
}
