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
    public partial class Parte3 : Form
    {
        public Parte3()
        {
            InitializeComponent();
        }

        string menEntrada;
        int c1d, c2n, valorc, numEncriptado = 0;


        private void button1_Click(object sender, EventArgs e)
        {
            if (validardatosentrada())
            {
                menEntrada = textBox1.Text.ToLower();
                //menEnciptado = Convert.ToInt32(textBox1.Text);
                c1d = Convert.ToInt32(textBox2.Text);
                c2n = Convert.ToInt32(textBox3.Text);

                numEncriptado = pasartextoanum();

                valorc = calcularm();

                label4.Text = valorc.ToString();

                mostrarmensaje(valorc);
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

        public int pasartextoanum()
        {
            Char[] cifMensaje = menEntrada.ToCharArray();

            int numer = 0;

            for (int i = cifMensaje.Length; i > 0; i--)
            {
                switch (cifMensaje[i - 1].ToString())
                {
                    case "a": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 0; break;
                    case "b": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 1; break;
                    case "c": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 2; break;
                    case "d": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 3; break;
                    case "e": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 4; break;
                    case "f": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 5; break;
                    case "g": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 6; break;
                    case "h": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 7; break;
                    case "i": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 8; break;
                    case "j": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 9; break;
                    case "k": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 10; break;
                    case "l": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 11; break;
                    case "m": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 12; break;
                    case "n": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 13; break;
                    case "o": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 14; break;
                    case "p": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 15; break;
                    case "q": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 16; break;
                    case "r": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 17; break;
                    case "s": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 18; break;
                    case "t": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 19; break;
                    case "u": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 20; break;
                    case "v": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 21; break;
                    case "w": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 22; break;
                    case "x": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 23; break;
                    case "y": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 24; break;
                    case "z": numer += Convert.ToInt32(Math.Pow(26, cifMensaje.Length - i)) * 25; break;
                }
            }
            return numer;
        }

        public int calcularm()
        {
            //ulong num = Convert.ToUInt64(m);
            //ulong c1dd = Convert.ToUInt64(c1d);
            //ulong c2nn = Convert.ToUInt64(c2n);

            //ulong num1 = 0;

            //int bass = m;
            //int exp = 27;
            //int m = 55;
            int menDesencrip = 1;

            while (c1d > 0)
            {
                if ((c1d & 1) > 0)
                {
                    menDesencrip = (menDesencrip * numEncriptado) % c2n;
                }
                c1d >>= 1;
                numEncriptado = (numEncriptado * numEncriptado) % c2n;
            }

            return menDesencrip;

            //label4.Text = menDesencrip.ToString();

            //mostrarmensaje(menDesencrip);
        }

        public void mostrarmensaje(int mensaje)
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

            label9.Text = texto;
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
    }
}
