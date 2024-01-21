namespace SafeCampus;
public class SafeCampusDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;

    public List<string> Collections { get;set; } = null!;
}
