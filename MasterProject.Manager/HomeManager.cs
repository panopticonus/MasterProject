namespace MasterProject.Manager
{
    using Core.Dto;
    using Core.Interfaces.Managers;
    using System;
    using System.Globalization;
    using System.Net;
    using System.Text;
    using Core.Enums;

    public class HomeManager : IHomeManager
    {
        public DataPoint GetData(int deviceId)
        {
            try
            {
                var client = new WebClient { Encoding = Encoding.UTF8 };
                var stringUrl = "";

                switch (deviceId)
                {
                    case (int)DeviceTypes.Temperature:
                        stringUrl = "http://192.168.0.102:8080/temperature";
                        break;
                    case (int)DeviceTypes.Humidity:
                        stringUrl = "http://192.168.0.102:8080/humidity";
                        break;
                    default:
                        stringUrl = "http://192.168.0.102:8080/";
                        break;
                }

                var url = new Uri(stringUrl, UriKind.Absolute);
                var apiResponse = client.DownloadString(url);

                return new DataPoint(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"), Convert.ToDouble(apiResponse.Replace(".", ",")));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
