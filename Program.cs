using System;
using System.IO;
using System.Text;


namespace TutorialsWithAndrew
{
    class Program
    {
        class StringList
        {
            string[] array = { "one", "two", "three" };

            public void Show()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine((i + 1) + ") " + array[i]);
                }
            }

            public void Add(string item)
            {
                string[] newTasks = new string[array.Length + 1];
                for (int i = 0; i < array.Length; i++)
                {
                    newTasks[i] = array[i];
                }
                newTasks[newTasks.Length - 1] = item;
                array = newTasks;
            }

            public void Delete(int deleteIndex)
            {
                if (deleteIndex >= array.Length || deleteIndex < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                string[] newTasks2 = new string[array.Length - 1];
                for (int i = 0; i < newTasks2.Length; i++)
                {
                    newTasks2[i] = i < deleteIndex ? array[i] : array[i + 1];
                    
                }
                array = newTasks2;
                Console.WriteLine("Element succesfuly deleted");
            }

            public void ReadFromFile (string file)
            {
                array = File.ReadAllLines(file);
            }

            public void WriteToFile(string file)
            {
                File.WriteAllLines (file, array, Encoding.UTF8);
            }
        }

        static void Main(string[] args)
        {
            StringList list = new StringList();

            string path = "apka.txt";
            
            list.ReadFromFile(path);


            for (; ; )
            {
                Console.WriteLine("enter 1, to CONTINUE");
                Console.WriteLine("enter 2, for SHOW ELEMENTS");
                Console.WriteLine("enter 3, for ADD ELEMENT");
                Console.WriteLine("enter 4, for DELETE ELEMENT");
                Console.WriteLine("enter 5, for EXIT");

                int number = Convert.ToInt32(Console.ReadLine());
                if (number == 2)
                {
                    list.Show();
                }
                if (number == 3)
                {
                    Console.WriteLine("Enter name of the new item");
                    string item = Convert.ToString(Console.ReadLine());
                    list.Add(item);
                    Console.WriteLine("New element was succesful added");

                }
                if (number == 4)
                {
                    Console.WriteLine("Enter number of the element which you wanna delete");

                    int deleteIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                    try
                    {
                        list.Delete(deleteIndex);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine("You entered incorrect index");
                    } 
                }
                list.WriteToFile(path);

                if (number == 5)
                    break;
            }
        }
    }
}