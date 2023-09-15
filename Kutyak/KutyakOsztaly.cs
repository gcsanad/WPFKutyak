using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    public class KutyakOsztaly
    {

        static Dictionary<int, string> kutyaNevekDict = new Dictionary<int, string>();
        static Dictionary<int, List<string>> kutyaFajtakDict = new Dictionary<int, List<string>>();
        List<KutyaBeolvasas> kutyaBeolvasas = new List<KutyaBeolvasas>();

        public KutyakOsztaly()
        {
            foreach (var sor in File.ReadAllLines("KutyaNevek.csv").Skip(1))
            {
                string[] felosztas = sor.Split(';');
                kutyaNevekDict.Add(int.Parse(felosztas[0]), felosztas[1]);
            }
            foreach (var sor in File.ReadAllLines("KutyaFajtak.csv").Skip(1))
            {
                string[] felosztas = sor.Split(';');
                List<string> fajtaNevek = new List<string>();
                fajtaNevek.Add(felosztas[1]);
                fajtaNevek.Add(felosztas[2]);
                kutyaFajtakDict.Add(int.Parse(felosztas[0]), fajtaNevek);
            }

            List<string> sorok = File.ReadAllLines("Kutyak.csv", encoding: Encoding.UTF8).Skip(1).ToList();
            foreach (var sor in sorok)
            {
                string[] felosztas = sor.Split(';');
                KutyaBeolvasas ujKutya = new KutyaBeolvasas(int.Parse(felosztas[0]), int.Parse(felosztas[1]), int.Parse(felosztas[2]), int.Parse(felosztas[3]), felosztas[4]);
                kutyaBeolvasas.Add(ujKutya);
            }

        }


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
        public List<KutyaBeolvasas> KutyaBeolvasas { get => kutyaBeolvasas;}

        static public string KutyaNeve(KutyaBeolvasas obj)
        {
            return kutyaNevekDict[obj.NevId];
        }
        static public string KutyaFajtaMagyarul(KutyaBeolvasas obj)
        {
            return kutyaFajtakDict[obj.FajtaId][0];
        }
        static public string KutyaFajtaAngolul(KutyaBeolvasas obj)
        {
            return kutyaFajtakDict[obj.FajtaId][1];
        }
        static public string KutyaNeveFromId(int id)
        {
            return kutyaNevekDict[id];
        }
        static public string KutyaFajtaMagyFromId(int id)
        {
            return kutyaFajtakDict[id][0];
        }
        static public string KutyaFajtaAngFromId(int id)
        {
            return kutyaFajtakDict[id][1];
        }
    }
}
