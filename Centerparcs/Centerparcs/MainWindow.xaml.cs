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

namespace Centerparcs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Globale variabele

        private readonly int[] _numberOfDays = new int[] { 1, 2, 5, 7, 8, 12, 14, 21 };

        private string[,] _houseWithPrice = new string[5, 2] {
                            { "2 personen", "80" },
                            { "4 personen", "120" } ,
                            { "4 personen lux", "140" } ,
                            { "6 personen", "180" },
                            { "8 personen", "200"}
        };

        int price = 0;
        int person = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadComboBox()
        {
            int count = 0;

            foreach (var item in _houseWithPrice)
            {
                if (count%2 == 0)
                {
                    typeCollageComboBox.Items.Add(item);
                }
                count++;
            }

            foreach (var item in _numberOfDays)
            {
                countDaysComboBox.Items.Add(item);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadComboBox();

            countDaysComboBox.IsEnabled = false;
        }

        private void typeCollageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            price = int.Parse(_houseWithPrice[typeCollageComboBox.SelectedIndex,1]);

            if (typeCollageComboBox.SelectedIndex > -1)
            {
                countDaysComboBox.IsEnabled = true;
            }

            if (person > 0 && price > 0)
            {
                showResult();
            }
        }

        private void countDaysComboBox_DropDownClosed(object sender, EventArgs e)
        {
            person = int.Parse(countDaysComboBox.Text);

            if (person > 0 && price > 0)
            {
                showResult();
            }
        }

        private void showResult()
        {
            priceTextBox.Text = (price * person).ToString();
        }

    }
}