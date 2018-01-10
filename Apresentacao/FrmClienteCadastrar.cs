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

namespace Apresentacao
{
    public partial class FrmClienteCadastrar : Form
    {
        public FrmClienteCadastrar(AcaoNaTela acaoNaTela, Cliente cliente)
        {
            InitializeComponent();
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
            }
            else if(acaoNaTela.Equals(AcaoNaTela.Inserir))
            {
                Text = "Inserir Cliente";
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {

        }
    }
}
