using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HNUiMap.core;
using RestSharp;
using RestSharp.Authenticators;

namespace HNUiMap.api
{
    public class Accomplishments
    {
        public int Id { get; set; }
        public string AccomplishmentName { get; set; }
        public DateTime AccomplishmentDate { get; set; }
        public DateTime AccomplishmentTime { get; set; }
        public int EmpId { get; set; }

        public static string AddErrorMessage = string.Empty;
        public static bool AddIsSuccessfull = false;
        public static void Add(string AccomplishmentName, DateTime AccomplishmentDate, DateTime AccomplishmentTime)
        {
            try
            {
                string requestURL = PublicVariables.APIBaseURL + "add";
                RestClient client = new RestClient(requestURL)
                {
                    Authenticator = new HttpBasicAuthenticator(PublicVariables.APIAuthUsername, PublicVariables.APIAuthPassword)
                };
                var request = new RestRequest(Method.POST);
                string x = AccomplishmentDate.ToMySQLDateTimeFormat();
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("accomplishment_name", AccomplishmentName);
                request.AddParameter("accomplishment_date", AccomplishmentDate.ToMySQLDateFormat());
                request.AddParameter("accomplishment_time", AccomplishmentTime.ToMySQLDateTimeFormat());
                request.AddParameter("emp_id", PublicVariables.UserId);

                IRestResponse response = client.Execute(request);
                string content = response.Content; // raw content as string

                if (content.Equals("\"No data found\"") || content.Equals("\"Error has occured\""))
                {
                    AddIsSuccessfull = false;
                    AddErrorMessage = content;
                    return;
                }

                AddIsSuccessfull = true;
                return;
            }

            catch (Exception ex)
            {
                AddIsSuccessfull = false;
                AddErrorMessage = ex.Message + "\nFunction : Get";
                return;
            }
        }

        public static bool GetIsSuccessfull = false;
        public static string GetErrorMessage = string.Empty;
        public static DataTable Get(DateTime dateFrom, DateTime dateTo, int empId)
        {
            DataSet dt = new DataSet();
            try
            {
                string requestURL = PublicVariables.APIBaseURL + "get";
                RestClient client = new RestClient(requestURL)
                {
                    Authenticator = new HttpBasicAuthenticator(PublicVariables.APIAuthUsername, PublicVariables.APIAuthPassword)
                };
                var request = new RestRequest(Method.POST);

                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("date_from", dateFrom.ToMySQLDateFormat());
                request.AddParameter("date_to", dateTo.ToMySQLDateFormat());
                request.AddParameter("emp_id", empId);

                IRestResponse response = client.Execute(request);
                string content = response.Content; // raw content as string

                if (content.Equals("\"No data found\"") || content.Equals("\"Error has occured\""))
                {
                    GetIsSuccessfull = false;
                    GetErrorMessage = content;
                    return null;
                }

                DataTable tableX = StringManipulation.JsonStringToDatatable(content);
                GetIsSuccessfull = true;
                return tableX;
            }
            catch (Exception ex)
            {
                GetIsSuccessfull = false;
                GetErrorMessage = ex.Message + "\nFunction : Get";
                return null;
            }
        }

    }
}