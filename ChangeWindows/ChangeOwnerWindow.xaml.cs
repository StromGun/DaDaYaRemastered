using System;
using System.Windows;

namespace DaDaYaRemastered
{
    /// <summary>
    /// Логика взаимодействия для ChangeOwnerWindow.xaml
    /// </summary>
    public partial class ChangeOwnerWindow : Window
    {
        CollectionOwners collectionOwners = new CollectionOwners();
        IOwnerRepository ownerRepository = new OwnerRepository();

        public ChangeOwnerWindow(CollectionOwners owners)
        {
            InitializeComponent();
            GetData(owners);
        }

        private void GetData(CollectionOwners owners)
        {
            collectionOwners.OwnerId = owners.OwnerId;
            ownerName.Text = owners.OwnerName.Trim();
            ownerTelephone.Text = owners.OwnerTelephone;
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                collectionOwners.OwnerName = ownerName.Text;
                collectionOwners.OwnerTelephone = ownerTelephone.Text;

                ownerRepository.UpdateOwner(collectionOwners);
                MessageBox.Show("Данные изменены");
                Close();
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
