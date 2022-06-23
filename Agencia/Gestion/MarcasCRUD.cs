using Agencia.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.Gestion
{
    public class MarcasCRUD
    {
        // Conexion a la base de datos
        public string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgenciaDB; Integrated Security = True";

        public void AgregarMarca(string nombre)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string comando = string.Format("INSERT INTO Marcas (Nombre) VALUES ('{0}')", nombre);
                using (SqlCommand cmd = new SqlCommand(comando, conexion))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
            }
        }

        // Metodo para leer los registros
        public List<Marcas> Read()
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("SELECT Id, Nombre FROM Marcas;", conexion);

                SqlDataReader reader = command.ExecuteReader();

                List<Marcas> marcas = new List<Marcas>();
                int id = 0;
                string nombre = "";

                while (reader.Read())
                {
                    id = (int)reader[0];
                    nombre = reader[1].ToString();

                    Marcas marca = new Marcas() { Id = id, Nombre = nombre };
                    marcas.Add(marca);
                }

                reader.Close();
                return marcas;
            }
        }

    }
}
