using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            /*comboBoxOperacion.Items.Add("+");
            comboBoxOperacion.Items.Add("-");
            comboBoxOperacion.Items.Add("*");
            comboBoxOperacion.Items.Add("/");*/
        }


        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero primerNumero = new Numero();
            Numero segundoNumero = new Numero();
            double resultado;

            primerNumero.SetNumero = numero1;
            segundoNumero.SetNumero = numero2;

            resultado = Calculadora.Operar(primerNumero, segundoNumero, operador);
            return resultado;            
        }
        
        private void ButtonOperar_Click(object sender, EventArgs e)
        {
            double resultado=Operar(textPrimerNumero.Text, textSegundoNumero.Text, comboBoxOperacion.Text);
            if (resultado != double.MinValue)
            {
                labelMostrarResultado.Text = resultado.ToString();
            }
            else
            {
                labelMostrarResultado.Text = "No se puede dividir por 0";
            }            
        }

        
        private void Limpiar()
        {
            textPrimerNumero.Clear();
            textSegundoNumero.Clear();
            comboBoxOperacion.Text = "";
            labelMostrarResultado.Text = "";
        }
        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void ButtonConvertABinario_Click(object sender, EventArgs e)
        {
            string numeroAConvertir = labelMostrarResultado.Text;
            string retorno = Numero.DecimalBinario(numeroAConvertir);
            labelMostrarResultado.Text = retorno;
        }

        private void ButtonConvertADecimal_Click(object sender, EventArgs e)
        {
            string retorno;
            retorno=Numero.BinarioDecimal(labelMostrarResultado.Text);
            labelMostrarResultado.Text = retorno;
        }
    }
}
