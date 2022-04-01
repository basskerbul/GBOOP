//Создать класс рациональных чисел. В классе два поля – числитель и
//знаменатель. Предусмотреть конструктор. Определить операторы ==, != (метод
//Equals()), <, >, <=, >=, +, – .Переопределить метод ToString() для вывода
//дроби. Определить операторы преобразования типов между типом дробь, float, int.
//Определить операторы *, /

RationalNumbers rn1 = new RationalNumbers(6, 5);
RationalNumbers rn2 = new RationalNumbers(1, 2);

var result = rn1 - rn2;
Console.WriteLine(result);

result = rn1 + rn2;
Console.WriteLine(result);

bool comparison = rn1 >= rn2;
Console.WriteLine($"Оператор >= {comparison}");

comparison = rn1 <= rn2;
Console.WriteLine($"Оператор <= {comparison}");

comparison = rn1 < rn2;
Console.WriteLine($"Оператор < {comparison}");

comparison = rn1 > rn2;
Console.WriteLine($"Оператор > {comparison}");

comparison = rn1 == rn2;
Console.WriteLine($"Оператор == {comparison}");

comparison = rn1 != rn2;
Console.WriteLine($"Оператор != {comparison}");

Console.WriteLine($"{rn1.ToString()}\n{rn2.ToString()}");

Console.WriteLine(rn1.Equals(rn2));

result = rn1 * rn2;
Console.WriteLine(result);

result = rn1 / rn2;
Console.WriteLine(result);

class RationalNumbers
{
    internal int numerator;
    internal int denominator;

    public RationalNumbers(int value1, int value2)
    {
        numerator = value1;
        if (value1 != 0)
            denominator = value2;
        else
        {
            Console.WriteLine("Делитель не может быть нулем. Установлено значение по умолчанию");
            denominator = 1;
        }
    }
    public static double operator / (RationalNumbers rn1, RationalNumbers rn2)
    {
        double quotient1 = rn1.numerator * rn2.denominator;
        double quotient2 = rn1.denominator * rn2.numerator;
        return quotient1 / quotient2;
    }
    public static double operator * (RationalNumbers rn1, RationalNumbers rn2)
    {
        double quotientN = rn1.numerator * rn2.numerator;
        double quotientD = rn1.denominator * rn2.denominator;
        return quotientN / quotientD;
    } 
    public override string ToString()
    {
        return $"RationalNumber {numerator}/{denominator}";
    }
    public static double operator - (RationalNumbers rn1, RationalNumbers rn2)
    {
        if(rn1.denominator == rn2.denominator)
        {
            double result = rn1.numerator - rn2.numerator;
            return result / rn1.denominator;
        }
        else
        {
            double an = rn1.numerator * rn2.denominator;
            double ab = rn1.denominator * rn2.denominator;
            double bn = rn2.numerator * rn1.denominator;
            double result = an - bn;
            result /= ab;
            return result;
        }
    }
    public static double operator + (RationalNumbers rn1, RationalNumbers rn2)
    {
        if (rn1.denominator == rn2.denominator)
        {
            double result = rn1.numerator + rn2.numerator;
            return result / rn1.denominator;
        }
        else
        {
            double an = rn1.numerator * rn2.denominator;
            double ab = rn1.denominator * rn2.denominator;
            double bn = rn2.numerator * rn1.denominator;
            double result = an + bn;
            result /= ab;
            return result;
        }
    }
    public static bool operator >= (RationalNumbers rn1, RationalNumbers rn2)
    {
        if (rn1.denominator == rn2.denominator)
        {
            return rn1.numerator >= rn2.numerator;
        }
        else
        {
            double an = rn1.numerator * rn2.denominator;
            double bn = rn2.numerator * rn1.denominator;
            
            return an >= bn;
        }
    }
    public static bool operator <= (RationalNumbers rn1, RationalNumbers rn2)
    {
        if (rn1.denominator == rn2.denominator)
        {
            return rn1.numerator <= rn2.numerator;
        }
        else
        {
            double an = rn1.numerator * rn2.denominator;
            double bn = rn2.numerator * rn1.denominator;

            return an <= bn;
        }
    }
    public static bool operator < (RationalNumbers rn1, RationalNumbers rn2)
    {
        if (rn1.denominator == rn2.denominator)
        {
            return rn1.numerator < rn2.numerator;
        }
        else
        {
            double an = rn1.numerator * rn2.denominator;
            double bn = rn2.numerator * rn1.denominator;

            return an < bn;
        }
    }
    public static bool operator > (RationalNumbers rn1, RationalNumbers rn2)
    {
        if (rn1.denominator == rn2.denominator)
        {
            return rn1.numerator > rn2.numerator;
        }
        else
        {
            double an = rn1.numerator * rn2.denominator;
            double bn = rn2.numerator * rn1.denominator;

            return an > bn;
        }
    }
    /// <summary>
    /// Возвращает true если равно
    /// </summary>
    /// <param name="rn1"></param>
    /// <param name="rn2"></param>
    /// <returns></returns>
    public static bool operator == (RationalNumbers rn1, RationalNumbers rn2)
    {
        if (rn1.denominator == rn2.denominator)
        {
            return rn1.numerator == rn2.numerator;
        }
        else
        {
            double an = rn1.numerator * rn2.denominator;
            double bn = rn2.numerator * rn1.denominator;

            return an == bn;
        }
    }
    /// <summary>
    /// Возвращает true если не равно
    /// </summary>
    /// <param name="rn1"></param>
    /// <param name="rn2"></param>
    /// <returns></returns>
    public static bool operator != (RationalNumbers rn1, RationalNumbers rn2)
    {
        if (rn1.denominator == rn2.denominator)
        {
            return rn1.numerator != rn2.numerator;
        }
        else
        {
            double an = rn1.numerator * rn2.denominator;
            double bn = rn2.numerator * rn1.denominator;

            return an != bn;
        }
    }
    public override bool Equals(object o)
    {
        if (o is RationalNumbers)
            return true;
        else
            return false;
    }
}