using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sortiranjeVozila
{
    public partial class Form1 : Form
    {
        List<Vozilo> voziloList = new List<Vozilo>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDodajVozilo_Click(object sender, EventArgs e)
        {
           try
            {
                if (string.IsNullOrWhiteSpace(textBoxMarka.Text) ||
                    string.IsNullOrWhiteSpace(textBoxModel.Text) ||
                    string.IsNullOrWhiteSpace(textBoxGodProizvodnje.Text) ||
                    string.IsNullOrWhiteSpace(textBoxKilometraza.Text) ||

                   //tries to parse the text from the
                   //textBoxGodProizvodnje and textBoxKilometraza field into a short (32-bit integer)
                    !int.TryParse(textBoxGodProizvodnje.Text, out int godina) ||
                    !int.TryParse(textBoxKilometraza.Text, out int kilometraza))
                {
                    MessageBox.Show("Pogrešan unos. Molimo pokušajte ponovo",
                        "Pogrešan unos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxModel.Clear();
                    textBoxMarka.Clear();
                    textBoxGodProizvodnje.Clear();
                    textBoxKilometraza.Clear();
                    textBoxModel.Focus();
                }
                else
                {
                    Vozilo vozilo = new Vozilo(textBoxMarka.Text, textBoxModel.Text, godina, kilometraza);
                    voziloList.Add(vozilo);

                    textBoxModel.Clear();
                    textBoxMarka.Clear();
                    textBoxGodProizvodnje.Clear();
                    textBoxKilometraza.Clear();
                    textBoxModel.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Pogrešan unos. Molimo pokušajte ponovo",
                    "Pogrešan unos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxMarka.Clear();
                textBoxModel.Clear();
                textBoxGodProizvodnje.Clear();
                textBoxKilometraza.Clear();
            }


        }

        private void buttonSortiraj_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                bool uzlazno = comboBoxSortiranjeSmjera.SelectedItem.ToString() == "Uzlazno";

                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Marka":
                        voziloList = voziloList.OrderBy(v => v.Marka).ToList();
                        break;
                    case "Model":
                        voziloList = voziloList.OrderBy(v => v.Model).ToList();
                        break;
                    case "Godina Proizvodnje":
                        voziloList = voziloList.OrderBy(v => v.GodinaProizvodnje).ToList();
                        break;
                    case "Kilometraza":
                        voziloList = voziloList.OrderBy(v => v.Kilometraza).ToList();
                        break;
                    default:
                        break;
                }
            }
            textBoxIspis.Clear();
            foreach (Vozilo v in voziloList)
            {
                textBoxIspis.AppendText(v.ToString() + Environment.NewLine);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // comboBox1.Items.Add("Marka");
           // comboBox1.Items.Add("Model");
            // comboBox1.Items.Add("Godina Proizvodnje");
            // comboBox1.Items.Add("Kilometraza");
        }

        private void comboBoxSortiranjeSmjera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxSortiranjeSmjera = new ComboBox();
            comboBoxSortiranjeSmjera.Items.Add("Uzlazno");
            comboBoxSortiranjeSmjera.Items.Add("Silazno");
            comboBoxSortiranjeSmjera.SelectedIndex = 0;
            this.Controls.Add(comboBoxSortiranjeSmjera);
        }

    }

}
