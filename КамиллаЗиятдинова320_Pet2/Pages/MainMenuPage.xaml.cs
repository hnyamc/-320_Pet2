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
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public static List<Pet> Pet { get; set; }
        public static List<Vid> Vid { get; set; }

        public static Pet pet = new Pet();
        public MainMenuPage()
        {
            InitializeComponent();
            Pet = new List<Pet>
                (DBConnection.PetEntities.Pet.ToList());
            Vid = new List<Vid>
            (DBConnection.PetEntities.Vid.ToList());
            this.DataContext = this;
        }

        private void ZapisBTN_Click(object sender, RoutedEventArgs e)
        {
            Pet pet = new Pet();
            pet.Name = NameCB.Text.Trim();
            DBConnection.PetEntities.Pet.Add(pet);
            DBConnection.PetEntities.SaveChanges();



            work.ID_client = client.ID_client;
            work.Date_work = DateDT.SelectedDate;
            var t = SotCB.SelectedItem as Sotrydnic;
            work.ID_sotrydnic = t.ID_sotrydnic;
            var a = Type1CB.SelectedItem as Price_List;
            work.Code_price = a.Code_price;
            var b = TypeCB.SelectedItem as Type_service;
            work.Code_type_service = b.Code_type_service;
            DBConnection.SalonEntities.Work.Add(work);
            DBConnection.SalonEntities.SaveChanges();

            NavigationService.Navigate(new WorkList());
        }
    }
    }
}
