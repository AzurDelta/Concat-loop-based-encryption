
using System.Text;

Console.Write("enter a string: ");
string stringToEncrypt = Console.ReadLine();
int iterations = 0;
while (true)
{
    Console.Write("enter number of iterations: ");
    try
    {
       iterations = int.Parse(Console.ReadLine());
    }
    catch
    {   
         Console.WriteLine("not an integer");
    }
    if (iterations != 0) 
        break;
}
var result = Incrypt(stringToEncrypt, iterations);
Console.WriteLine(result);
result = Decrypt(result);
Console.WriteLine(result);



string Incrypt(string stringToEncrypt, int iterations)
{
    StringBuilder outstring = new StringBuilder();
    string encryptedString = "";
    var length = stringToEncrypt.Length;

    if (length % 2 != 0) length--;

    for (var iter = 0; iter < iterations; iter++)
    {
        for (int i = 0; i < length; i++)
        {
            if (i < length - i-1)
            {
                outstring.Append(stringToEncrypt[i]);
                outstring.Append(stringToEncrypt[length - 1 - i]);
            }
            else if (i == length - i - 1)
            {
                outstring.Append(stringToEncrypt[i]);
            }
            else
            {
                if (stringToEncrypt.Length % 2 != 0) outstring.Append(stringToEncrypt[stringToEncrypt.Length-1]);
                encryptedString = outstring.ToString();
                outstring.Clear();
                break;
            }

        }
    }

    encryptedString = encryptedString + "@" + iterations;

    return encryptedString;
}

string Decrypt(string stringToDecrypt)
{
    StringBuilder outstring = new StringBuilder();
    var iterations = int.Parse(stringToDecrypt.Split('@')[1]);
    stringToDecrypt = stringToDecrypt.Split('@')[0];
    int length = stringToDecrypt.Length;
    bool even = true;
    string decryptedString = "";

    if (length % 2 != 0)
    {
        length--;
        even = false;
    }

    for (var iter = 0;iter < iterations;iter++)
    {
        for (var i = length-1; i >= 0; i--)
        {
            if (i % 2 == 0) outstring.Insert(0, stringToDecrypt[i]); 
            else outstring.Append(stringToDecrypt[i]);
        }
        decryptedString = outstring.ToString();
        outstring.Clear();
    }

    if (!even) decryptedString += stringToDecrypt[stringToDecrypt.Length - 1];

    return decryptedString;
}