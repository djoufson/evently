namespace app.Settings;

public class AzureOpenAiSettings
{
    public const string SectionName = "AzureOpenAi";

    public required string DeploymentName { get; set; }
    public required string Endpoint { get; set; }
    public required string ApiKey { get; set; }
    public required string ModelId { get; set; }
}
