using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace UserPhoneNumber
{
    public enum IstructionState
    {
        Success,
        Error,
        NotCompleted

    }
    public class UserAction
    {
        protected string _ConnectionString;
        protected int UserID;
        public IstructionState RequestState;
        public UserAction(string Connection)
        {
            UserID = GetNewUserID();
            _ConnectionString = Connection;
            RequestState = IstructionState.Success;
        }
        /// <summary>
        /// Registra un utente sulla tabella sql
        /// </summary>
        protected async Task RegisterUser(UserNumber userNumber)
        {
            RequestState = IstructionState.NotCompleted;
            using (var con = new SqlConnection(this._ConnectionString))
            {
                try
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                        con.Open();

                    var cmd = new SqlCommand("PB_InsertNewUser", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var result = await cmd.ExecuteNonQueryAsync();
                    if (result > 0)// più di o righe modificate
                    {
                        RequestState = IstructionState.Success;
                    }
                }
                catch (Exception ex)
                {
                    RequestState = IstructionState.Error;
                }
                finally
                {
                    con.Close();
                }

            }
            //commando di insert tabella
            //registra un uten
        }

        public void DelateUser(int userid)
        {
            //cancello dall 'id
        }

        /// <summary>
        /// Genera un nuovo user ID 
        /// </summary>
        /// <returns></returns>
        private int GetNewUserID()
        {
            // apre una connessione e fa il max +1 della coloinna user    
            return 0;
        }

        public async Task<IEnumerable<UserNumber>> LoadUserList()
        {
            List<UserNumber> userlist = new List<UserNumber>();

            RequestState = IstructionState.NotCompleted;
            using (var con = new SqlConnection(this._ConnectionString))
            {
                try
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                        con.Open();

                    var cmd = new SqlCommand("Select * from [PHONE BOOK].[dbo].[CompanyPhoneNumber]", con);
                    
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {


                        userlist.Add(new UserNumber()
                        {
                            userID = int.Parse(reader["UserID"].ToString()),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            MobileNumber = reader["MobilePhoneNumber"].ToString(),
                            Department = reader["Department"].ToString(),
                            InternalNumber = reader["InternalNumber"].ToString(),

                        }); 
                    }                    
                    RequestState = IstructionState.Success;                   
                                     
                    
                }
                catch (Exception ex)
                {
                    RequestState = IstructionState.Error;
                }
                finally
                {
                    con.Close();
                }
                return userlist;

            }




        }



    }
}
