

using PizzariaSys.Dominio.Entidades;
using PizzariaSys.Dominio.Interfaces.Servicos.Core;

namespace PizzariaSys.Dominio.Interfaces.Servicos
{
    public interface IClienteServicos: IServicosBase<Cliente>
    {
        Cliente ListarClienteTelefone(string param);
    }
}
