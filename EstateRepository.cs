using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Configuration;

namespace DaDaYaRemastered
{
    internal class EstateRepository : IEstatesRepository
    {
        public ObservableCollection<CollectionEstates> _estateCollection = new ObservableCollection<CollectionEstates>();

        public void AddEstate(CollectionEstates estate)
        {
            //
            // поменять connection
            //
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                using (SqlCommand insertCommand = new SqlCommand("Insert Into dbo.EstatesTable " +
                               "(EstateName, Price, Square, " +
                               "City, Adress, Date) Values (@EstateName, @Price, @Square, @City, @Adress, @Date) ", connection))
                {

                    //foreach (CollectionEstates _estate in _estateCollection)
                    //{
                        insertCommand.Parameters.Clear();

                        insertCommand.Parameters.AddWithValue("@EstateName", typeof(string)).Value = estate.EstateName;
                        insertCommand.Parameters.AddWithValue("@Price", typeof(string)).Value = estate.Price;
                        insertCommand.Parameters.AddWithValue("@Square", typeof(string)).Value = estate.Square;
                        insertCommand.Parameters.AddWithValue("@Adress", typeof(string)).Value = estate.Adress;
                        insertCommand.Parameters.AddWithValue("@City", typeof(string)).Value = estate.City;
                        insertCommand.Parameters.AddWithValue("@Date", typeof(string)).Value = estate.Date;
                    //}
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

        public void DeleteEstate(CollectionEstates estate)
        {
            //
            // поменять connection
            //
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
              using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM dbo.EstatesTable " +
                               "WHERE Id = @Id", connection))
                {
                    deleteCommand.Parameters.Clear();
                    deleteCommand.Parameters.AddWithValue("@Id", typeof(string)).Value = estate.Id;

                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateEstate(CollectionEstates estate)
        {
            //
            // поменять connection
            //
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                using (SqlCommand updateCommand = new SqlCommand("UPDATE dbo.EstatesTable " +
                               "SET " +

                               //"Id = @Id, " +
                               "EstateName = @EstateName, " +
                               "Adress = @Adress, " +
                               "Price = @Price, " +
                               "Square = @Square, " +
                               "City = @City, " +
                               "Date = @Date " +
                               "WHERE Id = @Id", connection))
                {
                    updateCommand.Parameters.Clear();

                    updateCommand.Parameters.AddWithValue("@Id", typeof(string)).Value = estate.Id;
                    updateCommand.Parameters.AddWithValue("@EstateName", typeof(string)).Value = estate.EstateName;
                    updateCommand.Parameters.AddWithValue("@Adress", typeof(string)).Value = estate.Adress;
                    updateCommand.Parameters.AddWithValue("@Price", typeof(string)).Value = estate.Price;
                    updateCommand.Parameters.AddWithValue("@Square", typeof(string)).Value = estate.Square;
                    updateCommand.Parameters.AddWithValue("@City", typeof(string)).Value = estate.City;
                    updateCommand.Parameters.AddWithValue("@Date", typeof(string)).Value = estate.Date;

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<CollectionEstates> GetAll()
        {
            //
            // поменять connection
            //
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM EstatesTable";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CollectionEstates new_estate = new CollectionEstates();

                        new_estate.Id = (Int32)reader.GetValue(0);
                        new_estate.EstateName = (string)reader.GetValue(1);
                        new_estate.Adress = (string)reader.GetValue(5);
                        new_estate.Price = (Int32)reader.GetValue(2);
                        new_estate.Square = (Int32)reader.GetValue(3);
                        new_estate.City = (string)reader.GetValue(4);
                        new_estate.Date = (Int32)reader.GetValue(6);

                        _estateCollection.Add(new_estate);
                    }
                    connection.Close();
                }
                return _estateCollection;

            }
        }
    }
}
