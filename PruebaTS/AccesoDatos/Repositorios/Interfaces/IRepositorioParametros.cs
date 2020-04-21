using AccesoDatos.Contexto;
using AccesoDatos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AccesoDatos.Repositorios
{
    public interface IRepositorioParametros : IBaseRepositorioBusqueda<Parametros> {
    }
}
