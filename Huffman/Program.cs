using System;

namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            string text =
                "This is short sample text to encode.";
            var tree = new HuffTree();
            string encoded = tree.Encode(text);

            tree.Reset();
            string decoded = tree.Decode(encoded);

            Console.WriteLine(decoded);
        }
    }
}