﻿using Agencia.Models;
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
        public string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgenciaDB;";

        // Metodo para crear nuevos registros
        public void Create(string nombre, string usuario, string password, string tipo)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string comando = "INSERT INTO Login (Nombre, Usuario, Password, Tipo) VALUES ('{0}', '{1}', '{2}', '{3}')";
                using (SqlCommand command = new SqlCommand(string.Format(comando, nombre, usuario, password, tipo), conexion))
                {
                    SqlDataReader reader = command.ExecuteReader();
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
                SqlCommand command = new SqlCommand("SELECT Id, Nombre, Usuario, Password, Tipo, Activo FROM Login;", conexion);

                SqlDataReader reader = command.ExecuteReader();

                List<Usuarios> logins = new List<Usuarios>();
                int id = 0;
                string nombre = "";
                string usuario = "";
                string password = "";
                string tipo = "";
                bool activo = false;

                while (reader.Read())
                {
                    id = (int)reader[0];
                    nombre = reader[1].ToString();
                    usuario = reader[2].ToString();
                    password = reader[3].ToString();
                    tipo = reader[4].ToString();
                    activo = (bool)reader[5];

                    Usuarios login = new Usuarios() { Id = id, NombreCompleto = nombre, NombreUsuario = usuario, Password = password, Tipo = tipo, Activo = activo };
                    logins.Add(login);
                }

                reader.Close();
                return logins;
            }
        }

        // Metodo para actualizar o modificar los registros
        public void Update(Usuarios login)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string comando =
                    "UPDATE Login SET " +
                        "Nombre = '{0}'," +
                        "Usuario = '{1}'," +
                        "Password = '{2}'," +
                        "Tipo = '{3}', " +
                        "Activo = '{4}' " +
                    "WHERE Id = {5};";

                SqlCommand command = new SqlCommand(
                    string.Format(comando, login.NombreCompleto, login.NombreUsuario, login.Password, login.Tipo, login.Activo, login.Id), conexion);

                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }
        }

        // Metodo para borrar registros
        public void Delete(int id)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string comando = "DELETE FROM Login WHERE Id = {0};";
                SqlCommand command = new SqlCommand(string.Format(comando, id), conexion);

                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }
        }

        public Usuarios IniciarSesion(string user, string pass)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string comando = "SELECT Id, Nombre, Usuario, Password, Tipo, Activo FROM Login WHERE Usuario = '{0}';";
                SqlCommand command = new SqlCommand(string.Format(comando, user), conexion);

                SqlDataReader reader = command.ExecuteReader();

                List<Usuarios> logins = new List<Usuarios>();
                int id = 0;
                string nombre = "";
                string usuario = "";
                string password = "";
                string tipo = "";
                bool activo = false;

                while (reader.Read())
                {
                    id = (int)reader[0];
                    nombre = reader[1].ToString();
                    usuario = reader[2].ToString();
                    password = reader[3].ToString();
                    tipo = reader[4].ToString();
                    activo = (bool)reader[5];

                    Usuarios login = new Usuarios() { Id = id, NombreCompleto = nombre, NombreUsuario = usuario, Password = password, Tipo = tipo, Activo = activo };
                    logins.Add(login);
                }

                Usuarios xLogin = new Usuarios();
                foreach (Usuarios x in logins)
                {
                    if (x.Password == pass)
                    {
                        xLogin = x;
                    }
                }

                reader.Close();
                return xLogin;
            }
        }
    }
}
