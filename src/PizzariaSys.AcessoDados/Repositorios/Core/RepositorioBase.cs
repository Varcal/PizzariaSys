
using System.Data.Entity;
using System.Linq;
using PizzariaSys.AcessoDados.Contexto;
using PizzariaSys.Dominio.Interfaces.Repositorios.Core;

namespace PizzariaSys.AcessoDados.Repositorios.Core
{

    public class RepositorioBase<T>: IRepositorioBase<T> where T:class
    {
        protected EfContexto _db;

        public RepositorioBase(EfContexto db)
        {
            _db = db;
        }
       

        public void Inserir(T entidade)
        {
            _db.Set<T>().Add(entidade);
        }

        public void Alterar(T entidade)
        {
           _db.Entry(entidade).State = EntityState.Modified;
        }

        public void Deletar(T entidade)
        {
            _db.Set<T>().Remove(entidade);
        }

        public T BuscarId(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public IQueryable<T> ListarTodos()
        {
            return _db.Set<T>();
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
