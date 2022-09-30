using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal class Contacts : IContact
    {
        private string connectionString = "Data Source=.;Initial Catalog=Contact_DB;Integrated Security=true";
        public bool Delete(int contactID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Delete from ContactTable where ContactID=@ContactID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContactID", contactID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable SelectRow(int contactID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from ContactTable Where ContactID="+contactID;
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool Insert(string name, string lastName, string number, int age, string address, string email)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "Insert into ContactTable (Name,LastName,Mobile,Email,Age,Address) values (@Name,@LastName,@Mobile,@Email,@Age,@Address)";
            try
            {
                SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                sqlCommand.Parameters.AddWithValue("@Mobile", number);
                sqlCommand.Parameters.AddWithValue("@Email", email);
                sqlCommand.Parameters.AddWithValue("@Age", age);
                sqlCommand.Parameters.AddWithValue("@Address", address);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public DataTable selectAll()
        {
            string query = "select * from ContactTable";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query,connectionString);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(int contactID, string name, string lastName, string number, int age, string address, string email)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Update ContactTable Set Name=@Name, LastName=@LastName, Mobile=@Number, Email=@Email, Age=@Age, Address=@Address Where ContactID = @ContactId";
                SqlCommand command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Number", number);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@ContactId", contactID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable Search(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from ContactTable where Name like @name or LastName like @LastName";
            SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
            adapter.SelectCommand.Parameters.AddWithValue("@name", "%" + name + "%");
            adapter.SelectCommand.Parameters.AddWithValue("@LastName", "%" + name + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
}
