//Определить интерфейс IСoder, который полагает методы поддержки шифрования строк. В интерфейсе объявляются два
//метода Encode() и Decode(), используемые для шифрования и дешифрования строк. Создать класс ACoder, реализующий
//интерфейс ICoder. Класс шифрует строку посредством сдвига каждого символа на одну «алфавитную» позицию выше.
//(В результате такого сдвига буква А становится буквой Б). Создать класс BCoder, реализующий интерфейс ICoder.
//Класс шифрует строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на букву того же регистра,
//расположенную в алфавите на i-й позиции с конца алфавита. (Например, буква В заменяется на букву Э. Написать
//программу, демонстрирующую функционирование классов).

string text = "Я дерево. Когда меня срубят,";
ACoder coder = new ACoder();
Console.WriteLine(text);
Console.WriteLine(coder.Encode(text));
text = "бвгдеёж";
Console.WriteLine(text);
Console.WriteLine(coder.Decode(text));

interface ICoder
{
    /// <summary>
    /// Шифрование строк
    /// </summary>
    public string Encode(string text);
    /// <summary>
    /// Дешифрование строк
    /// </summary>
    public string Decode(string text);
}
/// <summary>
/// Сдвигает символы
/// </summary>
class ACoder: ICoder
{
    string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    string chars = " .,?!+-=*/@#%^;:~_";
    
    public string Encode(string text)
    {
        text = text.ToLower();
        string newText = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == 'я')
                newText += 'а';
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (text[i] == alphabet[j])
                {
                    newText += alphabet[++j];
                }
                switch (text[i])
                {
                    case ' ':
                        newText += ' ';
                        break;
                    case '.':
                        newText += '.';
                        break;
                    case ',':
                        newText += ',';
                        break;
                }
                //for (int z = 0; z < chars.Length; z++)
                //{
                //    if (z >= text.Length)
                //        continue;
                //    if (chars.Contains(text[z]))
                //    {
                //        newText += text[z];
                //    }
                //}
            }
        }
        return newText;
    }
    public string Decode(string text)
    {
        text = text.ToLower();
        string newText = "";
        string deasph = "";
        for(int i = alphabet.Length - 1; i >= 0; i--)
        {
            deasph += alphabet[i];
        }
        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < deasph.Length; j++)
            {
                if (text[i] == ' ')
                    newText += ' ';
                if (text[i] == 'а')
                    newText += 'я';
                if (text[i] == deasph[j])
                {
                    newText += deasph[++j];
                }
            }
        }
        return newText;
    }
}
/// <summary>
/// "Переворачивает" алфавит
/// </summary>
class BCoder: ICoder
{
    public string Encode(string text)
    {
        return "TODO";
    }
    public string Decode(string text)
    {
        return "TODO";
    }
}