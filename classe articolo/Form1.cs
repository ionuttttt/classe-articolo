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

        private void Form1_Load(object sender, EventArgs e)
        {

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

            public Articolo()
            {

            }

            public Articolo(string a, double b)
            {
                nome = a;
                prezzo = b;
            }

            public double sconto()
            {
                DialogResult dialogResult = MessageBox.Show("Ha la carta fedeltà?", "Carta Fedeltà", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    prezzo=prezzo-(prezzo*5)/100;
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
             
            public ArticoloAlimentare()
            {

            }
            public ArticoloAlimentare(string a, double b,string c,bool d):base(a,b)
            {
                nome=a; prezzo=b; scadenza=c; fr=d;
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

            public double scontoAL(double prezzo)
            {
                DateTime thisYear = DateTime.Today;
                int anno= thisYear.Year;
                if(anno==int.Parse(scadenza))
                {
                    prezzo = prezzo-(prezzo *20) /100;
                }
                return prezzo;
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

            public ArticoloNonAlimentare()
            { 
            }

            public ArticoloNonAlimentare(string a, double b,string c,bool d):base(a,b)
            {
                nome = a; prezzo = b; materiale = c; riciclabiler = d;
            }

            public double scontoNON(double prezzo)
            {
                prezzo=prezzo-(prezzo *10) /100;
                return prezzo;
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

            public AlimentareFresco()
            {

            }
            public AlimentareFresco(string a, double b,string c,bool d, string e) : base(a,b,c,d)
            {
                nome = a; prezzo = b; scadenza = c;fr = d;giorni = e;
            }

            public double scontoFR(double prezzo)
            {
                switch(int.Parse(giorni))
                {
                    case 1: prezzo = prezzo - (prezzo * 10) / 100; break;
                    case 2: prezzo = prezzo-(prezzo*8) / 100; break;
                    case 3: prezzo = prezzo - (prezzo * 6) / 100; break;
                    case 4: prezzo = prezzo-(prezzo * 4) / 100; break;
                    case 5: prezzo = prezzo - (prezzo * 2) / 100; break;
                }
                return prezzo;
            }
        }

        double prez = 0;
        bool fr, al;
        Articolo articolo = new Articolo();
        ArticoloNonAlimentare non = new ArticoloNonAlimentare();
        ArticoloAlimentare alimentare = new ArticoloAlimentare();
        AlimentareFresco fresco = new AlimentareFresco();
        List<Articolo> ticolo = new List<Articolo>();

        public string scontrino()
        {
            string scontrino;
            scontrino= articolo.Nome+"     "+Convert.ToString(prez);
            return scontrino;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(articolo.AlimentareONo()==false)
            {
                al = false;
                DialogResult dialogResult = MessageBox.Show("Il suo articolo è riciclabile?", "Riciclabile", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    prez = non.scontoNON(prez);
                }
                MessageBox.Show("Inserisci il prezzo, il nome e il materiale dell'articolo");
            }
            else
            {
                al=true;
                if(fresco.fresco()==true)
                {
                    fr= true;
                    MessageBox.Show("Inserisci il prezzo, il nome, l'anno di scadenza dell'articiolo e i giorni entro cui consumarlo dall'aperura");
                }
                else
                {
                    fr= false;
                    MessageBox.Show("Inserisci il prezzo, il nome e l'anno di scadenza dell'articiolo");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            articolo.Nome = textBox1.Text;
            articolo.Prezzo = Convert.ToDouble(textBox2.Text);
            prez = articolo.sconto();
            if (al == false)
            {
                non.Materiale = textBox3.Text;
                textBox3.Text = "";
            }
            else
            {
                prez = alimentare.scontoAL(prez);
                if (fr == true)
                {
                    prez = fresco.scontoFR(prez);
                    alimentare.Scadenza = textBox4.Text;
                    fresco.Giorni = textBox5.Text;
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    alimentare.Scadenza = textBox4.Text;
                    textBox4.Text = "";
                }
            }
            textBox1.Text = ""; 
            textBox2.Text = "";

            listBox1.Items.Add(scontrino());
        }

    }
}
