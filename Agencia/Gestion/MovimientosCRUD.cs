using Agencia.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.Gestion
{
    public class MovimientosCRUD
    {
        // Conexion a la base de datos
        public string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgenciaDB; Integrated Security = True";

        public void AgregarMovimientos(bool tipo, int modelo, int cantidad)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string comando = string.Format("INSERT INTO Movimientos (Tipo, Modelo, Cantidad) VALUES ('{0}', '{1}', '{2}')", tipo, modelo, cantidad);
                using (SqlCommand cmd = new SqlCommand(comando, conexion))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
            }
        }

        // Metodo para leer los registros
        public List<Movimientos> Read()
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("SELECT Id, Tipo, Modelo, Cantidad, Fecha FROM Movimientos;", conexion);

                SqlDataReader reader = command.ExecuteReader();

                List<Movimientos> movimientos = new List<Movimientos>();
                int id = 0;
                bool tipo = true;
                int modelo = 0;
                int cantidad = 0;
                DateTime fecha = new DateTime();

                while (reader.Read())
                {
                    id = (int)reader[0];
                    tipo = (bool)reader[1];
                    modelo = (int)reader[2];
                    cantidad = (int)reader[3];
                    fecha = (DateTime)reader[4];

                    Movimientos movimiento = new Movimientos() { 
                        Id = id, Tipo = tipo, Modelo = modelo, Cantidad = cantidad, Fecha = fecha };
                    movimientos.Add(movimiento);
                }

                reader.Close();
                return movimientos;
            }
        }

    }
}
