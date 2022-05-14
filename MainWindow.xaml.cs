using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DaDaYaRemastered
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string connectionString;

        private IOwnerRepository _ownerRepository;
        private IEstatesRepository estateRepository;
        private IBuyerRepository buyerRepository;

        public MainWindow()
        {
            InitializeComponent();

            UpdateSelectedEstate();
            UpdateSelectedOwner();
            UpdateSelectedBuyers();

        }

        #region Action with Estate


        private void UpdateSelectedEstate()
        {
            estateRepository = new EstateRepository();
            estateList.Items.Clear();
            foreach (CollectionEstates estate in estateRepository.GetAll())
            {
                estateList.Items.Add(estate);
            }

        }

        private void addEstate_Click(object sender, RoutedEventArgs e)
        {
           AddEstateWindow winAddEstate = new AddEstateWindow();
           winAddEstate.ShowDialog();

            UpdateSelectedEstate();
            UpdateSelectedOwner();
        }

        private void changeEstate_Click(object sender, RoutedEventArgs e)
        {
            if (estateList.SelectedItem is CollectionEstates)
            {
                ChangeEstateWindow winChangeEstate = new ChangeEstateWindow((CollectionEstates)estateList.SelectedItem);
                winChangeEstate.ShowDialog();

                UpdateSelectedEstate();
            }
            else
                MessageBox.Show("Объект не выбран. Выберите объект для внесения изменений.");
        }

        private void deleteEstate_Click(object sender, RoutedEventArgs e)
        {
            if (estateList.SelectedItem is CollectionEstates)
            {
                estateRepository.DeleteEstate((CollectionEstates)estateList.SelectedItem);
                UpdateSelectedEstate();
            }
            else
                MessageBox.Show("Объект не выбран. Выберите объект для внесения изменений.");
        }
        private void estateList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionEstates selectedEstate = estateList.SelectedItem as CollectionEstates;

            if (selectedEstate != null)
            {
                estateDescription.Text =                 
                    $"Общая площадь: {selectedEstate.Square} \n" +
                    $"Местонахождение: {selectedEstate.Adress} \n" +
                    $"Назначение: {selectedEstate.EstateName} \n" +
                    $"Год постройки: {selectedEstate.Date} \n" +
                    $"Цена продажи: {selectedEstate.Price} руб.\n";
            }
        }

        #endregion
        #region Action with Owners
        private void UpdateSelectedOwner()
        {
            _ownerRepository = new OwnerRepository();
            OwnerList.Items.Clear();
            foreach (CollectionOwners owners in _ownerRepository.GetAll())
            {
                OwnerList.Items.Add(owners);
            }
        }
        private void changeOwner_Click(object sender, RoutedEventArgs e)
        {
            if ( OwnerList.SelectedItem is CollectionOwners)
            {
                ChangeOwnerWindow changeOwnerWindow = new ChangeOwnerWindow((CollectionOwners)OwnerList.SelectedItem);
                changeOwnerWindow.Owner = this;
                changeOwnerWindow.ShowDialog();
                UpdateSelectedOwner();
            }
            else
            {
                MessageBox.Show("Не выбран объект");
            }
        }
        private void deleteOwner_Click(object sender, RoutedEventArgs e)
        {
            if (OwnerList.SelectedItem is CollectionOwners)
            {
                _ownerRepository.DeleteOwner((CollectionOwners)OwnerList.SelectedItem);
                UpdateSelectedOwner();
            }
            else
                MessageBox.Show("Объект не выбран. Выберите объект для внесения изменений.");
        }

        #endregion
        #region Action with Buyers
        void UpdateSelectedBuyers()
        {
            buyerRepository = new BuyerRepository();
            BuyerList.Items.Clear();
            foreach (CollectionBuyers buyer in buyerRepository.GetAll())
            {
                BuyerList.Items.Add(buyer);
            }
        }

        private void addBuyer_Click(object sender, RoutedEventArgs e)
        {
            AddBuyerWindow addBuyerWindow = new AddBuyerWindow();
            addBuyerWindow.Owner = this;
            addBuyerWindow.ShowDialog();

            UpdateSelectedBuyers();
        }

        private void changeBuyer_Click(object sender, RoutedEventArgs e)
        {
            if( BuyerList.SelectedItem is CollectionBuyers)
            {
                UpdateBuyerWindow updateBuyerWindow = new UpdateBuyerWindow((CollectionBuyers)BuyerList.SelectedItem);
                updateBuyerWindow.Owner = this;
                updateBuyerWindow.ShowDialog();
                UpdateSelectedBuyers();
            }
            else
            {
                MessageBox.Show("Объект не выбран");
            }
        }

        private void deleteBuyer_Click(object sender, RoutedEventArgs e)
        {
            if ( BuyerList.SelectedItem is CollectionBuyers)
            {
                buyerRepository.DeleteBuyer((CollectionBuyers)BuyerList.SelectedItem);
                UpdateSelectedBuyers();
            }
            else
            {
                MessageBox.Show("Объект не выбран");
            }
        }
        #endregion
        #region Sort

        private void SortName_Selected(object sender, RoutedEventArgs e)
        {
            estateList.Items.SortDescriptions.Clear();
            estateList.Items.SortDescriptions.Add(new SortDescription("EstateName", ListSortDirection.Ascending));
        }

        private void SortCost_Selected(object sender, RoutedEventArgs e)
        {
            estateList.Items.SortDescriptions.Clear();
            estateList.Items.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Ascending));
        }

        private void SortYear_Selected(object sender, RoutedEventArgs e)
        {
            estateList.Items.SortDescriptions.Clear();
            estateList.Items.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));
        }

        private void SortArea_Selected(object sender, RoutedEventArgs e)
        {
            estateList.Items.SortDescriptions.Clear();
            estateList.Items.SortDescriptions.Add(new SortDescription("Square", ListSortDirection.Ascending));
        }

        private void SortWithout_Selected(object sender, RoutedEventArgs e)
        {
            UpdateSelectedEstate();
        }
        private void SortCity_SelectionChanged(object sender, RoutedEventArgs e)
        {
           // estateRepository = new EstateRepository();
           // estateList.Items.Clear();
           // foreach (CollectionEstates estate in estateRepository.GetAll())
           // {
           //     if (SortCity.Text == estate.City.ToString().Trim() && SortCity.Text!=null)
           //        estateList.Items.Add(estate);
           // }

        }
        #endregion



        private void TretiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        
    }
}
