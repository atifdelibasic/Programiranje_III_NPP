using cSharpIntroWinForms.P9;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace cSharpIntroWinForms
{
    public partial class GodineStudijaForm : Form
    {
        KonekcijaNaBazu konekcija = Baza.konekcija;
        private GodineStudija godinaStudija;
        private int Id = 0;
        private bool Edit;
        public GodineStudijaForm()
        {
            InitializeComponent();
            dgvGodinaStudja.AutoGenerateColumns = false;
            LoadData();
        }
        private void LoadData()
        {
            dgvGodinaStudja.DataSource = null;
            dgvGodinaStudja.DataSource = konekcija.GodineStudija.ToList();
        }
        private void BtnSacuvaj_Click(object sender, EventArgs e)
        {
            string godinaStr = txtNaziv.Text;

            if (!string.IsNullOrEmpty(godinaStr) && !DaLiPostojiGodina(godinaStr))
            {
                if (!Edit)
                {
                    godinaStudija = new GodineStudija();
                    godinaStudija.Naziv = godinaStr;
                    godinaStudija.Aktivna = cbAktivna.Checked ? 1 : 0;
                    konekcija.GodineStudija.Add(godinaStudija);
                    MessageBox.Show("Uspjesno dodavanje!");
                }
                else
                {
                    godinaStudija.Naziv = godinaStr;
                    godinaStudija.Aktivna = cbAktivna.Checked ? 1 : 0;
                    konekcija.Entry(godinaStudija).State = EntityState.Modified;
                    Edit = false;
                    Id = 0;
                    MessageBox.Show("Uspjesan edit");
                }

                konekcija.SaveChanges();
                LoadData();
                Reset();
            }
            else
            {
                MessageBox.Show("Greska!");
            }
        }
        private void Reset()
        {
            txtNaziv.Text = "";
            cbAktivna.Checked = false;
        }
        bool DaLiPostojiGodina(string godina)
        {
            GodineStudija gs = konekcija.GodineStudija.ToList().Find(god => god.Naziv == godina && god.Id != Id);
            if (gs != null)
                return true;
            return false;
        }
        private void DgvGodinaStudja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvGodinaStudja.Columns[e.ColumnIndex].Name == "Ukloni")
                {
                    GodineStudija god = dgvGodinaStudja.SelectedRows[0].DataBoundItem as GodineStudija;
                    konekcija.GodineStudija.Remove(god);
                    konekcija.SaveChanges();
                    LoadData();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvGodinaStudja_DoubleClick(object sender, EventArgs e)
        {
            if (dgvGodinaStudja.Rows.Count > 0)
            {
                Edit = true;
                godinaStudija = dgvGodinaStudja.SelectedRows[0].DataBoundItem as GodineStudija;
                Id = godinaStudija.Id;
                //ucitaj godinu
                txtNaziv.Text = godinaStudija.Naziv;
                cbAktivna.Checked = godinaStudija.Aktivna != 0;
            }
        }
    }
}
