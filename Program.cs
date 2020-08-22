using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar arquivo");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: Sair(); break;
                case 1: Abrir(); break;
                case 2: Criar(); break;
                default: Menu(); break;
            }
        }

        static void Sair()
        {
            System.Environment.Exit(0);
        }

        static void Abrir()
        {
            Console.Clear();
            Console.Write("Qual o caminho do arquivo?");

            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                var text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Criar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo:");
            Console.WriteLine("------------------------");

            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Digite o caminho que deseja salvar:");

            string path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}
