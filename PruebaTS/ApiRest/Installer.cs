using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using AccesoDatos.Servicios;
using Microsoft.Extensions.DependencyInjection;
using Negocio.Parametros;
using Negocio.Supervisor;
using Negocio.Traza;
using Negocio.Viajes;

namespace ApiRest
{
    public class Installer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBaseRepositorioBusqueda<Parametros>, RepositorioParametros>();
            services.AddTransient<IBaseServicioBusqueda<Parametros>, BaseServicioParametros>();
            services.AddTransient<IAdministradorParametros, AdministradorParametros>();

            services.AddTransient<IBaseRepositorioBusqueda<ObtenerSupervisado>, RepositorioObtenerSupervisado>();
            services.AddTransient<IBaseServicioBusqueda<ObtenerSupervisado>, BaseServicioObtenerSupervisado>();
            services.AddTransient<IAdministradorObtenerSupervisado, AdministradorObtenerSupervisado>();

            services.AddTransient<IBaseRepositorio<Viajes>, BaseRepositorio<Viajes>>();
            services.AddTransient<IbaseServicio<Viajes>, BaseServicio<Viajes>>();
            services.AddTransient<IAdministradorViajes, AdministradorViajes>();

            services.AddTransient<IBaseRepositorio<Traza>, BaseRepositorio<Traza>>();
            services.AddTransient<IbaseServicio<Traza>, BaseServicio<Traza>>();
            services.AddTransient<IAdministradorTraza, AdministradorTraza>();
        }
    }
}
