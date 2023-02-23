using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Calculadora
{

    public partial class Calculadora : Form
    {
        private string numero1 = string.Empty;
        private string numero2 = string.Empty;
        private string operacao = string.Empty;
        string connectionString = @"Data Source=APSDEVNB10\SQLEXPRESS;Initial Catalog=CARROS;USER ID= sa; password = _brazil";
        public Calculadora()
        {
            InitializeComponent();
        }


        double resultado;
        private void button8_Click(object sender, EventArgs e)
        {
            atribuirValorDigitado(btn1.Text.Trim());
        }
        private void button9_Click(object sender, EventArgs e)
        {
            atribuirValorDigitado(btn2.Text.Trim());
        }

        public void atribuirValorDigitado(string valor)
        {
            if (string.IsNullOrEmpty(operacao.Trim()))
            {

                if (!numero1.Contains(",") || !valor.Contains(","))
                    numero1 += valor.Trim();

            }
            else
            {
                if (!numero2.Contains(",") || !valor.Contains(","))
                    numero2 += valor.Trim();
            }
            textBox1.Text = $"{numero1}{operacao}{numero2}";
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            atribuirValorDigitado(btn3.Text.Trim());
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            atribuirValorDigitado(btn4.Text.Trim());
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            atribuirValorDigitado(btn5.Text.Trim());
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            atribuirValorDigitado(btn6.Text.Trim());
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            atribuirValorDigitado(btn7.Text.Trim());
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            atribuirValorDigitado(btn8.Text.Trim());
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            atribuirValorDigitado(btn9.Text.Trim());
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            atribuirValorDigitado(btn0.Text.Trim());
        }
        private void btnce_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            LimparVariavel();
        }
        private void LimparVariavel()
        {
            numero1 = string.Empty;
            numero2 = string.Empty;
            operacao = string.Empty;
        }
        private void btnsoma_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(numero1) && !string.IsNullOrEmpty(operacao) && !string.IsNullOrEmpty(numero2))
            {
                compute();
                LimparVariavel();
                numero1 = textBox1.Text;
                operacao = btnsoma.Text;
                return;
            }
            if (string.IsNullOrEmpty(numero1))
            {
                if (string.IsNullOrEmpty(numero2))
                {


                }

            }
            else
            {
                operacao = btnsoma.Text;
            }
        }
        private void btnx_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(numero1) && !string.IsNullOrEmpty(operacao) && !string.IsNullOrEmpty(numero2))
            {
                compute();
                LimparVariavel();
                numero1 = textBox1.Text;
                operacao = btnx.Text;
                return;
            }
            if (string.IsNullOrEmpty(numero1))
            {
                if (string.IsNullOrEmpty(numero2))
                {


                }

            }
            else
            {
                operacao = btnx.Text;
            }
        }
        private void btndiv_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(numero1) && !string.IsNullOrEmpty(operacao) && !string.IsNullOrEmpty(numero2))
            {
                compute();
                LimparVariavel();
                numero1 = textBox1.Text;
                operacao = btndiv.Text;
                return;
            }
            if (string.IsNullOrEmpty(numero1))
            {
                if (string.IsNullOrEmpty(numero2))
                {


                }
            }
            else
            {
                operacao = btndiv.Text;
            }
        }
        private void btnsub_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(numero1) && !string.IsNullOrEmpty(operacao) && !string.IsNullOrEmpty(numero2))
            {
                compute();
                LimparVariavel();
                numero1 = textBox1.Text;
                operacao = btnsub.Text;
                return;
            }

            if (string.IsNullOrEmpty(numero1))
            {
                if (btnsub.Text == "-")
                    numero1 = btnsub.Text;
            }
            else
            {
                operacao = btnsub.Text;
            }
        }
        private void buttonvirg_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(numero1) && string.IsNullOrEmpty(operacao))
            {
                atribuirValorDigitado(buttonvirg.Text.Trim());
            }
            if (!string.IsNullOrEmpty(operacao) && !string.IsNullOrEmpty(numero2))
            {
                atribuirValorDigitado(buttonvirg.Text.Trim());
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnigual_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(numero2))
            {


            }
            else
            {
                compute();
            }
        }
        public void compute()
        {
            switch (operacao)
            {
                case "-":
                    resultado = double.Parse(numero1) - double.Parse(numero2);
                    break;
                case "+":
                    resultado = double.Parse(numero1) + double.Parse(numero2);
                    break;
                case "*":
                    resultado = double.Parse(numero1) * double.Parse(numero2);
                    break;
                case "/":
                    resultado = double.Parse(numero1) / double.Parse(numero2);
                    break;
                default:
                    break;
            }
            if (resultado == double.PositiveInfinity || resultado == double.NegativeInfinity)
            {
                textBox1.Text = "Erro";
                LimparVariavel();
                return;
            }
            textBox1.Text = resultado.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<calculadora1> lstCalculadora = new List<calculadora1>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from calculadora", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    calculadora1 calculadora = new calculadora1();
                    calculadora.ID_NMOPERACAO = Convert.ToInt32(rdr["ID_CALCULADORA"]);
                    calculadora.HOR_OP = Convert.ToDateTime(rdr["HOR_OP"]);
                    calculadora.RESULT = Convert.ToDecimal(rdr["RESULT"]);
                    calculadora.OPERACAO = Convert.ToChar(rdr["OPERACAO"]);
                    calculadora.VALOR_1 = Convert.ToDecimal(rdr["VALOR_1"]);
                    calculadora.VALOR_2 = Convert.ToDecimal(rdr["VALOR_2"]);
                    lstCalculadora.Add(calculadora);
                }
                con.Close();
            }
        }
    }
}



