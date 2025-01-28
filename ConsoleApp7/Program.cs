using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConsoleApp7
{
    class Program
    {
        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {



            



            string dateAndTime = DateTime.Now.ToShortDateString();
            string sPath = "D:/Log/TodayReport-"+ dateAndTime + ".txt";
            string currenttime = "Tool Started : "+ DateTime.Now.ToShortTimeString();

            StreamWriter sw = File.CreateText(sPath);

            sw.WriteLine(currenttime);
            sw.Flush();
            sw.Close();
            StreamWriter sw_new = File.AppendText(sPath);
            sw_new.WriteLine(currenttime);
            sw_new.Flush();
            sw_new.Close();
                



            List<Student> studentList = new List<Student>() {
        new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
        new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
        new Student() { StudentID = 4, StudentName = "Ram" , Age = 18} ,
        new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
    };
            //var result = from student in studentList where student.StudentID == 2 || student.StudentID==4
            //             orderby student.StudentID descending
            //             select student;

            var result = from student in studentList
                          group student
                         by student.Age;

            //            List<string> stringList = new List<string>() {
            //    "C# Tutorials",
            //    "VB.NET Tutorials",
            //    "Learn C++",
            //    "Learn C#",
            //    "MVC Tutorials" ,
            //    "Java"
            //};
            //            var result = from course in stringList
            //                         where course.Contains("C#")
            //                         select course;
            //            List<string> output = result.ToList();
            //            for(int i=0;i< output.Count();i++)
            //            {
            //                Console.WriteLine(output[i]);
            //            }
            //            Console.WriteLine("method");
            //            result = stringList.Where(s => s.StartsWith("C#"));
            //            output = result.ToList();
            //            for (int i = 0; i < output.Count(); i++)
            //            {
            //                Console.WriteLine(output[i]);
            //            }
            //            Console.ReadLine();

            //foreach (var student in result)
            //    Console.WriteLine(student.StudentID + ", " + student.StudentName);
            foreach (var ageGroup in result)
            {
                Console.WriteLine("Age Group: {0}", ageGroup.Key); //Each group has a key 

                foreach (Student s in ageGroup) // Each group has inner collection
                    Console.WriteLine(s.StudentID + ", " + s.StudentName+","+s.Age); // not needed this line
            }
            Console.WriteLine("method");
           var results = studentList.Where(s => s.StudentID ==2 || s.StudentID==4).OrderByDescending(s=>s.StudentID);
            foreach (var student in results)
                Console.WriteLine(student.StudentID + ", " + student.StudentName);

            for(int i=0;i<results.Count();i++)
                Console.WriteLine(results.ElementAt(i).StudentID + ", " + results.ElementAt(i).StudentName);
            Console.ReadLine();
        }
    }
}
