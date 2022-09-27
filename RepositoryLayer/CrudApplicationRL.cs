﻿using CrudApplicationwithMySql.Common_Utility;
using CrudApplicationwithMySql.CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrudApplicationwithMySql.RepositoryLayer
{
    public class CrudApplicationRL : ICrudApplicationRL
    {
        public readonly IConfiguration _configuration;
        public readonly ILogger<CrudApplicationRL> _logger;
        public readonly MySqlConnection _mySqlConnection;
        public CrudApplicationRL(IConfiguration configuration, ILogger<CrudApplicationRL> logger)
        //dependancy injection of IConfiguration
        {
            _configuration = configuration;
            _logger = logger;
            _mySqlConnection = new MySqlConnection(_configuration["ConnectionStrings:MySqlDBString"]);
        }

        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            _logger.LogInformation("AddInformation Method calling in Repository layer");
            AddInformationResponse response = new AddInformationResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
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
                        _logger.LogError("Query not executed");
                        return response;
                    }

                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"error occurred at information repository layer {ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response ;
        }

        public async Task<DeleteAllInActiveInformationResponse> DeleteAllInActiveInformation()
        {
            {
                _logger.LogInformation("DeleteAllInActiveInformation Method calling in Repository layer");
                DeleteAllInActiveInformationResponse response = new DeleteAllInActiveInformationResponse();
                response.IsSuccess = true;
                response.Message = "Successful";
                try
                {
                    if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        await _mySqlConnection.OpenAsync();
                    }
                    using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.DeleteAllInActiveInformation, _mySqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        //we are getting text type from SqlQueries.xml
                        sqlCommand.CommandTimeout = 180;
                        int Status = await sqlCommand.ExecuteNonQueryAsync();
                        if (Status <= 0)
                        {
                            response.IsSuccess = false;
                            response.Message = "Query Not Executed";
                            _logger.LogError("Query not executed");
                            return response;
                        }

                    }
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = ex.Message;
                    _logger.LogError($"error occurred at DeleteAllInActiveInformation repository layer {ex.Message}");
                }
                finally
                {
                    await _mySqlConnection.CloseAsync();
                    await _mySqlConnection.DisposeAsync();
                }
                return response;
            }
        }

        public async Task<DeleteInformationByIdResponse> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            _logger.LogInformation("DeleteInformationById Method calling in Repository layer");
            DeleteInformationByIdResponse response = new DeleteInformationByIdResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }
                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.DeleteAllInActiveInformation, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    //we are getting text type from SqlQueries.xml
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserID", request.UserID);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError("Query not executed");
                        return response;
                    }

                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"error occurred at DeleteInformationById repository layer {ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<GetDeleteAllInformationResponse> GetDeleteAllInformation()
        {
            GetDeleteAllInformationResponse response = new GetDeleteAllInformationResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                _logger.LogInformation("GetDeleteAllInformation Data Access Layer Calling...");
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }
                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.GetDeleteAllInformation, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.getDeleteAllInformation = new List<GetDeleteAllInformation>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetDeleteAllInformation getdata = new GetDeleteAllInformation();
                                    getdata.UserID = dataReader["UserId"] != DBNull.Value ? Convert.ToInt32(dataReader["UserId"]) : 0;
                                    getdata.UserName = dataReader["UserName"] != DBNull.Value ? Convert.ToString(dataReader["UserName"]) : string.Empty;
                                    getdata.EmailId = dataReader["EmailID"] != DBNull.Value ? Convert.ToString(dataReader["EmailId"]) : string.Empty;
                                    getdata.Salary = dataReader["Salary"] != DBNull.Value ? Convert.ToInt32(dataReader["Salary"]) : 0;
                                    getdata.MobileNumber = dataReader["MobileNumber"] != DBNull.Value ? Convert.ToString(dataReader["MobileNumber"]) : string.Empty;
                                    getdata.Gender = dataReader["Gender"] != DBNull.Value ? Convert.ToString(dataReader["Gender"]) : string.Empty;

                                    response.getDeleteAllInformation.Add(getdata);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record not found";
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError("GetDeleteAllInformation Error Occur : Message : " + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError("GetDeleteAllInformation Error Occur : Message : " + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<ReadAllInformationResponse> ReadAllInformation()
        {
            ReadAllInformationResponse response = new ReadAllInformationResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }
                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.ReadAllInformation, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.readAllInformation = new List<GetReadAllInformation>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetReadAllInformation getdata = new GetReadAllInformation();
                                    getdata.UserID = dataReader["UserId"] != DBNull.Value ? Convert.ToInt32(dataReader["UserId"]) : 0;
                                    getdata.UserName = dataReader["UserName"] != DBNull.Value ? Convert.ToString(dataReader["UserName"]) : string.Empty;
                                    getdata.EmailID = dataReader["EmailID"] != DBNull.Value ? Convert.ToString(dataReader["EmailId"]) : string.Empty;
                                    getdata.Salary = dataReader["Salary"] != DBNull.Value ? Convert.ToInt32(dataReader["Salary"]) : 0;
                                    getdata.MobileNumber = dataReader["MobileNumber"] != DBNull.Value ? Convert.ToString(dataReader["MobileNumber"]) : string.Empty;
                                    getdata.Gender = dataReader["Gender"] != DBNull.Value ? Convert.ToString(dataReader["Gender"]) : string.Empty;
                                    getdata.IsActive = dataReader["IsActive"] != DBNull.Value ? Convert.ToBoolean(dataReader["IsActive"]) : false;

                                    response.readAllInformation.Add(getdata);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record not found/ Database Empty";
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError("GetAllInformation Error Occur : Message : " + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();
                    }
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError("GetAllInformation Error Occur : Message : " + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<ReadInformationByIdResponse> ReadInformationById(ReadInformationByIdRequest request)
        {
            ReadInformationByIdResponse response = new ReadInformationByIdResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }
                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.ReadInformationById, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;
                        sqlCommand.Parameters.AddWithValue("UserID",request.UserID);

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.readAllInformation = new List<GetReadAllInformation>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetReadAllInformation getdata = new GetReadAllInformation();
                                    getdata.UserID = dataReader["UserId"] != DBNull.Value ? Convert.ToInt32(dataReader["UserId"]) : 0;
                                    getdata.UserName = dataReader["UserName"] != DBNull.Value ? Convert.ToString(dataReader["UserName"]) : string.Empty;
                                    getdata.EmailID = dataReader["EmailID"] != DBNull.Value ? Convert.ToString(dataReader["EmailId"]) : string.Empty;
                                    getdata.Salary = dataReader["Salary"] != DBNull.Value ? Convert.ToInt32(dataReader["Salary"]) : 0;
                                    getdata.MobileNumber = dataReader["MobileNumber"] != DBNull.Value ? Convert.ToString(dataReader["MobileNumber"]) : string.Empty;
                                    getdata.Gender = dataReader["Gender"] != DBNull.Value ? Convert.ToString(dataReader["Gender"]) : string.Empty;
                                    getdata.IsActive = dataReader["IsActive"] != DBNull.Value ? Convert.ToBoolean(dataReader["IsActive"]) : false;

                                    response.readAllInformation.Add(getdata);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record not found/ Database Empty";
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError("GetAllInformation Error Occur : Message : " + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError("GetAllInformation Error Occur : Message : " + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<UpdateAllInformationByIdResponse> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            _logger.LogInformation("UpdateAllInformationById Method calling in Repository layer");
            UpdateAllInformationByIdResponse response = new UpdateAllInformationByIdResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }
                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.UpdateAllInformationById, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    //we are getting text type from SqlQueries.xml
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserID", request.UserId);
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@EmailID", request.EmailID);
                    sqlCommand.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@Gender", request.Gender);
                    sqlCommand.Parameters.AddWithValue("@Salary", request.Salary);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError("Query not executed");
                        return response;
                    }

                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"error occurred at UpdateAllInformationById repository layer {ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }
    }
}
