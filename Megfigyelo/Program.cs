using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megfigyelo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var r = new Reszveny();
            var g = new Befekteto("Geza", r, 500);
            var j = new Befekteto("Judit", r, 1000);
            r.Arfolyam = 10;
            System.Threading.Thread.Sleep(1000);
            r.Arfolyam = 12;
            System.Threading.Thread.Sleep(1000);
            r.Arfolyam = 15;
            Console.ReadLine();
        }
    }

    public delegate void ArfolyamFigyelo(double Arfolyam);

    public class Reszveny
    {
        private double _Arfolyam;
        public event ArfolyamFigyelo Arfolyamvaltozas;

        public double Arfolyam
        {
            get { return _Arfolyam; }
            set
            {
                _Arfolyam = value;
                Arfolyamvaltozas(_Arfolyam);
            }
        }
    }

    public class Befekteto
    {
        public string Nev { get; set; }
        private readonly int Darab;


        public Befekteto (string nev, Reszveny reszveny, int darab)
        {
            Nev = nev;
            Darab = darab;
            
            reszveny.Arfolyamvaltozas += Megfigyel;
        }

      

        public void Megfigyel (double Arfolyam)
        {
            Console.WriteLine(Nev + ":\t" + Darab * Arfolyam + "Ft");
        }
    }
}
