
using System.Linq;
using PizzariaSys.Dominio.Interfaces.Repositorios.Core;
using PizzariaSys.Dominio.Interfaces.Servicos.Core;

namespace PizzariaSys.Dominio.Servicos.Core
{
    public class ServicosBase<T>: IServicosBase<T> where T: class
    {
        private readonly IRepositorioBase<T> _repositorioBase;

        public ServicosBase(IRepositorioBase<T> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public void Inserir(T entidade)
        {
           _repositorioBase.Inserir(entidade);
        }

        public void Alterar(T entidade)
        {
            _repositorioBase.Alterar(entidade);
        }

        public void Deletar(T entidade)
        {
            _repositorioBase.Deletar(entidade);
        }

        public T BuscarId(int id)
        {
            return _repositorioBase.BuscarId(id);
        }

        public IQueryable<T> ListarTodos()
        {
            return _repositorioBase.ListarTodos();
        }

        public void Commit()
        {
            _repositorioBase.Commit();
        }
    }
}
