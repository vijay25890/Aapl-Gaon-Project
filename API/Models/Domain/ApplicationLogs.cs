namespace API.Models.Domain
{
    public class ApplicationLogs
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FunctionName { get; set; }
        public string LineNumber { get; set; }
        public string Description { get; set; }
    }
}
