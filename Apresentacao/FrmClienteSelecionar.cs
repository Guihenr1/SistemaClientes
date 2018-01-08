using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using ObjetoTransferencia;

namespace Apresentacao
{
    public partial class FrmClienteSelecionar : Form
    {
        public FrmClienteSelecionar()
        {
            InitializeComponent();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            ClienteColecao clienteColecao = new ClienteColecao();

            clienteColecao = clienteNegocio.PesquisarPorNome(txtPesquisar.Text);

            dgwPrincipal.DataSource = null;
            dgwPrincipal.DataSource = clienteColecao;
            dgwPrincipal.Update();
            dgwPrincipal.Refresh();
        }
    }
}
