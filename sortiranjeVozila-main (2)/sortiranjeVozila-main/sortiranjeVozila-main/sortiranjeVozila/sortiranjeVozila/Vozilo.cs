using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortiranjeVozila
{
    internal class Vozilo
    {
        string marka, model;
        int godinaProizvodnje, kilometraza;

        public Vozilo(string marka, string model, int godinaProizvodnje, int kilometraza)
        {
            this.Marka = marka;
            this.Model = model;
            this.GodinaProizvodnje = godinaProizvodnje;
            this.Kilometraza = kilometraza;
        }

        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public int GodinaProizvodnje { get => godinaProizvodnje; set => godinaProizvodnje = value; }
        public int Kilometraza { get => kilometraza; set => kilometraza = value; }

        public override string ToString()
        {
            string ispis = "Marka: " + this.marka
                + "\tModel: " + this.model
                + "\tGodina Proizvodnje: " + this.godinaProizvodnje
                + "\tKilometraza: " + this.kilometraza
                + "\r\n";
            return ispis;
        }

    }
}
