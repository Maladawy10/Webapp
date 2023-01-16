using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using SchoolDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        //public StudentController(ApplicationDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}


        //[HttpGet("GetStudents")]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        var students = this.dbContext.Students.ToList();
        //        if(students.Count==0)
        //        {
        //            return StatusCode(404, "No students found");
        //        }
        //    return Ok(students);
        //    }
        //    catch(Exception)
        //    {
        //        return StatusCode(500, "An error has occurred");
        //    }
        //}

        //[HttpPost("InsertStudents")]
        //public IActionResult Post([FromBody] StudentRequest studentRequest)
        //{
        //    Student student = new Student();
        //    student.SSN = studentRequest.SSN;
        //    student.Name = studentRequest.Name;
        //    student.Birthdate = studentRequest.Birthdate;
        //    student.Gender = studentRequest.Gender;
            
        //    try
        //    {
        //        this.dbContext.Students.Add(student);
        //        this.dbContext.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "An error has occurred");
        //    }
        //    var students = this.dbContext.Students.ToList();
        //    return Ok(students);
        //}
        //[HttpPut("UpdateStudents")]
        //public IActionResult Put([FromBody] StudentRequest studentRequest)
        //{
        //    try
        //    {
        //        var student = this.dbContext.Students.FirstOrDefault(x=>x.SSN==studentRequest.SSN);
        //        if(student == null)
        //        {
        //            return StatusCode(404, "No students found");
        //        }
        //        student.SSN = studentRequest.SSN;
        //        student.Name = studentRequest.Name;
        //        student.Birthdate = studentRequest.Birthdate;
        //        student.Gender = studentRequest.Gender;
        //        this.dbContext.Entry(student).State=EntityState.Modified;
        //        this.dbContext.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "An error has occurred");
        //    }
        //    var students = this.dbContext.Students.ToList();
        //    return Ok(students);
        //}
        //[HttpDelete("DeleteStudents")]
        //public IActionResult Delete([FromBody] int SSN)
        //{
        //    try
        //    {
        //        var student = this.dbContext.Students.FirstOrDefault(x => x.SSN == SSN);
        //        if (student == null)
        //        {
        //            return StatusCode(404, "No students found");
        //        }
        //        this.dbContext.Entry(student).State = EntityState.Deleted;
        //        this.dbContext.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "An error has occurred");
        //    }
        //    var students = this.dbContext.Students.ToList();
        //    return Ok(students);
        //}







        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select SSN,Name,convert(varchar(10),Birthdate,120) as Birthdate,Gender from dbo.Students";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("StudentAppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, mycon))
                {
                    sqlDataReader = sqlCommand.ExecuteReader();
                    table.Load(sqlDataReader);
                    sqlDataReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Student student)
        {
            string query = @"
                    insert into dbo.Students 
                    (Name,Birthdate,Gender)
                    values 
                    (
                    '" + student.Name + @"'
                    ,'" + student.Birthdate + @"'
                    ,'" + student.Gender + @"'
                    )
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("StudentAppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, mycon))
                {
                    sqlDataReader = sqlCommand.ExecuteReader();
                    table.Load(sqlDataReader);
                    sqlDataReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Student student)
        {
            string query = @"update dbo.Students set Name='" + student.Name + @"',
                                                     Birthdate='" + student.Birthdate + @"',
                                                     Gender='" + student.Gender + @"' where SSN=" + student.SSN + @"";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("StudentAppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, mycon))
                {
                    sqlDataReader = sqlCommand.ExecuteReader();
                    table.Load(sqlDataReader);
                    sqlDataReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        private readonly IConfiguration configuration;

        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpDelete("{SSN}")]
        public JsonResult Delete(int SSN)
    {
        string query = @"Delete from dbo.Students where SSN=" + SSN + @"";
        DataTable table = new DataTable();
        string sqlDataSource = configuration.GetConnectionString("StudentAppCon");
        SqlDataReader sqlDataReader;
        using (SqlConnection mycon = new SqlConnection(sqlDataSource))
        {
            mycon.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, mycon))
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                table.Load(sqlDataReader);
                sqlDataReader.Close();
                mycon.Close();
            }
        }
        return new JsonResult("Deleted Successfully");
    }
}
}
