using System;
using MySqlConnector;
using System.Collections.Generic;

namespace DestinoCerto.Models
{
    public class UsuariosRepository
    {
        //Esta classe precisa ler as credenciais de acesso ao banco de dados.
        //A credencial de acesso precisa ser privada.

        private const string DadosConexao = "Database=DestinoCerto; Data Source=localhost; User Id=root;";
        public Usuario ValidarLogin(Usuario user)
        {
            // abrir conexão com o banco de dados.
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            // Query Sql para Inserir
            String Query = "Select * from Usuarios where Login=@Login and Senha=@Senha";

            // Preparar um comando, passando: Sql + conexão com o banco de dados
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            // tratamento do SqlInjection
            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);

            //Executa no banco de dados, que retorna um único usuário quando encontrado.
            MySqlDataReader Reader = Comando.ExecuteReader(); 

            Usuario UsuarioEncontrado = null; 

            if(Reader.Read())
            {
                UsuarioEncontrado = new Usuario();

                UsuarioEncontrado.IdUsuario = Reader.GetInt32("IdUsuario");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                UsuarioEncontrado.Nome = Reader.GetString("Nome");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                UsuarioEncontrado.Login = Reader.GetString("Login");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                UsuarioEncontrado.Senha = Reader.GetString("Senha");

                UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
                
                // fechar a conexao com o banco de dados
                Conexao.Close();

                // Retornar o AlunosEncontrado
                return UsuarioEncontrado;
                
            }else{
                Conexao.Close();
                return UsuarioEncontrado;
            }
        }
    }
}
