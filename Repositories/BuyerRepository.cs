using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DaDaYaRemastered
{
    public class BuyerRepository : IBuyerRepository
    {
        public ObservableCollection<CollectionBuyers> collectionBuyers = new ObservableCollection<CollectionBuyers>();

        public void AddBuyer(CollectionBuyers buyers)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Insert into dbo.Buyers " +
                    "(BuyerName, BuyerTelephone, EstateName)" +
                    "Values (@buyerName, @buyerTelephone, @estateName)", connection))
                {
                    command.Parameters.Clear();

                    command.Parameters.Add("@buyerName", SqlDbType.NVarChar).Value = buyers.BuyerName;
                    command.Parameters.Add("@buyerTelephone", SqlDbType.NVarChar).Value = buyers.BuyerTelephone;
                    command.Parameters.Add("@estateName", SqlDbType.NVarChar).Value = buyers.EstateName;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
        public void DeleteBuyer(CollectionBuyers buyers)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM dbo.Buyers WHERE Id = @id", connection))
                {
                    deleteCommand.Parameters.Clear();

                    deleteCommand.Parameters.Add("@id", SqlDbType.Int).Value = buyers.BuyerId;

                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateBuyer(CollectionBuyers buyers)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                using (SqlCommand updateCommand = new SqlCommand("Update dbo.Buyers " +
                    "Set " +
                    "BuyerName = @buyerName, " +
                    "BuyerTelephone = @buyerTelephone, " +
                    "EstateName = @estateName " +
                    "Where Id = @id", connection))
                {
                    updateCommand.Parameters.Clear();

                    updateCommand.Parameters.Add("@id", SqlDbType.Int).Value = buyers.BuyerId;
                    updateCommand.Parameters.Add("@buyerName", SqlDbType.NVarChar).Value = buyers.BuyerName;
                    updateCommand.Parameters.Add("@buyerTelephone", SqlDbType.NVarChar).Value = buyers.BuyerTelephone;
                    updateCommand.Parameters.Add("@estateName", SqlDbType.NVarChar).Value = buyers.EstateName;

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<CollectionBuyers> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                connection.Open();

                string sql = "Select * From Buyers";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CollectionBuyers new_buyers = new CollectionBuyers();
                        new_buyers.BuyerId = (Int32)reader.GetValue(0);
                        new_buyers.BuyerName = (String)reader.GetValue(1);
                        new_buyers.BuyerTelephone = (String)reader.GetValue(2);
                        new_buyers.EstateName = (String)reader.GetValue(3);

                        collectionBuyers.Add(new_buyers);
                    }
                    connection.Close();
                }
                return collectionBuyers;
            }
        }
    }
}
