using Agencia.Gestion;
using Agencia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agencia.Formularios
{
    public partial class PanelForm : Form
    {
        UsuariosForm usuariosForm;
        AddEditUsuarios addEditUsuariosForm;

        MarcasForm marcasForm;
        AddEditMarcasForm addEditMarcasForm;

        AddEditModelosForm addEditModelosForm;

        ModelosCRUD clase = new ModelosCRUD();
        public PanelForm()
        {
            InitializeComponent();
        }

        private void PanelForm_Load(object sender, EventArgs e)
        {
            try
            {
                Configurar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Configurar()
        {
            //if (usuariosForm != null) { usuariosForm = null; }
            //if (addEditUsuariosForm != null) { addEditUsuariosForm = null; }

            //if (marcasForm != null) { marcasForm = null; }
            //if (addEditMarcasForm != null) { addEditMarcasForm = null; }

            List<Modelos> modelos = new List<Modelos>();
            modelos = clase.Read();

            dgvModelos.DataSource = null;
            if (modelos.Any())
            {
                dgvModelos.DataSource = modelos;
            }
            dgvModelos.Refresh();
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usuariosForm != null)
            {
                usuariosForm = null;
            }

            usuariosForm = new UsuariosForm();
            usuariosForm.Show();
        }

        private void agregarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addEditUsuariosForm != null)
            {
                addEditUsuariosForm = null;
            }

            addEditUsuariosForm = new AddEditUsuarios();
            addEditUsuariosForm.Show();
        }

        private void verMarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (marcasForm != null)
            {
                marcasForm = null;
            }

            marcasForm = new MarcasForm();
            marcasForm.Show();
        }

        private void agregarMarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addEditMarcasForm != null)
            {
                addEditMarcasForm = null;
            }

            addEditMarcasForm = new AddEditMarcasForm();
            addEditMarcasForm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (addEditModelosForm != null)
            {
                addEditModelosForm = null;
            }

            addEditModelosForm = new AddEditModelosForm();
            addEditModelosForm.ShowDialog();
        }
    }
}
