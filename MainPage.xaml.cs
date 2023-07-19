using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace SlovnikAnglickyUWP
{
	public sealed partial class MainPage : Page
	{
		public static readonly List<Slovo> SlovnikAJCZ = Slovnik.ZiskatSlovnik();
        public static readonly List<Slovo> SlovnikCZAJ = Slovnik.ZiskatSlovnik(false);

        public MainPage()
		{
            this.InitializeComponent();

            SlovnikZakladni.TypSlovnikuAJCZ = true;
            NadpisStrankyTextBlock.Text = "Slovník Anglicko-Český";
            NavigacniRamec.Navigate(typeof(SlovnikZakladni));
		}

		private void TlacitkoNastaveni_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
            NadpisStrankyTextBlock.Text = "Nastavení";
            NavigacniRamec.Navigate(typeof(StrankaNastaveni));
		}

		private void tlacitkoSlovnikZakladni_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
            /*var parametrySlovniku = new KterySlovnikPouzit();
			parametrySlovniku.TypSlovnikuAJCZ = true;*/
            NadpisStrankyTextBlock.Text = "Slovník Anglicko-Český";
            SlovnikZakladni.TypSlovnikuAJCZ = true;
            NavigacniRamec.Navigate(typeof(SlovnikZakladni));
		}

		private void tlacitkoSlovnikZakladniCZEN_Click(object sender, RoutedEventArgs e)
		{
            /*var parametrySlovniku = new KterySlovnikPouzit();
			parametrySlovniku.TypSlovnikuAJCZ = false;*/
            NadpisStrankyTextBlock.Text = "Slovník Česko-Anglický";
            SlovnikZakladni.TypSlovnikuAJCZ = false;
            NavigacniRamec.Navigate(typeof(SlovnikZakladni));
		}
	}
}