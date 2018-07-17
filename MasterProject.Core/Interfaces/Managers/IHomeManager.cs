namespace MasterProject.Core.Interfaces.Managers
{
    using Dto;

    public interface IHomeManager
    {
        DataPoint GetData(int deviceId);
        void SaveData(string patientName, string deviceName);
    }
}
