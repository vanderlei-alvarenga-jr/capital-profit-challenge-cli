namespace capital_profit_challenge_cli.Exceptions;

public class CapitalProfitInputFormatException : Exception
{
    public const string INVALID_FORMAT_OPERATION_LINE_MESSAGE = "The operation line #{0} format is invalid.";

    public CapitalProfitInputFormatException(string message, params string[] messageArguments) : base(message = string.Format(message, messageArguments)) { }

    public CapitalProfitInputFormatException(string message, Exception? inner = null, params string[] messageArguments) : base(message = string.Format(message, messageArguments), inner) { }
}