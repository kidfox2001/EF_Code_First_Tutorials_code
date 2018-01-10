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
        // เปิดดูที่ object sql server

        static void Main(string[] args)
        {

            try
            {
                using (var ctx = new SchoolContext())
                {
                    Student stud = new Student() { StudentName = "New Student2" };

                    //ctx.Students.Add(stud);

                    Standard std = new Standard() { StandardName = "Test1", StandardId = 1 };
                    std.Students.Add(stud);

                    ctx.Standards.Add(std);
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
