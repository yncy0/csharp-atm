// See https://aka.ms/new-console-template for more information

double balance = 1000.00;
bool looper = true;

do
{
    menu();
} while (looper);


void menu()
{
    Console.WriteLine("\nWelcome to the Simple ATM Simulation");
    Console.WriteLine("Your starting balance $1000.00");

    Console.WriteLine("\n==========================================================");
    Console.WriteLine("Please select an option to perform a single action");
    Console.WriteLine("1. Deposit");
    Console.WriteLine("2. Withdraw");
    Console.WriteLine("3. Check Balance");
    Console.WriteLine("4. Exit ATM");
    Console.Write("Enter your choice (1, 2, 3, or 4): ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            onDeposit();
            break;
        case 2:
            onWithdraw();
            break;
        case 3:
            onCheckBalance();
            break;
        case 4:
            onExit();
            break;
        default:
            Console.WriteLine("\n!!!Invalid Input!!!\n");
            break;
    }
}

void onDeposit()
{
    double amount = 0;

    Console.Write("Please Enter Deposit amount: ");
    amount = double.Parse(Console.ReadLine());

    if (amount < 0)
    {
        Console.WriteLine("Insufficient Funds");
        // onSelectChoice();
        return;
    }

    balance += amount;

    Console.WriteLine($"Your deposit amount: ${amount:F}");
    Console.WriteLine($"Your balance: ${balance:F}");
    onSelectChoice();
}

void onWithdraw()
{
    double amount = 0;

    Console.Write("Please Enter Withdraw amount: ");
    amount = double.Parse(Console.ReadLine());

    if (amount < 0 || amount < 100)
    {
        Console.WriteLine("Insufficient Funds");
        // onSelectChoice();
        return;
    }

    if (amount > balance)
    {
        Console.WriteLine("Withdraw Error! Insufficient Balance");
        // onSelectChoice();
        return;
    }

    double isDivisible = amount % 100;
    if (isDivisible != 0)
    {
        Console.WriteLine("Withdraw Failed! Must follow common denominator");
        // onSelectChoice();
        return;
    }

    balance -= amount;

    Console.WriteLine($"Your withdraw amount: ${amount:F}");
    Console.WriteLine($"Your balance: ${balance:F}");
    onSelectChoice();
}

void onCheckBalance()
{
    Console.Write($"Your total balance is ${balance:F}");
}

void onExit()
{
    Console.WriteLine("Exiting ATM");
    looper = false;
}

void onSelectChoice()
{
    string userInput = "";

    Console.Write(@"Would you like to continue? [y/N] ");
    userInput = Console.ReadLine().ToLower();

    switch (userInput)
    {
        case "y":
            break;
        case "n":
            looper = false;
            break;
        default:
            Console.WriteLine("\n!!!Invalid Input!!!\n");
            break;
    }
}
