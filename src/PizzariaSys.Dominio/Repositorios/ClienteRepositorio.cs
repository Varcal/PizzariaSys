using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PizzariaSys.AcessoDados;
using PizzariaSys.AcessoDados.Interface;

namespace PizzariaSys.Dominio.Repositorios
{
    public class ClienteRepositorio : Contexto, IRepositorio<Cliente>
    {

        public string Salvar(Cliente entidade)
        {
            string retorno = "";

            if (entidade.Id <= 0)
            {
                retorno = Inserir(entidade);
            }
            if (entidade.Id > 0)
            {
                retorno = Alterar(entidade);
            }

            return retorno;
        }

        private string Inserir(Cliente entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@Nome", entidade.Nome);
                AdicionarParametros("@Logradouro", entidade.Logradouro);
                AdicionarParametros("@Numero", entidade.Numero);
                AdicionarParametros("@Bairro", entidade.Bairro);
                AdicionarParametros("@Telefone", entidade.Telefone);
                string retorno = ExecutarComando(CommandType.StoredProcedure, "uspClienteInserir").ToString();
                return retorno;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string Alterar(Cliente entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@Id", entidade.Id);
                AdicionarParametros("@Nome", entidade.Nome);
                AdicionarParametros("@Logradouro", entidade.Logradouro);
                AdicionarParametros("@Numero", entidade.Numero);
                AdicionarParametros("@Bairro", entidade.Bairro);
                AdicionarParametros("@Telefone", entidade.Telefone);
                string retorno = ExecutarComando(CommandType.StoredProcedure, "uspClienteAlterar").ToString();
                return retorno;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Deletar(Cliente entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@Id", entidade.Id);
                string retorno = ExecutarComando(CommandType.StoredProcedure, "uspClienteExcluir").ToString();
                return retorno;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public Cliente BuscarId(int id)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@Id", id);
                DataTable dtCliente = new DataTable();
                Cliente cliente = new Cliente();
                dtCliente = ExecutarConsulta(CommandType.StoredProcedure, "uspClienteListarId");
                foreach (DataRow linha in dtCliente.Rows)
                {

                    cliente.Id = Convert.ToInt32(linha["Id"]);
                    cliente.Nome = linha["Nome"].ToString();
                    cliente.Logradouro = linha["Logradouro"].ToString();
                    cliente.Numero = Convert.ToInt32(linha["Numero"]);
                    cliente.Bairro = linha["Bairro"].ToString();
                    cliente.Telefone = linha["Telefone"].ToString();
                }

                return cliente;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public IEnumerable<Cliente> ListarTodos()
        {
            try
            {
                IList<Cliente> clientes = new List<Cliente>();
                var dtCliente = ExecutarConsultaReader(CommandType.StoredProcedure, "uspClienteListarTodos");
                using (dtCliente)
                {
                    while (dtCliente.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.Id = Convert.ToInt32(dtCliente["Id"]);
                        cliente.Nome = dtCliente["Nome"].ToString();
                        cliente.Logradouro = dtCliente["Logradouro"].ToString();
                        cliente.Numero = Convert.ToInt32(dtCliente["Numero"]);
                        cliente.Bairro = dtCliente["Bairro"].ToString();
                        cliente.Telefone = dtCliente["Telefone"].ToString();

                        clientes.Add(cliente);
                    }
                }
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public IEnumerable<Cliente> ListarTodos()
        //{
        //    try
        //    {
        //        DataTable dtCliente = new DataTable();
        //        IList<Cliente> clientes = new List<Cliente>();
        //        dtCliente = ExecutarConsulta(CommandType.StoredProcedure, "uspClienteListarTodos");
        //        foreach (DataRow linha in dtCliente.Rows)
        //        {
        //            Cliente cliente = new Cliente();
        //            cliente.Id = Convert.ToInt32(linha["Id"]);
        //            cliente.Nome = linha["Nome"].ToString();
        //            cliente.Logradouro = linha["Logradouro"].ToString();
        //            cliente.Numero = Convert.ToInt32(linha["Numero"]);
        //            cliente.Bairro = linha["Bairro"].ToString();
        //            cliente.Telefone = linha["Telefone"].ToString();

        //            clientes.Add(cliente);
        //        }

        //        return clientes;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        //public IEnumerable<Cliente> ListarTelefone(string telefone)
        //{
        //    try
        //    {
        //        LimparParametro();
        //        AdicionarParametros("@Telefone", telefone);
        //        DataTable dtCliente = new DataTable();
        //        IList<Cliente> clientes = new List<Cliente>();
        //        dtCliente = ExecutarConsulta(CommandType.StoredProcedure, "uspClienteListarTelefone");
        //        foreach (DataRow linha in dtCliente.Rows)
        //        {
        //            Cliente cliente = new Cliente();
        //            cliente.Id = Convert.ToInt32(linha["Id"]);
        //            cliente.Nome = linha["Nome"].ToString();
        //            cliente.Logradouro = linha["Logradouro"].ToString();
        //            cliente.Numero = Convert.ToInt32(linha["Numero"]);
        //            cliente.Bairro = linha["Bairro"].ToString();
        //            cliente.Telefone = linha["Telefone"].ToString();

        //            clientes.Add(cliente);
        //        }

        //        return clientes;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

    }
}
