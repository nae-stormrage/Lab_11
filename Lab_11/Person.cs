using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11
{
    class Person
    {
        String ID { get; set; }
        String FirstName { get; set; }
        String LastName { get; set; }
        public string email { get; set; }
        public float Plus { get; set; }
        public float Minus { get; set; }
        public long credit_card { get; set; }
        public float Tax { get; set; }

        public static Person Create (string str)
        {
            Person person = new Person ();
            string[] e = str.Split (',');
            person.ID = e[0].Trim();
            person.FirstName = e[1].Trim();
            person.LastName = e[2].Trim();
            person.email = e[3].Trim();
            person.Plus = Convert.ToSingle(e[4].TrimStart('$').Replace('.', ','));
            person.Minus = Convert.ToSingle(e[5].TrimStart('$').Replace('.', ','));
            person.credit_card = Convert.ToInt64(e[6]);
            person.Tax = Convert.ToSingle(e[7].TrimStart('$').Replace('.', ','));

            return person;
        }

        public override string ToString()
        {
            String s = string.Format("***********************************************************************************************\n" + 
                "ID: {0}, Имя: {1}, Фамилия: {2}, Email: {3}\n" +
                "Доход: {4}, Расход: {5}, Номер кредитной карты: {6}, Налог: {7}",
                ID, FirstName, LastName, email,
                Plus, Minus, credit_card, Tax);

            return s;
        }
    }
}
