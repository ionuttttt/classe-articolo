using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace classe_articolo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Articolo
        {
            protected string nome;
            protected double prezzo;
            protected bool al=false;

            public string Nome
            {
                get => nome;
                set
                {
                    nome = value;
                }

            }

            public double Prezzo
            {
                get => prezzo;
                set
                {
                    prezzo = value;
                }

            }

            public double sconto()
            {
                DialogResult dialogResult = MessageBox.Show("Ha la carta fedeltà?", "Carta Fedeltà", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    prezzo=(prezzo*5)/100;
                }
                return prezzo;

            }

            public void AlimentareONo()
            {
                DialogResult dialogResult = MessageBox.Show("Il suo articolo è alimentare?", "Alimentare / Non Alimentare", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    al = true;
                }
            }

        }

        class ArticoloAlimentare : Articolo
        {

        }

        class ArticoloNonAlimentare : Articolo
        {
            protected string materiale;
            protected bool riciclabiler;

            public string Materiale
            {
                get => materiale;
                set
                {
                    materiale = value;
                }

            }

            

        }

        class AlimentareFresco : ArticoloAlimentare 
        { 

        }

        Articolo articolo = new Articolo();
        double prez;
        private void button1_Click(object sender, EventArgs e)
        {
            articolo.Nome = textBox1.Text;
            articolo.Prezzo = Convert.ToDouble(textBox2.Text);
            prez = articolo.sconto();
            textBox1.Text = "";
            textBox2.Text = "";
            articolo.AlimentareONo();
        }

    }
}
