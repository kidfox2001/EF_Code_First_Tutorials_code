﻿using System;
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

    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }

    }


    public class Student
    {
        public Student()
        {

        }
        public int StudentID { get; set; } // default ชื่อคี <class name>Id จะมองว่าเป็น key
        public string StudentName { get; set; }
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
