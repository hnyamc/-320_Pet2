using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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



            pet.ID_pet = pet.ID_pet;
            pet.Description = DescripTB.Text;
            var a = VidCB.SelectedItem as Vid;
            pet.ID_vid = a.ID_vid;
            var b = NameCB.SelectedItem as Pet;
            pet.Name = b.Name;
            DBConnection.PetEntities.Pet.Add(pet);
            DBConnection.PetEntities.SaveChanges();

            NavigationService.Navigate(new WorkListPage());
        }

        private void DobavBT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                pet.Photo = File.ReadAllBytes(openFileDialog.FileName);
                Image.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
    }

