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
    /// Логика взаимодействия для UpdateBuyerWindow.xaml
    /// </summary>
    public partial class UpdateBuyerWindow : Window
    {
        CollectionBuyers collectionBuyers = new CollectionBuyers();
        IBuyerRepository buyerRepository = new BuyerRepository();
        public UpdateBuyerWindow(CollectionBuyers buyers)
        {
            InitializeComponent();
            GetData(buyers);
        }

        void GetData(CollectionBuyers buyers)
        {
            collectionBuyers.BuyerId = buyers.BuyerId;
            buyerName.Text = buyers.BuyerName;
            buyerTelephone.Text = buyers.BuyerTelephone;
            estateName.Text = buyers.EstateName;
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                collectionBuyers.BuyerName = buyerName.Text;
                collectionBuyers.BuyerTelephone = buyerTelephone.Text;
                collectionBuyers.EstateName = estateName.Text;

                buyerRepository.UpdateBuyer(collectionBuyers);
                MessageBox.Show("Данные обновлены");
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
