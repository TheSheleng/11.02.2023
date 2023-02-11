using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _11._02._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MenuByList test = new MenuByList("My menu", "punct 1");
            //test.GetChise();

            //BookShelf test2 = new BookShelf(BookShelf.Sorts.Author);
            //test2.NewBook(new Book("b name book 1", "a kto-to", "c fantasy"));
            //test2.NewBook(new Book("d name book 2", "d kto-to", "d fantasy"));
            //test2.NewBook(new Book("a name book 3", "c kto-to", "a fantasy"));
            //test2.NewBook(new Book("c name book 4", "b kto-to", "b fantasy"));

            //test2.SortType = BookShelf.Sorts.BookName;

            //MenuByList test3 = new MenuByList("test", "Отмена", test2);
            //test3.GetChise();

            BookShelf lib = new BookShelf(BookShelf.Sorts.Author);

            MenuByList MainMenu = new MenuByList(
                "Главное меню",
                "Просмотр",
                "Добавить",
                "Удалить",
                "Выйти"
            );

            while (true)
                switch (MainMenu.GetChise())
                {
                    case 0: //Просмотр
                        if (lib.Count != 0)
                        {
                            MenuByList ShowMenu = new MenuByList(
                                "Меню просмотра",
                                "Назад",
                                lib
                            );

                            while (true)
                            {
                                int choise = ShowMenu.GetChise();
                                if (choise == 0) break;

                                int chised = choise - 1;
                                Console.Clear();
                                Console.WriteLine($"\n\tНазвание: {lib[chised].Name}");
                                Console.WriteLine($"\tАвтор: {lib[chised].Author}");
                                Console.WriteLine($"\tЖанр: {lib[chised].Genre}");
                                Console.ReadKey();
                            }
                        }
                        else 
                        { 
                            Console.WriteLine("\n\tВсе полки пусты.");
                            Console.ReadKey();
                        }
                        break;

                    case 1: //Добавить
                        {
                            Console.Write("\n\tВведи название книги: ");
                            string name = Console.ReadLine();
                            Console.Write("\tВведи имя автора: ");
                            string author = Console.ReadLine();
                            Console.Write("\tВведи жанр: ");
                            string genre = Console.ReadLine();
                            Book book = new Book(name, author, genre);
                            lib.NewBook(book);

                            Console.WriteLine("\n\tКнига добавлена.");
                            Console.ReadKey();
                        }
                        break;

                    case 2: //Удалить
                        {
                            MenuByList DeleteMenu = new MenuByList(
                                "Выберите что удалить",
                                "Назад",
                                lib
                            );

                            while (true)
                            {
                                int choise = DeleteMenu.GetChise();
                                if (choise == 0) break;

                                int chised = choise - 1;
                                lib.RemBook(chised);

                                Console.Clear();
                                Console.WriteLine("\n\tКнига удалина;");
                                Console.ReadKey();
                            }
                        }
                        break;

                    case 3: //Выйти
                        Environment.Exit(0);
                        break;
                }
        }
    }
}
