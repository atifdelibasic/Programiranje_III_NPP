using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.P8
{
    public partial class KorisniciPolozeniPredmeti : Form
    {
        private Korisnik korisnik;

        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;

        public KorisniciPolozeniPredmeti()
        {
            InitializeComponent();
            dgvPolozeniPredmeti.AutoGenerateColumns = false;
            cmbOcjene.SelectedIndex = 0;
        }

        public KorisniciPolozeniPredmeti(Korisnik korisnik) : this()
        {
            this.korisnik = korisnik;
            LoadData();
            LoadPredmete();
        }
        private void LoadData()
        {
            dgvPolozeniPredmeti.DataSource = null;
            dgvPolozeniPredmeti.DataSource = korisnik.Uspjeh;
        }
        private void LoadPredmete(List<Predmeti> predmeti = null)
        {
            cmbPredmeti.DataSource = null;
            cmbPredmeti.DataSource = predmeti ?? konekcijaNaBazu.Predmeti.ToList();
            cmbPredmeti.ValueMember = "Id";
            cmbPredmeti.DisplayMember = "Naziv";
        }
        private void cbUcitajNepolozene_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUcitajNepolozene.Checked)
                LoadPredmete(korisnik.LoadNepolozene());
            else
                LoadPredmete();
        }

        private void btnDodajPolozeni_Click(object sender, EventArgs e)
        {
            try
            {
                KorisniciPredmeti kp = new KorisniciPredmeti();
                kp.Ocjena = int.Parse(cmbOcjene.Text);
                kp.Datum = dtpDatumPolaganja.Value.ToString();
                kp.Predmet = cmbPredmeti.SelectedItem as Predmeti;

                korisnik.Uspjeh.Add(kp);
                konekcijaNaBazu.SaveChanges();
                LoadData();

                if (cbUcitajNepolozene.Checked)
                    LoadPredmete(korisnik.LoadNepolozene());
            }
            catch 
            {
                MessageBox.Show("Greska!");
            }
        }
        private void btnPrintajUvjerenje_Click(object sender, EventArgs e)
        {
            Izvjestaj izvj = new Izvjestaj(korisnik);
            izvj.ShowDialog();
        }
        private async void btnASYNC_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 500; i++)
                {
                    KorisniciPredmeti kp = new KorisniciPredmeti();
                    kp.Ocjena = 6;
                    kp.Datum = DateTime.Now.ToString();
                    kp.Predmet = cmbPredmeti.SelectedItem as Predmeti;
                    korisnik.Uspjeh.Add(kp);
                }
            });

            konekcijaNaBazu.SaveChanges();
            LoadData();
            MessageBox.Show("Uspjesno dodano 500 predmeta!");
        }
    }
}
