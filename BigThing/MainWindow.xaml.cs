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
using System.Collections.Generic;


namespace BigThing
{

    public partial class MainWindow : Window
    {
        public List<Gra> BibliotekaGier { get; set; } = new List<Gra>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            string nazwa = NazwaGry.Text.Trim();
            string opis = Opis.Text.Trim();

            string? gatunek = (GatunekGryComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

            if (string.IsNullOrWhiteSpace(nazwa) ||
                string.IsNullOrWhiteSpace(opis) ||
                string.IsNullOrWhiteSpace(gatunek))
            {
                MessageBox.Show(
                    "Wpisz Nazwe, opis i wybierz gatunek gry.",
                    "Brak Danych",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            Gra nowaGra = new Gra
            {
                Nazwa = NazwaGry.Text,
                Opis = Opis.Text,
                Gatunek = (GatunekGryComboBox.SelectedItem as ComboBoxItem).Content.ToString()
            };

            BibliotekaGier.Add(nowaGra);

            MessageBox.Show($"Pomyslnie Dodano Gre: {nowaGra.Nazwa}", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

            NazwaGry.Clear();
            Opis.Clear();
            GatunekGryComboBox.SelectedIndex = -1;
        }

        private void Button_Wyswietl_Click(object sender, RoutedEventArgs e)
        {
            if (BibliotekaGier.Count == 0)
            {
                MessageBox.Show(
                    "Biblioteka jest pusta. Dodaj najpierw jakas Gre.",
                    "Brak Gier",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            Wszystkie okno = new Wszystkie(BibliotekaGier);


            okno.Owner = this;
            okno.ShowDialog();


        }
        public class Gra
        {
            public string Nazwa { get; set; }
            public string Opis { get; set; }
            public string Gatunek { get; set; }
        }
    } 
}