using Xunit;
using capital_profit_challenge_cli.Model;
using capital_profit_challenge_cli.Processor;
using System.Text.Json;

namespace capital_profit_challenge_cli_tests;

public class CapitalProfitProcesssorFactTests
{
    private readonly CapitalProfitProcessor _processor;

    private static readonly string jsonContentCase01 = @"[{ ""operation"": ""buy"", ""unit-cost"": 10.00, ""quantity"": 100 }, { ""operation"": ""sell"", ""unit-cost"": 15.00, ""quantity"": 50 }, { ""operation"": ""sell"", ""unit-cost"": 20.00, ""quantity"": 50 }]";

    private static readonly List<TaxToPayVO> expectedTaxesCase01 = new List<TaxToPayVO>
    {
        new TaxToPayVO { Tax = 0 },
        new TaxToPayVO { Tax = 0 },
        new TaxToPayVO { Tax = 0 }
    };

    private static readonly string jsonContentCase02 = @"[{ ""operation"": ""buy"", ""unit-cost"": 10.00, ""quantity"": 10000 }, { ""operation"": ""sell"", ""unit-cost"": 20.00, ""quantity"": 5000 }, { ""operation"": ""sell"", ""unit-cost"": 5.00, ""quantity"": 5000 }]";

    private static readonly List<TaxToPayVO> expectedTaxesCase02 = new List<TaxToPayVO>
    {
        new TaxToPayVO { Tax = 0 },
        new TaxToPayVO { Tax = 10000.00m },
        new TaxToPayVO { Tax = 0 }
    };

    private static readonly string jsonContentCase03 = @"[{ ""operation"": ""buy"", ""unit-cost"": 10.00, ""quantity"": 10000 }, { ""operation"": ""sell"", ""unit-cost"": 5.00, ""quantity"": 5000 }, { ""operation"": ""sell"", ""unit-cost"": 20.00, ""quantity"": 3000 }]";

    private static readonly List<TaxToPayVO> expectedTaxesCase03 = new List<TaxToPayVO>
    {
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 1000.00m }
    };

    private static readonly string jsonContentCase04 = @"[{ ""operation"": ""buy"", ""unit-cost"": 10.00, ""quantity"": 10000 }, { ""operation"": ""buy"", ""unit-cost"": 25.00, ""quantity"": 5000 }, { ""operation"": ""sell"", ""unit-cost"": 15.00, ""quantity"": 10000 }]";

    private static readonly List<TaxToPayVO> expectedTaxesCase04 = new List<TaxToPayVO>
    {
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m }
    };

    private static readonly string jsonContentCase05 = @"[{ ""operation"": ""buy"", ""unit-cost"": 10.00, ""quantity"": 10000 }, { ""operation"": ""buy"", ""unit-cost"": 25.00, ""quantity"": 5000 }, { ""operation"": ""sell"", ""unit-cost"": 15.00, ""quantity"": 10000 }, { ""operation"": ""sell"", ""unit-cost"": 25.00, ""quantity"": 5000 }]";

    private static readonly List<TaxToPayVO> expectedTaxesCase05 = new List<TaxToPayVO>
    {
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 10000.00m }
    };

    private static readonly string jsonContentCase06 = @"[{ ""operation"": ""buy"", ""unit-cost"": 10.00, ""quantity"": 10000 }, { ""operation"": ""sell"", ""unit-cost"": 2.00, ""quantity"": 5000 }, { ""operation"": ""sell"", ""unit-cost"": 20.00, ""quantity"": 2000 }, { ""operation"": ""sell"", ""unit-cost"": 20.00, ""quantity"": 2000 }, { ""operation"": ""sell"", ""unit-cost"": 25.00, ""quantity"": 1000 }]";

    private static readonly List<TaxToPayVO> expectedTaxesCase06 = new List<TaxToPayVO>
    {
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 3000.00m }
    };

    private static readonly string jsonContentCase07 = @"[{""operation"": ""buy"", ""unit-cost"": 10.00, ""quantity"": 10000}, {""operation"": ""sell"", ""unit-cost"": 2.00, ""quantity"": 5000}, {""operation"": ""sell"", ""unit-cost"": 20.00, ""quantity"": 2000}, {""operation"": ""sell"", ""unit-cost"": 20.00, ""quantity"": 2000}, {""operation"": ""sell"", ""unit-cost"": 25.00, ""quantity"": 1000}, {""operation"": ""buy"", ""unit-cost"": 20.00, ""quantity"": 10000}, {""operation"": ""sell"", ""unit-cost"": 15.00, ""quantity"": 5000}, {""operation"": ""sell"", ""unit-cost"": 30.00, ""quantity"": 4350}, {""operation"": ""sell"", ""unit-cost"": 30.00, ""quantity"": 650}]";

    private static readonly List<TaxToPayVO> expectedTaxesCase07 = new List<TaxToPayVO>
    {
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 3000.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 3700.00m },
        new TaxToPayVO { Tax = 0.00m }
    };

    private static readonly string jsonContentCase08 = @"[{""operation"": ""buy"", ""unit-cost"": 10.00, ""quantity"": 10000}, {""operation"": ""sell"", ""unit-cost"": 50.00, ""quantity"": 10000}, {""operation"": ""buy"", ""unit-cost"": 20.00, ""quantity"": 10000}, {""operation"": ""sell"", ""unit-cost"": 50.00, ""quantity"": 10000}]";

    private static readonly List<TaxToPayVO> expectedTaxesCase08 = new List<TaxToPayVO>
    {
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 80000.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 60000.00m }
    };

    private static readonly string jsonContentCase09 = @"[{""operation"": ""buy"", ""unit-cost"": 5000.00, ""quantity"": 10}, {""operation"": ""sell"", ""unit-cost"": 4000.00, ""quantity"": 5}, {""operation"": ""buy"", ""unit-cost"": 15000.00, ""quantity"": 5}, {""operation"": ""buy"", ""unit-cost"": 4000.00, ""quantity"": 2}, {""operation"": ""buy"", ""unit-cost"": 23000.00, ""quantity"": 2}, {""operation"": ""sell"", ""unit-cost"": 20000.00, ""quantity"": 1}, {""operation"": ""sell"", ""unit-cost"": 12000.00, ""quantity"": 10}, {""operation"": ""sell"", ""unit-cost"": 15000.00, ""quantity"": 3}]";

    private static readonly List<TaxToPayVO> expectedTaxesCase09 = new List<TaxToPayVO>
    {
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 0.00m },
        new TaxToPayVO { Tax = 1000.00m },
        new TaxToPayVO { Tax = 2400.00m }
    };

    public CapitalProfitProcesssorFactTests()
    {
        _processor = new CapitalProfitProcessor();
    }

    [Fact]
    public void ProcessFile_ShouldCalculateWeightedAveragePriceCorrectly_CaseFour_SecondOperation()
    {
        // Arrange
        List<OperationVO>? operationsList = OperationVO.ToObjectList(jsonContentCase04);
        int operationIndex = 1; // Operation in Case04
        OperationVO currentBuyOperation = operationsList[operationIndex];
        List<OperationVO> previousOperations = operationsList.GetRange(0, operationIndex);
        OperationVO lastBuyOperation = previousOperations.FindLast(q => q.Operation.ToUpper() == OperationEnum.BUY) ?? throw new ArgumentNullException(); // Getting last buy operation in Case01
        decimal currentWheightedAveragePrice = lastBuyOperation.UnitCost; // Initial weighted average price is the unit cost of the last buy operation
        int currentUnitsBalance = _processor.CalculateUnitsBalance(previousOperations); // Calculate current units balance from all previous operations

        // Act
        var results = _processor.CalculateWeightedAveragePrice(currentWheightedAveragePrice, currentUnitsBalance, currentBuyOperation);

        // Assert
        Assert.Equal(15.00m, results);
    }

    [Fact]
    public void ProcessFile_ShouldCalculateTaxLineCorrectly_CaseOne()
    {
        // Arrange
        List<OperationVO>? operationsList = OperationVO.ToObjectList(jsonContentCase01);

        // Act
        var results = _processor.ProcessOperationsTaxLine(operationsList);

        // Assert
        Assert.Equivalent(expectedTaxesCase01, results, false);
    }

    [Fact]
    public void ProcessFile_ShouldCalculateTaxLineCorrectly_CaseTwo()
    {
        // Arrange
        List<OperationVO>? operationsList = OperationVO.ToObjectList(jsonContentCase02);

        // Act
        var results = _processor.ProcessOperationsTaxLine(operationsList);

        // Assert
        Assert.Equivalent(expectedTaxesCase02, results, false);
    }

    [Fact]
    public void ProcessFile_ShouldCalculateTaxLineCorrectly_CaseOne_And_CaseTwo()
    {
        // Arrange
        string jsonContentExpected = String.Concat(TaxToPayVO.ToJsonString(expectedTaxesCase01), Environment.NewLine, TaxToPayVO.ToJsonString(expectedTaxesCase02));

        string jsonContent = String.Concat(jsonContentCase01, Environment.NewLine, jsonContentCase02);

        // Act
        var jsonContentResult = _processor.ProcessFile(jsonContent);

        // Assert
        Assert.Equal(jsonContentExpected, jsonContentResult);
    }

    [Fact]
    public void ProcessFile_ShouldCalculateTaxLineCorrectly_CaseThree()
    {
        // Arrange
        List<OperationVO>? operationsList = OperationVO.ToObjectList(jsonContentCase03);

        // Act
        var results = _processor.ProcessOperationsTaxLine(operationsList);

        // Assert
        Assert.Equivalent(expectedTaxesCase03, results, false);
    }

    [Fact]
    public void ProcessFile_ShouldCalculateTaxLineCorrectly_CaseFour()
    {
        // Arrange
        List<OperationVO>? operationsList = OperationVO.ToObjectList(jsonContentCase04);

        // Act
        var results = _processor.ProcessOperationsTaxLine(operationsList);

        // Assert
        Assert.Equivalent(expectedTaxesCase04, results, false);
    }

    [Fact]
    public void ProcessFile_ShouldCalculateTaxLineCorrectly_CaseFive()
    {
        // Arrange
        List<OperationVO>? operationsList = OperationVO.ToObjectList(jsonContentCase05);

        // Act
        var results = _processor.ProcessOperationsTaxLine(operationsList);

        // Assert
        Assert.Equivalent(expectedTaxesCase05, results, false);
    }

    [Fact]
    public void ProcessFile_ShouldCalculateTaxLineCorrectly_CaseSix()
    {
        // Arrange
        List<OperationVO>? operationsList = OperationVO.ToObjectList(jsonContentCase06);

        // Act
        var results = _processor.ProcessOperationsTaxLine(operationsList);

        // Assert
        Assert.Equivalent(expectedTaxesCase06, results, false);
    }

    [Fact]
    public void ProcessFile_ShouldCalculateTaxLineCorrectly_CaseSeven()
    {
        // Arrange
        List<OperationVO>? operationsList = OperationVO.ToObjectList(jsonContentCase07);

        // Act
        var results = _processor.ProcessOperationsTaxLine(operationsList);

        // Assert
        Assert.Equivalent(expectedTaxesCase07, results, false);
    }

    [Fact]
    public void ProcessFile_ShouldCalculateTaxLineCorrectly_CaseEight()
    {
        // Arrange
        List<OperationVO>? operationsList = OperationVO.ToObjectList(jsonContentCase08);

        // Act
        var results = _processor.ProcessOperationsTaxLine(operationsList);

        // Assert
        Assert.Equivalent(expectedTaxesCase08, results, false);
    }

    [Fact]
    public void ProcessFile_ShouldCalculateTaxLineCorrectly_CaseNine()
    {
        // Arrange
        List<OperationVO>? operationsList = OperationVO.ToObjectList(jsonContentCase09);

        // Act
        var results = _processor.ProcessOperationsTaxLine(operationsList);

        // Assert
        Assert.Equivalent(expectedTaxesCase09, results, false);
    }
}