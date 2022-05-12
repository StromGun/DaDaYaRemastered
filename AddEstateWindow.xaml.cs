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
using System.Windows.Shapes;

namespace DaDaYaRemastered
{
    /// <summary>
    /// Логика взаимодействия для AddEstateWindow.xaml
    /// </summary>
    public partial class AddEstateWindow : Window
    {

        CollectionEstates collectionEstates = new CollectionEstates();
        IEstatesRepository estateRepository = new EstateRepository();

        public AddEstateWindow()
        {
            InitializeComponent();
            this.DataContext = collectionEstates;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                collectionEstates.EstateName = estateName.Text;
                collectionEstates.Adress = estateAdress.Text;
                collectionEstates.Price = int.Parse(estatePrice.Text);
                collectionEstates.Date = int.Parse(estateBirthday.Text);
                collectionEstates.City = estateCity.Text;
                collectionEstates.Square = int.Parse(estateSquare.Text);


                estateRepository.AddEstate(collectionEstates);

                MessageBox.Show("Данные добавлены.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
