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

            ///Paso 1 - Ingresar valores
            #region Paso1

            p = Convert.ToInt32(textBox1.Text);
            q = Convert.ToInt32(textBox2.Text);
            #endregion

            // Paso 2 - Validar que sean primos      
            #region Paso2
            if (validarPrimos(p) && p != 1)
            {
                if (validarPrimos(q) && q != 1)
                {
                    //Paso 3 - Calcular valores n y of
                    calcularValoresNyOf(p, q);

                    do
                    {
                        //Paso 4 - Determinar e
                        buscare(of);
                        //MessageBox.Show(ee.ToString(), "valor e");


                        //Paso 5 - Determinar d

                        calculard();
                        //MessageBox.Show(d.ToString(), "valor d");

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
            #endregion



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
            do //ciclo para las iteraciones
            {
                resultado = b;  // Guardamos el divisor en el resultado
                b = a % b;      //Guardamos el resto en el divisor
                a = resultado;  //El divisor para al dividendo
            }
            while
            (b != 0);

            return resultado;

        }
        public void buscare(int of) //Paso 4
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

        public int calculard()
        {
            for (int i = 1; i < of; i++)
            {
                if ((ee * i - 1) % of == 0 && i != ee)
                {
                    //if (i != ee)
                    //{
                    d = i;
                    break;
                    //}
                }
            }
            return d;
        }

    }
}

