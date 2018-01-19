using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Code_First_Tutorials
{
    // ค่า default พื้นฐานที่ ef จะ gen ให้ ดูที่ http://www.entityframeworktutorial.net/code-first/code-first-conventions.aspx
    // ดูเรื่องการแตก table inheritance ที่ http://www.entityframeworktutorial.net/code-first/inheritance-strategy-in-code-first.aspx
    // Data Annotations http://www.entityframeworktutorial.net/code-first/dataannotation-in-code-first.aspx
    // Fluent API http://www.entityframeworktutorial.net/code-first/fluent-api-in-code-first.aspx
    // วิธี gen from database http://www.entityframeworktutorial.net/code-first/code-first-from-existing-database.aspx
    // แบ่ง Fluent API เป็นส่วนๆ http://www.entityframeworktutorial.net/code-first/move-configurations-to-seperate-class-in-code-first.aspx
    // รูปแแบบการสร้างดาต้าเบส http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx


    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base()
        {

            //Disable initializer ตัวอย่างการปิดการ auto create database
            //Database.SetInitializer<SchoolContext>(null);
        }
         
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }

        // Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            //modelBuilder.HasDefaultSchema("Admin");


            //Map entity to table
            //modelBuilder.Entity<Student>().ToTable("StudentInfo");
            //modelBuilder.Entity<Standard>().ToTable("StandardInfo", "dbo");


            // exe 1
            //modelBuilder.Entity<Student>().Map(m =>
            //{
            //    m.Properties(p => new { p.StudentId, p.StudentName });
            //    m.ToTable("StudentInfo");

            //}).Map(m =>
            //{
            //    m.Properties(p => new { p.StudentId, p.Height, p.Weight, p.Photo, p.DateOfBirth });
            //    m.ToTable("StudentInfoDetail");

            //});

            //modelBuilder.Entity<Standard>().ToTable("StandardInfo");
        }

    }

    public class Student
    {
        public Student()
        {

        }

        //[Key]
        //public int StudentKey { get; set; }

        // [Column(Order = 0)] ไว้ใช้เรียงลำดับ column ใน design
        public int StudentID { get; set; } // default ชื่อคี <class name>Id จะมองว่าเป็น key
        [Column("Name")]
        public string StudentName { get; set; }
        [Column("DoB", TypeName = "DateTime2")]
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        //Foreign key for Standard แบบนี้ฟิกชื่อ foreign key ให้
        public int StandardId { get; set; }
        public Standard Standard { get; set; }

        //Foreign key for Standard แบบนี้จะ gen foreign key ให้
        //public Standard Standard { get; set; }


    }

    [Table("StandardMaster")] // DataAnnotations
    public class Standard
    {
        public Standard()
        {

        }
        public int StandardId { get; set; }
        public string StandardName { get; set; }

        // Navigation properties are typically defined as virtual so that they can take advantage of certain Entity Framework functionality such as lazy loading
        public virtual ICollection<Student> Students { get; set; }

    }

}
