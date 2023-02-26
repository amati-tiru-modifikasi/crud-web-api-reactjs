using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // create dependesi injection
        private readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get() {
            string query = @"
                SELECT EmployeeId, EmployeeName, Department,
                CONVERT(varchar(10), DateOfJoining, 120) as DateOfJoining, PhotoFileName
                FROM dbo.Employee
            ";

            DataTable table = new DataTable();
            string slqDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(slqDataSource)) {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon)) {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Employee empl) {
            string query = @"
                INSERT INTO dbo.Employee
                (EmployeeName, Department, DateOfJoining, PhotoFileName)
                VALUES (@EmployeeName, @Department, @DateOfJoining, @PhotoFileName)
            ";

            DataTable table = new DataTable();
            string slqDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(slqDataSource)) {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon)) {
                    myCommand.Parameters.AddWithValue("@EmployeeName",empl.EmployeeName);
                    myCommand.Parameters.AddWithValue("@Department",empl.Department);
                    myCommand.Parameters.AddWithValue("@DateOfJoining",empl.DateOfJoining);
                    myCommand.Parameters.AddWithValue("@PhotoFileName",empl.PhotoFileName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Berhasil Ditambahkan!");
        }

        [HttpPut]
        public JsonResult Put(Employee empl) {
            string query = @"
                UPDATE dbo.Employee
                SET 
                    EmployeeName = (@EmployeeName),
                    Department = (@Department),
                    DateOfJoining = (@DateOfJoining),
                    PhotoFileName = (@PhotoFileName)
                WHERE EmployeeId = @EmployeeId
            ";

            DataTable table = new DataTable();
            string slqDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(slqDataSource)) {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon)) {
                    myCommand.Parameters.AddWithValue("@EmployeeId",empl.EmployeeId);
                    myCommand.Parameters.AddWithValue("@EmployeeName",empl.EmployeeName);
                    myCommand.Parameters.AddWithValue("@Department",empl.Department);
                    myCommand.Parameters.AddWithValue("@DateOfJoining",empl.DateOfJoining);
                    myCommand.Parameters.AddWithValue("@PhotoFileName",empl.PhotoFileName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Berhasil ubah data!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id) {
            string query = @"
                DELETE FROM dbo.Employee
                WHERE EmployeeId = @EmployeeId
            ";

            DataTable table = new DataTable();
            string slqDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(slqDataSource)) {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon)) {
                    myCommand.Parameters.AddWithValue("@EmployeeId",id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Berhasil dihapus!");
        }

    }
}