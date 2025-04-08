/*
- This is an automated till application
- handles custormer order and process the transaction
- keep up to five records of the processed transactions (custormer id and sale)
- the till is provided with £150 worth of change
- the transaction is canceled if the program cannot provided the required change 
- hold payment if customer provide less payment and refund the held payment if the program can't provide change
- or the custormer cancels the transaction
- display upto five records of the transactions made (custormer id and sale)
- display the financial report at the end of the program showing what is left in the till
- and taking out the profit to reset the till change back to £150
*/

decimal[] tillCurrency = new decimal[] { 50, 20, 10, 5, 2, 1, 0.50m, 0.20m, 0.10m, 0.05m, 0.02m, 0.01m };
int[] currencyCount = new int[] { 0, 0, 5, 10, 10, 10, 20, 27, 30, 20, 20, 20 };
string[] drinks = new string[] { "Americano", "Cappuccino", "Latte", "Frappuccino", "Tea" };
decimal[] drinksPrice = new decimal[] { 3.49m, 4.50m, 5.00m, 5.25m, 2.55m };
string[] cakes = new string[] { "Croissant", "Carrot Cake", "Millionaire Slice", "Tiffin", "Tea Cake" };
decimal[] cakesPrice = new decimal[] { 2.15m, 3.89m, 2.75m, 2.55m, 2.20m };
int MAX_TRANSACTION_RECORD = 5;
string[,] transactionRecord = new string[MAX_TRANSACTION_RECORD, 2];

decimal tillSum = 0;
decimal validateChange = 0;
decimal currentSale = 0;
decimal itemCost = 0;
decimal totalSale = 0;
bool exit = false;
bool found = false;
bool validInput = false;
string? userInput = "";
int customerCount = 0;
decimal holdPayment = 0;
do
{
    Console.WriteLine("\nWelcome to Great Coffee. Here is our menu");
    displayMenu();
    Console.WriteLine("\nHow may I serve you today?");
    itemCost = 0;

    itemCost = processOrder();
    Console.WriteLine($"Your item(s) cost is...{itemCost:C}");
    while (!exit)
    {
        Console.WriteLine("Do you want to buy another item? (yes/no)");
        userInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(userInput))
        {
            if (userInput.ToLower() == "yes")
            {
                itemCost = processOrder();
                Console.WriteLine($"Your item(s) cost is...{itemCost:C}");
            }
            else if (userInput.ToLower() == "no")
            {
                Console.WriteLine($"Your item(s) cost is...{itemCost:C}");
                Console.WriteLine("Would you like to pay or cancel the transaction? (pay/cancel)");
                userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput))
                {
                    if (userInput.ToLower() == "pay")
                    {
                        processPayment(itemCost);
                        break;
                    }
                    else if (userInput.ToLower() == "cancel")
                    {
                        itemCost = 0;
                        Console.WriteLine("Transaction cancelled successfully.");
                        break;
                    }
                }
            }
        }
    }
    Console.WriteLine($"Current sale is... {currentSale:C}");
    Console.WriteLine($"Total sale is... {totalSale:C}");
    Console.WriteLine("Press enter to continue");
    Console.ReadLine();
    itemCost = 0;
} while (!exit);


Console.WriteLine("\nTransaction Records (for admin only)\n");
for (int i = 0; i < transactionRecord.GetLength(0); i++)
{
    if (!string.IsNullOrEmpty(transactionRecord[i, 0]))
    {
        found = true;
        Console.WriteLine($"{transactionRecord[i, 0]}");
        Console.WriteLine(transactionRecord[i, 1]);
    }
}
if (!found)
{
    Console.WriteLine("No transaction record");
}

Console.WriteLine($"Total sale is... {totalSale:C}");
Console.WriteLine($"Total money in till is...{tillCount():C}");
Console.WriteLine("Press enter to close the transaction record");
Console.ReadLine();

Console.WriteLine("Financial Report (for admin only)");
Console.WriteLine("Closing...report");
closingTill(totalSale);
Console.WriteLine("Press enter to close the report");
Console.ReadLine();

void displayMenu()
{
    Console.WriteLine("\nMENU\n");
    Console.WriteLine("Drinks List");
    for (int i = 0; i < drinks.Length; i++)
    {
        Console.WriteLine($"{drinks[i].PadRight(20)}{drinksPrice[i]:C}");
    }
    Console.WriteLine("\nCakes List");
    for (int i = 0; i < cakes.Length; i++)
    {
        Console.WriteLine($"{cakes[i].PadRight(20)}{cakesPrice[i]:C}");
    }
}

decimal processOrder()
{
    Console.WriteLine("Please enter the name of the item you'd like to buy or exit to quit");
    do
    {
        found = false;
        userInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(userInput))
        {
            if (userInput.ToLower().Trim() == "exit")
            {
                exit = true;
                break;
            }
            else
            {
                string item = userInput.Trim();
                for (int i = 0; i < drinks.Length; i++)
                {
                    if (string.Equals(item, drinks[i], StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        itemCost += drinksPrice[i];
                        break;
                    }
                }

                if (!found)
                {
                    for (int i = 0; i < cakes.Length; i++)
                    {
                        if (string.Equals(item, cakes[i], StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            itemCost += cakesPrice[i];
                            break;
                        }
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Invalid item: Please enter an item from our menu or check your spelling");
                    found = false;
                }
            }
        }
    } while (found == false);
    return itemCost;
}
decimal processPayment(decimal cost)
{
    if (takePayment(cost))
    {
        for (int i = 0; i < transactionRecord.GetLength(0); i++)
        {

            if (string.IsNullOrEmpty(transactionRecord[i, 0]))
            {
                customerCount += 1;
                transactionRecord[i, 0] = "Customer" + customerCount;
                transactionRecord[i, 1] = $"Sale:   {cost:C}";
                Console.WriteLine("Payment Successful. Thank You!");
                break;
            }
            if (i == transactionRecord.GetLength(0) - 1)
            {
                Console.WriteLine($"Warning! I can't keep record of more than {transactionRecord.GetLength(0)} transactions, so the record of this transaction has not been kept");
                break;
            }

        }
    }
    else
    {
        cost = 0;
        Console.WriteLine("Payment Failed!");
    }
    currentSale = cost;
    totalSale += cost;
    return totalSale;
}
bool takePayment(decimal cost, decimal userDenomination = 0, int userDenominationCount = 1)
{
    do
    {
        Console.WriteLine("Please enter the denomination (e.g 20) or/and how many of the same denomination " +
                          "separated by comma (e.g 20,1).\nAccepted denominations are: 50, 20, 10, 5, 2, 1, " +
                          "0.50, 0.20, 0.10, 0.05, 0.02, and 0.01.");
        userInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(userInput))
        {
            string[] userPayment = new string[2];
            if (userInput.Contains(','))
            {
                userPayment = userInput.Trim().Split(',');
                if (userPayment.Length == 2)
                {
                    decimal.TryParse(userPayment[0], out userDenomination);
                    int.TryParse(userPayment[1], out userDenominationCount);
                }
                else
                {
                    Console.WriteLine("Invalid Format: Too many arguments");
                }
            }
            else
            {
                userPayment[0] = userInput.Trim();
                decimal.TryParse(userInput, out userDenomination);
            }
            if (Array.Exists(tillCurrency, c => c == userDenomination))
            {
                decimal custormerPayment = userDenomination * userDenominationCount;
                if (custormerPayment == cost)
                {
                    sortPayment(userDenomination, userDenominationCount);
                    validInput = true;
                    holdPayment = 0;
                    return true;
                }
                else if (custormerPayment > cost)
                {

                    if (giveChange(cost, custormerPayment))
                    {
                        sortPayment(userDenomination, userDenominationCount);
                        validInput = true;
                        holdPayment = 0;
                        return true;
                    }
                    else
                    {

                        if (holdPayment > 0)
                        {
                            cost = 0;
                            giveChange(cost, holdPayment);
                            Console.WriteLine("Your held payment has been refunded");
                            holdPayment = 0;
                        }
                        Console.WriteLine("Transaction has been cancelled as i am not able to give change.");
                        Console.WriteLine($"Your payment of {custormerPayment:C} ({userDenomination:C} * {userDenominationCount}) is returned.");
                        holdPayment = 0;
                        return false;
                    }
                }
                else
                {
                    holdPayment += custormerPayment;
                    sortPayment(userDenomination, userDenominationCount);
                    cost -= custormerPayment;
                    Console.WriteLine($"Not enough money, {cost} left to pay.");
                    Console.WriteLine($"Would you like to continue? (continue/cancel)");
                    userInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        if (userInput.ToLower() == "continue")
                        {
                            return takePayment(cost);
                        }
                        else if (userInput.ToLower() == "cancel")
                        {
                            cost = 0;
                            custormerPayment = holdPayment;
                            if (giveChange(cost, custormerPayment))
                            {
                                Console.WriteLine("Transaction canceled successfully");
                                holdPayment = 0;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Cannot give change. Sorry!");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter the right denomination to continue");
                            return takePayment(cost);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input: Please input the right denominations");
                return takePayment(cost);
            }
        }
    } while (validInput == false);
    return false;
}
void sortPayment(decimal denomination, int denominationCount)
{
    for (int i = 0; i < tillCurrency.Length; i++)
    {
        if (denomination == tillCurrency[i])
        {
            currencyCount[i] += denominationCount;
        }
    }
}
bool giveChange(decimal cost, decimal payment)
{
    decimal change = payment - cost;
    if (change > 0)
    {
        changeValidation(change);
        if (change > tillCount())
        {
            Console.WriteLine("Not enough money in till to provide change.");
            return false;
        }
        else if (change < validateChange)
        {
            do
            {
                for (int i = 0; i < currencyCount.Length; i++)
                {
                    if (currencyCount[i] > 0)
                    {
                        if (change >= tillCurrency[i])
                        {
                            decimal changeGiven = 0;
                            int count = 0;
                            do
                            {
                                change -= tillCurrency[i];
                                currencyCount[i] -= 1;
                                changeGiven += tillCurrency[i];
                                count++;
                            } while (change >= tillCurrency[i] && currencyCount[i] > 0);
                            Console.WriteLine($"Here is {changeGiven:C} ({tillCurrency[i]:C} * {count}) Change, Your remainging change is {change:C}.");
                            found = true;
                            i = 0;
                        }
                    }
                }
                if (change <= 0)
                {
                    Console.WriteLine("Change is fully given! Thank You");
                    return true;
                }
                if (!found)
                {
                    Console.WriteLine("I am not able to provide the required change");
                    return false;
                }
            } while (change > 0);
        }
        else
        {
            Console.WriteLine("No required denomination to provide change in the till.");
            return false;
        }
    }
    return false;
}

decimal tillCount()
{
    tillSum = 0;
    for (int i = 0; i < currencyCount.Length; i++)
    {
        tillSum += (tillCurrency[i] * currencyCount[i]);
    }
    return tillSum;
}
decimal changeValidation(decimal change)
{
    validateChange = 0;
    for (int i = 0; i < currencyCount.Length; i++)
    {

        if (change >= tillCurrency[i] && currencyCount[i] > 0)
        {
            validateChange += (tillCurrency[i] * currencyCount[i]);
        }
    }
    return validateChange;
}
void closingTill(decimal sale)
{
    decimal deduction = sale;

    if (deduction <= 0)
    {
        Console.WriteLine("No profit made");
        Console.WriteLine($"The total money in till is {tillCount:C}");
    }
    else if (deduction > 0)
    {
        for (int i = 0; i < currencyCount.Length; i++)
        {
            if (currencyCount[i] > 0)
            {
                if (deduction >= tillCurrency[i])
                {
                    int count = 0;
                    do
                    {
                        deduction -= tillCurrency[i];
                        currencyCount[i]--;
                        count++;
                    } while (deduction >= tillCurrency[i] && currencyCount[i] > 0);
                    Console.WriteLine($"{tillCurrency[i]:C} * {count} has been taken out of the till");
                    i = 0;
                }
            }
        }
        if (deduction == 0)
        {
            Console.WriteLine($"Total amount taken out of the till is...{sale:C}, Therefore we made a total of...{sale:C} profit");
            Console.WriteLine($"Total Money in till is now...{tillCount():C}");
            for (int i = 0; i < currencyCount.Length; i++)
            {
                Console.WriteLine($"Total number of {tillCurrency[i]:C} is {currencyCount[i]}");
            }
        }
        else
        {
            Console.WriteLine("Couldn't complete closing till proccess");
        }
    }
}