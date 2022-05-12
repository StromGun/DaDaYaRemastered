using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Collections.ObjectModel;
using System.Configuration;
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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
        #endregion


        private void estateList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SortCity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TretiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
