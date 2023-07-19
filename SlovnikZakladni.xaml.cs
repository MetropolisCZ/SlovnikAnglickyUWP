using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace SlovnikAnglickyUWP
{
    public sealed partial class SlovnikZakladni : Page
    {

        public static bool TypSlovnikuAJCZ = true;

        /*protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parametrySlovniku = (KterySlovnikPouzit)e.Parameter;
            if (parametrySlovniku != null)
            {
                TypSlovnikuAJCZ = parametrySlovniku.TypSlovnikuAJCZ;
            }
        }*/

        private readonly List<Slovo> SlovnikSerazeny;
        int PocetSlovVeSlovniku = -1;


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
        }
        */
        public SlovnikZakladni()
        {
            /*String txtSlovnikRadek;
            List<Slovo> slovnikAJ = new List<Slovo>();

            Stream soubor = File.OpenRead("slovnik_data_utf8.txt");
            StreamReader cteniSouboru = new StreamReader(soubor);
            while ((txtSlovnikRadek = cteniSouboru.ReadLine()) != null)
            {
                slovnikAJ.Add(new Slovo { AnglickeSlovo = txtSlovnikRadek, CeskyPreklad = "Pozdějc :)" });

            }
            pocetSlovVeSlovniku = slovnikAJ.Count;*/

            if (TypSlovnikuAJCZ)
            {
                SlovnikSerazeny = MainPage.SlovnikAJCZ;
            }
            else
            {
                SlovnikSerazeny = MainPage.SlovnikCZAJ;
            }
            //SlovnikSerazeny = Slovnik.ZiskatSlovnik();
            //SlovnikCZAJ = Slovnik.ZiskatSlovnik(false);
            //PocetSlovVeSlovniku = SlovnikSerazeny.Count;
            this.InitializeComponent();
            
        }

        private async void SlovnikListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var vybraneSlovo = e.ClickedItem as Slovo;
            ContentDialog dialogVybraneSlovo = new ContentDialog()
            {
                Title = vybraneSlovo.AnglickeSlovo,
                Content = "Český překlad je „" + vybraneSlovo.CeskyPreklad + "“\n" + 
                "Poznámka: „" + vybraneSlovo.PoznamkyPreklad + "|" + vybraneSlovo.PoznamkyPrekladSpecialni + "“, přeložil " + vybraneSlovo.PrekladatelSlova + ", číslo překladu " + vybraneSlovo.RadekSlovaVsouboru,
                CloseButtonText = "Zavřít"
            };

            await dialogVybraneSlovo.ShowAsync();
        }

        private void SlovnikVyhledavaciPole_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var nalezeneSlovo = SlovnikAJ.Find(x => x.CeskyPreklad == SlovnikVyhledavaciPole.Text);
            //var nalezeneSlovo = SlovnikAJ.Any(x => x.CeskyPreklad.Contains(SlovnikVyhledavaciPole.Text));
            //var nalezeneSlovo = SlovnikAJ.Where(x => x.CeskyPreklad.Contains(SlovnikVyhledavaciPole.Text));
            //var nalezeneSlovo = SlovnikAJ.Find(x => x.CeskyPreklad.Contains(SlovnikVyhledavaciPole.Text));
            var nalezeneSlovo = SlovnikSerazeny.Find(x => x.CeskyPreklad.StartsWith(SlovnikVyhledavaciPole.Text));

            if (nalezeneSlovo != null)
            {
                /*ContentDialog dialogSlovoNalezeno = new ContentDialog()
                {
                    Title = "Slovo nalezeno",
                    Content = "Bylo nalezeno slovo " + nalezeneSlovo.CeskyPreklad + " – " + nalezeneSlovo.AnglickeSlovo,
                    CloseButtonText = "Nasrat."
                };
                await dialogSlovoNalezeno.ShowAsync();*/
                SlovnikListView.SelectedItem = nalezeneSlovo;
                SlovnikListView.ScrollIntoView(SlovnikListView.SelectedItem);
                SlovnikVyhledavaciPole.ClearValue(BorderBrushProperty);
            }
            else if (SlovnikVyhledavaciPole.Text != "")
            {
                // Slovo se neshoduje se slovem v databázi
                SlovnikVyhledavaciPole.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                SlovnikVyhledavaciPole.ClearValue(BorderBrushProperty);
            }
        }
    }
}
