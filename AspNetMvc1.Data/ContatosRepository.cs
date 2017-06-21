using System.Collections.Generic;
using AspNetMvc1.Domain;
using System.Data.SqlClient;
using System.Data;

namespace AspNetMvc1.Data
{
    public class ContatosRepository
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vinicius.nunes\Documents\Visual Studio 2017\Projects\ASP NET MVC WEB API\AspNetMvc1\AspNetMvc1.Presentation\App_Data\Database1.mdf;Integrated Security=True";

        public IEnumerable<Contato> pegarContatos()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Contatos";
                var selectCommand = new SqlCommand(commandText, connection);

                Contato contato = null;
                var contatos = new List<Contato>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            contato = new Contato();
                            contato.Id = (int)reader["Id"];
                            contato.nome = reader["nome"].ToString();
                            contato.sobreNome = reader["sobreNome"].ToString();
                            contato.telefone= reader["telefone"].ToString();
                            contato.email = reader["email"].ToString();

                            contatos.Add(contato);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }

                return contatos;
            }
        }

        public Contato getContatoDetails(int idContato)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Contatos WHERE Id = " + idContato;
                var selectCommand = new SqlCommand(commandText, connection);

                Contato contato = null;

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            contato = new Contato();
                            contato.Id = (int)reader["Id"];
                            contato.nome = reader["nome"].ToString();
                            contato.sobreNome = reader["sobreNome"].ToString();
                            contato.telefone = reader["telefone"].ToString();
                            contato.email = reader["email"].ToString();
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }

                return contato;
            }
        }
    }
}
