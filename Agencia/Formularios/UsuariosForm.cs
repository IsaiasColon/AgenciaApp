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
    public partial class UsuariosForm : Form
    {
        AddEditUsuarios addEdit;
        UsuariosCRUD clase = new UsuariosCRUD();
        public UsuariosForm()
        {
            InitializeComponent();
        }

        private void AddEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Configurar();
            dgvUsuarios.Refresh();
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            try
            {
                Configurar();
                dgvUsuarios.RowHeaderMouseDoubleClick += DgvUsuarios_RowHeaderMouseDoubleClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvUsuarios_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Usuarios usuario = new Usuarios();
            try
            {
                usuario = dgvUsuarios.CurrentRow.DataBoundItem as Usuarios;
                addEdit.CurrrentUser = usuario;
                addEdit.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (addEdit != null)
            {
                addEdit = null;
            }

            addEdit = new AddEditUsuarios();
            addEdit.FormClosed += AddEdit_FormClosed;

            addEdit.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void Configurar()
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            usuarios = clase.Read();
            dgvUsuarios.DataSource = null;
            if (usuarios.Any())
            {
                dgvUsuarios.DataSource = usuarios;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (dgvUsuarios.CurrentRow.DataBoundItem as Usuarios).Id;
                if (id > 0)
                {
                    clase.BorrarUsuarios(id);
                    Configurar();
                }
                else
                {
                    throw new ArgumentException("Algo fallo al borrar el usuario seleccionado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
