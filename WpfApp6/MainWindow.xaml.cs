using System;
using System.Windows;

namespace WpfApp6
{
    public partial class MainWindow : Window // Klasa publiczna MainWindow oznacza główne okno WPF, które dziedziczy klasę Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Inicjalizuje komponenty okna
        }

        // Obsługa kliknięcia przycisku "Oblicz liczbę włosów"
        private void Oblicz_Click(object sender, RoutedEventArgs e) // Zmieniono metodę na przyjmującą parametry
        {
            try // Zawiera kod, który generuje błędy
            {
                // Użyłem zmiennej typu float, ponieważ jest to typ zmiennoprzecinkowy 
                // Odczytanie i parsowanie danych wejściowych jako float
                float obwodGlowy = float.Parse(txtObwod.Text);
                float wysokoscCzola = float.Parse(txtWysokoscCzola.Text);
                float gestoscWlosow = float.Parse(txtGestosc.Text);

                // Tworzenie instancji klasy Glowa
                Glowa glowa = new Glowa();
                glowa.ObliczLiczbeWlosow(gestoscWlosow, obwodGlowy, wysokoscCzola); // Obliczenie liczby włosów

                // Wyświetlenie wyniku
                txtWynik.Text = $"Szacunkowa liczba włosów: {glowa.LiczbaWlosow:F}\n" +
                                $"Procent względem przeciętnej: {glowa.PorownajDoPrzecietnej():F2}%";
            }
            catch (FormatException) // Catch reaguje, gdy użytkownik nie wprowadzi danych lub wprowadzi inne dane
            {
                MessageBox.Show("Wprowadź poprawne wartości liczbowe."); // MessageBox to wyskakujący komunikat informujący użytkownika o złych wprowadzonych danych
            }
        }

        // Obsługa kliknięcia przycisku "Reset"
        private void Reset_Click(object sender, RoutedEventArgs e) // Zmieniono metodę na przyjmującą parametry
        {
            // Czyszczenie pól tekstowych
            txtObwod.Clear();
            txtWysokoscCzola.Clear();
            txtGestosc.Clear();
            txtWynik.Text = string.Empty; // Resetowanie wyniku
        }
    }

    public class Glowa
    {
        private const float PrzecietnaLiczbaWlosow = 100000f; // Używamy 'f' dla float
        private float liczbaWlosow; // Typ float dla liczby włosów

        public float LiczbaWlosow => liczbaWlosow; // Właściwość do uzyskania liczby włosów

        // Oblicza powierzchnię głowy na podstawie obwodu i wysokości czoła
        private float ObliczPowierzchnie(float obwod, float wysokosc)
        {
            return (obwod * wysokosc) / (4 * (float)Math.PI); // Używamy Math.PI dla operacji na float ponieważ głowa nie jest kwadratem
        }

        // Oblicza liczbę włosów na podstawie gęstości, obwodu i wysokości czoła
        public void ObliczLiczbeWlosow(float gestosc, float obwod, float wysokosc)
        {
            float powierzchnia = ObliczPowierzchnie(obwod, wysokosc);
            liczbaWlosow = gestosc * powierzchnia; // Wyliczenie liczby włosów
        }

        // Oblicza procentową różnicę w stosunku do przeciętnej liczby włosów
        public float PorownajDoPrzecietnej()
        {
            return ((liczbaWlosow - PrzecietnaLiczbaWlosow) * 100) / PrzecietnaLiczbaWlosow; // Obliczenie różnicy procentowej
        }
    }
}
