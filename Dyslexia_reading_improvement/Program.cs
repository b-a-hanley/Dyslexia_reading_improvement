using System;
using System.Threading;
namespace Dyslexia_reading_improvement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the HyperLexic \n************************************************** ");
            Thread.Sleep(500);
            Console.WriteLine("I'm your host Bennington and heres the instructions..");
            Thread.Sleep(500);
            Console.WriteLine("You will be given a word and you guess it");
            sbyte points = 5;
            int score = 0;
            int level = 1;
            //first time correct = 5 points
            //second tim e correct = 3 points 
            //third time correct = 1 point
            //any time wrong = 0 points
            //makes an array of words

            //random number generator 
            string playagain = ("y");
            game();
            while (playagain != "n")
            {
                Console.WriteLine($"\nPlay again? (y/n) or for highscores type 'h'");
                playagain = Console.ReadLine();
                switch (playagain)
                {
                    case "y":
                        game();
                        break;
                    case "yes":
                        game();
                        break;
                    case "highscore":
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
            void game()
            {
                bool gamestate = true;
                while (gamestate)
                {
                    points = 5;

                    string[] words = { "birch", "because", "brilliant", "jamaican", "cordroy", "lemon", "trickled", "impeach", "establish", "configure", "number", "monosyllabic" };
                    Random rnd = new Random();
                    string word = words[rnd.Next(words.Length - 1)].ToUpper();
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
                        string[] array = clue.ToUpper().Trim().Split("CLUE");
                        try
                        { return array[1]; }
                        catch
                        { return array[0]; }
                    }
                    string clue = ClueCut(response);
                    while (response != clue)
                    {
                        response = ClueCut(response);

                        if ((clue == "1") && (points == 5))
                        {
                            Console.WriteLine(word[0].ToString() + word[1].ToString() + randchar(word.Length - 3).ToString() + word[word.Length - 1].ToString());
                            response = Console.ReadLine();
                            clue = ClueCut(response);

                            points = 3;
                        }
                        else if ((clue == "2") && (points > 2))
                        {
                            Console.WriteLine(word[0].ToString() + word[1].ToString() + randchar(word.Length - 4).ToString() + word[word.Length - 2].ToString() + word[word.Length - 1].ToString());
                            response = Console.ReadLine();
                            clue = ClueCut(response);
                            points = 2;
                        }
                        else if ((clue == "3") && (points > 1))
                        {
                            Console.WriteLine(word[0].ToString() + word[1].ToString() + word[2].ToString() + randchar(word.Length - 5).ToString() + word[word.Length - 2].ToString() + word[word.Length - 1].ToString());
                            response = Console.ReadLine();
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