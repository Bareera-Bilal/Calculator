using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.Project
{
    public partial class Form1 : Form
    {

        Double result = 0;
        string operation = string.Empty;
        string fstNum, secNum;
        bool enterValue = false;
        public Form1()
        {
            InitializeComponent();
        }


        private void btnBackSpace_Click(object sender, EventArgs e)
        {

            if (txtDisplay1.Text.Length > 0)
                txtDisplay1.Text.Remove(txtDisplay1.Text.Length - 1, 1);

            if (txtDisplay1.Text == string.Empty) txtDisplay1.Text = "0";


        }


        private void BtnMathOperations_Click(object sender, EventArgs e)
        {
            if (result != 0) btnEquals.PerformClick();
            else result = Double.Parse(txtDisplay1.Text);
            Button button = (Button)sender;
            operation = button.Text;
            enterValue = true;
            if(txtDisplay1.Text != "0")
            {
                txtDisplay2.Text = fstNum = $"{result}{operation}";
                txtDisplay1.Text = string.Empty;
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            secNum = txtDisplay1.Text;
            txtDisplay2.Text = $"{txtDisplay2.Text} {txtDisplay1.Text}";
            if (txtDisplay1.Text != string.Empty)
            {
                if (txtDisplay1.Text == "0") txtDisplay2.Text = string.Empty;
                switch (operation)
                {
                    case "+":
                        txtDisplay1.Text = (result + Double.Parse(txtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum}={txtDisplay1.Text}\n");


                        break;

                    case "-":
                        txtDisplay1.Text = (result - Double.Parse(txtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum}={txtDisplay1.Text}\n");

                        break;

                    case "×":
                        txtDisplay1.Text = (result * Double.Parse(txtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum}={txtDisplay1.Text}\n");

                        break;

                    case "÷":
                        txtDisplay1.Text = (result / Double.Parse(txtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum}={txtDisplay1.Text}\n");

                        break;

                    default:txtDisplay2.Text = $"{txtDisplay1.Text}=";

                        break;
                }
                result = Double.Parse(txtDisplay1.Text);
                operation = string.Empty;
            }
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            pnlHistory.Height = (pnlHistory.Height == 5) ? pnlHistory.Height = 345 : 5;
        }

       

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            RtBoxDisplayHistory.Clear();
            if (RtBoxDisplayHistory.Text==string.Empty)
                RtBoxDisplayHistory.Text = ("There's is no history yet");

            
        }

        private void btnC_Click(object sender, EventArgs e)
        {

            txtDisplay1.Text = "0";
            txtDisplay2.Text = string.Empty;
            result = 0;

        }

        private void btnCE_Click(object sender, EventArgs e)
        {

            txtDisplay1.Text = "0";
            txtDisplay2.Text = string.Empty;
            result = 0;
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {



            Button button = (Button)sender;

            operation = button.Text;
            switch (operation)
            {

                case "2√x":

                    txtDisplay2.Text = $"({txtDisplay1.Text})x²";
                    txtDisplay1.Text = Convert.ToString(Math.Sqrt(Double.Parse(txtDisplay1.Text)));

                    break;



                case "x²":

                    txtDisplay2.Text = $"√({txtDisplay1.Text})";
                    txtDisplay1.Text = Convert.ToString(Convert.ToDouble(txtDisplay1.Text));

                   
                    break;



                case "¹/x":

                    txtDisplay2.Text = $"¹/({txtDisplay1.Text})";
                    txtDisplay1.Text = Convert.ToString(1.0/Convert.ToDouble(txtDisplay1.Text) * Convert.ToDouble(txtDisplay1.Text));


                    break;



                case "%":

                    txtDisplay2.Text = $"%({txtDisplay1.Text})";
                    txtDisplay1.Text = Convert.ToString( Convert.ToDouble(txtDisplay1.Text)/ Convert.ToDouble(100));


                    break;



                case "+/-":

                    txtDisplay1.Text = Convert.ToString(-1 * Convert.ToDouble(txtDisplay1.Text) * Convert.ToDouble(txtDisplay1.Text));


                    break;

            }

            RtBoxDisplayHistory.AppendText($"{txtDisplay2.Text}=={txtDisplay1.Text}\n");

        }

        private void BtnExitClick(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void BtnZoom_Click(object sender, EventArgs e)
        {
            if (WindowState==FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (txtDisplay1.Text == "0" || enterValue) txtDisplay1.Text = string.Empty;

            enterValue = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {

                if (!txtDisplay1.Text.Contains("."))
                    txtDisplay1.Text = txtDisplay1.Text + button.Text;



            }

            else txtDisplay1.Text = txtDisplay1.Text + button.Text;
          
        }
    }
}
