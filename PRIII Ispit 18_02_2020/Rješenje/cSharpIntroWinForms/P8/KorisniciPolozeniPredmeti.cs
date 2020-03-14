using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.P8
{
    public partial class KorisniciPolozeniPredmeti : Form
    {
        private Korisnik korisnik;
        KonekcijaNaBazu konekcija = Baza.konekcija;
        private int ocjena;
        public KorisniciPolozeniPredmeti()
        {
            InitializeComponent();
            dgvPolozeniPredmeti.AutoGenerateColumns = false;
        }

        public KorisniciPolozeniPredmeti(Korisnik korisnik):this()
        {
            this.korisnik = korisnik;
            LoadPredmete();
            LoadAktivneGodine();
            LoadData();
        }

        private void LoadData()
        {
            dgvPolozeniPredmeti.DataSource = null;
            dgvPolozeniPredmeti.DataSource = korisnik.Uspjeh;
        }

        private async void Dodaj1000Predmeta()
        {
            Random rand = new Random();
            await Task.Run(() => {
                for (int i = 0; i < 1000; i++)
                {
                    KorisniciPredmeti kp = new KorisniciPredmeti();
                    kp.Ocjena = rand.Next(6, 11);
                    kp.Datum = DateTime.Now.ToString();
                    kp.GodineStudija = cmbGodineStudija.SelectedItem as GodineStudija;
                    kp.Predmet = cmbPredmeti.SelectedItem as Predmeti;
                    korisnik.Uspjeh.Add(kp);
                }
            });
        
            MessageBox.Show("Uspjesno dodano 1000 predmeta!");
            konekcija.SaveChanges();
        }

        private List<GodineStudija> GetAktivneGodine()
        {
            List<GodineStudija> lista = new List<GodineStudija>();

            foreach (var godina in konekcija.GodineStudija)
            {
                if (godina.Aktivna != 0)
                    lista.Add(godina);
            }
            return lista;
        }

        private void LoadAktivneGodine()
        {
            List<GodineStudija> lista = GetAktivneGodine();
            if(lista.Count > 0)
            {
                cmbGodineStudija.DataSource = null;
                cmbGodineStudija.DataSource = lista;
                cmbGodineStudija.ValueMember = "Id";
                cmbGodineStudija.DisplayMember = "Naziv";
            }
            else
            {
                MessageBox.Show("Ne postoji aktivna godina!");
            }
        } 

        private void LoadPredmete()
        {
            cmbPredmeti.DataSource = null;
            cmbPredmeti.DataSource = konekcija.Predmeti.ToList();
            cmbPredmeti.ValueMember = "Id";
            cmbPredmeti.DisplayMember = "Naziv";
        }

        private void BtnDodajPolozeni_Click(object sender, EventArgs e)
        {
            if (Provjera())
            {
                if (!JelPolozioPredmet())
                {
                    DodajPolozeniPredmet();
                    LoadData();
                }
                else
                    MessageBox.Show("Student je vec polozio taj predmet!");
            }
            else
            {
                MessageBox.Show("Greska, unesite validne vrijednosti!");
            }
        }
        private bool Provjera()
        {
            if (string.IsNullOrEmpty(txtOcjena.Text) || !ProvjeriOcjenaTxt())
                return false;
            
            return true;
        }
        private bool JelPolozioPredmet()
        {
            GodineStudija godina = cmbGodineStudija.SelectedItem as GodineStudija;

            foreach (var user in korisnik.Uspjeh)
            {
                if (user.Predmet == cmbPredmeti.SelectedItem /*&& user.GodineStudija == godina*/)
                    return true;
            }
            return false;
        }
        private void DodajPolozeniPredmet()
        {
            KorisniciPredmeti uspjeh = new KorisniciPredmeti();
            uspjeh.Ocjena = ocjena;
            uspjeh.GodineStudija = cmbGodineStudija.SelectedItem as GodineStudija;
            uspjeh.Predmet = cmbPredmeti.SelectedItem as Predmeti;
            uspjeh.Datum = dtpDatumPolaganja.Value.ToString();

            korisnik.Uspjeh.Add(uspjeh);
            konekcija.SaveChanges();
        }
        private bool ProvjeriOcjenaTxt()
        {
            bool uspjesanParse = int.TryParse(txtOcjena.Text, out ocjena);
            if (uspjesanParse && (ocjena > 5 && ocjena < 11))
                return true;

            return false;
        }
        private void BtnPrintajUvjerenje_Click(object sender, EventArgs e)
        {
            try
            {
                Izvjestaj izvjestaj = new Izvjestaj(korisnik, cmbGodineStudija.SelectedItem as GodineStudija);
                izvjestaj.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
