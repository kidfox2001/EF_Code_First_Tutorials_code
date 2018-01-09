using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Code_First_Tutorials;

namespace ConsoleApplication1
{
    class Program
    {
        // เปิดดูที่ objct sql server

        static void Main(string[] args)
        {

            try
            {
                using (var ctx = new SchoolContext())
                {
                    Student stud = new Student() { StudentName = "New Student2" };

                    ctx.Students.Add(stud);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Console.WriteLine("finnish");
                Console.ReadLine();
            }

        }
    }
}
