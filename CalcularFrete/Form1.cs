using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            var freteMinimo = Convert.ToDecimal( txtFreteMinimo.Text );
            var uf = txtUf.Text;

            CalcularFrete(freteMinimo, uf);
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
            }else if (uf.Equals("SC"))
            {
                freteFinal = freteMinimo + 1.0M;
            }
            else 
            {
                freteFinal = freteMinimo + adicional;
            }
            txtTotalFrete.Text = freteFinal.ToString("F2");
        }
    }
}
