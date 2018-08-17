using IoT.Domain.Enums;
using Newtonsoft.Json.Linq;
using System;
namespace IoT.Domain.Models.Devices
{
    public interface IFAS500
    {
        string DeviceId { get; set; }
        DeviceDataType DataType { get; set; }
        string Time { get; set; }
    }
    public class FAS500Factory
    {
        public static IFAS500 Parsing(DeviceDataType type)
        {
            IFAS500 result;
            switch (type)
            {
                case DeviceDataType.OnTime_StsChg:
                    result = new FAS500OnTimeData();
                    break;
                case DeviceDataType.Manual_StsChg:
                    result = new FAS500ManualData();
                    break;
                case DeviceDataType.UpdateFirmware:
                    result = new FAS500UpdateFirmwareData();
                    break;
                case DeviceDataType.Auto_StsChg:
                    result = new FAS500AutoData();
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }
    }
    public class FAS500OnTimeData : IFAS500
    {
        public string DeviceId { get; set; }
        public DeviceDataType DataType { get; set; }
        public string Time { get; set; }
        public string Rssi { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Timer { get; set; }
        public string FilterLife { get; set; }
        public string PM25 { get; set; }
    }
    public class FAS500ManualData : IFAS500
    {
        public string DeviceId { get; set; }
        public DeviceDataType DataType { get; set; }
        public string Time { get; set; }
        public bool PowerStatus { get; set; }
        public bool UltravioletStatus { get; set; }
        public bool ChildLockStatus { get; set; }
        public bool SleepStatus { get; set; }
        public int ModeStatus { get; set; }
        public int FanSpeed { get; set; }
        public int Timer { get; set; }
    }
    public class FAS500UpdateFirmwareData : IFAS500
    {
        public string DeviceId { get; set; }
        public DeviceDataType DataType { get; set; }
        public string Time { get; set; }
    }
    public class FAS500AutoData : IFAS500
    {
        public string DeviceId { get; set; }
        public DeviceDataType DataType { get; set; }
        public string Time { get; set; }
    }
}