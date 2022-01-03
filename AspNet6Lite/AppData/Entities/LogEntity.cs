#pragma warning disable CS8618

namespace AspNet6Lite.AppData.Entities
{
    public class LogEntity: BaseEntity
    {
        public string Guid { get; set; }
        public string LogType { get; set; }
        public string LogMessage { get; set; }
    }
}

#pragma warning restore CS8618