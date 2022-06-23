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
    public partial class AddEditMarcasForm : Form
    {
        MarcasCRUD clase = new MarcasCRUD();
        public AddEditMarcasForm()
        {
            InitializeComponent();
        }
        private void AddEditMarcasForm_Load(object sender, EventArgs e)
        {
            Configurar();
        }

        private Marcas currentMarca;
        public Marcas CurrentMarca
        {
            get { return currentMarca; }
            set { currentMarca = value; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtMarca.Text;
                if (CurrentMarca == null)
                {
                    clase.AgregarMarca(nombre);
                }
                else
                {
                    if (currentMarca.Id > 0)
                    {
                        int id = currentMarca.Id;
                        clase.EditarMarcas(id, nombre);
                    }
                    else
                    {
                        clase.AgregarMarca(nombre);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Configurar()
        {
            if (CurrentMarca == null)
            {
                txtMarca.Text = "";
            }
            else
            {
                txtMarca.Text = CurrentMarca.Nombre;
            }
        }

    }
}
