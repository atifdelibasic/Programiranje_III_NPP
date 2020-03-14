using cSharpIntroWinForms.P8;
using cSharpIntroWinForms.P9;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms
{
    public partial class Glavna : Form
    {
        KonekcijaNaBazu konekcija = Baza.konekcija;
        public Glavna()
        {
            InitializeComponent();
        }

        private void BtnGodineStudija_Click(object sender, EventArgs e)
        {
                GodineStudijaForm godineStudija = new GodineStudijaForm();
                godineStudija.ShowDialog();
        }

        private void BtnPolozeniPredmeti_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = null;
            try
            {
                //odabir random korisnika iz baze
                korisnik = konekcija.Korisnici.ToList()[1];
                KorisniciPolozeniPredmeti korisniciPP = new KorisniciPolozeniPredmeti(korisnik);
                korisniciPP.ShowDialog();
            }
            catch { }
        }

        private async void BtnIzracunajSumu_Click(object sender, EventArgs e)
        {
            int broj;
            int sum = 0;
            bool provjera = int.TryParse(txtSuma.Text, out broj);

            if (provjera)
            {
                await Task.Run(() =>
                {
                    for (int i = 1; i <= broj; i++)
                    {
                        sum += i;
                    }
                });

                MessageBox.Show(sum.ToString());
            }
        }
    }
}
