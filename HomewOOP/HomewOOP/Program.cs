//Для класса банковский счет переопределить операторы == и != для сравнения информации в двух счетах.
//Переопределить метод Equals аналогично оператору ==, не забыть переопределить метод GetHashCode().
//Переопределить методToString() для печати информации о счете. Протестировать функционирование
//переопределенных методов и операторов на простом примере.

BancAccount a1 = new BancAccount(100000, AccountType.Budget_Account);
BancAccount a2 = new BancAccount(100000, AccountType.Budget_Account);
BancAccount a3 = new BancAccount(8500, AccountType.Savings_Account);
BancAccount a4 = a3;

bool comparison = a1 == a2;
Console.WriteLine(comparison);
comparison = a2 == a3;
Console.WriteLine(comparison);
comparison = a1 != a2;
Console.WriteLine(comparison);
comparison = a1 != a3;
Console.WriteLine(comparison);

Console.WriteLine(a1.ToString());
Console.WriteLine(a3.ToString());

Console.WriteLine(a1.Equals(a3));
Console.WriteLine(a3.Equals(a4));

Console.WriteLine(a1.GetHashCode());
Console.WriteLine(a2.GetHashCode());
Console.WriteLine(a3.GetHashCode());

public enum AccountType
{
    Budget_Account,
    Currency_Account,
    Frozen_Account,
    Insured_Account,
    Current_Account,
    Correspondent_Account,
    Savings_Account,
}
public class BancAccount
{
    private static int number = 1;
    private int accountNumber;
    private decimal balance;
    private AccountType _type;

    public BancAccount(decimal v1, AccountType v2)
    {
        accountNumber = number++;
        balance = v1;
        _type = v2;
    }
    public void Take(int someMoney)
    {
        if (someMoney > balance)
        {
            Console.WriteLine("Недостаточно средств на счёте");
        }
        else if (someMoney <= balance)
        {
            balance -= someMoney;
            Console.WriteLine($"Баланс: {balance}");
        }
    }
    public void Put(int someMoney)
    {
        balance += someMoney;
        Console.WriteLine($"Баланс: {balance}");
    }
    public void TransferToAnotherAccount(BancAccount Debit, int sum)
    {
        if (sum > Debit.balance)
        {
            Console.WriteLine("Перевод средств невозможен");
        }
        if (sum <= Debit.balance)
        {
            Debit.balance -= sum;
            this.balance += sum;
        }
    }
    public static bool operator ==(BancAccount bn1, BancAccount bn2)
    {
        if (bn1._type == bn2._type)
            return true;
        else
            return false;
    }
    public static bool operator !=(BancAccount bn1, BancAccount bn2)
    {
        if (bn1._type != bn2._type)
            return true;
        else
            return false;
    }
    public override string ToString()
    {
        return $"Номер счета: {accountNumber}\nТип счета: {_type}\nБаланс: {balance}";
    }
    public override bool Equals(object? o)
    {
        if (o.GetHashCode == this.GetHashCode)
            return true;
        else
            return false;
    }
    public override int GetHashCode()
    {
        Random r = new Random();
        string hashcode = "1";
        for(int i = 0; i < 9; i++)
        {
            hashcode += r.Next(0, 10).ToString();
        }
        return Convert.ToInt32(hashcode);
    }
}