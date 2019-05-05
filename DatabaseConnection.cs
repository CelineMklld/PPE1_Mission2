using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace GestionClotureGSB
{
    public class DatabaseConnection
    {
        private string connectionString;


        /// <summary>
        /// Méthode "databaseConnection" : se connecte à la base de données 
        /// </summary>
        /// <param name="connectionString"></param>
        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }


        /// <summary>
        /// Méthode "adminRequest" : exécute des requêtes d’administration dans la base de données (en SQL)
        /// </summary>
        /// <param name="sqlRequest"> Paramètre de requêtes d'exécution dans la BDD : insert, update, delete </param>
        public void adminRequest(string sqlRequest)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = sqlRequest;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                }

            }
        }

        /// <summary>
        /// Méthode "getFromDb" : récupère des données de la base de données (en SQL)
        /// </summary>
        /// <param name="sqlRequest"> Paramètre de requête de récupération de données de la BDD </param>
        /// <returns></returns>
        public string getFromDb(string sqlRequest)
        {
            string resultat = "";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = sqlRequest;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultat += reader.GetString(0)+"\n";
                    }
                }

            }
            return resultat;
        }

    }
}
