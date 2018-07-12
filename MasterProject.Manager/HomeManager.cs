namespace MasterProject.Manager
{
    using Core.Dto;
    using Core.Enums;
    using Core.Interfaces.Managers;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;

    public class HomeManager : IHomeManager
    {
        private Dictionary<DateTime, double> _dic = new Dictionary<DateTime, double>();

        public DataPoint GetData(int deviceId)
        {
            var client = new WebClient { Encoding = Encoding.UTF8 };
            string stringUrl;

            switch (deviceId)
            {
                case (int)DeviceTypes.Temperature:
                    stringUrl = "http://192.168.1.102:8080/temperature";
                    break;
                case (int)DeviceTypes.Humidity:
                    stringUrl = "http://192.168.1.102:8080/humidity";
                    break;
                default:
                    stringUrl = "http://192.168.1.102:8080/";
                    break;
            }

            var url = new Uri(stringUrl, UriKind.Absolute);
            var apiResponse = client.DownloadString(url);

            _dic.Add(DateTime.Now, Convert.ToDouble(apiResponse.Replace(".", ",")));

            return new DataPoint(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"), Convert.ToDouble(apiResponse.Replace(".", ",")));
        }

        public void SaveData()
        {
            var csv = new StringBuilder();

            foreach (var item in _dic)
            {
                csv.AppendLine($"{item.Value},{item.Key:yyyy-MM-dd HH:mm:ss}");
            }

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\Medical Data\data.csv";

            File.WriteAllText(path, csv.ToString());
        }
    }
}
