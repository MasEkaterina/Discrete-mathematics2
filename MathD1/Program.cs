using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathD1
{
    class Program
    {
        static int count1 = 0, count2 = 0, count3 = 0, numb1 = 0, numb2 = 0;
        static void Main(string[] args)
        {
            int[] arr1 = new int[0];
            int[] arr2 = new int[0];
            int[] arr3 = new int[0];
            Menu(ref arr1, ref arr2, ref arr3);
            Action(ref arr1, ref arr2, ref arr3);
        }
        static void Menu(ref int[] arr1, ref int[] arr2, ref int[] arr3)
        {
            int choice = -1;
            bool exit = false;
            while (choice < 1 || choice > 4 || exit == false)
            {
                if (!exit)
                {
                    Console.Clear();
                    exit = false;
                    Console.WriteLine("\t\tВыберите множество: " +
                        "\n1. Первое множество" +
                        "\n2. Второе множество" +
                        "\n3. Третье множество" +
                        "\n4. Перейти к действиям");
                    SelectMenu(ref choice, ref exit, ref arr1, ref arr2, ref arr3);
                }
                else
                    break;
            }
        }
        static void SelectMenu(ref int choice, ref bool exit, ref int[] arr1, ref int[] arr2, ref int[] arr3)
        {
            string buf;
            buf = Console.ReadLine();
            if (!Int32.TryParse(buf, out choice))
            {
                choice = -1;
                return;
            }
            else
            {
                switch (choice)
                {
                    case 1: MenuOneArray(ref arr1); break;
                    case 2: MenuTwoArray(ref arr2); break;
                    case 3: MenuThreeArray(ref arr3); break;
                    case 4: exit = true; break;
                }
            }
        }
        static void MenuOneArray(ref int[] arr1)
        {
            bool cancel = false;
            bool end = false;
            do
            {
                int choice = -1;
                while (choice < 1 || choice > 4 || cancel)
                {
                    if (count1 == 0)
                    {
                        Console.Clear();
                        count1++;
                    }
                    cancel = false;
                    Console.WriteLine("Работа с первым множеством" +
                        "\n1. Создать множество" +
                        "\n2. Напечатать множество" +
                        "\n3. Назад");
                    SelectMenuOneArray(ref end, ref choice, ref arr1);
                }
            } while (!end);
        }
        static void SelectMenuOneArray(ref bool end, ref int choice, ref int[] arr1)
        {
            string buf;
            buf = Console.ReadLine();
            if (!Int32.TryParse(buf, out choice))
            {
                choice = -1;
                return;
            }
            else
            {
                switch (choice)
                {
                    case 1: CreateArray(ref arr1); break;
                    case 2: PrintArray(arr1); break;
                    case 3: end = true; return;
                }
            }
        }
        static void MenuTwoArray(ref int[] arr2)
        {
            bool end = false;
            do
            {
                int choice = -1;
                do
                {
                    if (count2 == 0)
                    {
                        Console.Clear();
                        count2++;
                    }

                    Console.WriteLine("Работа со вторым множеством" +
                        "\n1. Создать множество" +
                        "\n2. Напечатать множество" +
                        "\n3. Назад");
                    SelectMenuTwoArray(ref choice, ref end, ref arr2);
                } while (choice < 1 || choice > 4);
            } while (!end);
        }
        static void SelectMenuTwoArray(ref int choice, ref bool end, ref int[] arr2)
        {
            string buf;
            buf = Console.ReadLine();
            bool ok = Int32.TryParse(buf, out choice);
            if (!ok)
            {
                choice = -1;
                return;
            }
            else
            {
                switch (choice)
                {
                    case 1: CreateArray(ref arr2); break;
                    case 2: PrintArray(arr2); break;
                    case 3: end = true; return;
                }
            }
        }
        static void MenuThreeArray(ref int[] arr3)
        {
            bool end = false;
            do
            {
                int choice = -1;
                do
                {
                    if (count3 == 0)
                    {
                        Console.Clear();
                        count3++;
                    }
                    Console.WriteLine("Работа с третьим множеством" +
                        "\n1. Создать множество" +
                        "\n2. Напечатать множество" +
                        "\n3. Назад");
                    SelectMenuThreeArray(ref choice, ref end, ref arr3);
                } while (choice < 1 || choice > 4);
            } while (!end);
        }
        static void SelectMenuThreeArray(ref int choice, ref bool end, ref int[] arr3)
        {
            string buf;
            buf = Console.ReadLine();
            bool ok = Int32.TryParse(buf, out choice);
            if (!ok)
            {
                choice = -1;
                return;
            }
            else
            {
                switch (choice)
                {
                    case 1: CreateArray(ref arr3); break;
                    case 2: PrintArray(arr3); break;
                    case 3: end = true; return;
                }
            }
        }
        static void CreateArray(ref int[] arr)
        {
            bool cancel = false, ok = false;
            int choice = -1, size = 0;
            string buf;
            do
            {
                Console.Write("Введите количество элементов: ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out size);
            } while (size < 1 || size > 41 || !ok);
            do
            {
                Console.WriteLine("Как вы хотите заполнить множество?" +
                    "\n1. Автоматическое заполнение" +
                    "\n2. Ручной ввод" +
                    "\n3. Заполнение по условию" +
                    "\n4. Назад");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out choice);

            } while (choice < 1 || choice > 4 || !ok);
            SelectCreate(size, choice, ref cancel, ref arr);
        }
        static void PrintArray(int[] arr)
        {
            if (arr.Length == 0)
                Console.WriteLine("Множество пустое!");
            else
            {
                Console.Write("{ ");
                foreach (int item in arr)
                    Console.Write(item + " ");
                Console.Write(" }\n");
            }
            return;
        }
        static void SelectCreate(int size, int choice, ref bool cancel, ref int[] arr)
        {
            int a;
            arr = new int[size];
            do
            {
                switch (choice)
                {
                    case 1:
                        Random rand = new Random();
                        for (int i = 0; i < size; i++)
                        {
                            a = rand.Next(-20, 21);
                            if (!arr.Contains(a))
                            {
                                arr[i] = a;
                            }
                            else
                                i--;
                        }
                        return;
                    case 2:
                        bool ok = false;
                        do
                        {
                            for (int i = 0; i < size; i++)
                            {
                                string buf;
                                Console.Write($"Введите {i} элемент множества: ");
                                buf = Console.ReadLine();
                                int temp;
                                ok = Int32.TryParse(buf, out temp);
                                if (!ok)
                                    Console.WriteLine("Указано некоректное значение!");
                                else
                                {
                                    if (!arr.Contains(temp))
                                    {
                                        arr[i] = temp; ;
                                    }
                                    else
                                    {
                                        i--;
                                        Console.WriteLine("Такой элемент уже есть!");
                                    }
                                }
                            }
                        } while (!ok);
                        return;
                    case 3: Condition(size, ref arr);
                        return;
                    case 4:
                        cancel = true;
                        return;
                }
            } while (!cancel);
            PrintArray(arr);
        }
        static void Condition(int size, ref int[] arr)
        {
            bool cancel = false, ok = false;
            int choice = -1;
            string buf;
            do
            {
                Console.WriteLine("Выберите, по какому условию сформировать множество: " +
                "\n1. Только положительные" +
                "\n2. Только отрицательные" +
                "\n3. Только нечетные" +
                "\n4. Только четные" +
                "\n5. Элементы кратны заданному числу" +
                "\n6. Назад");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out choice);
            } while (choice < 1 || choice > 6 || !ok);
            SelectCondition(size, choice, ref cancel, ref arr);
        }
        static void SelectCondition(int size, int choice, ref bool cancel, ref int[] arr)
        {
            arr = new int[size];
            int a, elem;
            bool ok;
            Random rand = new Random();
            do
            {
                switch (choice)
                {
                    case 1:
                        for (int i = 0; i < size; i++)
                        {
                            a = rand.Next(0, 21);
                            if (!arr.Contains(a))
                            {
                                arr[i] = a;
                            }
                            else
                                i--;
                        }
                        return;
                    case 2:
                        for (int i = 0; i < size; i++)
                        {
                            a = rand.Next(-20, 0);
                            if (!arr.Contains(a))
                                arr[i] = a;
                            else
                                i--;
                        }
                        return;
                    case 3:
                        for (int i = 0; i < size; i++)
                        {
                            a = rand.Next(-20, 21);
                            if (a % 2 != 0)
                            {
                                if (!arr.Contains(a))
                                    arr[i] = a;
                                else
                                    i--;
                            }
                            else
                                i--;
                        }
                        return;
                    case 4:
                        for (int i = 0; i < size; i++)
                        {
                            a = rand.Next(-20, 21);
                            if (a % 2 == 0)
                            {
                                if (!arr.Contains(a))
                                    arr[i] = a;
                                else
                                    i--;
                            }
                            else
                                i--;
                        }
                        return;
                    case 5:
                        do
                        {
                            Console.Write("Введите элемент: ");
                            string buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out elem);
                        } while (!ok);
                        for (int i = 0; i < size; i++)
                        {
                            a = rand.Next(-20, 21);
                            if (a % elem == 0)
                            {
                                if (!arr.Contains(a))
                                    arr[i] = a;
                                else
                                    i--;
                            }
                            else
                                i--;
                        }
                        return;
                    case 6:
                        cancel = true;
                        return;
                }
            } while (!cancel);
        }
        static void Action(ref int[] arr1, ref int[] arr2, ref int[] arr3)
        {
            int choice = -1;
            bool exit = false;
            while (choice < 1 || choice > 4 || exit == false)
            {
                if (!exit)
                {
                    Console.Clear();
                    exit = false;
                    Console.WriteLine("\t\tВыберите действие: " +
                        "\n1. Пересечение" +
                        "\n2. Объединение" +
                        "\n3. Разность" +
                        "\n4. Симметрическая разность" +
                        "\n5. Дополнение" +
                        "\n6. Выход из программы");
                    SelectAction(ref choice, ref exit, ref arr1, ref arr2, ref arr3);
                }
                else
                    break;
            }
        }
        static void SelectAction(ref int choice, ref bool exit, ref int[] arr1, ref int[] arr2, ref int[] arr3)
        {
            string buf;
            buf = Console.ReadLine();
            if (!Int32.TryParse(buf, out choice))
            {
                choice = -1;
                return;
            }
            else
            {
                switch (choice)
                {
                    case 1: Intersection(ref arr1, ref arr2, ref arr3); break;
                    case 2: Union(ref arr1, ref arr2, ref arr3); break;
                    case 3: Difference(ref arr1, ref arr2, ref arr3); break;
                    case 4: SymmetricDifference(ref arr1, ref arr2, ref arr3); break;
                    case 5: Addition(ref arr1, ref arr2, ref arr3); break;
                    case 6: exit = true; break;
                }
            }
        }
        static void Intersection(ref int[] arr1, ref int[] arr2, ref int[] arr3)
        {
            Choice();
            int[] mas1 = new int[0];
            int[] mas2 = new int[0];
            int r = numb1;
            switch (r)
            {
                case 1: mas1 = arr1; break;
                case 2: mas1 = arr2; break;
                case 3: mas1 = arr3; break;
            }
            Console.Write(numb1 + ": ");
            PrintArray(mas1);
            r = numb2;
            switch (r)
            {
                case 1: mas2 = arr1; break;
                case 2: mas2 = arr2; break;
                case 3: mas2 = arr3; break;
            }
            Console.Write(numb2 + ": ");
            PrintArray(mas2);
            var result = mas1.Intersect(mas2);
            Console.Write("Результат: ");
            foreach (var i in result)
                Console.Write(i + " ");
            Console.ReadKey();
        }
        static void Union(ref int[] arr1, ref int[] arr2, ref int[] arr3)
        {
            Choice();
            int[] mas1 = new int[0];
            int[] mas2 = new int[0];
            int r = numb1;
            switch (r)
            {
                case 1: mas1 = arr1; break;
                case 2: mas1 = arr2; break;
                case 3: mas1 = arr3; break;
            }
            Console.Write(numb1 + ": ");
            PrintArray(mas1);
            r = numb2;
            switch (r)
            {
                case 1: mas2 = arr1; break;
                case 2: mas2 = arr2; break;
                case 3: mas2 = arr3; break;
            }
            Console.Write(numb2 + ": ");
            PrintArray(mas2);
            var result = mas1.Union(mas2);
            Console.Write("Результат: ");
            foreach (var i in result)
                Console.Write(i + " ");
            Console.ReadKey();
        }
        static void Difference(ref int[] arr1, ref int[] arr2, ref int[] arr3)
        {
            Choice();
            int[] mas1 = new int[0];
            int[] mas2 = new int[0];
            int r = numb1;
            switch (r)
            {
                case 1: mas1 = arr1; break;
                case 2: mas1 = arr2; break;
                case 3: mas1 = arr3; break;
            }
            Console.Write(numb1 + ": ");
            PrintArray(mas1);
            r = numb2;
            switch (r)
            {
                case 1: mas2 = arr1; break;
                case 2: mas2 = arr2; break;
                case 3: mas2 = arr3; break;
            }
            Console.Write(numb2 + ": ");
            PrintArray(mas2);
            var result = mas1.Except(mas2);
            Console.Write("Результат: ");
            foreach (var i in result)
                Console.Write(i + " ");
            Console.ReadKey();
        }
        static void SymmetricDifference(ref int[] arr1, ref int[] arr2, ref int[] arr3)
        {
            Choice();
            int[] mas1 = new int[0];
            int[] mas2 = new int[0];
            int r = numb1;
            switch (r)
            {
                case 1: mas1 = arr1; break;
                case 2: mas1 = arr2; break;
                case 3: mas1 = arr3; break;
            }
            Console.Write(numb1 + ": ");
            PrintArray(mas1);
            r = numb2;
            switch (r)
            {
                case 1: mas2 = arr1; break;
                case 2: mas2 = arr2; break;
                case 3: mas2 = arr3; break;
            }
            Console.Write(numb2 + ": ");
            PrintArray(mas2);
            var result = mas1.Except(mas2);
            var result1 = mas2.Except(mas1);
            var result2 = result.Union(result1);
            Console.Write("Результат: ");
            foreach (var i in result2)
                Console.Write(i + " ");
            Console.ReadKey();
        }
        static void Addition(ref int[] arr1, ref int[] arr2, ref int[] arr3)
        {
            bool ok = false;
            string buf;
            Console.WriteLine("Выберите, с каким множеством работать " +
                    "\n1. Первое множество" +
                    "\n2. Второе множество" +
                    "\n3. Третье множество");
            do
            {
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out numb1);
            } while (!ok);
            int[] mas1 = new int[0];
            int r = numb1;
            switch (r)
            {
                case 1: mas1 = arr1; break;
                case 2: mas1 = arr2; break;
                case 3: mas1 = arr3; break;
            }
            Console.Write(numb1 + ": ");
            PrintArray(mas1);
            int[] mas2 = new int[41];
            int i = -20;
            for (int j = 0; j < 41; j++)
            {
                mas2[j] = i;
                i++;
            }
            var result = mas1.Except(mas2);
            var result1 = mas2.Except(mas1);
            var result2 = result.Union(result1);
            Console.Write("Результат: ");
            foreach (var w in result2)
                Console.Write(w + " ");
            Console.ReadKey();
        }
        static void Choice()
        {
            bool ok = false;
            string buf;
            Console.WriteLine("Выберите, с какими(двумя) множествами работать " +
                    "\n1. Первое множество" +
                    "\n2. Второе множество" +
                    "\n3. Третье множество");
            do
            {
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out numb1);
            } while (!ok);
            do
            {
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out numb2);
            } while (!ok);
        }
    }
}