using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        // create dependesi injection
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get() {
            string query = @"
                SELECT DepartmentId, DepartmentName
                FROM dbo.Department
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
        public JsonResult Post(Department dep) {
            string query = @"
                INSERT INTO dbo.Department
                VALUES (@DepartmentName)
            ";

            DataTable table = new DataTable();
            string slqDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(slqDataSource)) {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon)) {
                    myCommand.Parameters.AddWithValue("@DepartmentName",dep.DepartmentName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Berhasil Ditambahkan!");
        }

        [HttpPut]
        public JsonResult Put(Department dep) {
            string query = @"
                UPDATE dbo.Department
                SET DepartmentName = (@DepartmentName)
                WHERE DepartmentId = @DepartmentId
            ";

            DataTable table = new DataTable();
            string slqDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(slqDataSource)) {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon)) {
                    myCommand.Parameters.AddWithValue("@DepartmentId",dep.DepartmentId);
                    myCommand.Parameters.AddWithValue("@DepartmentName",dep.DepartmentName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Berhasil ubah data!");
        }

        [HttpDelete]
        public JsonResult Delete(int id) {
            string query = @"
                DELETE FROM dbo.Department
                WHERE DepartmentId = @DepartmentId
            ";

            DataTable table = new DataTable();
            string slqDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(slqDataSource)) {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon)) {
                    myCommand.Parameters.AddWithValue("@DepartmentId",id);
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