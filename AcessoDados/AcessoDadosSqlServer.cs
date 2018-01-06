using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AcessoDados.Properties;

namespace AcessobancoDados
{
    public class AcessoDadosSqlServer
    {
        //Criar a conexão
        private SqlConnection CriarConexao()
        {
            return new SqlConnection(Settings.Default.stringConexao);
        }

        //Parametros que vão para o banco
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        //Persistencia - Inserir, Alterar e Excluir
        public object ExecutarManipulacao(CommandType commandType, string nomeStoredProcedureOuTexoSql)
        {
            try
            {
                //criar conexao
                SqlConnection sqlConnection = CriarConexao();
                //Abrir conexao
                sqlConnection.Open();
                //criar comando que vai levar as informacoes
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //Colocando os dados dentro do comando
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTexoSql;
                sqlCommand.CommandTimeout = 7200;

                //Adicionar os parametros no comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                //Executa o comando, ou seja, manda os dados
                return sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Consultar registros do banco de dados
        public DataTable ExecutarConsulta(CommandType commandType, string nomeStoredProcedureOuTexoSql)
        {
            try
            {
                //criar conexao
                SqlConnection sqlConnection = CriarConexao();
                //Abrir conexao
                sqlConnection.Open();
                //criar comando que vai levar as informacoes
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //Colocando os dados dentro do comando
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTexoSql;
                sqlCommand.CommandTimeout = 7200;

                //Adicionar os parametros no comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                //Criar o adaptador
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //Tabela vazia, onde fica os dados que vem do banco
                DataTable dataTable = new DataTable();
                //Mandar o comando ir ate o banco buscar os dados e o adaptador preencher o datatable
                sqlDataAdapter.Fill(dataTable);
                //Retornar com os dados
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
