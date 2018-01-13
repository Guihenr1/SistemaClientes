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
            dgwPrincipal.AutoGenerateColumns = false;
            AtualizarGrid();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        public void AtualizarGrid()
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            ClienteColecao clienteColecao = new ClienteColecao();

            clienteColecao = clienteNegocio.PesquisarPorNome(txtPesquisar.Text);

            dgwPrincipal.DataSource = null;
            dgwPrincipal.DataSource = clienteColecao;
            dgwPrincipal.Update();
            dgwPrincipal.Refresh();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if(dgwPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Deseja excluir esse cliente?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if(dialogResult == DialogResult.No)
            {
                return;
            }

            Cliente clienteSelecionado = (dgwPrincipal.SelectedRows[0].DataBoundItem as Cliente);
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            string retorno = clienteNegocio.Excluir(clienteSelecionado);

            try
            {
                int idCliente = Convert.ToInt32(retorno);
                MessageBox.Show("Cliente excluido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGrid();
            }
            catch
            {
                MessageBox.Show("Não foi possivel excluir. Detalhes: " + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar(AcaoNaTela.Inserir, null);
            DialogResult dialogResult = frmClienteCadastrar.ShowDialog();
            if(dialogResult == DialogResult.Yes)
            {
                AtualizarGrid();
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (dgwPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            Cliente clienteSelecionado = (dgwPrincipal.SelectedRows[0].DataBoundItem as Cliente);

            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar(AcaoNaTela.Alterar, clienteSelecionado);
            DialogResult result = frmClienteCadastrar.ShowDialog();
            if (result == DialogResult.Yes)
            {
                AtualizarGrid();
            }
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            if (dgwPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Cliente clienteSelecionado = (dgwPrincipal.SelectedRows[0].DataBoundItem as Cliente);

            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar(AcaoNaTela.Consultar, clienteSelecionado);
            frmClienteCadastrar.ShowDialog();
        }
    }
}
