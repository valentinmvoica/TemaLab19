using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataLayer
    {
        private string connectionString;
        public DataLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Student> GetAllStudents()
        {
            using var ctx = new CatalogueDbContext(this.connectionString);
            return ctx.Students.Include(s=>s.Address).ToList();
        }
        public Student GetStudentById(int studentId)
        {
            using var ctx = new CatalogueDbContext(this.connectionString);
            return ctx.Students.Where(s => s.Id == studentId).FirstOrDefault();
        }
        public Student CreateStudent(Student studentToCreate)
        {
            var student = new Student { FirstName = studentToCreate.FirstName, LastName = studentToCreate.LastName, Age = studentToCreate.Age };
            using var ctx = new CatalogueDbContext(this.connectionString);

            ctx.Add(student);
            ctx.SaveChanges();
            return student;
        }
        public void DeleteStudent(int studentId, bool deleteAddress)
        {
            using var ctx = new CatalogueDbContext(this.connectionString);

            var student = ctx.Students
                .Include(student => student.Address)
                .Where(s => s.Id == studentId)
                .FirstOrDefault();

            if (student == null)
            {
                return;
            }

            if (!deleteAddress)
            {
                if (student.Address != null)
                {
                    student.Address.StudentId = null;
                    student.Address = null;
                }
            }
            else
            {
                if (student.Address != null)
                {
                    ctx.Remove(student.Address);
                }
            }

            ctx.Remove(student);
            ctx.SaveChanges();
        }
        public void ChangeStudentData(int studentId, Student newStudentData)
        {
            using var ctx = new CatalogueDbContext(this.connectionString);
            var student = ctx.Students.FirstOrDefault(s => s.Id == studentId);

            if (student == null)
                return;

            student.FirstName = newStudentData.FirstName;
            student.LastName = newStudentData.LastName;
            student.Age = newStudentData.Age;

            ctx.SaveChanges();
        }
        public void ChangeStudentAddress(int studentId, Address newAddress)
        {
            using var ctx = new CatalogueDbContext(this.connectionString);
            
            var student = ctx.Students.Include(s=>s.Address).FirstOrDefault(s => s.Id == studentId);
            if (student.Address==null)
            {
                student.Address = new Address();
            }

            student.Address.City = newAddress.City;
            student.Address.Street = newAddress.Street;
            student.Address.Number = newAddress.Number;

            ctx.SaveChanges();
        }
    }
}
