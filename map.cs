using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Guman
{
    public class map
    {


        int score = 0;
        public List<List<string>> matrix { get; set; }

        public static int readhighscore()
        {
            using StreamReader reader = new("./highscore.json");
            var json = reader.ReadToEnd();
            List<highscore> scores = JsonConvert.DeserializeObject<List<highscore>>(json);

            return scores[0].high;
        }
        public static void writehighscore(int score)
        {
            using StreamWriter writer = new("./highscore.json");
            writer.Write("[{\"high\":"+score+"}]");
        }
        public static void makeapple(List<List<string>> matrix)
        {
            Random Random = new Random();
            int apple_row = Random.Next(1, matrix.Count - 1);
            int apple_col = Random.Next(1, matrix[apple_row].Count - 2);
            if (matrix[apple_row][apple_col] == "∅" || matrix[apple_row][apple_col] == "#" || matrix[apple_row][apple_col] == "@")
            {
                makeapple(matrix);
            }
            else
            {
                matrix[apple_row][apple_col] = "0";
            }

        }
        public static void makeComponent(List<List<string>> matrix)
        {
            // clear components
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    if (matrix[i][j] == "@")
                    {
                        matrix[i][j] = " ";
                    }
                }
            }
            // Create Components
            for (int i = 0; i < 5; i++)
            {
                Random Random = new Random();
                int apple_row = Random.Next(1, matrix.Count - 1);
                int apple_col = Random.Next(1, matrix[apple_row].Count - 2);
                if (matrix[apple_row][apple_col] == "∅" || matrix[apple_row][apple_col] == "#" || matrix[apple_row][apple_col] == "0")
                {
                }
                else
                {
                    matrix[apple_row][apple_col] = "@";
                }
            }


        }
        public map(List<List<string>> map) => this.matrix = map;

        public void printmap(List<List<string>> matrix)
        {
            List<string> lines = new List<string>();

            foreach (var list in matrix)
            {
                string line = "";
                foreach (var item in list)
                {
                    line = line + item;
                }
                lines.Add(line);
            }
            Console.WriteLine("Gumman v1.0.0");
            Console.WriteLine("your high score : " + readhighscore()); ;
            Console.WriteLine("you score : " + this.score);
            foreach (var list in lines)
            {
                Console.WriteLine(list);
            }
        }
        public void left(List<List<string>> map)
        {
            bool a = false;
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    if (map[i][j] == "∅" && map[i][j - 1] != "#")
                    {
                        if (map[i][j - 1] == "0")
                        {
                            a = true;
                        }
                        if (map[i][j - 1] == "@")
                        {
                            score = -1;
                        }
                        map[i][j] = " ";
                        map[i][j - 1] = "∅";
                        if (a == true)
                        {
                            this.score++;
                            makeapple(matrix);
                            makeComponent(matrix);
                            makeComponent(matrix);
                            makeComponent(matrix);
                            makeComponent(matrix);
                        }
                        break;

                    }

                }
            }
        }
        public void right(List<List<string>> map)
        {
            bool a = false;
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    if (map[i][j] == "∅" && map[i][j + 1] != "#")
                    {
                        if (map[i][j + 1] == "0")
                        {
                            a = true;
                        }
                        if (map[i][j + 1] == "@")
                        {
                            score = -1;
                        }
                        map[i][j] = " ";
                        map[i][j + 1] = "∅";
                        if (a == true)
                        {
                            this.score++;
                            makeapple(matrix);
                            makeComponent(matrix);
                            makeComponent(matrix);
                            makeComponent(matrix);
                            makeComponent(matrix);
                        }
                        break;
                    }

                }
            }
        }
        public void up(List<List<string>> map)
        {
            bool a = false;
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    if (map[i][j] == "∅" && map[i - 1][j] != "#")
                    {
                        if (map[i - 1][j] == "0")
                        {
                            a = true;
                        }
                        if (map[i - 1][j] == "@")
                        {
                            score = -1;
                        }
                        map[i][j] = " ";
                        map[i - 1][j] = "∅";
                        if (a == true)
                        {
                            this.score++;
                            makeapple(matrix);
                            makeComponent(matrix);
                            makeComponent(matrix);
                            makeComponent(matrix);
                            makeComponent(matrix);
                        }
                        break;
                    }
                }
            }
        }
        public void down(List<List<string>> map)
        {
            bool a = false;
            bool is_ok = false;
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    if (map[i][j] == "∅" && map[i + 1][j] != "#")
                    {
                        if (map[i + 1][j] == "0")
                        {
                            a = true;
                        }
                        if (map[i + 1][j] == "@")
                        {
                            score = -1;
                        }
                        map[i][j] = " ";
                        map[i + 1][j] = "∅";
                        is_ok = true;
                        if (a == true)
                        {
                            this.score++;
                            makeapple(matrix);
                            makeComponent(matrix);
                            makeComponent(matrix);
                            makeComponent(matrix);
                            makeComponent(matrix);
                        }
                        break;
                    }
                }
                if (is_ok)
                {
                    break;
                }
            }
        }
        public void run()
        {
            
            makeapple(this.matrix);
            while (true)
            {
                Console.Clear();
                int readerhighscore = readhighscore();
                if (readerhighscore < score)
                {
                    writehighscore(score);
                }
                this.printmap(matrix);
                var a = Console.ReadKey().KeyChar;
                if (a.ToString() == "a")
                {
                    this.left(this.matrix);
                }
                else if (a.ToString() == "d")
                {
                    this.right(this.matrix);
                }
                else if (a.ToString() == "w")
                {
                    this.up(this.matrix);
                }
                else if (a.ToString() == "s")
                {
                    this.down(this.matrix);
                }
                else if (a.ToString() == "p")
                {
                    makeapple(this.matrix);
                }
                else if (a.ToString() == "m")
                {
                    score = 501;
                }
                if (score == 500)
                {

                    Console.Clear();
                    Console.WriteLine("\r\n__   __            _                                             _   _   _ \r\n\\ \\ / /           | |                                           | | | | | |\r\n \\ V /___  _   _  | |__   __ ___   _____  __      _____  _ __   | | | | | |\r\n  \\ // _ \\| | | | | '_ \\ / _` \\ \\ / / _ \\ \\ \\ /\\ / / _ \\| '_ \\  | | | | | |\r\n  | | (_) | |_| | | | | | (_| |\\ V /  __/  \\ V  V / (_) | | | | |_| |_| |_|\r\n  \\_/\\___/ \\__,_| |_| |_|\\__,_| \\_/ \\___|   \\_/\\_/ \\___/|_| |_| (_) (_) (_)\r\n                                                                           \r\n                                                                           \r\n");
                    Console.ReadKey();
                    break;
                }
                else if (score == 501)
                {
                    Console.Clear();
                    Console.WriteLine("__   __                                         _   \r\n\\ \\ / /__  _   _   ___  ___ __ _ _ __   ___  __| |  \r\n \\ V / _ \\| | | | / __|/ __/ _` | '_ \\ / _ \\/ _` |  \r\n  | | (_) | |_| | \\__ \\ (_| (_| | |_) |  __/ (_| |  \r\n  |_|\\___/ \\__,_| |___/\\___\\__,_| .__/ \\___|\\__,_|  \r\n _____ _____ _____ _____ _____ _|_|_ _____ _____    \r\n|_____|_____|_____|_____|_____|_____|_____|_____|   \r\n  | |_| |__   ___   _ __ ___   __ _| |_ _ __(_)_  __\r\n  | __| '_ \\ / _ \\ | '_ ` _ \\ / _` | __| '__| \\ \\/ /\r\n  | |_| | | |  __/ | | | | | | (_| | |_| |  | |>  < \r\n   \\__|_| |_|\\___| |_| |_| |_|\\__,_|\\__|_|  |_/_/\\_\\");
                    Console.ReadKey();
                    break;
                }
                else if (score == -1)
                {
                    Console.Clear();
                    Console.WriteLine(" ____  _          _   _ \r\n|  _ \\(_) ___  __| | | |\r\n| | | | |/ _ \\/ _` | | |\r\n| |_| | |  __/ (_| | |_|\r\n|____/|_|\\___|\\__,_| (_)");
                    Console.ReadKey();
                    break;
                }
            }

        }
    }
}
