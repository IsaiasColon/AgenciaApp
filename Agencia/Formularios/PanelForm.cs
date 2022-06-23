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
        public PanelForm()
        {
            InitializeComponent();
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usuariosForm != null)
            {
                usuariosForm = null;
            }

            usuariosForm = new UsuariosForm();
            usuariosForm.Show();
        }

        private void PanelForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Configurar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Configurar()
        {
            if (usuariosForm != null)
            {
                usuariosForm = null;
            }

            if (addEditUsuariosForm != null)
            {
                addEditUsuariosForm = null;
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addEditUsuariosForm != null)
            {
                addEditUsuariosForm = null;
            }

            addEditUsuariosForm = new AddEditUsuarios();
            addEditUsuariosForm.Show();
        }
    }
}
