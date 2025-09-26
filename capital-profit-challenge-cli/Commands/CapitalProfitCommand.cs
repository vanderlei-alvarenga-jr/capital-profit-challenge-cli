using Cocona;
using capital_profit_challenge_cli.Processor;

namespace capital_profit_challenge_cli.Commands;
public class CapitalProfitCommand
{
    private readonly CapitalProfitProcessor processor;

    public CapitalProfitCommand()
    {
        processor = new CapitalProfitProcessor();
    }

    [Command(name: "process", Description = "Processa o arquivo JSON com as operações de compra e venda de ações.")]
    public async Task Process(string filePath)
    {
        FileInfo fileInfo = new FileInfo(filePath);
        var fileContent = await File.ReadAllTextAsync(fileInfo.FullName);
        processor.ProcessFile(fileContent);
    }
}