using System;
using System.Windows;

namespace DaDaYaRemastered
{
    /// <summary>
    /// Логика взаимодействия для AddEstateWindow.xaml
    /// </summary>
    public partial class AddEstateWindow : Window
    {

        CollectionEstates collectionEstates = new CollectionEstates();
        IEstatesRepository estateRepository = new EstateRepository();

        CollectionOwners collectionOwners = new CollectionOwners();
        IOwnerRepository ownerRepository = new OwnerRepository();

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
                collectionEstates.City = estateCity.Text;
                collectionEstates.Square = int.Parse(estateSquare.Text);
                collectionEstates.Date = int.Parse(estateBirthday.Text);

                collectionOwners.OwnerName = estateOwner.Text;
                collectionOwners.OwnerTelephone = ownerTelephone.Text;

                if (int.Parse(estateBirthday.Text) < 2022)
                {
                    estateRepository.AddEstate(collectionEstates);
                    ownerRepository.AddOwner(collectionOwners);
                    MessageBox.Show("Данные добавлены.");
                    this.Close();
                }
                else
                    MessageBox.Show("Неверная дата");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
