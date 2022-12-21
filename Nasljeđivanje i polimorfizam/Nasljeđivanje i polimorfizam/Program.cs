using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Nasljeđivanje_i_polimorfizam
{
    internal class Program
    {
        class Dessert
        {
            private string name;
            private double weight;
            private int calories;

            public Dessert()
            {

            }
            public Dessert(string name, double weight, int calories)
            {
                this.name = name;
                this.weight = weight;
                this.calories = calories;
            }

            public string Name { get => this.name; set => this.name = value; }
            public double Weight { get => this.weight; set => this.weight = value; }
            public int Calories { get => this.calories; set => this.calories = value; }

            public override string ToString()
            {
                return this.name + " " + this.weight + " " + this.calories;
            }

            virtual public string getDessertType()
            {
                return "dessert";
            }
        }

        class Cake : Dessert
        {
            bool containsGluten;
            string cakeType;
            public Cake(string name, double weight, int calories, bool containsGluten, string cakeType) : base(name, weight, calories)
            {
                this.containsGluten = containsGluten;
                this.cakeType = cakeType;
            }

            public bool ContainsGluten { get => this.containsGluten; set => this.containsGluten = value;}
            public string CakeType { get => this.cakeType; set => this.cakeType = value; }

            public override string ToString()
            {
                return base.ToString() + " " + this.ContainsGluten + " " + this.cakeType;
            }

            public override string getDessertType()
            {
                return " cake";
            }

        }

        class IceCream : Dessert
        {
            string flavour;
            string color;

            public IceCream(string name, double weight, int calories, string flavour, string color) : base(name, weight, calories)
            {
                this.flavour = flavour;
                this.color = color;
            }

            public string Flavour { get => this.flavour; set => this.flavour = value; }
            public string Color { get => this.color; set => this.color = value; }

            public override string ToString()
            {
                return base.ToString() + " " + this.flavour + " " + this.color;
            }

            public override string getDessertType()
            {
                return "ice cream";
            }

        }

        class Person
        {
            string name;
            string surname;
            int age;

            public Person()
            {

            }

            public Person(string name, string surname, int age)
            {
                this.name = name;
                this.surname = surname;
                this.age = age;
            }

            public string Name { get => this.name; set => this.name = value; }
            public int Age { get => this.age; set => this.age = value; }
            public string Surname { get => this.surname; set => this.surname = value; }

            public override bool Equals(object obj)
            {
                return obj is Person person &&
                       name == person.name &&
                       surname == person.surname &&
                       age == person.age;
            }

            public override string ToString()
            {
                return this.name + " " + this.surname + " " + this.age;
            }

            

        }
        class Student : Person
        {
            string studentid;
            int  academicYear;

            public Student(string name, string surname, int age, string studentid, int academicYear) : base(name, surname, age)
            {
                this.studentid = studentid;
                this.academicYear = academicYear;
            }

            public string Studentid { get => this.studentid; set => this.studentid = value; }
            public int AcademicYear { get => this.academicYear; set => this.academicYear = value;}

            public override bool Equals(object obj)
            {
                return obj is Student student &&
                       base.Equals(obj) &&
                       studentid == student.studentid;
            }

            public override string ToString()
            {
                return base.ToString() + " " + this.studentid + " " + this.academicYear;
            }



        }

        class Teacher : Person
        {
            string email;
            string subject;
            double salery;
            public Teacher(string name, string surname, int age, string email, string subject, double salery) : base(name, surname, age)
            {
                this.email = email;
                this.subject = subject;
                this.salery = salery;
            }

            public string Email { get => this.email; set => this.email = value; }
            public string Subject { get => this.subject; set => this.subject = value; }
            public double Salery { get => this.salery; set => this.salery = value;}

            public override bool Equals(object obj)
            {
                return obj is Teacher teacher &&
                       base.Equals(obj) &&
                       email == teacher.email;
            }

            public override int GetHashCode()
            {
                return 848330207 + EqualityComparer<string>.Default.GetHashCode(email);
            }

            public override string ToString()
            {
                return base.ToString() + " " + this.email + " " + this.subject + " " + this.salery;
            }



        }

        static void Main(string[] args)
        {
            Cake a = new Cake("Anina", 4.5, 450, false, "rođendanska");
            IceCream b = new IceCream("Šrumf", 0.5, 200, "šumsko voće", "plav");

            Console.Write(a.ToString());

            Console.WriteLine(a.getDessertType());

            Console.WriteLine(b.ToString());

            Console.WriteLine(b.getDessertType());

            Console.ReadKey();
        }
    }
}
