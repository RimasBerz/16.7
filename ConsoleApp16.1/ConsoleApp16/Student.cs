using System;
using System.Collections.Generic;

namespace ConsoleApp16
{
    class StudentAdder : Student
    {
        int Choice;

        public delegate void MethodHandler();


        public event MethodHandler PAddStudent;
        public event MethodHandler PDelStudent;
        public event MethodHandler PShowStudent;
        public event MethodHandler PStopStudent;
      
        public void StartStudentG(this Student s)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (i == Choice)
                {
                    PAddStudent();
                }
                else if(i == Choice)
                {
                    PDelStudent();
                }
                else if (i == Choice)
                {
                    s.Print2();
                    PShowStudent();
                }
                else
                {
                    PStopStudent();
                    Environment.Exit(0);
                }
            }
        }
        
    
    }
    public static class StudentExtension
    {
        //public static int CharCount(this Student q, Student w)
        //{
        //    int counter = 0;
        //    switch (counter)
        //    {
        //        case 1:
        //            if (q.Phonenumber != w.Phonenumber)
        //                counter++;
        //            break;
        //            default:
        //            q.Phonenumber = w.Phonenumber;
        //            counter++;
        //            break;
        //    }
        //    return counter;
        //}
        public static int CharCount(this int[] hometasks, char c)
        {
            int counter = 0;
            for (int i = 0; i < hometasks.Length; i++)
            {
                if (hometasks[i] >= c)
                    counter++;
                else
                    return -1;
            }
            return counter;
        }
        public static void MethodSecond(this Student s, Student copy)
        {
            if (copy.Name != s.Name)
            {
                Console.WriteLine("Имена 2 студентов отличаются:{0},{1}!", copy.Name, s.Name);
            }
            else
            {
                Console.WriteLine("Прикол:{0} = {1}!)", copy.Name, s.Name);
            }//Суть понятна но идеи кончились
        }
        
    }
    public struct MyDate
    {
        private int d;
        private int m;
        private int y;
        //public void CharDays()
        //{
        //    int counter = 0;
        //    for (int i = 0; i < d; i++)
        //    {
        //        if (d <= 31 || d >= 0)
        //            counter++;
        //        else throw new Exception("Wrong date!");
        //    }
        //    return counter;
        //    for (int i = 0; i < m; i++)
        //    {
        //        if (m <= 12 || m >= 0)
        //            counter++;
        //        else throw new Exception("Wrong date!");
        //    }
        //    return counter;
        //    for (int i = 0; i < y; i++)
        //    {
        //        if (y <= 2022 || y >= 0)
        //            counter++;
        //        else throw new Exception("Wrong date!");
        //    }
        //    return counter;
        //}
        public int Days
        {
            get => d;
            set
            {
                if (value <= 0 || value >= 32)
                {
                    throw new Exception("Вы вышли за диапазон чисел(");
                }
                else
                {
                    Console.WriteLine("Окей!");
                }
                d = value;
            }
        }
        public int Months
        {
            get => m;
            set
            {
                if (value <= 0 || value >= 13)
                {
                    throw new Exception("Вы вышли за диапазон чисел(");
                }
                else
                {
                    Console.WriteLine("Окей!");
                }
                m = value;
            }
        }
        public int Years
        {
            get => y;
            set
            {
                if (value <= 0 || value >= 2007)
                {
                    throw new Exception("Вы вышли за диапазон чисел(");
                }
                else
                {
                    Console.WriteLine("Окей!");
                }
                y = value;
            }
        }
        public void Print()
        {
            Console.WriteLine($"Days: {Days}  Months: {Months} Years:{Years}");
        }

        //public MyDate(int d, int m, int y)
        //{
        //    Days = d;
        //    Months = m;
        //    Years = y;
        //}
    }
    public class Student : Person, ICloneable, IComparable<Student>
    {
        public class NameComparer : IComparer<Student> // пример необобщённого интерфейса
        {
            public int Compare(this Student s, Student copy)
            {
                if (s.Name.Length > copy.Name.Length) return 1;
                if (s.Name.Length < copy.Name.Length) return -1;
                if (s.Name.Length == copy.Name.Length) return 0;                 
            }
            //public int Compare(Student x, Student y)
            //{
            //    if (x.CompareTo(y) != 0)
            //    {
            //        return x.CompareTo(y);
            //    }
            //    else
            //    {
            //        return 0;
            //    }
            //}
            //public int Compare(char a, char b)
            //{
            //    Student another = new Student();
            //    if (hometasks.Contains(a) == true &&
            //       another.hometasks.Contains(b) == true)
            //        return 1;
            //    if (hometasks.Contains(a) == true &&
            //      another.hometasks.Contains(b) == true)
            //        return -1;
            //    return a.CompareTo(b);
            //}
        }
        public class SurnameComparer : IComparer<Student> // пример необобщённого интерфейса
        {
            public int Compare(this Student s, Student copy)
            {
                if (s.Surname.Length > copy.Surname.Length) return 1;
                if (s.Surname.Length < copy.Surname.Length) return -1;
                if (s.Surname.Length == copy.Surname.Length) return 0;
            }
            //public int Compare(Student x, Student y)
            //{
            //    if (x.CompareTo(y) != 0)
            //    {
            //        return x.CompareTo(y);
            //    }
            //    else
            //    {
            //        return 0;
            //    }
            //}
            //public int Compare(char a, char b)
            //{
            //    Student another = new Student();
            //    if (hometasks.Contains(a) == true &&
            //       another.hometasks.Contains(b) == true)
            //        return 1;
            //    if (hometasks.Contains(a) == true &&
            //      another.hometasks.Contains(b) == true)
            //        return -1;
            //    return a.CompareTo(b);
            //}
        }
        List<int> hometasks = new List<int>();
        List<int> practices = new List<int>();
        List<int> exams = new List<int>();
        
        
        public void AddHometask(int rate)
        {

            if (rate > 12 || rate <= 0) throw new IndexOutOfRangeException();

            hometasks.Add(rate);
        }

        public void AddPractices(int rate)
        {
            if (rate > 12 || rate <= 0) throw new IndexOutOfRangeException();

            practices.Add(rate);
        }
        public void AddExams(int rate)
        {
            if (rate > 12 || rate <= 0) throw new IndexOutOfRangeException();

            exams.Add(rate);
        }

        public void PrintHometasks()
        {
            foreach (var i in hometasks)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine();
        }

        public double AverageHt()
        {
            double avg = 0;
            for (int i = 0; i < hometasks.Count; i++)
            {
                avg += hometasks[i];
            }
            avg /= hometasks.Count;
            return avg;
        }
        public void PrintPractices()
        {
            foreach (var i in practices)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine();
        }
        public double AveragePractices()
        {
            double avg2 = 0;
            for (int i = 0; i < practices.Count; i++)
            {
                avg2 += practices[i];
            }
            avg2 /= practices.Count;
            return avg2;

        }
        public void PrintExams()
        {
            foreach (var i in exams)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine();
        }
        public double AverageExams()
        {
            double avg3 = 0;
            for (int i = 0; i < exams.Count; i++)
            {
                avg3 += exams[i];
            }
            avg3 /= exams.Count;
            return avg3;

        }
        public override bool Equals(object Otsenka)
        {
            Student OtsenkaSt = Otsenka as Student;
            if (OtsenkaSt == null)
            {
                Console.WriteLine("OOPS! ETO NE PERSON!!!");
                return false;
            }
            return OtsenkaSt.hometasks == this.hometasks;
            //return OtsenkaSt.practices == this.practices;
            //return OtsenkaSt.exams == this.exams;
        }

        public static bool operator ==(Student left, Student right)
        {
            return left.AverageHt() == right.AverageHt();
            //return left.AveragePractices() == right.AveragePractices();
            //return left.AverageExams() == right.AverageExams();
        }

        public static bool operator !=(Student left, Student right)
        {
            return !(left == right);
        }
        public static bool operator >(Student left, Student right)
        {
            return left.AverageHt() > right.AverageHt();
            //return left.AveragePractices() > right.AveragePractices();
            //return left.AverageExams() > right.AverageExams();

        }
        public static bool operator <(Student left, Student right)
        {
            return left.AverageHt() < right.AverageHt();
            //return left.AveragePractices() < right.AveragePractices();
            //return left.AverageExams() < right.AverageExams();
        }
        public override int GetHashCode()
        {
            return -1062103556 + hometasks.GetHashCode();
            //return -1062104578 + practices.GetHashCode();
            //return -1062105063 + exams.GetHashCode();
        }

        public void Print2()
        {
            System.Console.WriteLine("ФИО : {0}\n{1}\n{2}", Name, Surname, Fathername);
            System.Console.WriteLine("Улица : {0}", Adresshome);
            System.Console.WriteLine("Телефон : {0}", Phonenumber);
            System.Console.WriteLine("День рождения : {1}", Birthday, new MyDate());
            System.Console.WriteLine("среднее арифметическое дз:{0}", AverageHt());
            PrintHometasks();
            PrintPractices();
            PrintExams();
            AverageHt();
            AveragePractices();
            AverageExams();
        }


        public Student(string name, string surname, string fathername) { }
        public Student() : this("Name", "Surname", "FN") { }
        public Student(string name, string surname, string fathername, string adresshome, string phonenumber)
        {
            SetName(name);
            SetSurname(surname);
            SetFathername(fathername);
            SetAddress(adresshome);
            SetPhoneNumber(phonenumber);
            SetBirthday(new MyDate());
            PrintHometasks();
            PrintPractices();
            PrintExams();
            AverageHt();
            AveragePractices();
            AverageExams();
        }
        public override string ToString()
        {
            return base.ToString() + ", среднее арифметическое дз: " + AverageHt() + "среднее арифметическое пр: " + AveragePractices();
        }

        public object Clone()
        {
            Student copy = new Student();
            copy.Name = this.Name;
            copy.Surname = this.Surname;
            copy.Fathername = this.Fathername;
            copy.Adresshome = this.Adresshome;
            copy.Birthday = this.Birthday;
            copy.Phonenumber = this.Phonenumber;
            return copy;
            //new Student(Name, Surname, Fathername, Adresshome, Phonenumber);
        }

        public int CompareTo(Student other)
        {
            if (this.AverageHt() < other.AverageHt()) return -1;
            if (this.AverageHt() > other.AverageHt()) return 1;
            if (this.AverageExams() < other.AverageExams()) return -1;
            if (this.AverageExams() > other.AverageExams()) return 1;
            if (this.AveragePractices() < other.AveragePractices()) return -1;
            if (this.AveragePractices() > other.AveragePractices()) return 1;


            return 0;
        }
        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                Student another = obj as Student;
                 if (this.Name == another.Name) return 0;
                 else if (this.Name != another.Name) return -1;
                 else return 1;

                return this.Name.CompareTo(another.Name);
            }
            else
            {
                throw new ArgumentException("bad type for parameter!");
            }
        }
    }

}

