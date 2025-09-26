using System.Text.Json.Serialization;

namespace capital_profit_challenge_cli.Model;

public class OperationVO
{
    [JsonPropertyName("operation")]
    [JsonRequired]
    public string Operation { get; set; }
    [JsonPropertyName("unit-cost")]
    [JsonRequired]
    public decimal UnitCost { get; set; }
    [JsonPropertyName("quantity")]
    [JsonRequired]
    public int Quantity { get; set; }

    public static List<OperationVO>? ToObjectList(string operationLine)
    {
        return System.Text.Json.JsonSerializer.Deserialize<List<OperationVO>>(operationLine);
    }
    
    public static string ToJsonString(List<OperationVO> operationList)
    {
        return System.Text.Json.JsonSerializer.Serialize(operationList);
    }
}