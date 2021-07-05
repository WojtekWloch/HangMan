using System;
using System.Linq;

namespace Hangman_WW
{
    class Program
    {
        static void Main(string[] args)
        {
                while (true)
                {
                    string[] draw =
                    {
                    "  |   |   |",
                    "  |   O   |",
                    "  |  -|-  |",
                    "  |   |   |",
                    "  |  d b  |",
                };
                    string[] allWords =
                    {
                    "amsterdam",
                    "andorra",
                    "athens",
                    "belgrade",
                    "berlin",
                    "bern",
                    "bratislava",
                    "brussels",
                    "bucharest",
                    "budapest",
                    "chisinau",
                    "copenhagen",
                    "dublin",
                    "kiev",
                    "helsinki",
                    "lisbon",
                    "ljubljana",
                    "london",
                    "luxembourg",
                    "madrid",
                    "monaco",
                    "nicosia",
                    "nuuk",
                    "oslo",
                    "paris",
                    "podgorica",
                    "prague",
                    "reykjavik",
                    "riga",
                    "rome",
                    "sarajevo",
                    "skopje",
                    "sofia",
                    "stockholm",
                    "tallinn",
                    "tirana",
                    "vaduz",
                    "vienna",
                    "valletta",
                    "warsaw",
                    "zagreb",
                    }; 
                    Random rand = new Random();
                    string word;
                    int allWordsLen = allWords.Length;
                    int random = rand.Next(allWordsLen);
                    word = allWords[random];
                    int wordLen = word.Length;
                    char[] userWord = new char[wordLen];
                    for (int i = 0; i < wordLen; i++) 
                    {
                        userWord[i] = '-';
                    }
                    int errCount = draw.Length;
                    int err = 0;
                    char[] errChars = new char[errCount];
                    bool game = true;
                    for (int i = 0; i < errCount; i++)
                    {
                        Console.WriteLine(draw[i]);
                    }
                    Console.WriteLine("\nTylko się nie zawieś!\n");
                    while (game)
                    {
                        for (int i = 0; i < err; i++)
                        {
                            Console.WriteLine(draw[i]);
                        }
                        Console.WriteLine();
                        Console.WriteLine(userWord);
                        Console.WriteLine();
                        Console.Write("Podane błędne litery: ");
                        Console.Write(errChars);
                        Console.WriteLine("\nZ 5 szans pozostało Ci jeszcze {0}", errCount - err);
                        Console.WriteLine("\nPodaj literę: ");
                        string s = Console.ReadLine();
                        char c;
                        if (s.Length > 0)
                            c = s.ElementAt(0);
                        else
                            continue;
                        bool charFound = false;
                        bool win = false;
                        for (int i = 0; i < wordLen; i++)
                        {
                            if (c == word.ElementAt(i))
                            {
                                userWord[i] = c;
                                charFound = true;
                            }
                        }
                        bool errCharFound = false;
                        if (!charFound)
                        {
                            err += 1;
                            for (int i = 0; i < errChars.Length; i++)
                            {
                                if (errChars[i] == c)
                                {
                                    errCharFound = true;
                                    break;
                                }
                            }
                            if (!errCharFound)
                            {
                                for (int i = 0; i < errChars.Length; i++)
                                {
                                    if (errChars[i] == 0)
                                    {
                                        errChars[i] = c;
                                        break;
                                    }

                                }
                            }
                        }
                        for (int i = 0; i < wordLen; i++)
                        {
                            if (userWord[i] == '-')
                            {
                                win = false;
                                break;
                            }
                            win = true;
                        }
                        if (err == errCount)
                        {
                            Console.WriteLine("Wisisz i powiewasz\n Szukane słowo to: {0}!\n", word);
                            Console.WriteLine("Naciśnij dowolny klawisz, aby rozpocząć nową grę");

                        Console.ReadLine();
                            game = false;
                        }
                        if (win)
                        {
                            Console.WriteLine("\nIdealnie! Szukana stolica to {0}!", word);
                            Console.WriteLine("Naciśnij dowolny klawisz, aby rozpocząć nową grę");

                        Console.ReadLine();
                            game = false;
                        }
                    
                    }

                }
            }
        }
    }