using System.Text.Json.Serialization;

namespace capital_profit_challenge_cli.Model;

public class TaxToPayVO
{
    [JsonPropertyName("tax")]
    [JsonRequired]
    public decimal Tax { get; set; }

    public static List<TaxToPayVO>? ToObjectList(string taxLine)
    {
        return System.Text.Json.JsonSerializer.Deserialize<List<TaxToPayVO>>(taxLine);
    }
    
    public static string ToJsonString(List<TaxToPayVO> taxList)
    {
        return System.Text.Json.JsonSerializer.Serialize(taxList);
    }
}