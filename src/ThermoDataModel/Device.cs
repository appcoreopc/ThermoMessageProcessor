namespace ThemoDataModel
{
    public partial class Device
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public string IPAddress { get; set; }
        public bool? IsActive { get; set; }
    }
}
