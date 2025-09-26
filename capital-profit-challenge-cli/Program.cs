using capital_profit_challenge_cli.Commands;
using Cocona;

public class Program
{
    static void Main(string[] args)
    {
        var builder = CoconaLiteApp.CreateBuilder();

        var app = builder.Build();

        app.AddCommands<CapitalProfitCommand>();
        app.Run();
    }
}