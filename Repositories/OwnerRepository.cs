using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace DaDaYaRemastered
{
    public class OwnerRepository : IOwnerRepository
    {
        public ObservableCollection<CollectionOwners> collectionOwners = new ObservableCollection<CollectionOwners>();

        public void AddOwner(CollectionOwners owners)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Insert into Owners" +
                    "(OwnerName, OwnerTelephone)" +
                    "Values (@ownerName, @ownerTelephone)", connection))
                {
                    command.Parameters.Clear();

                    command.Parameters.Add("@ownerName", SqlDbType.NVarChar).Value = owners.OwnerName;
                    command.Parameters.Add("@ownerTelephone", SqlDbType.NVarChar).Value = owners.OwnerTelephone;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
        public void DeleteOwner(CollectionOwners owners)
        {
            using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM dbo.Owners WHERE Id = @id", connection))
                {
                    deleteCommand.Parameters.Clear();

                    deleteCommand.Parameters.Add("@id", SqlDbType.Int).Value = owners.OwnerId;

                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateOwner(CollectionOwners owners)
        {
            using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                using (SqlCommand updateCommand = new SqlCommand("Update dbo.Owners " +
                    "Set " +
                    "OwnerName = @ownerName, " +
                    "OwnerTelephone = @ownerTelephone " +
                    "Where Id = @id",connection))
                {
                    updateCommand.Parameters.Clear();

                    updateCommand.Parameters.Add("@id", SqlDbType.Int).Value = owners.OwnerId;
                    updateCommand.Parameters.Add("@ownerName", SqlDbType.NVarChar).Value = owners.OwnerName;
                    updateCommand.Parameters.Add("@ownerTelephone", SqlDbType.NVarChar).Value = owners.OwnerTelephone;

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<CollectionOwners> GetAll()
        {
            using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString))
            {
                connection.Open();

                string sql = "Select * From Owners";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CollectionOwners new_owners = new CollectionOwners();
                        new_owners.OwnerId = (Int32)reader.GetValue(0);
                        new_owners.OwnerName = (String)reader.GetValue(1);
                        new_owners.OwnerTelephone = (String)reader.GetValue(2);

                        collectionOwners.Add(new_owners);
                    }
                    connection.Close();
                }
                return collectionOwners;
            }
        }
    }
}
