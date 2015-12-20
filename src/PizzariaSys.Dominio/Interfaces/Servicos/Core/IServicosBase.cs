using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaSys.Dominio.Interfaces.Servicos.Core
{
    public interface IServicosBase<T> where T: class
    {
        void Inserir(T entidade);
        void Alterar(T entidade);
        void Deletar(T entidade);
        T BuscarId(int id);
        IQueryable<T> ListarTodos();
        void Commit();
    }
}
