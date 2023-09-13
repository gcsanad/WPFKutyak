using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    internal class KutyakOsztaly
    {
        int id;
        int fajtaId;
        int nevId;
        int eletkor;
        DateTime utolsoOrvosiVizsgalat;
        string nev;
        string eredetiNev;
        string kutyaNev;


        public KutyakOsztaly(string sor) {
            string[] felosztandoSor = sor.Split(";");
            this.id = int.Parse(felosztandoSor[0]);
            this.fajtaId = int.Parse(felosztandoSor[1]);
            this.nevId = int.Parse(felosztandoSor[2]);
            this.eletkor = int.Parse(felosztandoSor[3]);
            this.utolsoOrvosiVizsgalat = DateTime.Parse(felosztandoSor[4]);
        }


        public KutyakOsztaly(string sor, bool valaszto) {
            string[] felosztandoSor = sor.Split(";");
            if (valaszto == true)
            {
                this.id = int.Parse(felosztandoSor[0]);
                this.nev = felosztandoSor[1];
                this.eredetiNev = felosztandoSor[2];
            }
            else if (valaszto == false)
            {
                this.id = int.Parse(felosztandoSor[0]);
                this.kutyaNev = felosztandoSor[1];
            }
        }









        public int Id { get => id; }
        public int FajtaId { get => fajtaId;}
        public int NevId { get => nevId; }
        public int Eletkor { get => eletkor; }
        public DateTime UtolsoOrvosiVizsgalat { get => utolsoOrvosiVizsgalat; }
        public string Nev { get => nev; }
        public string EredetiNev { get => eredetiNev; }
        public string KutyaNev { get => kutyaNev; }
    }
}
