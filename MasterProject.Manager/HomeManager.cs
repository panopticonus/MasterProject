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

        public void SaveData(string patientName, string deviceName)
        {
            var csv = new StringBuilder();

#warning: do testowania
            //for (var i = 0; i < 8; i++)
            //{
            //    _dic.Add(DateTime.Now.AddMinutes(i), 12);
            //}

            foreach (var item in _dic)
            {
                csv.AppendLine($"{item.Value},{item.Key:yyyy-MM-dd HH:mm:ss}");
            }

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
            var date = DateTime.Now;

            var path = Path.Combine(desktopPath, "Dane medyczne", patientName, deviceName, date.ToString("dd-MM-yyyy"));
            var documentName = "data" + date.ToShortTimeString().Replace(':', '_') + ".csv";

            if (Directory.Exists(path))
            {
                File.WriteAllText(Path.Combine(path, documentName), csv.ToString());
            }
            else
            {
                Directory.CreateDirectory(path);
                File.WriteAllText(Path.Combine(path, documentName), csv.ToString());
            }

            _dic.Clear();
        }
    }
}
