/*
 *  API methods on employee screen.
 */


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using API_Tutorial.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Runtime.Intrinsics.Arm;


namespace API_Tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // API method to get department details
        [HttpGet]
        public JsonResult Get()
        {
            string spName = @"employeeGet";

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

            return new JsonResult(table);

            /*
            string query = @"
                            select EmployeeId, EmployeeName, Department,
                            convert(varchar(10), DateOfJoining, 120) as DateOfJoining,
                            PhotoFileName
                            from dbo.Employee
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

            return new JsonResult(table);
            */
        }



        // Insert query
        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            string spName = @"employeePost";

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
                    param1.ParameterName = "@EmployeeName";
                    param1.SqlDbType = SqlDbType.VarChar;
                    param1.Value = emp.EmployeeName;

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@Department";
                    param2.SqlDbType = SqlDbType.VarChar;
                    param2.Value = emp.Department;

                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@DateOfJoining";
                    param3.SqlDbType = SqlDbType.Date;
                    param3.Value = emp.DateOfJoining;
                    //param3.Value = DateOnly.ParseExact();

                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@PhotoFileName";
                    param4.SqlDbType = SqlDbType.VarChar;
                    param4.Value = emp.PhotoFileName;

                    myCommand.Parameters.Add(param1);
                    myCommand.Parameters.Add(param2);
                    myCommand.Parameters.Add(param3);
                    myCommand.Parameters.Add(param4);

                    myCommand.CommandType = CommandType.StoredProcedure;

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            /*
            string query = @"
                            insert into dbo.Employee
                            (EmployeeName,Department,DateOfJoining,PhotoFileName)
                            values
                            (
                            '" + emp.EmployeeName + @"',
                            '" + emp.Department + @"',
                            '" + emp.DateOfJoining + @"',
                            '" + emp.PhotoFileName + @"'
                            )
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

            return new JsonResult("Added Successfully");
        }




        // Update query/put method
        [HttpPut]

        public JsonResult Put(Employee emp)
        {
            string spName = @"employeeUpdate";

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
                    param1.ParameterName = "@EmployeeName";
                    param1.SqlDbType = SqlDbType.VarChar;
                    param1.Value = emp.EmployeeName;

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@Department";
                    param2.SqlDbType = SqlDbType.VarChar;
                    param2.Value = emp.Department;

                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@DateOfJoining";
                    param3.SqlDbType = SqlDbType.Date;
                    param3.Value = emp.DateOfJoining;

                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@PhotoFileName";
                    param4.SqlDbType = SqlDbType.VarChar;
                    param4.Value = emp.PhotoFileName;

                    SqlParameter param5 = new SqlParameter();
                    param5.ParameterName = "@EmployeeId";
                    param5.SqlDbType = SqlDbType.VarChar;
                    param5.Value = emp.EmployeeID;

                    myCommand.Parameters.Add(param1);
                    myCommand.Parameters.Add(param2);
                    myCommand.Parameters.Add(param3);
                    myCommand.Parameters.Add(param4);
                    myCommand.Parameters.Add(param5);

                    myCommand.CommandType = CommandType.StoredProcedure;

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }


            /*
            string query = @"
                            update dbo.Employee set 
                            EmployeeName = '" + emp.EmployeeName + @"',
                            Department = '" + emp.Department + @"',
                            DateOfJoining = '" + emp.DateOfJoining + @"',
                            PhotoFileName = '" + emp.PhotoFileName + @"'
                            where EmployeeId = '" + emp.EmployeeID + @"'
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

            return new JsonResult("Updated Successfully");
        }



        // Delete method
        // Receives id as input

        // id in url, so it needs to be in root parameter
        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            string spName = @"employeeDelete";

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
                    param1.ParameterName = "@EmployeeId";
                    param1.SqlDbType = SqlDbType.Int;
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
                            delete from dbo.Employee
                            where EmployeeId = '" + id + @"'
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



        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;

                using(var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(fileName);
            }
            // If there is any exception, return default anonymous.png file
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }



        // Drop down menu to get departments for employee
        [Route("GetAllDepartmentNames")]
        [HttpGet]
        public JsonResult GetAllDepartmentNames()
        {
            string spName = @"departmentNamesGet";

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

            /*
            string query = @"
                            select DepartmentName from dbo.Department
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

            return new JsonResult(table);
        }
    }
}
