namespace Core.Models
{
    public partial class Log
    {
        public int LogId { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
