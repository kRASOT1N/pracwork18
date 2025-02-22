using System;

namespace CampusLife
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public Person(string name, int age, string address)
        {
            Name = name;
            Age = age;
            Address = address;
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}, Адрес: {Address}";
        }
    }

    public class Student : Person
    {
        public string University { get; set; }
        public string Major { get; set; }
        private double gpa;
        public double GPA
        {
            get { return gpa; }
            set
            {
                if (value < 0.0 || value > 4.0)
                {
                    throw new ArgumentOutOfRangeException(nameof(GPA), "Средний балл должен быть в диапазоне от 0.0 до 4.0.");
                }
                gpa = value;
            }
        }
        public string StudentID { get; set; }
        public string CampusClub { get; set; }

        public Student(string name, int age, string address, string university, string major, double gpa, string studentId, string campusClub)
            : base(name, age, address)
        {
            University = university;
            Major = major;
            GPA = gpa;
            StudentID = studentId;
            CampusClub = campusClub;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $", Университет: {University}, Специальность: {Major}, Средний балл: {GPA}, Номер студенческого билета: {StudentID}, Кампусный клуб: {CampusClub}";
        }

        public void UpdateGPA(double newGPA)
        {
            if (newGPA > GPA)
            {
                GPA = newGPA;
                Console.WriteLine($"Успешное обновление: новый средний балл = {GPA}");
            }
            else
            {
                Console.WriteLine("Новый балл не выше текущего. Обновление не выполнено.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(
                "Глеб Красотин",
                17,
                "AITU COLLEGE",
                "AITU COLLEGE",
                "Информационные технологии",
                3.0,
                "GL2025",
                "IT Club"
            );

            Console.WriteLine(student.ToString());
        }
    }
}
