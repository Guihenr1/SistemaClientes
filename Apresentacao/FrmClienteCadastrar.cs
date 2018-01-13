using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjetoTransferencia;
using Negocio;

namespace Apresentacao
{
    public partial class FrmClienteCadastrar : Form
    {
        AcaoNaTela acaoNaTelaSelecionada;
        public FrmClienteCadastrar(AcaoNaTela acaoNaTela, Cliente cliente)
        {
            InitializeComponent();
            acaoNaTelaSelecionada = acaoNaTela;
            if(acaoNaTela.Equals(AcaoNaTela.Alterar))
            {
                Text = "Alterar Cliente";
                textBoxCodigo.Text = cliente.IDCliente.ToString();
                textBoxNome.Text = cliente.Nome;
                dateDataNascimento.Value = cliente.DataNascimento;
                if (cliente.Sexo.Equals(true))
                    radioSexoMasc.Checked = true;
                else
                    radioSexoFem.Checked = true;
                textBoxLimiteCompra.Text = cliente.LimiteDeCompra.ToString();
            }
            else if(acaoNaTela.Equals(AcaoNaTela.Consultar))
            {
                Text = "Consultar Cliente";
                textBoxCodigo.Text = cliente.IDCliente.ToString();
                textBoxNome.Text = cliente.Nome;
                dateDataNascimento.Value = cliente.DataNascimento;
                if (cliente.Sexo == true)
                {
                    radioSexoMasc.Checked = true;
                }
                else
                {
                    radioSexoFem.Checked = true;
                }
                textBoxLimiteCompra.Text = cliente.LimiteDeCompra.ToString();

                textBoxNome.ReadOnly = true;
                textBoxNome.TabStop = false;
                dateDataNascimento.Enabled = false;
                radioSexoFem.Enabled = false;
                radioSexoMasc.Enabled = false;
                textBoxLimiteCompra.ReadOnly = true;
                textBoxLimiteCompra.TabStop = false;
                buttonSalvar.Visible = false;
                buttonCancelar.Text = "Fechar";
                buttonCancelar.Focus();
            }
            else if(acaoNaTela.Equals(AcaoNaTela.Inserir))
            {
                Text = "Inserir Cliente";
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (acaoNaTelaSelecionada.Equals(AcaoNaTela.Inserir))
            {
                Cliente cliente = new Cliente();
                cliente.Nome = textBoxNome.Text;
                cliente.DataNascimento = dateDataNascimento.Value;
                if(radioSexoMasc.Checked == true)
                {
                    cliente.Sexo = true;
                }
                else if(radioSexoFem.Checked == true)
                {
                    cliente.Sexo = false;
                }
                cliente.LimiteDeCompra = Convert.ToDecimal(textBoxLimiteCompra.Text);

                ClienteNegocio clienteNegocio = new ClienteNegocio();
                string Retorno = clienteNegocio.Inserir(cliente);

                try
                {
                    int idCliente = Convert.ToInt32(Retorno);
                    MessageBox.Show("Cliente inserido com sucesso. Codigo: " + idCliente, "Inserir diz:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Yes;
                }
                catch
                {
                    MessageBox.Show("Erro ao inserir o Cliente. Detalhes: " + Retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.No;
                }
            }
            else if (acaoNaTelaSelecionada.Equals(AcaoNaTela.Alterar))
            {
                Cliente cliente = new Cliente();
                cliente.IDCliente = Convert.ToInt32(textBoxCodigo.Text);
                cliente.Nome = textBoxNome.Text;
                cliente.DataNascimento = dateDataNascimento.Value;
                if (radioSexoMasc.Checked == true)
                {
                    cliente.Sexo = true;
                }
                else if (radioSexoFem.Checked == true)
                {
                    cliente.Sexo = false;
                }
                cliente.LimiteDeCompra = Convert.ToDecimal(textBoxLimiteCompra.Text);

                ClienteNegocio clienteNegocio = new ClienteNegocio();
                string Retorno = clienteNegocio.Alterar(cliente);

                try
                {
                    int idCliente = Convert.ToInt32(Retorno);
                    MessageBox.Show("Cliente alterado com sucesso. Codigo: " + idCliente, "Alterar diz:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Yes;
                }
                catch
                {
                    MessageBox.Show("Erro ao alterar o Cliente. Detalhes: " + Retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.No;
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
