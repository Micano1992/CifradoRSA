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
    public partial class Parte2 : Form
    {
        int valorm, valorc = 0;
        int c1e;
        int c2n;

        public Parte2()
        {
            InitializeComponent();
        }

        private void Parte2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            valorm = 0;

            if (validardatosentrada() && validarn() && validara())
            {
                c1e = Convert.ToInt32(textBox2.Text);
                c2n = Convert.ToInt32(textBox3.Text);

                string menDesencrip = textBox1.Text.ToLower();

                calcularm(menDesencrip);

                //cifrarMensaje(c1, c2, mensaje);

                valorc = calcularc(valorm);

                label4.Text = valorc.ToString();

                pasarATexto(valorc);
            }
        }

        public bool validardatosentrada()
        {
            int resultado = 0;


            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Completar los 3 campos", "ERROR");

                return false;
            }
            else
            {
                if (Int32.TryParse(textBox2.Text, out resultado) && Int32.TryParse(textBox3.Text, out resultado))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Los campos clave deben ser numéricos", "ERROR");
                    return false;
                }
            }

        }

        public bool validara()
        {
            if (textBox1.Text.Contains("a"))
            {
                MessageBox.Show("El texto no puede contener la letra a", "ERROR");

                return false;
            }

            return true;
        }
        public bool validarn()
        {
            //26 ^ 1 = 26
            //26 ^ 2 = 676
            //26 ^ 3 = 17576
            //26 ^ 4 = 456976

            if (Math.Pow(26, textBox1.Text.Length) > Convert.ToInt32(textBox3.Text))
            {
                MessageBox.Show("No puede encriptarse el mensaje con un número tan bajo de n. \n " +
                    "Si desea encriptar 3 caracteres, n debe ser mayor a 17576 \n" +
                    "Si desea encriptar 2 caracteres, n debe ser mayor a 676 \n" +
                    "Si desea encriptar 1 caracter, n debe ser mayor a 26 \n", "ERROR");

                return false;
            }

            return true;
        }
        public void calcularm(string mensaje)
        {
            Char[] cifMensaje = mensaje.ToCharArray();

            for (int i = cifMensaje.Length; i > 0; i--)
            {
                switch (cifMensaje[i - 1].ToString())
                {
                    case "a": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 0; break;
                    case "b": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 1; break;
                    case "c": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 2; break;
                    case "d": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 3; break;
                    case "e": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 4; break;
                    case "f": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 5; break;
                    case "g": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 6; break;
                    case "h": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 7; break;
                    case "i": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 8; break;
                    case "j": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 9; break;
                    case "k": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 10; break;
                    case "l": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 11; break;
                    case "m": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 12; break;
                    case "n": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 13; break;
                    case "o": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 14; break;
                    case "p": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 15; break;
                    case "q": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 16; break;
                    case "r": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 17; break;
                    case "s": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 18; break;
                    case "t": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 19; break;
                    case "u": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 20; break;
                    case "v": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 21; break;
                    case "w": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 22; break;
                    case "x": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 23; break;
                    case "y": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 24; break;
                    case "z": valorm += Convert.ToInt32(Math.Pow(26, mensaje.Length - i)) * 25; break;

                }
            }

            label4.Text = valorm.ToString();

        }
        public int calcularc(int mensaje)
        {
            int menDesencrip = 1;

            while (c1e > 0)
            {
                if ((c1e & 1) > 0)
                {
                    menDesencrip = (menDesencrip * valorm) % c2n;
                }
                c1e >>= 1;
                valorm = (valorm * valorm) % c2n;

            }

            return menDesencrip;

            //label4.Text = menDesencrip.ToString();

            //pasarATexto(menDesencrip);

        }

        public void pasarATexto(int mensaje)
        {
            //    26^4  = 456976
            //    26^3  = 17576
            //    26^2  = 676
            //    26^1  = 26

            int valorfinal = 0;
            string texto = "";

            if (mensaje <= 456976 && mensaje > 17576)
            {
                valorfinal = mensaje / 17576;

                texto += obtenerletra(valorfinal);

                mensaje -= valorfinal * 17576;
            }

            if (mensaje <= 17576 && mensaje > 676)
            {
                valorfinal = mensaje / 676;

                texto += obtenerletra(valorfinal);

                mensaje -= valorfinal * 676;
            }

            if (mensaje <= 676 && mensaje > 26)
            {
                valorfinal = mensaje / 26;

                texto += obtenerletra(valorfinal);

                mensaje -= valorfinal * 26;
            }

            if (mensaje <= 26)
            {
                valorfinal = mensaje;

                texto += obtenerletra(valorfinal);

            }

            label6.Text = texto;
            MessageBox.Show(texto, "Texto desencriptado");
        }

        public string obtenerletra(int num)
        {
            switch (num)
            {
                case 0: return "A";
                case 1: return "B";
                case 2: return "C";
                case 3: return "D";
                case 4: return "E";
                case 5: return "F";
                case 6: return "G";
                case 7: return "H";
                case 8: return "I";
                case 9: return "J";
                case 10: return "J";
                case 11: return "L";
                case 12: return "M";
                case 13: return "N";
                case 14: return "O";
                case 15: return "P";
                case 16: return "Q";
                case 17: return "R";
                case 18: return "S";
                case 19: return "T";
                case 20: return "U";
                case 21: return "V";
                case 22: return "W";
                case 23: return "X";
                case 24: return "Y";
                case 25: return "Z";
                default: return "error";

            }

        }


        private void button2_Click_1(object sender, EventArgs e)
        {

            int bb = 27 / 4;

            MessageBox.Show(bb.ToString());

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
