using CrudApplicationwithMySql.Common_Utility;
using CrudApplicationwithMySql.CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplicationwithMySql.RepositoryLayer
{
    public class CrudApplicationRL : ICrudApplicationRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _mySqlConnection;
        public CrudApplicationRL(IConfiguration configuration)
        //dependancy injection of IConfiguration
        {
            _configuration = configuration;
            _mySqlConnection = new MySqlConnection(_configuration["ConnectionStrings:MySqlDBString"]);
        }

        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            AddInformationResponse response = new AddInformationResponse();
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }
                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.AddInformation, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    //we are getting text type from SqlQueries.xml
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@EmailID", request.EmailID);
                    sqlCommand.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@Gender", request.Gender);
                    sqlCommand.Parameters.AddWithValue("@Salary", request.Salary);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if(Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        return response;
                    }

                }

            }
            catch(Exception ex)
            {

            }
            return response ;
        }
    }
}
