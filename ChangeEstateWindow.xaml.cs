using System;
using System.Windows;

namespace DaDaYaRemastered
{
    /// <summary>
    /// Логика взаимодействия для ChangeEstateWindow.xaml
    /// </summary>
    public partial class ChangeEstateWindow : Window
    {

        CollectionEstates updateEstates = new CollectionEstates();
        IEstatesRepository estateRepository = new EstateRepository();

        public ChangeEstateWindow(CollectionEstates estate)
        {
            InitializeComponent();
            this.DataContext = updateEstates;
            GetData(estate);
        }
        

        private void GetData(CollectionEstates estate)
        {
            updateEstates.Id = estate.Id;
            estateName.Text = estate.EstateName.Trim();
            estatePrice.Text = estate.Price.ToString();
            estateSquare.Text = estate.Square.ToString();
            estateCity.Text = estate.City.Trim();
            estateAdress.Text = estate.Adress.Trim();
            estateBirthday.Text = estate.Date.ToString();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                updateEstates.EstateName = estateName.Text;
                updateEstates.Price = int.Parse(estatePrice.Text);
                updateEstates.Square = int.Parse(estateSquare.Text);
                updateEstates.City = estateCity.Text;
                updateEstates.Adress = estateAdress.Text;
                updateEstates.Date = int.Parse(estateBirthday.Text);

                estateRepository.UpdateEstate(updateEstates);

                MessageBox.Show("Данные изменены");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
