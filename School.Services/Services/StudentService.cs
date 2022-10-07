﻿using School.Data;
using School.Data.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Services
{
    public interface IStudentService
    {
        Student CreateStudent(string name);
        ICollection<Student> GetStudents();
        Student GetStudentById(int id);      
        Student UpdateStudent(Student student, string name);
        bool DeleteStudent(int id);
    }


    public class StudentService : IStudentService
    {
        private readonly SchoolDbContext _context;

        public StudentService(SchoolDbContext context)
        {
            _context = context;
        }

        public Student CreateStudent(string name)
        {
            var student = new Student
            {
                Name = name
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return student;
        }

        public ICollection<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }

        public Student UpdateStudent(Student student, string name)
        {
            student.Name = name;

            _context.Students.Update(student);
            _context.SaveChanges();

            return student;
        } 
        
        public bool DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);

            if(student == null)
            {
                return false;
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return true;
        }
    }
}
