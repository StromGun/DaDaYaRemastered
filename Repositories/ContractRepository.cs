using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DaDaYaRemastered
{
    public class ContractRepository : IContractRepository
    {
        ObservableCollection<CollectionContracts> contracts = new ObservableCollection<CollectionContracts>();

        public void AddContract(CollectionContracts collectionContracts)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Insert into dbo.Contracts " +
                    "(DateSigning, Owner, Buyer, Price, EstateName)" +
                    "Values (@dateSigning, @owner, @buyer, @price, @estateName)", connection))
                {
                    command.Parameters.Clear();

                    command.Parameters.Add("@dateSigning", SqlDbType.NVarChar).Value = collectionContracts.DateSigning;
                    command.Parameters.Add("@owner", SqlDbType.NVarChar).Value = collectionContracts.Owner;
                    command.Parameters.Add("@buyer", SqlDbType.NVarChar).Value = collectionContracts.Buyer;
                    command.Parameters.Add("@price", SqlDbType.Int).Value = collectionContracts.Price;
                    command.Parameters.Add("@estateName", SqlDbType.NVarChar).Value = collectionContracts.EstateName;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

        public void DeleteContract(CollectionContracts collectionContracts)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM dbo.Contracts WHERE Id = @id", connection))
                {
                    deleteCommand.Parameters.Clear();

                    deleteCommand.Parameters.Add("@id", SqlDbType.Int).Value = collectionContracts.NumberContract;

                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void UpdateContract(CollectionContracts collectionContracts)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                using (SqlCommand updateCommand = new SqlCommand("Update dbo.Contracts " +
                    "Set " +
                    "DateSigning = @dateSigning, " +
                    "Owner = @owner, " +
                    "Buyer = @buyer, " +
                    "EstateName = @estateName," +
                    "Price = @price " +
                    "Where Id = @id", connection))
                {
                    updateCommand.Parameters.Clear();

                    updateCommand.Parameters.Add("@id", SqlDbType.Int).Value = collectionContracts.NumberContract;
                    updateCommand.Parameters.Add("@buyer", SqlDbType.NVarChar).Value = collectionContracts.Buyer;
                    updateCommand.Parameters.Add("@owner", SqlDbType.NVarChar).Value = collectionContracts.Owner;
                    updateCommand.Parameters.Add("@estateName", SqlDbType.NVarChar).Value = collectionContracts.EstateName;
                    updateCommand.Parameters.Add("@price", SqlDbType.Int).Value = collectionContracts.Price;

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<CollectionContracts> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                connection.Open();

                string sql = "Select * From Contracts";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CollectionContracts new_contracts = new CollectionContracts();
                        new_contracts.NumberContract = (Int32)reader.GetValue(0);
                        new_contracts.DateSigning = (String)reader.GetValue(1);
                        new_contracts.Owner = (String)reader.GetValue(2);
                        new_contracts.Buyer = (String)reader.GetValue(3);
                        new_contracts.Price = (Int32)reader.GetValue(4);
                        new_contracts.EstateName = (String)reader.GetValue(5);

                        contracts.Add(new_contracts);
                    }
                    connection.Close();
                }
                return contracts;
            }
        }

    }
}
