using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Student
    {
        public string name;
        public string surname;
        public double gpa;

        public Student(string name1, string surname1, double gpa1)
        {
            this.name = name1;
            this.surname = surname1;
            this.gpa = gpa1;
        }
        public override string ToString()
        {
            return name + " " + surname + " " +gpa;
        }
    }
        class Program
        { 

        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string surname = Console.ReadLine();
            double gpa =Convert.ToDouble(Console.ReadLine());
            Student info = new Student(name, surname, gpa);
            Console.WriteLine(info);
            Console.ReadKey();
        }
    }
}
