#nullable disable

// nota: nombre la interfaz "ILista" en vez de "IList" como en los requerimientos por que al parecer C# tiene una interfaz/clase o algo(? llamado IList ya.
public interface ILista
{
    public void InsertInOrder(int value);
    public int DeleteFirst();
    public int DeleteLast();
    public bool DeleteValue(int value);
    public int GetMiddle();
    public void MergeSorted();

}

public class DoubleNode
{
    public int value;
    public DoubleNode next;
    public DoubleNode previous;


}

public class DoublyLinkedList : ILista
{
    private DoubleNode first;

    public void InsertInOrder(int value)
    {
        if (first == null)
        {
            Console.WriteLine($"Wrote {value} first!");
            first = new DoubleNode();
            first.value = value; 
        }
        else
        {
            DoubleNode current = first;
            DoubleNode insertedNode = new DoubleNode();
            insertedNode.value = value;

            // checks list order and inserts value in correct space
            while (current != null)
            {
                if (current.value >= value && current == first)
                {
                    first.previous = insertedNode;
                    insertedNode.next = first;
                    first = insertedNode;
                    break;
                }

                else if (current.value >= value && current != first)
                {
                    insertedNode.next = current;
                    current.previous.next = insertedNode;
                    insertedNode.previous = current.previous;
                    current.previous = insertedNode;
                    break;

                }

                else if (current.value <= value && current.next == null)
                {
                    current.next = insertedNode;
                    insertedNode.previous = current;
                    break;
                }

                current = current.next;
            }
            
        }
    }

    public int DeleteFirst()
    {
        if (first  != null && first.next == null)
        {
            first = null;
        }
        else
        {
            first = first.next;
            first.previous = null;

        }
        return 0;
    }

    public int DeleteLast()
    {
        if (first != null)
        {
            DoubleNode current = first;
            while (current.next != null)
            {
                current = current.next;
            }

            current.previous.next = null;

            current = null;

        }
        else
        {
            throw new Exception("List is empty.");
        }

        return 0;
    }

    public bool DeleteValue(int value)
    {
        DoubleNode current = first;

        while (current != null)
        {
            if (current.value == value)
            {
                current.previous.next = current.next;
                current.next.previous = current.previous;
                break;
            }
            else
            {
                current = current.next;
            }
        }

        return true;

    }

    public int GetMiddle()
    {
        return 0;
    }

    public void MergeSorted()
    {

    }


    // prints list (debugging purpose)
    public void Print()
    {
        DoubleNode current = first;

        while (current != null)
        {
            Console.WriteLine(current.value);
            current = current.next;
        }

        Console.WriteLine("--------------");

    }
}



public class Program
{
    public static void Main()
    {
        DoublyLinkedList list = new DoublyLinkedList();

        list.InsertInOrder(6);
        list.InsertInOrder(2);
        list.InsertInOrder(10);
        list.InsertInOrder(3);
        list.InsertInOrder(8);
        list.InsertInOrder(5);

        list.Print();

        list.DeleteValue(8);
        list.DeleteValue(4);

        list.Print();

    }
}

// preguntas: funciones que devuelven void y bool?
// si un valor no existe en una lista, y se le aplica DeleteValue() a ese valor, que sucede?