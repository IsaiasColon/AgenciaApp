using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agencia.Gestion;
using Agencia.Models;

namespace Agencia.Formularios
{
    public partial class AddEditUsuarios : Form
    {
        UsuariosCRUD clase = new UsuariosCRUD();
        public AddEditUsuarios()
        {
            InitializeComponent();
        }

        private Usuarios currentUser;

        public Usuarios CurrrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }


        private void AddEditUsuarios_Load(object sender, EventArgs e)
        {
            Configurar();
        }

        void Configurar()
        {
            Usuarios usuario = new Usuarios();

            if (CurrrentUser != null)
            {
                usuario = CurrrentUser;
                txtNombre.Text = usuario.NombreCompleto;
                txtUsuario.Text = usuario.NombreUsuario;
                txtPassword.Text = usuario.Password;
                txtPassword2.Text = usuario.Password;
                cmbTipo.SelectedText = usuario.Tipo;
            }
            else
            {
                txtNombre.Text = "";
                txtUsuario.Text = "";
                txtPassword.Text = "";
                txtPassword2.Text ="";
                cmbTipo.SelectedIndex = 0;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string usuario = txtUsuario.Text;
                string password = "";

                if (txtPassword.Text == txtPassword2.Text)
                {
                    password = txtPassword.Text;
                }
                else
                {
                    throw new ArgumentException("Las contraseñas no coinciden");
                }
                string tipo = cmbTipo.SelectedItem.ToString();

                if (CurrrentUser == null)
                {
                    clase.AgregarUsuarios(nombre, usuario, password, tipo);
                }
                else
                {
                    if (CurrrentUser.Id > 0)
                    {
                        int id = currentUser.Id;
                        clase.EditarUsuarios(id, nombre, usuario, password, tipo);
                    }
                    else
                    {
                        clase.AgregarUsuarios(nombre, usuario, password, tipo);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
