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
    public class SubjectController : ControllerBase
    {
        //private ApplicationDbContext dbContext;

        //public SubjectController(ApplicationDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}



        //[HttpGet("GetSubjects")]
        //public IActionResult Get()
        //{

        //    try
        //    {
        //        var subjects = this.dbContext.Subjects.ToList();
        //        if (subjects.Count == 0)
        //        {
        //            return StatusCode(404, "No subjects found");
        //        }
        //        return Ok(subjects);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "An error has occurred");
        //    }
        //}

        //[HttpPost("InsertSubjects")]
        //public IActionResult Post([FromBody] SubjectRequest subjectRequest)
        //{
        //    Subject subject = new Subject();
        //    subject.Name = subjectRequest.Name;
        //    subject.Description = subjectRequest.Description;

        //    try
        //    {
        //        this.dbContext.Subjects.Add(subject);
        //        this.dbContext.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "An error has occurred");
        //    }
        //    var subjects = this.dbContext.Subjects.ToList();
        //    return Ok(subjects);
        //}
        //[HttpPut("UpdateSubjects")]
        //public IActionResult Put([FromBody] SubjectRequest subjectRequest)
        //{
        //    try
        //    {
        //        var subject = this.dbContext.Subjects.FirstOrDefault(x => x.Name == subjectRequest.Name);
        //        if (subject == null)
        //        {
        //            return StatusCode(404, "No subjects found");
        //        }
        //        subject.Name = subjectRequest.Name;
        //        subject.Description = subjectRequest.Description;
        //        this.dbContext.Entry(subject).State = EntityState.Modified;
        //        this.dbContext.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "An error has occurred");
        //    }
        //    var subjects = this.dbContext.Subjects.ToList();
        //    return Ok(subjects);
        //}
        //[HttpDelete("DeleteSubjects")]
        //public IActionResult Delete([FromBody]string Name)
        //{
        //    try
        //    {
        //        var subject = this.dbContext.Subjects.FirstOrDefault(x => x.Name == Name);
        //        if (subject == null)
        //        {
        //            return StatusCode(404, "No subjects found");
        //        }
        //        this.dbContext.Entry(subject).State = EntityState.Deleted;
        //        this.dbContext.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "An error has occurred");
        //    }
        //    var subjects = this.dbContext.Subjects.ToList();
        //    return Ok(subjects);
        //}

























        private readonly IConfiguration configuration;

        public SubjectController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select Name,Description from dbo.Subjects";
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
        public JsonResult Post(Subject subject)
        {
            string query = @"insert into  dbo.Subjects values ('" + subject.Name + @"','" + subject.Description + @"')";
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
        public JsonResult Put(Subject subject)
        {
            string query = @"update dbo.Subjects set Description = '" + subject.Description + @"' where Name = '" + subject.Name + @"'
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
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{Name}")]
        public JsonResult Delete(string Name)
        {
            string query = @"Delete from dbo.Subjects where Name='" + Name + @"'";
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
