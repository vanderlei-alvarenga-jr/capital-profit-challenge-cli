using Xunit;
using capital_profit_challenge_cli.Processor;
using capital_profit_challenge_cli.Exceptions;

namespace capital_profit_challenge_cli_tests;

public class CapitalProfitInputValidationTests
{
    private readonly CapitalProfitProcessor _processor;

    private static readonly string jsonContentNoExceptionInput = @"[{ ""operation"": ""buy"", ""unit-cost"": 10.00, ""quantity"": 100 }, { ""operation"": ""sell"", ""unit-cost"": 15.00, ""quantity"": 50 }, { ""operation"": ""sell"", ""unit-cost"": 20.00, ""quantity"": 50 }]";

    private static readonly string jsonContentNoExceptionResult = "[{\"tax\":0},{\"tax\":0},{\"tax\":0}]";

    private static readonly string jsonContentExceptionCase01 = "";

    private static readonly string jsonContentExceptionCase02 = String.Empty + Environment.NewLine + "[{ \"operation\": \"buy\", \"unit-cost\": 10.00, \"quantity\": 100 }, { \"operation\": \"sell\", \"unit-cost\": 15.00, \"quantity\": 50 }, { \"operation\": \"sell\", \"unit-cost\": 20.00, \"quantity\": 50 }]";

    private static readonly string jsonContentExceptionCase03 = "[{ \"operation\": \"buy\", \"unit-cost\": 10.00, \"quantity\": 100 }, { \"operation\": \"sell\", \"unit-cost\": 15.00, \"quantity\": 50 }, { \"operation\": \"sell\", \"unit-cost\": 20.00, \"quantity\": 50 }]" + Environment.NewLine + "[{ \"operations\": \"buy\", \"unit-costs\": 10.00, \"quantities\": 100 }, { \"operations\": \"sell\", \"unit-costs\": 15.00, \"quantities\": 50 }, { \"operations\": \"sell\", \"unit-costs\": 20.00, \"quantities\": 50 }]";

    private static readonly string jsonContentExceptionCase04 = @"[{ ""operation"": ""sell"", ""unit-cost"": 10.00, ""quantity"": 100 }, { ""operation"": ""sell"", ""unit-cost"": 15.00, ""quantity"": 50 }, { ""operation"": ""sell"", ""unit-cost"": 20.00, ""quantity"": 50 }]";

    public CapitalProfitInputValidationTests()
    {
        _processor = new CapitalProfitProcessor();
    }

    [Fact]
    public void ProcessFile_ShouldThrowNoExceptions()
    {
        // Act
        string resultString = String.Empty;
        Exception? resultException = null;
        try
        {
            resultString = _processor.ProcessFile(jsonContentNoExceptionInput);
        }
        catch (Exception ex)
        {
            resultException = ex;
        }

        // Assert
        Assert.True(resultException is null && resultString == jsonContentNoExceptionResult);
    }

    [Fact]
    public void ProcessFile_ShouldThrowInvalidFormat_ExceptionCaseOne()
    {
        // Arrange
        CapitalProfitInputFormatException expectedException = new CapitalProfitInputFormatException(CapitalProfitInputFormatException.INVALID_FORMAT_OPERATION_LINE_MESSAGE, "1");

        // Act
        Exception? resultException = null;
        try
        {
            _processor.ProcessFile(jsonContentExceptionCase01);
        }
        catch (Exception ex)
        {
            resultException = ex;
        }

        // Assert
        Assert.True(resultException is CapitalProfitInputFormatException && resultException.Message == expectedException.Message);
    }

    [Fact]
    public void ProcessFile_ShouldThrowInvalidFormat_ExceptionCaseTwo()
    {
        // Arrange
        CapitalProfitInputFormatException expectedException = new CapitalProfitInputFormatException(CapitalProfitInputFormatException.INVALID_FORMAT_OPERATION_LINE_MESSAGE, "1");

        // Act
        Exception? resultException = null;
        try
        {
            _processor.ProcessFile(jsonContentExceptionCase02);
        }
        catch (Exception ex)
        {
            resultException = ex;
        }

        // Assert
        Assert.True(resultException is CapitalProfitInputFormatException && resultException.Message == expectedException.Message);
    }

    [Fact]
    public void ProcessFile_ShouldThrowInvalidFormat_ExceptionCaseThree()
    {
        // Arrange
        CapitalProfitInputFormatException expectedException = new CapitalProfitInputFormatException(CapitalProfitInputFormatException.INVALID_FORMAT_OPERATION_LINE_MESSAGE, "2");

        // Act
        Exception? resultException = null;
        try
        {
            _processor.ProcessFile(jsonContentExceptionCase03);
        }
        catch (Exception ex)
        {
            resultException = ex;
        }

        // Assert
        Assert.True(resultException is CapitalProfitInputFormatException && resultException.Message == expectedException.Message);
    }
    
    [Fact]
    public void ProcessFile_ShouldThrowInvalidFormat_ExceptionCaseFour()
    {
        // Arrange
        CapitalProfitProcessException expectedException = new CapitalProfitProcessException(CapitalProfitProcessException.NOT_ENOUGHT_UNIT_BALANCE_MESSAGE, "1", "1");

        // Act
        Exception? resultException = null;
        try
        {
            _processor.ProcessFile(jsonContentExceptionCase04);
        }
        catch (Exception ex)
        {
            resultException = ex;
        }

        // Assert
        Assert.True(resultException is CapitalProfitProcessException && resultException.Message == expectedException.Message);
    }
}