using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6
{
    public partial class MainWindow : Window //klasa publiczna mainwindow oznacza glowne okno wpf ktore dziedziczy klase window
    {
        // Obsługa kliknięcia przycisku "Oblicz liczbe wlosow"
        private void Oblicz_Przycisk(object sender, RoutedEventArgs e) //private obliczanie przycisku
        {
            try // zawiera kod ktory generuje bledy
            {

                //uzylem zmiennej typu float poniewaz jest to typ zmiennoprzecinkowy 
                // Odczytanie i parsowanie danych wejściowych jako float
                float obwodGlowy = float.Parse(txtObwod.Text);
                float wysokoscCzola = float.Parse(txtWysokoscCzola.Text);
                float gestoscWlosow = float.Parse(txtGestosc.Text);

                // Obliczenie liczby włosow+



            }
            catch (FormatException) //catch reaguje gdy uzytkownik nie wprowadzi zadnych danych lub wprowadzi inne dane
            {
                MessageBox.Show("Wprowadź poprawne wartości liczbowe."); //messagebox to wyskakujacy komunikat ktory informuje uzytkownika o zle wprowadzonych danych
            }
        }


       
        // Obsluga klikniecia przycisku "Reset"
        private void Reset_Przycisk()
        {
            // Czyszczenie pol tekstowych
            txtObwod.Clear();
            txtWysokoscCzola.Clear();
            txtGestosc.Clear();
            txtWynik.Text = string.Empty;
        }
    }
}





   