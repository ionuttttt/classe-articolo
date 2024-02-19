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

            public bool AlimentareONo()
            {
                DialogResult dialogResult = MessageBox.Show("Il suo articolo è alimentare?", "Alimentare / Non Alimentare", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    al = true;
                }
                return al;
            }

        }

        class ArticoloAlimentare : Articolo
        {
            protected string scadenza;
            protected bool fr;

            public string Scadenza
            {
                get => scadenza;
                set
                {
                    scadenza= value;
                }

            }

            public bool fresco()
            {
                DialogResult dialogResult = MessageBox.Show("Il suo articolo è fresco?", "Fresco", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    fr = true;
                }
                return fr;
            }
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
            protected string giorni;

            public string Giorni
            {
                get => giorni;
                set
                {
                   giorni = value;
                }

            }
        }

        Articolo articolo = new Articolo();
        ArticoloNonAlimentare non= new ArticoloNonAlimentare();
        ArticoloAlimentare alimentare= new ArticoloAlimentare();
        AlimentareFresco fresco = new AlimentareFresco();
        double prez;
        private void button1_Click(object sender, EventArgs e)
        {
            articolo.Nome = textBox1.Text;
            articolo.Prezzo = Convert.ToDouble(textBox2.Text);
            prez = articolo.sconto();
            if(articolo.AlimentareONo()==false)
            {
                DialogResult dialogResult = MessageBox.Show("Il suo articolo è riciclabile?", "Riciclabile", MessageBoxButtons.YesNo);
                MessageBox.Show("Inserisci il materiale dell'articolo");
                non.Materiale= textBox3.Text;
            }
            else
            {
                MessageBox.Show("Inserisci la data di scadenza dell'articolo");
                alimentare.Scadenza = textBox4.Text;
                if(alimentare.fresco()==true)
                {
                    MessageBox.Show("Inserisci l'indicazione del numero di giorni entro cui consumare l'articolo");
                    fresco.Giorni= textBox5.Text;
                }
            }
        }

    }
}
