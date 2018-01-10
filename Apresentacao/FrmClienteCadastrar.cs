using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmClienteCadastrar : Form
    {
        public FrmClienteCadastrar(AcaoNaTela acaoNaTela)
        {
            InitializeComponent();
            if(acaoNaTela.Equals(AcaoNaTela.Alterar))
            {
                Text = "Alterar Cliente";
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
