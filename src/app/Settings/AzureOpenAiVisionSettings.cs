namespace app.Settings;

public class AzureOpenAiVisionSettings
{
    public const string SectionName = "AzureOpenAiVision";

    public required string DeploymentName { get; set; }
    public required string Endpoint { get; set; }
    public required string ApiKey { get; set; }
    public required string ModelId { get; set; }
}
