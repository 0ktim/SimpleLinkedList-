

namespace _5222025
{
    public class Node
    {
        public object Value { get; set; }
        public Node Next { get; set; }

        public Node(object value)
        {
            Value = value;
            Next = null;
        }
    }

    public class LinkedList
    {
        private Node head;
        private Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void Add(object value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Value + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        public object Get(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Индексът не може да бъде отрицателен.");
            }

            Node current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current.Value;
                }

                current = current.Next;
                currentIndex++;
            }

            throw new ArgumentOutOfRangeException("Индексът е извън границите на списъка.");
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || head == null)
            {
                throw new ArgumentOutOfRangeException("Невалиден индекс.");
            }

            if (index == 0)
            {
                head = head.Next;
                if (head == null)
                {
                    tail = null; // Ако списъкът остане празен
                }
                return;
            }

            Node current = head;
            Node previous = null;
            int currentIndex = 0;

            while (current != null && currentIndex < index)
            {
                previous = current;
                current = current.Next;
                currentIndex++;
            }

            if (current == null)
            {
                throw new ArgumentOutOfRangeException("Индексът е извън границите на списъка.");
            }

            previous.Next = current.Next;

            if (current.Next == null)
            {
                tail = previous; // Ако трием последния елемент, актуализираме tail
            }
        }

        public bool Contains(object item)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true; // Намерихме елемента
                }
                current = current.Next; // Преминаваме към следващия възел
            }

            return false; // Ако обходим целия списък и не намерим елемента
        }



    }

    class Program
    {
        static void Main()
        {
            LinkedList list = new LinkedList();

            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);
            list.Add(50);



            list.Print(); // Изход: 10 -> 20 -> 30 -> 40 -> null

            Console.WriteLine(list.Get(0)); // Изход: 10

            list.RemoveAt(1); // Премахва 20
            list.Print(); // Изход: 10 -> 30 -> 40 -> null

            Console.WriteLine(list.Contains(30)); // Изход: true
            Console.WriteLine(list.Contains(70)); // Изход: false
        }
    }

}
