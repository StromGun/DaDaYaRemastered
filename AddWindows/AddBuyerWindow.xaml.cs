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
    /// Логика взаимодействия для AddBuyerWindow.xaml
    /// </summary>
    public partial class AddBuyerWindow : Window
    {
        CollectionBuyers collectionBuyers = new CollectionBuyers();
        IBuyerRepository buyerRepository = new BuyerRepository();

        public AddBuyerWindow(CollectionEstates estate)
        {
            InitializeComponent();
            DataContext = collectionBuyers;
            GetData(estate);
        }

        void GetData(CollectionEstates estate)
        {
            if(estate == null) {}
            else 
            { 
                estateName.Text = estate.EstateName;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                collectionBuyers.BuyerName = buyerName.Text;
                collectionBuyers.BuyerTelephone = buyerTelephone.Text;
                collectionBuyers.EstateName = estateName.Text;

                buyerRepository.AddBuyer(collectionBuyers);

                MessageBox.Show("Данные добавлены");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
