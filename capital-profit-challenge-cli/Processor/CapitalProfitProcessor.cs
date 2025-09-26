using System.Diagnostics;
using capital_profit_challenge_cli.Model;

namespace capital_profit_challenge_cli.Processor;

public class CapitalProfitProcessor
{
    public CapitalProfitProcessor()
    {
    }

    public string ProcessFile(string fileContent)
    {
        List<List<TaxToPayVO>> taxList = new List<List<TaxToPayVO>>();
        List<string> taxLineList = new List<string>();
        List<string> operationsLineList = getOperationStringLines(fileContent);

        if (!operationsLineList.Any())
        {
            throw new ArgumentException("Invalid JSON content.");
        }

        foreach (var operationLine in operationsLineList)
        {
            List<OperationVO>? operationsList = OperationVO.ToObjectList(operationLine);

            if (operationsList == null)
            {
                Debug.WriteLine("Invalid JSON content line." + Environment.NewLine + "Content: " + operationLine);
                continue;
            }

            taxList.Add(ProcessOperationsTaxLine(operationsList));
        }

        foreach (var taxLine in taxList)
        {
            taxLineList.Add(TaxToPayVO.ToJsonString(taxLine).Trim());
        }

        return String.Join(Environment.NewLine, taxLineList).Trim();
    }

    private List<string> getOperationStringLines(string fileContent)
    {
        List<string> lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        return lines;
    }

    public List<TaxToPayVO> ProcessOperationsTaxLine(List<OperationVO> operations)
    {
        var result = new List<TaxToPayVO>();
        decimal profitAccumulator = 0;
        decimal unitsBalance = 0;
        decimal currentWeightedAveragePrice = 0;

        Debug.WriteLine($"### Begin Line Process ###");

        for (int i = 0; i < operations.Count; i++)
        {
            Debug.WriteLine($"### Operation #{i + 1} ###");

            OperationVO currentOperation = operations[i];

            Debug.WriteLine($"Operation.type = {currentOperation.Operation}");
            Debug.WriteLine($"Operation.unit-cost = {currentOperation.UnitCost}");
            Debug.WriteLine($"Operation.quantity = {currentOperation.Quantity}");

            TaxToPayVO taxToPay = new TaxToPayVO();
            taxToPay.Tax = 0;

            if (currentOperation.Operation.ToUpper() == OperationEnum.BUY)
            {
                if (currentWeightedAveragePrice == 0 && unitsBalance == 0)
                    currentWeightedAveragePrice = currentOperation.UnitCost;
                else
                    currentWeightedAveragePrice = CalculateWeightedAveragePrice(currentWeightedAveragePrice, unitsBalance, currentOperation);
                Debug.WriteLine($"currentWeightedAveragePrice = {currentWeightedAveragePrice}");
                unitsBalance += currentOperation.Quantity;
                Debug.WriteLine($"unitsBalance = {unitsBalance}");
            }
            else if (currentOperation.Operation.ToUpper() == OperationEnum.SELL && unitsBalance > 0 && unitsBalance >= currentOperation.Quantity)
            {
                decimal operationProfit = 0;
                decimal operationLoss = 0;
                Debug.WriteLine($"currentWeightedAveragePrice = {currentWeightedAveragePrice}");

                unitsBalance -= currentOperation.Quantity;
                Debug.WriteLine($"unitsBalance = {unitsBalance}");

                if (currentWeightedAveragePrice < currentOperation.UnitCost) // Profit
                {
                    operationProfit = (currentOperation.UnitCost - currentWeightedAveragePrice) * currentOperation.Quantity;
                    profitAccumulator += operationProfit;
                    Debug.WriteLine($"Operation: Profit! ({operationProfit})");
                }
                else if (currentWeightedAveragePrice > currentOperation.UnitCost) //Loss
                {
                    operationLoss = (currentWeightedAveragePrice - currentOperation.UnitCost) * currentOperation.Quantity;
                    profitAccumulator -= operationLoss;
                    Debug.WriteLine($"Operation: Loss! ({operationLoss})");
                }

                var transactionTotalValue = currentOperation.UnitCost * currentOperation.Quantity;
                Debug.WriteLine($"transactionTotalValue = {transactionTotalValue}");
                if (transactionTotalValue > 20000.00m && operationProfit > operationLoss && profitAccumulator > 0)
                {
                    taxToPay.Tax = profitAccumulator * 0.20m;
                    Debug.WriteLine($"Tax applied over profit! Reset \"profitAccumulator\".");
                    profitAccumulator = 0;
                }
            }
            else if (unitsBalance <= 0)
            {
                Debug.WriteLine($"ERROR: Invalid operation on operation #{i + 1}. Units balance is not enought to process operation.");
                Debug.WriteLine($"unitsBalance = {unitsBalance}");
                Debug.WriteLine($"profitAccumulator = {profitAccumulator}");
                Debug.WriteLine($"TaxToPay = {taxToPay.Tax}");
                Debug.WriteLine($"### End Operation #{i + 1} ###");
                continue;
            }
            else
            {
                Debug.WriteLine($"ERROR: Invalid operation type on operation #{i + 1}.");
                Debug.WriteLine($"unitsBalance = {unitsBalance}");
                Debug.WriteLine($"profitAccumulator = {profitAccumulator}");
                Debug.WriteLine($"TaxToPay = {taxToPay.Tax}");
                Debug.WriteLine($"### End Operation #{i + 1} ###");
                continue;
            }

            Debug.WriteLine($"unitsBalance = {unitsBalance}");
            Debug.WriteLine($"profitAccumulator = {profitAccumulator}");
            Debug.WriteLine($"TaxToPay = {taxToPay.Tax}");
            Debug.WriteLine($"### End Operation #{i + 1} ###");

            result.Add(taxToPay);
        }

        Debug.WriteLine($"lastUnitsBalance = {unitsBalance}");
        Debug.WriteLine($"profitAccumulator = {profitAccumulator}");
        Debug.WriteLine($"lastCurrentWeightedAveragePrice = {currentWeightedAveragePrice}");
        Debug.WriteLine($"### End Line Process ###");

        return result;
    }

    public decimal CalculateWeightedAveragePrice(decimal currentWeightedAveragePrice, decimal currentUnitsBalance, OperationVO lastBuyOperation)
    {
        if (currentUnitsBalance + lastBuyOperation.Quantity == 0) return 0;
        if (currentWeightedAveragePrice == lastBuyOperation.UnitCost) return currentUnitsBalance;
        currentWeightedAveragePrice = ((currentUnitsBalance * currentWeightedAveragePrice) + (lastBuyOperation.Quantity * lastBuyOperation.UnitCost)) / (currentUnitsBalance + lastBuyOperation.Quantity);
        return currentWeightedAveragePrice;
    }
    
    public int CalculateUnitsBalance(List<OperationVO> operations, int startIndex = -1, int endIndex = -1)
    {
        if (startIndex > -1 && startIndex > operations.Count - 1) startIndex = operations.Count - 1;
        if (endIndex > -1 && endIndex > operations.Count - 1) endIndex = operations.Count - 1;

        if (startIndex > -1 && endIndex > -1)
        {
            operations = operations.GetRange(startIndex, endIndex - startIndex + 1);
        }
        else if (startIndex > -1)
        {
            operations = operations.GetRange(startIndex, operations.Count - startIndex);
        }
        else if (endIndex > -1)
        {
            operations = operations.GetRange(0, endIndex + 1);   
        }

        int unitsBalance = 0;
        foreach (var operation in operations)
        {
            if (operation.Operation.ToUpper() == OperationEnum.BUY)
                unitsBalance += operation.Quantity;
            else if (operation.Operation.ToUpper() == OperationEnum.SELL)
                unitsBalance -= operation.Quantity;
            else
                throw new ArgumentException("Invalid operation type.");
        }
        return unitsBalance;
    }
}
