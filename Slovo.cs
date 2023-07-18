using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlovnikAnglickyUWP
{
    public class Slovo
    {

        public string AnglickeSlovo { get; set; }
        public string CeskyPreklad { get; set; }
        public string PoznamkyPreklad { get; set; }
        public string PoznamkyPrekladSpecialni { get; set; }
        public string PrekladatelSlova { get; set; }
        public int RadekSlovaVsouboru { get; set; }

    }

    public class Slovnik
    {
        public static List<Slovo> ZiskatSlovnik(bool ZakladniAJ = true) {

            var slovnikAJ = new List<Slovo>();
            var slovnikCZAJ = new List<Slovo>();

            String txtSlovnikRadek;
            Stream soubor = File.OpenRead("slovnik_data_utf8.txt");
            StreamReader cteniSouboru = new StreamReader(soubor);
            int praveProhledavanyRadek = 0;
            while ((txtSlovnikRadek = cteniSouboru.ReadLine()) != null)
            {
                praveProhledavanyRadek++;
                string[] txtSlovnikRadekRozrezany = txtSlovnikRadek.Split('\t');
                if (txtSlovnikRadekRozrezany[1] == "")
                {
                    continue;
                }
                slovnikAJ.Add(new Slovo { AnglickeSlovo = txtSlovnikRadekRozrezany[0], CeskyPreklad = txtSlovnikRadekRozrezany[1], PoznamkyPreklad = txtSlovnikRadekRozrezany[2], PoznamkyPrekladSpecialni = txtSlovnikRadekRozrezany[3], PrekladatelSlova = txtSlovnikRadekRozrezany[4], RadekSlovaVsouboru = praveProhledavanyRadek });

            }

            if (ZakladniAJ)
            {
                return slovnikAJ;
            }
            else
            {
                slovnikCZAJ = slovnikAJ.OrderBy(x => x.CeskyPreklad).ToList();
                return slovnikCZAJ;
            }

        }
    }
}

public class KterySlovnikPouzit
{
    public KterySlovnikPouzit() { }
    public bool TypSlovnikuAJCZ { get; set; }
}


/*private string _anglickeSlovo;

public string AnglickeSlovo
{
    get { return _anglickeSlovo; }
    set { _anglickeSlovo = value; }
}

public Slovnik()
{
}*/

/*public class Slovo : IEquatable<Slovo>
{
    public string AnglickeSlovo { get; set; }

    public string CeskyPreklad { get; set; }

    public override string ToString()
    {
        return "České slovo: " + CeskyPreklad + "   Anglické slovo: " + AnglickeSlovo;
    }
    public bool Equals(Slovo other)
    {
        if (other == null) return false;
        return (this.CeskyPreklad.Equals(other.CeskyPreklad));
    }
    // Should also override == and != operators.
}*/