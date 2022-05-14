using Lab10_Interfaces;

namespace Lab12_CollectionsCreatedByUser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Меню:" +
                "\n1) Однонаправленный список" +
                "\n2) Двунаправленный список" +
                "\n3) Бинарное дерево" +
                "\n4) Задание 2");
            string menu = Console.ReadLine();
            switch (menu)
            {
                case "1":
                    Console.Clear();
                    OnePoint();
                    break;
                case "2":
                    Console.Clear();
                    TwoPoint();
                    break;
                case "3":
                    Console.Clear();
                    ThreeTree();
                    break;
                case "4":
                    MyCollection stack = null;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Меню:" +
                        "\n1) Cформировать коллекцию" +
                        "\n2) Добавить случайный объект" +
                        "\n3) Удалить последний объект" +
                        "\n4) Найти объект" +
                        "\n5) Клонировать коллекцию" +
                        "\n6) Копировать коллекцию" +
                        "\n7) Удалить коллекцию из памяти" +
                        "\n8) Показать коллекцию" +
                        "\n9) Закрыть программу" +
                        "\n10) Вывести все имена объектов, используя foreach");
                        menu = Console.ReadLine();
                        switch (menu)
                        {
                            case "1":
                                Console.Clear();
                                Console.Write("Введите размер коллекции: ");
                                stack = new MyCollection(int.Parse(Console.ReadLine()));
                                Console.WriteLine();
                                MyCollection.ShowList(stack);
                                Console.ReadLine();
                                break;
                            case "2":
                                Console.Clear();
                                stack = MyCollection.Add(stack);
                                MyCollection.ShowList(stack);
                                Console.ReadLine();
                                break;
                            case "3":
                                Console.Clear();
                                stack = MyCollection.DeletePoint(stack);
                                MyCollection.ShowList(stack);
                                Console.ReadLine();
                                break;
                            case "4":
                                Console.Clear();
                                if (stack == null)
                                {
                                    Console.WriteLine("Коллекция пуста!");
                                    Console.ReadLine();
                                    break;
                                }
                                MyCollection.ShowList(stack);
                                Console.Write("\nВведите оценку, найдёт последний вошедший объект с этой оценкой: ");
                                MyCollection.Search(stack, int.Parse(Console.ReadLine()));
                                Console.ReadLine();
                                break;
                            case "5":
                                Console.Clear();
                                MyCollection clone = MyCollection.Clone(stack);
                                Console.WriteLine("Клон: ");
                                MyCollection.ShowList(clone);
                                Console.WriteLine("\nКлон: ");
                                clone.next = null;
                                clone.Count = 1;
                                MyCollection.ShowList(clone);
                                Console.WriteLine("\nКлонируемый объект:");
                                MyCollection.ShowList(stack);
                                Console.WriteLine("");
                                Console.ReadLine();
                                break;
                            case "6":
                                Console.Clear();
                                MyCollection copy = stack.Copy();
                                Console.WriteLine("Копия: ");
                                MyCollection.ShowList(copy);
                                Console.WriteLine("\nКопия: ");
                                copy.next = null;
                                copy.Count = 1;
                                MyCollection.ShowList(copy);
                                Console.WriteLine("\nКопируемый объект:");
                                MyCollection.ShowList(stack);
                                Console.WriteLine("");
                                Console.ReadLine();
                                break;
                            case "7":
                                Console.Clear();
                                MyCollection.Clear(ref stack);
                                break;
                            case "8":
                                Console.Clear();
                                if (stack == null)
                                    Console.WriteLine("Коллекция пуста!");
                                else
                                    MyCollection.ShowList(stack);
                                Console.ReadLine();
                                break;
                            case "9":
                                Environment.Exit(0);
                                break;
                            case "10":
                                Console.Clear();
                                if (stack == null)
                                {
                                    Console.WriteLine("Коллекция пуста!");
                                    Console.ReadLine();
                                    break;
                                }
                                foreach (MyCollection x in stack)
                                {
                                    Console.WriteLine(x.data.Name);
                                }
                                Console.ReadLine();
                                break;
                        }
                    } while (true);
                    break;
            }
        }

        static void OnePoint()
        {
            Point p1 = Point.MakeListToEnd(3);
            Point.ShowList(p1);
            Console.WriteLine();
            Console.Write("Введите оценку предмета, после которого добавится новый предмет: ");
            int gr_sh = int.Parse(Console.ReadLine());
            Console.Write("Введите название предмета, после которого добавится новый предмет: ");
            string sub_sh = Console.ReadLine();
            Point.AddPoint(p1, gr_sh, sub_sh);
            Console.WriteLine();
            Point.ShowList(p1);
            Console.WriteLine();
            p1 = null;
            GC.Collect();
            Console.WriteLine("Очищение списка");
            Console.WriteLine();
            Point.ShowList(p1);
            Console.ReadLine();
        }

        static void TwoPoint()
        {
            PointTwoLink p2 = PointTwoLink.MakeListToEnd(3);
            PointTwoLink.ShowList(p2);
            Console.WriteLine();
            Console.Write("Введите оценку предмета на удаление из списка: ");
            int gr_sh2 = int.Parse(Console.ReadLine());
            Console.Write("Введите название предмета на удаление из списка: ");
            string sub_sh2 = Console.ReadLine();
            p2 = PointTwoLink.DeletePoint(p2, gr_sh2, sub_sh2);
            Console.WriteLine();
            PointTwoLink.ShowList(p2);
            Console.WriteLine();
            p2 = null;
            GC.Collect();
            Console.WriteLine("Очищение списка");
            Console.WriteLine();
            PointTwoLink.ShowList(p2);
            Console.ReadLine();
        }

        static void ThreeTree()
        {
            BinaryTree idtree = new BinaryTree();
            Console.WriteLine("Введите количество элементов в идеальном дереве: ");
            idtree = BinaryTree.IdealTree(int.Parse(Console.ReadLine()), idtree);
            BinaryTree.ShowTree(idtree, 1);
            Console.WriteLine("\nВысота дерева: " + idtree.Run(idtree) + "\n");
            BinaryTree root = BinaryTree.First();
            BinaryTree.Transform(root, idtree);
            BinaryTree.ShowTree(root, 1);
            root = null;
            idtree = null;
            GC.Collect();
            Console.WriteLine("\nОчищение списка\n");
            BinaryTree.ShowTree(idtree, 1);
            BinaryTree.ShowTree(root, 1);
            Console.ReadLine();
        }
    }
}
