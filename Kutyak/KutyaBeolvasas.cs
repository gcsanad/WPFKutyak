using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    public class KutyaBeolvasas
    {
        int id;
        int fajtaId;
        int nevId;
        int eletkor;
        string utolsoOrvosiVizsgalat;

        public KutyaBeolvasas(int id, int fajtaId, int nevId, int eletkor, string utolsoOrvosiVizsgalat)
        {
            this.id = id;
            this.fajtaId = fajtaId;
            this.nevId = nevId;
            this.eletkor = eletkor;
            this.utolsoOrvosiVizsgalat = utolsoOrvosiVizsgalat;
        }

        public int Id { get => id;}
        public int FajtaId { get => fajtaId;}
        public int NevId { get => nevId; }
        public int Eletkor { get => eletkor; }
        public string UtolsoOrvosiVizsgalat { get => utolsoOrvosiVizsgalat;}
    }
}
