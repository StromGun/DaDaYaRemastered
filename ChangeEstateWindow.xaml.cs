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
