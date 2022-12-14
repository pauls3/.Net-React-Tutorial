/*
        API Methods for department table on sql database
*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using API_Tutorial.Models;

namespace API_Tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // API method to get department details
        [HttpGet]
        public JsonResult Get()
        {
            string spName = @"departmentGet";

            DataTable table = new DataTable();

            // variable that stores database connection string
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(spName, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }


            /*string query = @"
                           select DepartmentId, DepartmentName from dbo.Department
                           ";

            DataTable table = new DataTable();
            */
            // variable that stores database connection string
            /*string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }*/

            return new JsonResult(table);
        }



        // Insert query
        [HttpPost]
        public JsonResult Post(Department dep)
        {
            string spName = @"departmentPost";

            DataTable table = new DataTable();

            // variable that stores database connection string
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(spName, myCon))
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@DepartmentName";
                    param1.SqlDbType = SqlDbType.VarChar;
                    param1.Value = dep.DepartmentName;
                    myCommand.Parameters.Add(param1);

                    myCommand.CommandType = CommandType.StoredProcedure;

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }



            /*
            string query = @"
                           insert into dbo.Department values
                           ('"+dep.DepartmentName+@"')
                           ";

            DataTable table = new DataTable();

            // variable that stores database connection string
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }*/

            return new JsonResult("Added Successfully");
        }




        // Update query/put method
        [HttpPut]

        public JsonResult Put(Department dep)
        {
            string spName = @"departmentUpdate";

            DataTable table = new DataTable();

            // variable that stores database connection string
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(spName, myCon))
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@DepartmentId";
                    param1.SqlDbType = SqlDbType.VarChar;
                    param1.Value = dep.DepartmentId;

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@DepartmentName";
                    param2.SqlDbType = SqlDbType.VarChar;
                    param2.Value = dep.DepartmentName;

                    myCommand.Parameters.Add(param1);
                    myCommand.Parameters.Add(param2);

                    myCommand.CommandType = CommandType.StoredProcedure;

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            /*
            string query = @"
                            update dbo.Department set 
                            DepartmentName = '" + dep.DepartmentName + @"'
                            where DepartmentId = '" + dep.DepartmentId + @"'
                            ";

            DataTable table = new DataTable();

            // variable that stores database connection string
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }*/

            return new JsonResult("Updated Successfully");
        }



        // Delete method
        // Receives id as input

        // id in url, so it needs to be in root parameter
        //[HttpDelete]
        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            string spName = @"departmentDelete";

            DataTable table = new DataTable();

            // variable that stores database connection string
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(spName, myCon))
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@DepartmentId";
                    param1.SqlDbType = SqlDbType.VarChar;
                    param1.Value = id;

                    myCommand.Parameters.Add(param1);

                    myCommand.CommandType = CommandType.StoredProcedure;

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            /*
            string query = @"
                            delete from dbo.Department
                            where DepartmentId = '" + dep.DepartmentId + @"' and
                            DepartmentName = '" + dep.DepartmentName + @"'
                            ";

            DataTable table = new DataTable();

            // variable that stores database connection string
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            */

            return new JsonResult("Deleted Successfully");
        }
    }
}
