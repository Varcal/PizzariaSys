using System.Collections.Generic;
using System.Linq;

namespace PizzariaSys.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<T> where T: class
    {
        void Inserir(T entidade);
        void Alterar(T entidade);
        void Deletar(T entidade);
        T BuscarId(int id);
        IQueryable<T> ListarTodos();
    }
}
