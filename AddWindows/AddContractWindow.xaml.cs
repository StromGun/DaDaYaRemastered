using System;
using System.Windows;

namespace DaDaYaRemastered
{
    /// <summary>
    /// Логика взаимодействия для AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        CollectionContracts collectionContracts = new CollectionContracts();
        IContractRepository contractRepository = new ContractRepository();

        public AddContractWindow()
        {
            InitializeComponent();
            DataContext = collectionContracts;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                collectionContracts.DateSigning = dateSigning.Text;
                collectionContracts.Buyer = buyer.Text;
                collectionContracts.Owner = owner.Text;
                collectionContracts.Price = int.Parse(price.Text);
                collectionContracts.EstateName = estateName.Text;

                contractRepository.AddContract(collectionContracts);
                MessageBox.Show("Данные добавлены");
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
