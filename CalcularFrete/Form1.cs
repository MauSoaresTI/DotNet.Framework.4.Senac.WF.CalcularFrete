using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcularFrete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcularFrete_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() != true)
                return;

            //TRY DE TENTEAR EXECUTAR O CODIGO
            try
            {
                // CONVERTENDO TEXTO E MDECIMAL
                var freteMinimo = Convert.ToDecimal(txtFreteMinimo.Text);

                //CONVERTENDO OBJETO EM STRING 
                var uf = (string)cbxUF.SelectedItem;

                CalcularFrete(freteMinimo, uf);

            }
            // CATCH SIGNIFICA CAPUTRAR O ERRO SE OCORRER
            catch (Exception ex)
            {
                //LOG DO ERRO
                Console.WriteLine(ex.Message);


                //LIMPAR O CAMPO COM UMA STRING VAZIA
                txtFreteMinimo.Text = string.Empty;

                // COLOCA O FOCO DO TECLADO NO TXT
                txtFreteMinimo.Focus();

                // MENSAGEM DO ERRO PARA EXIBIR PRO USUARIO
                MessageBox.Show("Informe o valor do frete", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        void CalcularFrete(decimal freteMinimo, String uf)
        {
            //VARIAVEL DO TIPO DECIMAL
            var adicional = 5.0M;
            var freteFinal = freteMinimo;

            //SE UF FOR IGUAL == A RIO GRANDE DO SUL, VAI ENTRAR NO IF
            if (uf.Equals("RS"))
            {

                freteFinal = freteMinimo + 0.5M;
                //Equals é USADO PARA DEIXAR IGUAL COMO == que vai ser o Equals
            }
            else if (uf.Equals("SC"))
            {
                freteFinal = freteMinimo + 1.0M;
            }
            else if (uf.Equals("PR"))
            {
                freteFinal = freteMinimo + 2.0M;
            }
            else if (uf.Equals("SP"))
            {
                freteFinal = freteMinimo + 3.0M;
            }
            else
            {
                freteFinal = freteMinimo + adicional;
            }
            txtTotalFrete.Text = freteFinal.ToString("F2");
        }

        bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtFreteMinimo.Text))
            {

                ExibirMensagem("INFORME O VALOR FRETE MINIMO,");
                return false;
            }
            // VERIFICA SE O TEXT DO XBX ESTA VAZIO SETA O FOCO E EXIBE A MENSAGEM
            if (string.IsNullOrEmpty(cbxUF.Text))
            {
                cbxUF.Focus();
                ExibirMensagem(" INFORME A UF!");
                return false;
            }
            return true;
        }


        private void ExibirMensagem(string msg)
        {

            MessageBox.Show(msg,
                "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

    }
}
