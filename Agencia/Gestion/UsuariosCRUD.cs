using Agencia.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.Gestion
{
    public class UsuariosCRUD
    {
        // Conexion a la base de datos
        public string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgenciaDB; Integrated Security = True";

        public void AgregarUsuarios(string nombreCompleto, string nombreUsuario, string password, string tipo)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string comando = 
                    string.Format("INSERT INTO Usuarios (" +
                    "NombreCompleto, NombreUsuario, Password, Tipo) VALUES ('{0}', '{1}', '{2}', '{3}')", nombreCompleto, nombreUsuario, password, tipo);

                using (SqlCommand cmd = new SqlCommand(comando, conexion))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
            }
        }

        // Metodo para leer los registros
        public List<Usuarios> Read()
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("SELECT Id, NombreCompleto, NombreUsuario, Password, Tipo, Activo FROM Usuarios;", conexion);

                SqlDataReader reader = command.ExecuteReader();

                List<Usuarios> usuarios = new List<Usuarios>();
                int id = 0;
                string nombreCompleto = "";
                string nombreUsuario = "";
                string password = "";
                string tipo = "";
                bool activo = true;

                while (reader.Read())
                {
                    id = (int)reader[0];
                    nombreCompleto = reader[1].ToString();
                    nombreUsuario = reader[2].ToString();
                    password = reader[3].ToString();
                    tipo = reader[4].ToString();
                    activo = (bool)reader[5];

                    Usuarios usuario = new Usuarios() { Id = id, NombreCompleto = nombreCompleto, NombreUsuario = nombreUsuario, 
                        Password = password, Tipo = tipo, Activo = activo };
                    usuarios.Add(usuario);
                }

                reader.Close();
                return usuarios;
            }
        }

        public void EditarUsuarios(int id, string nombreCompleto, string nombreUsuario, string password, string tipo)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string comando =
                    string.Format("UPDATE Usuarios " +
                    "SET NombreCompleto = '{0}', NombreUsuario = '{1}', " +
                    "Password = '{2}', Tipo = '{3}' WHERE Id = {4}",
                     nombreCompleto, nombreUsuario, password, tipo, id);

                using (SqlCommand cmd = new SqlCommand(comando, conexion))
                {
                    var response = cmd.ExecuteNonQuery();                    
                }
                conexion.Close();
            }
        }

        public void BorrarUsuarios(int id)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string comando = "DELETE FROM Usuarios WHERE Id = {0};";
                SqlCommand command = new SqlCommand(string.Format(comando, id), conexion);

                var response = command.ExecuteNonQuery();                
                conexion.Close();
            }
        }
    }
}
