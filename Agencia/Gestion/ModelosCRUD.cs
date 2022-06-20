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
        public string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgenciaAutomotriz; Integrated Security = True";

        // Metodo para crear nuevos registros
        public void Agregar(string marca, string modelo, string tipo, string color)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("AgregarAutomovil", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Marca", marca);
                cmd.Parameters.AddWithValue("Modelo", modelo);
                cmd.Parameters.AddWithValue("Tipo", tipo);
                cmd.Parameters.AddWithValue("Color", color);

                cmd.ExecuteNonQuery();
            }
        }
        // Metodo para leer los registros
        public List<Modelos> Read()
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerAutos", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                List<Modelos> automoviles = new List<Modelos>();
                int id = 0;
                int marca = 0;
                string nombre = "";
                string tipo = "";
                string color = "";
                int total = 0;

                while (reader.Read())
                {
                    id = (int)reader[0];
                    marca = (int)reader[1];
                    nombre = reader[2].ToString();
                    tipo = reader[3].ToString();
                    color = reader[4].ToString();
                    total = (int)reader[5];

                    Modelos automovil = new Modelos() { Id = id, Marca = marca, Nombre = nombre, Tipo = tipo, Color = color, Total = total };
                    automoviles.Add(automovil);
                }

                reader.Close();
                return automoviles;
            }
        }

        // Metodo para actualizar o modificar los registros
        public void Modificar(Modelos automovil)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ModificarAutomovil", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", automovil.Id);
                cmd.Parameters.AddWithValue("Marca", automovil.Marca);
                cmd.Parameters.AddWithValue("Modelo", automovil.Nombre);
                cmd.Parameters.AddWithValue("Tipo", automovil.Tipo);
                cmd.Parameters.AddWithValue("Color", automovil.Color);

                cmd.ExecuteNonQuery();
            }
        }

        // Metodo para borrar registros
        public void Eliminar(int id)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("EliminarAutomovil", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
