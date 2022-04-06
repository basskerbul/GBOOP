//Определить интерфейс IСoder, который полагает методы поддержки шифрования строк. В интерфейсе объявляются два
//метода Encode() и Decode(), используемые для шифрования и дешифрования строк. Создать класс ACoder, реализующий
//интерфейс ICoder. Класс шифрует строку посредством сдвига каждого символа на одну «алфавитную» позицию выше.
//(В результате такого сдвига буква А становится буквой Б). Создать класс BCoder, реализующий интерфейс ICoder.
//Класс шифрует строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на букву того же регистра,
//расположенную в алфавите на i-й позиции с конца алфавита. (Например, буква В заменяется на букву Э. Написать
//программу, демонстрирующую функционирование классов).

string text = "Я дерево. Когда меня срубят,";
ACoder a_coder = new ACoder();
Console.WriteLine(text);
text = a_coder.Encode(text);
Console.WriteLine(text);
text = a_coder.Decode(text);
Console.WriteLine(text);

text = "разведите костер из моих ветвей";
BCoder b_coder = new BCoder();
Console.WriteLine(text);
text = b_coder.Encode(text);
Console.WriteLine(text);

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
    string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя.,?!+-=*/@#%^;:~_";
    
    public string Encode(string text)
    {
        text = text.ToLower();
        string newText = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == 'я')
            {
                newText += 'а';
                continue;
            }
            if (text[i] == ' ')
            {
                newText += ' ';
                continue;
            }
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (text[i] == alphabet[j])
                {
                    newText += alphabet[++j];
                    break;
                }
            }
        }
        return newText;
    }
    public string Decode(string text)
    {
        text = text.ToLower();
        string newText = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == 'а')
            {
                newText += 'я';
                continue;
            }
            if (text[i] == ' ')
            {
                newText += ' ';
                continue;
            }
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (text[i] == alphabet[j])
                {
                    newText += alphabet[--j];
                    break;
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
    string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    string newText = "";

    public string Encode(string text)
    {
        for(int i = 0; i < text.Length; i++)
        {
            newText += alphabet[index];
        }
        return newText;
    }
    public string Decode(string text)
    {
        return "TODO";
    }
}