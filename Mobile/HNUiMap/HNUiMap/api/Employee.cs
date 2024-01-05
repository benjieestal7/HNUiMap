using HNUiMap.core;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HNUiMap.api
{
   public class Employee
    {
        public static bool LoginIsSuccessfull = false;
        public static string LoginErrorMessage = string.Empty;
        public static DataTable Login(string Username, string Password)
        {
            DataSet dt = new DataSet();
            try
            {
                string requestURL = PublicVariables.APIBaseURL + "account/login";
               RestClient client = new RestClient(requestURL)
                {
                //    Authenticator = new HttpBasicAuthenticator(PublicVariables.APIAuthUsername, PublicVariables.APIAuthPassword)
                };
                var request = new RestRequest(Method.POST);

                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("username", Username);
                request.AddParameter("password", Password);

                IRestResponse response = client.Execute(request);
                string content = response.Content; // raw content as string

                if (content.Equals("\"No data found\"") || content.Equals("\"Error has occured\""))
                {
                    LoginIsSuccessfull = false;
                    LoginErrorMessage = content;
                    return null;
                }



                DataTable tableX = StringManipulation.JsonStringToDatatable(content);
                LoginIsSuccessfull = true;
                return tableX;
            }

            catch (Exception ex)
            {
                LoginIsSuccessfull = false;
                LoginErrorMessage = ex.Message + "\nFunction : Get";
                return null;
            }
        }

        public static bool EditInfoIsSuccessfull = false;
        public static string EditInfoErrorMessage = string.Empty;
        public static void EditInfo(string FullName, string Division, string Username, string Designation, string Password, int Id)
        {
            try
            {
                string requestURL = PublicVariables.APIBaseURL + "edit_info";
                RestClient client = new RestClient(requestURL)
                {
                    Authenticator = new HttpBasicAuthenticator(PublicVariables.APIAuthUsername, PublicVariables.APIAuthPassword)
                };
                var request = new RestRequest(Method.POST);

                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("new_password", Password);
                request.AddParameter("new_full_name", FullName);
                request.AddParameter("new_designation", Designation);
                request.AddParameter("new_username", Username);
                request.AddParameter("new_division", Division);
                request.AddParameter("emp_id", Id);

                IRestResponse response = client.Execute(request);
                string content = response.Content; // raw content as string

                if (content.Equals("\"No data found\"") || content.Equals("\"Error has occured\""))
                {
                    EditInfoIsSuccessfull = false;
                    EditInfoErrorMessage = content;
                    return;
                }
                EditInfoIsSuccessfull = true;
            }
            catch (Exception ex)
            {
                EditInfoIsSuccessfull = false;
                EditInfoErrorMessage = ex.Message + "\nFunction : EditPassword";
            }
        }

        public static bool DeleteUserIsSuccessfull = false;
        public static string DeleteUserErrorMessage = string.Empty;
        public static string DeleteUser(int Id)
        {
            try
            {
                string requestURL = PublicVariables.APIBaseURL + "delete_user";
                RestClient client = new RestClient(requestURL)
                {
                    Authenticator = new HttpBasicAuthenticator(PublicVariables.APIAuthUsername, PublicVariables.APIAuthPassword)
                };
                var request = new RestRequest(Method.POST);

                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("emp_id", Id);

                IRestResponse response = client.Execute(request);
                string content = response.Content; // raw content as string

                if (content.Equals("\"No data found\"") || content.Equals("\"Error has occured\""))
                {
                    DeleteUserIsSuccessfull = false;
                    DeleteUserErrorMessage = content;
                    return "Can't delete user if already has accomplishment.";
                }
          
                else  if (content.Equals("\"User is deleted successfully\"") )
                {
                    DeleteUserIsSuccessfull = true;
                    return "Successfully deleted account.";
                }
                DeleteUserIsSuccessfull = false;
                return "Can't delete user if already has accomplishment.";
            }
            catch (Exception ex)
            {
                DeleteUserIsSuccessfull = false;
                DeleteUserErrorMessage = ex.Message + "\nFunction : DeleteUser";
                return "Can't delete user if already has accomplishment.";
            }
        }


        public static bool CreateUserIsSuccessfull = false;
        public static string CreateUserErrorMessage = string.Empty;
        public static string CreateUser(string FullName, string Division, string Username, string Designation, string Password)
        {
            try
            {
                string requestURL = PublicVariables.APIBaseURL + "create_user";
                RestClient client = new RestClient(requestURL)
                {
                    Authenticator = new HttpBasicAuthenticator(PublicVariables.APIAuthUsername, PublicVariables.APIAuthPassword)
                };
                var request = new RestRequest(Method.POST);

                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("new_password", Password);
                request.AddParameter("new_full_name", FullName);
                request.AddParameter("new_designation", Designation);
                request.AddParameter("new_username", Username);
                request.AddParameter("new_division", Division);

                IRestResponse response = client.Execute(request);
                string content = response.Content; // raw content as string

                if (content.Equals("\"No data found\"") || content.Equals("\"Error has occured\""))
                {
                    CreateUserIsSuccessfull = false;
                    CreateUserErrorMessage = content;
                    return "Can't create user.";
                }

                else if (content.Equals("\"Data is created successfully\""))
                {
                    CreateUserIsSuccessfull = true;
                    return "Successfully created account.";
                }
                CreateUserIsSuccessfull = false;
                return "Can't create user.";
            }
            catch (Exception ex)
            {
                CreateUserIsSuccessfull = false;
                CreateUserErrorMessage = ex.Message + "\nFunction : DeleteUser";
                return "Can't create user.";
            }
        }

        internal static void CreateUser(string text1, string text2, string text3, string text4)
        {
            throw new NotImplementedException();
        }
    }
}
