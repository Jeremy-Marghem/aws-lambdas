using System.Text.Json.Serialization;

namespace AWSServerless1.Clients.CreateClient;
public class CreateClientCommand
{
	[JsonPropertyName("name")]
	public string? Name { get; set; }
}
