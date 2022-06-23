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
    public partial class MarcasForm : Form
    {
        AddEditMarcasForm addEditMarcasForm;
        MarcasCRUD clase = new MarcasCRUD();
        public MarcasForm()
        {
            InitializeComponent();
        }

        private void MarcasForm_Load(object sender, EventArgs e)
        {
            try
            {
                Configurar();
                dgvMarcas.RowHeaderMouseDoubleClick += DgvMarcas_RowHeaderMouseDoubleClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvMarcas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Marcas marca = (dgvMarcas.CurrentRow.DataBoundItem as Marcas);
            if (addEditMarcasForm != null)
            {
                addEditMarcasForm = null;
            }

            addEditMarcasForm = new AddEditMarcasForm();
            addEditMarcasForm.FormClosed += AddEditMarcasForm_FormClosed;
            addEditMarcasForm.CurrentMarca = marca;
            addEditMarcasForm.ShowDialog();
        }

        void Configurar()
        {
            List<Marcas> marcas = new List<Marcas>();
            marcas = clase.Read();
            dgvMarcas.DataSource = null;
            if (marcas.Any())
            {
                dgvMarcas.DataSource = marcas;
            }
            dgvMarcas.Refresh();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (addEditMarcasForm != null)
                {
                    addEditMarcasForm = null;
                }
                addEditMarcasForm = new AddEditMarcasForm();
                addEditMarcasForm.FormClosed += AddEditMarcasForm_FormClosed;
                addEditMarcasForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddEditMarcasForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Configurar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (dgvMarcas.CurrentRow.DataBoundItem as Marcas).Id;
                if (id > 0)
                {
                    clase.BorrarMarcas(id);
                }
                Configurar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
