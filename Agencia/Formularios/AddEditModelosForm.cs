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
    public partial class AddEditModelosForm : Form
    {
        ModelosCRUD clase = new ModelosCRUD();
        MarcasCRUD claseMarcas = new MarcasCRUD();
        public AddEditModelosForm()
        {
            InitializeComponent();
        }
        private void AddEditModelosForm_Load(object sender, EventArgs e)
        {
            Configurar();
        }

        void Configurar()
        {
            try
            {
                List<Marcas> marcas = claseMarcas.Read();

                if (marcas.Any())
                {
                    cmbMarcas.DataSource = marcas;
                    cmbMarcas.DisplayMember = "Nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int marca = (cmbMarcas.SelectedItem as Marcas).Id;
                string nombre = txtNombre.Text;
                string tipo = txtTipo.Text;
                string color = txtColor.Text;
                int total = int.Parse(txtTotal.Text);
                int año = int.Parse(txtAño.Text);
                int puertas = int.Parse(txtPuertas.Text);
                string motor = txtMotor.Text;
                string transmision = txtTransmision.Text;

                clase.AgregarModelo(marca, nombre, tipo, color, total, año, puertas, motor, transmision);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
