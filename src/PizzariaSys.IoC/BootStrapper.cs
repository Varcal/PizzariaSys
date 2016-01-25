using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzariaSys.AcessoDados.Contexto;
using PizzariaSys.AcessoDados.Repositorios;
using PizzariaSys.AcessoDados.Repositorios.Core;
using PizzariaSys.App.Interfaces;
using PizzariaSys.App.Servicos;
using PizzariaSys.Dominio.Interfaces.Repositorios;
using PizzariaSys.Dominio.Interfaces.Repositorios.Core;
using PizzariaSys.Dominio.Interfaces.Servicos;
using PizzariaSys.Dominio.Interfaces.Servicos.Core;
using PizzariaSys.Dominio.Servicos;
using PizzariaSys.Dominio.Servicos.Core;
using SimpleInjector;

namespace PizzariaSys.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //Aplicação
            container.Register<IClienteAppService, ClienteAppServico>(Lifestyle.Scoped);


            //Dominio
            container.Register(typeof(IServicosBase<>), typeof(ServicosBase<>));
            container.Register<IClienteServicos, ClienteServicos>(Lifestyle.Scoped);

        
           //Repositorio
           container.Register(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
           container.Register<IClienteRepositorio, ClienteRepositorio>(Lifestyle.Scoped);

            //Contexto
            container.Register<EfContexto, EfContexto>(Lifestyle.Scoped);

        }

    }
}
