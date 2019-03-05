namespace Api.Model
{
    public class CreateJobCommand
    {
        public string Cron { get; set; }
        public long? Timestamp { get; set; }
        public string Method { get; set; }
        public string Url { get; set; }
        public string State { get; set; }
    }
}