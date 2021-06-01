using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialSeguridadInformatica
{
    public partial class Parte1 : Form
    {
        public Parte1()
        {
            InitializeComponent();
        }

        int p, q, n, of, ee, d;



        private void button1_Click(object sender, EventArgs e)
        {

            p = 0;
            q = 0;
            n = 0;
            of = 0;
            ee = 2;
            d = 0;

            ///Ingresar valores

            if (validardatosentrada())
            {
                p = Convert.ToInt32(textBox1.Text);
                q = Convert.ToInt32(textBox2.Text);

                // Validar que sean primos      

                if (validarmayor100(p) && validarPrimos(p) && p != 1)
                {
                    if (validarmayor100(q) && validarPrimos(q) && q != 1 )
                    {
                        //Calcular valores n y of(ø)
                        calcularValoresNyOf(p, q);

                        do
                        {
                            //Determinar e
                            buscare(of);
                            
                            //Determinar d
                            calculard();
                        }
                        while (ee == 0 || d == 0);


                        if (ee <= of)
                        {
                            label5.Text = "(" + ee.ToString() + " ," + n.ToString() + ")";
                            label6.Text = "(" + d.ToString() + " ," + n.ToString() + ")";
                        }
                        else
                        {
                            label5.Text = "No es posible calcular la clave con los valores indicados";
                            label6.Text = "No es posible calcular la clave con los valores indicados";
                        }
                    }
                    else
                    {
                        MessageBox.Show("El segundo número no es primo", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("El primer número no es primo", "Error");
                }
            }

        }

        public bool validardatosentrada()
        {
            int resultado = 0;

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Completar los 2 campos", "ERROR");
                return false;
            }
            else
            {
                if (Int32.TryParse(textBox1.Text, out resultado) && Int32.TryParse(textBox2.Text, out resultado))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Los campos deben ser numéricos enteros", "ERROR");
                    return false;
                }
            }

        }

        public bool validarmayor100(int nnn)
        {
            if(nnn > 100)
            {
                MessageBox.Show("Los números deben ser menor o igual a 100", "ERROR");
                return false;
            }

            return true;

        }

        public void calcularValoresNyOf(int p, int q)
        {
            n = p * q;

            label9.Text = n.ToString();

            of = (p - 1) * (q - 1);

            label10.Text = of.ToString();

        }


        public bool validarPrimos(int a)
        {
            for (int i = 2; i < a; i++)
            {
                if ((a % i) == 0)
                {
                    // No es primo :(
                    return false;
                }
            }
            // Es primo :)
            return true;

        }

        public int calcularMCD(int a, int b)
        {
            int resultado = 0;
            do 
            {
                resultado = b;  // Guardamos el divisor en el resultado
                b = a % b;      //Guardamos el resto en el divisor
                a = resultado;  //El divisor para al dividendo
            }
            while
            (b != 0);

            return resultado;

        }
        public void buscare(int of) //Se calcula e
        {
            if (ee != 2)
            {
                ee = ee + 1;
            }

            for (int i = ee; i < of; i++)
            {
                if (calcularMCD(of, i) == 1)
                {
                    ee = i;
                    break;
                }
            }
        }

        public int calculard() //Se calcula d
        {
            for (int i = 1; i < of; i++)
            {
                if ((ee * i - 1) % of == 0 && i != ee)
                {
                    d = i;
                    break;
                }
            }
            return d;
        }

    }
}

