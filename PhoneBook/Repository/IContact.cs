using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal interface IContact
    {
        DataTable selectAll();
        bool Insert(string name, string lastName, string number, int age, string address, string email);

        bool Update(int contactID,string name, string lastName, string number, int age, string address, string email);

        bool Delete(int contactID);
        DataTable SelectRow(int contactID);
        DataTable Search(string name);
    }
}
