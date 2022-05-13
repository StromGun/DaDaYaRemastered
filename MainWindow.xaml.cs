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

        private IEstatesRepository estateRepository;

        public MainWindow()
        {
            InitializeComponent();

            UpdateSelectedEstate();

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
        private void SortCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            
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
        #endregion



        private void TretiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
