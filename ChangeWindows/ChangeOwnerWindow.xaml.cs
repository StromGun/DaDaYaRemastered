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
