using System;
using MySqlConnector;
using System.Collections.Generic;

namespace DestinoCerto.Models
{
    public class PacotesTuristicosRepository
    {
        //Esta classe precisa ler as credenciais de acesso ao banco de dados.
        //A credencial de acesso precisa ser privada.

        private const string DadosConexao = "Database=DestinoCerto; Data Source=localhost; User Id=root;";

        //Operadores de manipulação da tabela 
        // CRUD - Criar (Insert), Listagem(Select), Alteração (Update), Excluir (Drop).

        public void Excluir(PacotesTuristicos dado) // Ele é void pois não retorna nenhum valor.
        {
            //abrir a conexão com o banco de dados
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Delete from PacotesTuristicos where IdPacote = @IdPacote";

            MySqlCommand Comando = new MySqlCommand (Query,Conexao);

            // Tratamento devido ao Sql Injection
            // AddWithValue = Adiciona somente o tipo de valor especificado.
            // sem isso o sistema pode ser invadido, pois um código malicioso poderia ser adicionado e executado.
            Comando.Parameters.AddWithValue("@IdPacote", dado.IdPacote);

            // ExecuteQuery executa o comando no banco de dados.
            Comando.ExecuteNonQuery();

            //fechar a conexão com o banco de dados.
            Conexao.Close();
        }

        public void Alterar(PacotesTuristicos dado)
        {
            //abrir a conexão com o banco de dados
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Update PacotesTuristicos set Imagem=@Imagem, Nome=@Nome, Origem=@Origem, Destino=@Destino, Atrativos=@Atrativos, Saida=@Saida, Retorno=@Retorno, Usuario=@Usuario where IdPacote = @IdPacote";

            MySqlCommand Comando = new MySqlCommand (Query,Conexao);

            //Tratamento devido ao Sql Injection
            Comando.Parameters.AddWithValue("@IdPacote", dado.IdPacote);
            Comando.Parameters.AddWithValue("@Imagem", dado.Imagem);
            Comando.Parameters.AddWithValue("@Nome", dado.Nome);
            Comando.Parameters.AddWithValue("@Origem", dado.Origem);
            Comando.Parameters.AddWithValue("@Destino", dado.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", dado.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", dado.Saida);
            Comando.Parameters.AddWithValue("@Retorno", dado.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", dado.Usuario);

            // ExecuteQuery executa o comando no banco de dados.
            Comando.ExecuteNonQuery();

            //fechar a conexão com o banco de dados.
            Conexao.Close();
        }

        public void Inserir(PacotesTuristicos dado)
        {
            //abrir a conexão com o banco de dados
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Insert into PacotesTuristicos (Imagem, Nome, Origem, Destino, Atrativos, Saida, Retorno, Usuario) Values (@Imagem, @Nome, @Origem, @Destino, @Atrativos, @Saida, @Retorno, @Usuario)";

            MySqlCommand Comando = new MySqlCommand (Query,Conexao);

            //Tratamento devido ao Sql Injection
            Comando.Parameters.AddWithValue("@IdPacote", dado.IdPacote);
            Comando.Parameters.AddWithValue("@Imagem", dado.Imagem);
            Comando.Parameters.AddWithValue("@Nome", dado.Nome);
            Comando.Parameters.AddWithValue("@Origem", dado.Origem);
            Comando.Parameters.AddWithValue("@Destino", dado.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", dado.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", dado.Saida);
            Comando.Parameters.AddWithValue("@Retorno", dado.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", dado.Usuario);

            // ExecuteQuery executa o comando no banco de dados.
            Comando.ExecuteNonQuery();

            //fechar a conexão com o banco de dados.
            Conexao.Close();
        }

        public List<PacotesTuristicos> Listar()
        {
            //abrir a conexão com o banco de dados
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Select * from PacotesTuristicos";

            MySqlCommand Comando = new MySqlCommand (Query,Conexao);

            // ExecuteReader =  Indicado para comandos que retornam uma seleção de informações, ou seja, que utilizem "Select".
            // MySqlDataReader está armazenando os dados da tabela na variável Reader
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<PacotesTuristicos> Lista = new List<PacotesTuristicos>(); 

            while(Reader.Read()){ 

                PacotesTuristicos pacoteEncontrado = new PacotesTuristicos();
                
                    pacoteEncontrado.IdPacote = Reader.GetInt32("IdPacote");

                    // verificar se o campo é nulo
                    if(!Reader.IsDBNull(Reader.GetOrdinal("Imagem")))
                        pacoteEncontrado.Imagem = Reader.GetString("Imagem"); 

                    if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                        pacoteEncontrado.Nome = Reader.GetString("Nome"); 

                    if(!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                        pacoteEncontrado.Origem = Reader.GetString("Origem"); 

                    if(!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                        pacoteEncontrado.Destino = Reader.GetString("Destino");

                    if(!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                        pacoteEncontrado.Atrativos = Reader.GetString("Atrativos");
                    
                    pacoteEncontrado.Saida = Reader.GetDateTime("Saida");

                    pacoteEncontrado.Retorno = Reader.GetDateTime("Retorno");  

                    if(!Reader.IsDBNull(Reader.GetOrdinal("Usuario")))
                        pacoteEncontrado.Usuario = Reader.GetInt32("Usuario"); 
               
                Lista.Add(pacoteEncontrado);
            }

            //fechar a conexão com o banco de dados.
            Conexao.Close();

            return Lista;
        }

        public PacotesTuristicos BuscarPorId(int IdPacote)
        {
            //abrir a conexão com o banco de dados
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Select * from PacotesTuristicos where IdPacote=@IdPacote";

            MySqlCommand Comando = new MySqlCommand (Query,Conexao);

            Comando.Parameters.AddWithValue("@IdPacote", IdPacote);

            MySqlDataReader Reader = Comando.ExecuteReader();

            PacotesTuristicos pacoteEncontrado = new PacotesTuristicos();

            if (Reader.Read()){

                    pacoteEncontrado.IdPacote = Reader.GetInt32("IdPacote");

                    // verificar se o campo é nulo
                    if(!Reader.IsDBNull(Reader.GetOrdinal("Imagem")))
                        pacoteEncontrado.Imagem = Reader.GetString("Imagem"); 
                        
                    if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                        pacoteEncontrado.Nome = Reader.GetString("Nome"); 

                    if(!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                        pacoteEncontrado.Origem = Reader.GetString("Origem"); 

                    if(!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                        pacoteEncontrado.Destino = Reader.GetString("Destino");

                    if(!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                        pacoteEncontrado.Atrativos = Reader.GetString("Atrativos");
                    
                        pacoteEncontrado.Saida = Reader.GetDateTime("Saida");

                        pacoteEncontrado.Retorno = Reader.GetDateTime("Retorno");  

                    if(!Reader.IsDBNull(Reader.GetOrdinal("Usuario")))
                        pacoteEncontrado.Usuario = Reader.GetInt32("Usuario"); 
            }

            //fechar a conexão com o banco de dados.
            Conexao.Close();

            return pacoteEncontrado;
        }                
    }

}