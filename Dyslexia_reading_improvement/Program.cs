using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Dyslexia_reading_improvement
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            //random number generator 

            Console.WriteLine("Welcome to the HyperLexic \n************************************************** ");
            Thread.Sleep(500);
            Console.WriteLine("I'm your host Bennington and would you like to hear how to play? (y/n)");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("The aim of the game is to guess the word hidden infront of you. You will be given a word which will start and end with the real letters which will be capitalised");
                Thread.Sleep(1500);
                Console.WriteLine("You can request clues by typing: clue1, clue2, clue3. These progressively make it easier to guess the word. However these will cost you points that can be earnt each round");
                Thread.Sleep(1500);
                Console.WriteLine("Word correct with No clues = 5 points");
                Thread.Sleep(100);
                Console.WriteLine("Word correct with Clue1 = 3 points");
                Thread.Sleep(100);
                Console.WriteLine("Word correct with Clue2 = 2 points");
                Thread.Sleep(100);
                Console.WriteLine("Word correct with Clue3 = 1 points");
                Thread.Sleep(300);
                Console.WriteLine("Get the word wrong you lose the game");
            }

            Thread.Sleep(300);
            Console.WriteLine("You will be given a word and you guess it");
            sbyte points = 5;
            int score = 0;
            int level = 1;
            List<string> words = loadDictionary();
            

                        string playagain = ("y");
            game(words);
            while (playagain != "n")
            {
                Console.WriteLine($"\nPlay again? (y/n) or for highscores type 'h'");
                playagain = Console.ReadLine();
                switch (playagain)
                {
                    case "y":
                        game(words);
                        break;
                    case "yes":
                        game(words);
                        break;
                    case "highscores":
                        highscore();
                        break;
                    case "h":
                        highscore();
                        break;
                    default:
                        Console.Write("Thanks for coming i was your host bennington and this was ");
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(300);
                            Console.Write(".");
                        }
                        Thread.Sleep(500);
                        Console.WriteLine(" HyperLexic!");                        
                        Environment.Exit(0);
                        break;
                }
            }
            void highscore()
            {

            }
            List<string> loadDictionary()
            {
                string filePath = "google-10000-english.txt";
                string[] dictionary= File.ReadAllLines(filePath);//reads file location and splits and stores in an array of lines 
                var wordList = new List<string>();
                for (int i = 0; i < dictionary.Length; i++)
                {
                    if (dictionary[i].Length > 5)
                    {
                        wordList.Add(dictionary[i]);
                    }
                    
                }
                return wordList;
            }
            
            void game(List<string> words)
            {
                bool gamestate = true;
                while (gamestate)
                {
                    points = 5;
                    string word = words[rnd.Next(words.Count - 1)].ToUpper();
                    string randchar(int len)
                    {
                        string str = "";
                        for (int i = 0; i < len; i++)
                        { str += Convert.ToChar(rnd.Next(97, 122)); }
                        return str;
                    }
                    Console.WriteLine(word[0] + randchar(word.Length - 2) + word[word.Length - 1]);
                    string response = Console.ReadLine().ToUpper().Trim();
                    string ClueCut(string clue)
                    {
                        string[] array = clue.Split("CLUE");
                        try
                        { return array[1]; }
                        catch
                        { return array[0]; }
                    }
                    string clue = ClueCut(response);
                    while (response != clue)
                    {   
                        response = ClueCut(response);

                        if (clue == "1") 
                        {
                            Console.WriteLine(word[0].ToString() + word[1].ToString() + randchar(word.Length - 3).ToString() + word[word.Length - 1].ToString());
                            response = Console.ReadLine().ToUpper().Trim();
                            clue = ClueCut(response);

                            points = 3;
                        }
                        else if (clue == "2") 
                        {
                            Console.WriteLine(word[0].ToString() + word[1].ToString() + randchar(word.Length - 4).ToString() + word[word.Length - 2].ToString() + word[word.Length - 1].ToString());
                            response = Console.ReadLine().ToUpper().Trim();
                            clue = ClueCut(response);
                            points = 2;
                        }
                        else if (clue == "3")
                        {
                            Console.WriteLine(word[0].ToString() + word[1].ToString() + word[2].ToString() + randchar(word.Length - 5).ToString() + word[word.Length - 2].ToString() + word[word.Length - 1].ToString());
                            response = Console.ReadLine().ToUpper().Trim();
                            clue = ClueCut(response);
                            points = 1;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You deserve to die in a pit of slimed eels");
                        }
                    }
                    if (response == word)
                    {
                        Console.WriteLine("Well done");
                        score += points;
                        Console.WriteLine($"\nScore={score}\nLevel={level}\n");
                        level++;
                    }
                    else
                    {
                        Console.WriteLine($"The word was {word}\nYou lost all your points :(");
                        Console.WriteLine($"{response}");
                        Console.Write($"\nYour final score was");
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(300);
                            Console.Write(".");
                        }     
                        Thread.Sleep(300);
                        Console.WriteLine($"\nScore={score}\nLevel={level}\n");

                        score = 0;
                        level = 1;
                        gamestate = false;
                    }
                }
            }
        }
    }
}