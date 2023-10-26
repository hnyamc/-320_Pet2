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

namespace КамиллаЗиятдинова320_Pet2.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkListPage.xaml
    /// </summary>
    public partial class WorkListPage : Page
    {
        public WorkListPage()
        {
            InitializeComponent();
        }

        private void SearchNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            WorkListLV.ItemsSource = new List<Work>(DBConnection.SalonEntities.Work.
            Where(i => i.Price_List.Name_service.StartsWith(SearchNameTB.Text)));
        }
    }
}
