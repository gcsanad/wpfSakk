using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Jatszma> jatszmak;
        string nyertes;
        string vezertUtottJatszmak;
        int jatszmaSorszam=1;
        public MainWindow()
        {
            InitializeComponent();
            TablaGeneralas();
            jatszmak = File.ReadAllLines("jatszmak.txt").Select(sor => new Jatszma(sor)).ToList();
            MessageBox.Show($"A huszárok ennyi mezőt haladtak: {jatszmak.Sum(jatszma=> jatszma.HuszarokLepesszama)*4}");
            MessageBox.Show($"A futók ennyi mezőt léptek: {jatszmak.Sum(jatszma => jatszma.TisztLepesszama('F'))}");
            foreach (var jatszma in jatszmak)
            {
                if (jatszma.LepesekSzama % 2 == 0)
                {
                    nyertes += 's';
                }
                else
                {
                    nyertes += 'v';
                }
            }
            MessageBox.Show($"Nyertes sorozat: {nyertes}");
            for (int i = 0; i < jatszmak.Count(); i++)
            {
                if (jatszmak[i].VezertUtottek)
                {
                    vezertUtottJatszmak += $"{i + 1};";
                }
            }
            MessageBox.Show($"A vezért leütött játszmák száma: {vezertUtottJatszmak}");
        }
        private void TablaGeneralas()
        {
            ugTabla.Rows = 8;
            ugTabla.Columns = 8;
            ugTabla.Children.Clear();
            List<int> lista = new List<int>();
            for (int i = 0; i < (ugTabla.Rows * ugTabla.Columns) / 2; i++)
            {
                lista.Add(i);
                lista.Add(i);
            }
            for (int index = 0; index < ugTabla.Rows * ugTabla.Columns; index++)
            {
                for (int row = 0; row < ugTabla.Rows; row++)
                {
                    for (int col = 0; col < ugTabla.Columns; col++)
                    {

                        Button gomb = new Button();
                        if (row % 2 == 0)
                        {
                            if (col % 2 == 0)
                            {
                                gomb.Background = Brushes.White;
                            }
                        }
                        else
                        {
                            gomb.Background = Brushes.Black;
                        }
                        lista.Remove(Convert.ToInt32(gomb.Content));
                        gomb.Name = $"Gomb{index}";
                        //gomb.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(Button_Click));
                        ugTabla.Children.Add(gomb);


                    }
                }
            }
            
        }
    }
}
