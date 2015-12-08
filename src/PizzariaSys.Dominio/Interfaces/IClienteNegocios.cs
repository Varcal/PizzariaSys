using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzariaSys.Dominio.Interfaces.Repositorios;

namespace PizzariaSys.Dominio.Interfaces
{
    public interface IClienteNegocios: IRepositorioBase<Cliente>
    {
        Cliente ListarClienteTelefone(string param);
    }
}
