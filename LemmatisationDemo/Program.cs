using LemmaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemmatisationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string exampleSentence = "On the other hand, inflectional paradigms, " +
                 "or lists of inflected forms of typical words (such as sing, sang, " +
                 "sung, sings, singing, singer, singers, song, songs, songstress, " +
                 "songstresses in English) need to be analyzed according to criteria " +
                 "for uncovering the underlying lexical stem.";

            string[] exampleWords = exampleSentence.Split(
                new char[] { ' ', ',', '.', ')', '(' }, StringSplitOptions.RemoveEmptyEntries);

            ILemmatizer lmtz = new LemmatizerPrebuiltFull(LanguagePrebuilt.English);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Example sentence lemmatized");
            Console.WriteLine("        WORD ==> LEMMA");
            foreach (string word in exampleWords)
                LemmatizeOne(lmtz, word);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static void LemmatizeOne(LemmaSharp.ILemmatizer lmtz, string word)
        {
            string wordLower = word.ToLower();
            string lemma = lmtz.Lemmatize(wordLower);
            Console.ForegroundColor = wordLower == lemma ? ConsoleColor.White : ConsoleColor.Red;
            Console.WriteLine("{0,12} ==> {1}", word, lemma);
        }
    }
}
