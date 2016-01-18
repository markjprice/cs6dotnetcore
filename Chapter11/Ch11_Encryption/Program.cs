using Ch11_Cryptography;
using static System.Console;

namespace Ch11_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter a message that you want to encrypt: ");
            string message = ReadLine();
            Write("Enter a password: ");
            string password = ReadLine();
            string cryptoText = Protector.Encrypt(message, password);
            WriteLine($"Encrypted text: {cryptoText}");
            string clearText = Protector.Decrypt(cryptoText, password);
            WriteLine($"Decrypted text: {clearText}");
        }
    }
}
