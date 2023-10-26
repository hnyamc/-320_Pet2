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
using КамиллаЗиятдинова320_Pet2.DB;

namespace КамиллаЗиятдинова320_Pet2.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkListPage.xaml
    /// </summary>
    public partial class WorkListPage : Page
    {
        public static List<Pet> pet { get; set; }
        public static List<Vid> vid { get; set; }
        public WorkListPage()
        {
            InitializeComponent();
        }

        private void SearchNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkListLV.ItemsSource = new List<Pet>(DBConnection.PetEntities.Pet.
            Where(i => i.Pet.Description.StartsWith(SearchNameTB.Text)));
        }
    }
}
