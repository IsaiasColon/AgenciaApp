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
    public partial class MovimientosForm : Form
    {
        MovimientosCRUD clase = new MovimientosCRUD();
        public MovimientosForm()
        {
            InitializeComponent();
        }

        private void MovimientosForm_Load(object sender, EventArgs e)
        {
            Configurar();
        }

        void Configurar()
        {
            List<Movimientos> movimientos = new List<Movimientos>();
            dgvMovimientos.DataSource = null;
            if (movimientos.Any())
            {
                dgvMovimientos.DataSource = movimientos;
            }
            dgvMovimientos.Refresh();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
