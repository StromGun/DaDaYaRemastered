﻿using System;
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
