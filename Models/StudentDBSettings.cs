namespace corewebapi.Model
{
    public class StudentDBSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string StudentCollectionName { get; set; } = null!;
    }
}