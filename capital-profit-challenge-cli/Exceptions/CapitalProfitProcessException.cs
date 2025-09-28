namespace capital_profit_challenge_cli.Exceptions;

public class CapitalProfitProcessException : Exception
{
    public const string INVALID_OPERATION_TYPE_MESSAGE = "The operation type informed in operation #{0}, line #{1} is invalid.";
    public const string NOT_ENOUGHT_UNIT_BALANCE_MESSAGE = "The units balance is not enought to process the operation #{0}, line #{1}.";
    
    public CapitalProfitProcessException(string message, params string[] messageArguments) : base(message = string.Format(message, messageArguments)) { }

    public CapitalProfitProcessException(string message, Exception? inner = null, params string[] messageArguments) : base(message = string.Format(message, messageArguments), inner) { }
}