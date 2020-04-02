using System;

 namespace Env
{

   
    public class EnvironmentVariables
    {
        // databases
        private readonly string cloudConnectionString = "Data Source=SERVER\\ONIMTA;Initial Catalog=OnimtaWebInventoryCloud;Persist Security Info=True;User ID=sa;Password=it@onimta1+;MultipleActiveResultSets=True";
        private readonly string localConnectionString = "Data Source=SERVER\\ONIMTA;Initial Catalog=OnimtaWebInventory;Persist Security Info=True;User ID=sa;Password=it@onimta1+;MultipleActiveResultSets=True";
        private readonly string remoteDbConnection = "Data Source = onimtait.dyndns.info,1443; Initial Catalog = OnimtaWebInventory; Persist Security Info=True;User ID = sa;Password=it@onimta1+;MultipleActiveResultSets=True";

        // notificationApiUrl 
    
        private readonly string cloudNotificationApiUrl = "https://onimtanotificationapi.azurewebsites.net/api/";
        private readonly string localNotificationApiUrl = "http://localhost:60841/api/";
        private readonly string ServerNotificationApiUrl = "http://192.168.1.60:4205/api/";


        public string GetDataBaseConnection()
        {
            return localConnectionString;
        }

        public string GetNotificationUrl()
        {
            return ServerNotificationApiUrl;
        }

    }
}
