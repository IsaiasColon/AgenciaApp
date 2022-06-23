using Agencia.Formularios;
using Agencia.Gestion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agencia
{
    public partial class Form1 : Form
    {
        PanelForm panel = new PanelForm();
        Operaciones clase = new Operaciones();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            bool login = clase.IniciarSesion(txtUsuario.Text, txtPassword.Text);
            if (login)
            {
                panel.ShowDialog();
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
