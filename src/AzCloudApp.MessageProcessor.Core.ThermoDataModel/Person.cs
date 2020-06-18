using System;

namespace AzCloudApp.MessageProcessor.Core.ThermoDataModel
{
    public class Person
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
