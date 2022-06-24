using Agencia.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.Gestion
{
    public class ModelosCRUD
    {
        // Conexion a la base de datos
        public string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgenciaDB; Integrated Security = True";

        public void AgregarModelo(int marca, string nombre, string tipo, string color, int total, int año, int puertas, string motor, string transmision)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string comando = 
                    string.Format(
                        "INSERT INTO Modelos (Marca, Nombre, Tipo, Color, Total, Año, Puertas, Motor, Transmision) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}','{5}', '{6}', '{7}', '{8}')",
                    marca, nombre, tipo, color, total, año, puertas, motor, transmision);

                using (SqlCommand cmd = new SqlCommand(comando, conexion))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
            }
        }

        // Metodo para leer los registros
        public List<Modelos> Read()
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("SELECT Id, Marca, Nombre, Tipo, Color, Total, Año, Puertas, Motor, Transmision FROM Modelos;", conexion);

                SqlDataReader reader = command.ExecuteReader();

                List<Modelos> modelos = new List<Modelos>();

                int id = 0;
                int marca = 0;
                string nombre = "";
                string tipo = "";
                string color = "";
                int total = 0;
                int año = 0;
                int puertas = 0;
                string motor = "";
                string transmision = "";

                while (reader.Read())
                {
                    id = (int)reader[0];
                    marca = (int)reader[1];
                    nombre = reader[1].ToString();

                    Modelos modelo = new Modelos() { 
                        Id = id, Marca = marca, Nombre = nombre,
                        Tipo = tipo, Color = color,
                        Total = total, Año = año, Puertas = puertas,
                        Motor = motor, Transmision = transmision
                    };

                    modelos.Add(modelo);
                }

                reader.Close();
                return modelos;
            }
        }
    }
}
