using System;

namespace AzCloudApp.MessageProcessor.Core.DataProcessor
{
    public class PersonImgDataMessageQueue
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string ImgBase64 { get; set; }
    }

    public class AttendRecordDataMessageQueue
    {
        public int AttendRecordId { get; set; }
        public int Id { get; set; }
        public string BodyTemperature { get; set; }
        public string DeviceId { get; set; }
        public string PersonId { get; set; }
        public int? Respirator { get; set; }
        public DateTime? Timestamp { get; set; }
        public string UserId { get; set; }
        public string ImgBase64 { get; set; }
    }

    public class DeviceDataMessageQueue
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public string IPAddress { get; set; }
        public bool? IsActive { get; set; }
    }

    public class PersonDataMessageQueue
    {
        public int Id { get; set; }
        public string CertificateNumber { get; set; }
        public int? CertificateType { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string GroupId { get; set; }
        public string Name { get; set; }
        public string PersonId { get; set; }
        public string Phone { get; set; }
        public string Userid { get; set; }
        public DateTime? UpdateTime { get; set; }

    }
}