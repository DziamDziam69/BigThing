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
         public List<Gra> BibliotekaGier { get; set; } = new List<Gra> ();
        
        public MainWindow()
        {
            InitializeComponent ();
        }

        private void Button_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            string nazwa = NazwaGry.Text.Trim();
            string opis = Opis.Text.Trim();

            string gatunek =
                (GatunekGryComboBox.SelectedItem as ComboBoxItem)
                ?.Content?.ToString();

            if (string.IsNullOrWhiteSpace(nazwa))
            {
                MessageBox.Show(
                    "Wpisz Nazwe Gry",
                    "Brak Nazwy",
                    MessageBoxButton.OK
                    );
                return;
            }

            Gra nowaGra = new Gra()
            {
                NazwaGry = NazwaGry.Text,
                Opis = Opis.Text,
                Gatunek = GatunekGryComboBox.ToString()
            };
            BibliotekaGier.Add(nowaGra);

            MessageBox.Show($"Pomyslnie Dodano Gre: {nowaGra.NazwaGry}", "Sukces", MessageBoxButton.OK);
            
            NazwaGry.Clear();
            Opis.Clear();
            GatunekGryComboBox.SelectedIndex = -1;
        }
    }
    public class Gra
    {
        public string NazwaGry { get; set; }
        public string Opis { get; set; }
        public string Gatunek { get; set; }
    }
}