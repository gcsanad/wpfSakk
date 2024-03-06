using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Jatszma
    {
        List<String> lepesek = new();



        /// <summary>
        /// Üres játék létrehozása
        /// </summary>
        public Jatszma()
        {
            lepesek = new List<String>();
        }
        public Jatszma(String fajlSor)
        {
            lepesek = new List<String>();

            foreach (var item in fajlSor.Trim().Split('\t'))
            {
                lepesek.Add(item);
            }
        }
        public int LepesekSzama => lepesek.Count();

        public char Nyertes => LepesekSzama % 2 == 0 ? 's' : 'v';

        public int HuszarokLepesszama => TisztLepesszama('H');


        public int TisztLepesszama(char tisztJele)
        {
            return lepesek.Count(lepes => lepes[0] == tisztJele);
        }
        public List<string> Lepesek { get => lepesek; }

        public bool VezertUtottek => UtottekVezert();

        public bool UtottekVezert() 
        {
            string feherVezer = "";
            string feketeVezer = "";
            bool utott = false;
            for (int i = 0; i < lepesek.Count(); i++)
            {
                if (lepesek[i][0]=='V')
                {
                    if (i%2==0)
                    {
                        feketeVezer = Convert.ToString(lepesek[i][lepesek[i].Length-2]+ lepesek[i][lepesek[i].Length-1]);
                    }
                    else
                    {
                        feherVezer = Convert.ToString(lepesek[i][lepesek[i].Length - 2] + lepesek[i][lepesek[i].Length-1]);
                    }
                }
                if (lepesek[i].Contains('x')) 
                {
                    if (lepesek[i].Split('x')[1].Contains(feherVezer) || lepesek[i].Split('x')[1].Contains(feketeVezer))
                    {
                        utott = true;
                    }
                }
            }
            return utott;
           
        }
        

        
    }
}
