using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input number of students in group");
            string str = null;
            int nmbr;
            while(!int.TryParse(str, out nmbr))
            {
                str=Console.ReadLine();
            }
            str=null;
            Student[] gr=new Student[nmbr];
            for (int i = 0; i < gr.GetLength(0); i++)
            {
                Console.Write("number of card:");
                gr[i].idCard = Console.ReadLine();
                Console.Write("Name:");
                gr[i].Name = Console.ReadLine();
                Console.Write("Surname:");
                gr[i].Surname = Console.ReadLine();
                Console.Write("GroupName:");
               gr[i].groupName = Console.ReadLine();

               Console.Write("Age:");
               while (!int.TryParse(str, out gr[i].age))
               {
                   str = Console.ReadLine();
               }
               str = null;
               Console.Write("Gender:");
               gr[i].gndr =gender.male;// (gender)Console.ReadLine();
                
            }
            
        }
    }
}
