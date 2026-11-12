using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net.Sockets;

namespace Szavazas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string helyszin = "Sopron";
        private string utazas = "Vonattal";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSzavazok_Click(object sender, RoutedEventArgs e)
        {
            try
            { if (tbxNev.Text != "" && tbxEmail.Text != "")
                {
                    string allomanyNev = "szavazat_";
                    allomanyNev += tbxNev.Text.Replace(" ", "_") + ".txt";
                    MessageBox.Show(allomanyNev);
                    using (StreamWriter sw = new StreamWriter(allomanyNev))
                    {
                        sw.WriteLine($"Szavazó neve: \n{tbxNev.Text}");
                        sw.WriteLine($"Szavazó email címe: \n{tbxEmail.Text}");
                        sw.WriteLine($"Szavazó telefonszáma: \n{tbxTelefon.Text}");
                        sw.WriteLine($"Szavazó helyszíne: \n{helyszin}");
                        sw.WriteLine($"Szavazó : \n{utazas}");
                        sw.WriteLine("Programok");
                        if (cbxMuzeum.IsChecked == true)
                        {
                            sw.WriteLine("Múzeum");
                        }
                        if (cbxPaintball.IsChecked == true)
                        {
                            sw.WriteLine("Paintball");
                        }
                        if (cbxSzabadulo.IsChecked == true)
                        {
                            sw.WriteLine("Szabadulószoba");
                        }
                        if (cbxFoci.IsChecked == true)
                        {
                            sw.WriteLine("Foci");
                        }
                        if (cbxCsapat.IsChecked == true)
                        {
                            sw.WriteLine("Csapatjáték (ami nem foci)");
                        }

                    }
                    MessageBox.Show($"Szavazatát mentettük az {allomanyNev} állományba. Köszönjük!");
                }
            else
                {
                    MessageBox.Show("A név és az email megadása kötelező!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történet \n {ex.Message}");
            }
        }

        private void RadioButtonHelyszin_Checked(object sender, RoutedEventArgs e)
        {
            helyszin = (sender as RadioButton).Content.ToString();
        }

        private void RadioButtonUtazas_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
