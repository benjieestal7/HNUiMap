using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNUiMap.core
{
    public class PublicVariables
    {
        public static DateTime ServerDate { get; set; }

        #region Project Setting

        public static string ProjectName = "HNUiMap";
        public static DateTime ServerDateTime = new DateTime();

        #endregion

        #region User Credentials

        /// <summary>
        /// Software username : the one that pass login
        /// </summary>
        public static string UserName { get; set; }

        /// <summary>
        /// Current User Id
        /// </summary>
        public static int UserId { get; set; }

        /// <summary>
        /// Current User Password
        /// </summary>
        public static string UserPassword { get; set; }

        /// <summary>
        /// Office Id of the user who login
        /// </summary>
        public static int UsersOfficeId { get; set; }

        public static bool UserIsDoneLogin = false;

        #endregion

        #region API Setting
        public static string APIBaseURL = "https://hnuimappserver-3de5524c7358.herokuapp.com/";
        public static string APIAuthUsername = "admin";
        public static string APIAuthPassword = "bictu.scrum2019";
        public static bool AppForRestart = false;
        #endregion
    }
}
