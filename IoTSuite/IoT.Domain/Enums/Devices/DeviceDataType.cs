using System.ComponentModel.DataAnnotations;

namespace IoT.Domain.Enums
{
    public enum DeviceDataType
    {
        [Display(Name = "狀態改變")]
        Manual_StsChg,
        [Display(Name = "定時回傳")]
        OnTime_StsChg,
        [Display(Name = "更新韌體")]
        UpdateFirmware,
        [Display(Name = "自動回傳")]
        Auto_StsChg
    }
}