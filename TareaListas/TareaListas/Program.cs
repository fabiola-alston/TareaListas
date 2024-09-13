#nullable disable

public enum SortDirection
{
    Ascending,
    Descending
}

// nota: nombre la interfaz "ILista" en vez de "IList" como en los requerimientos por que al parecer C# tiene una interfaz/clase o algo(? llamado IList ya.
public interface ILista
{
    public void InsertInOrder(int value);
    public int DeleteFirst();
    public int DeleteLast();
    public bool DeleteValue(int value);
    public int GetMiddle();
    public void MergeSorted(DoublyLinkedList listA, DoublyLinkedList listB, SortDirection direction);

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
    private DoubleNode last;
    private DoubleNode pivot;
    private int counter;

    private void UpdateLast()
    {
        if (first != null)
        {
            DoubleNode current = first;

            while (current.next != null)
            {
                current = current.next;
            }

            last = current;
        }
    }

    public void InsertInOrder(int value)
    {
        DoubleNode insertNode = new DoubleNode();
        insertNode.value = value;

        if (first == null)
        {
            first = insertNode;
            pivot = insertNode;
            last = insertNode;
            counter = 1;
        }
        else
        {
            if (value <= first.value)
            {
                insertNode.next = first;
                first.previous = insertNode;
                first = insertNode;
            }

            else if (value >= last.value)
            {
                last.next = insertNode;
                insertNode.previous = last;
                last = insertNode;
            }
            else
            {
                DoubleNode current = first;

                while (current != null && current.value < value)
                {
                    current = current.next;
                }

                insertNode.previous = current.previous;
                insertNode.next = current;
                current.previous.next = insertNode;
                current.previous = insertNode;
            }

            counter++;

            if (counter % 2 == 0)
            {
                pivot = this.IndexNode((counter / 2));
            }
            else if (counter % 2 != 0)
            {
                pivot = this.IndexNode(((counter - 1) / 2));
            }
        }
        

    }

    public int DeleteFirst()
    {
        if (first  != null && first.next == null)
        {
            first = null;
        }

        else if (first == null)
        {
            EmptyException();
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
            EmptyException();
        }

        this.UpdateLast();

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
        return pivot.value;
    }

    public void MergeSorted(DoublyLinkedList listA, DoublyLinkedList listB, SortDirection direction)
    {
        switch(direction)
        {
            case SortDirection.Ascending:
                for (int i = 0; i < listB.Length(); i++)
                {
                    listA.InsertInOrder(listB.IndexValue(i));
                }

                break;

            case SortDirection.Descending:
                for (int i = 0; i < listB.Length(); i++)
                {
                    listA.InsertInOrder(listB.IndexValue(i));
                }

                listA.InvertList();

                break;
        }
    }

    public void InvertList()
    {
        for (int i = 0; i < this.Length(); i++)
        {
            this.AddAt(i, last.value);
            this.DeleteLast();
            UpdateLast();
        }
    }

    public int Length()
    { 
        int length = 0;

        if (first != null)
        {
            DoubleNode current = first;

            while (current != null)
            {
                length++;
                current = current.next;
            }
        }

        return length;
    }

    private void EmptyException()
    {
        throw new Exception("List is empty.");
    }

    public int IndexValue(int index)
    {
        DoubleNode current = first;

        for (int i = 0; i < index; i++)
        {
            current = current.next;
        }

        return current.value;

    }

    public DoubleNode IndexNode(int index)
    {
        DoubleNode current = first;

        for (int i = 0; i < index; i++)
        {
            current = current.next;
        }

        return current;
    }

    public void AddAt(int index, int value)
    {

        if (index > this.Length() - 1)
        {
            throw new Exception("Index out of range.");
        }

        else
        {
            DoubleNode current = first;

            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }

            UpdateLast();

            DoubleNode insertNode = new DoubleNode();
            insertNode.value = value;

            if (current == first)
            {
                first.previous = insertNode;
                insertNode.next = first;
                first = insertNode;
            }
            else if (current == last)
            {
                insertNode.previous = last.previous;
                last.previous = insertNode;
                insertNode.next = last;
                insertNode.previous.next = insertNode;

            }
            else
            {
                insertNode.previous = current.previous;
                current.previous = insertNode;
                insertNode.next = current;
                insertNode.previous.next = insertNode;
            }

        }
        
                
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

    }
}

// preguntas: funciones que devuelven void y bool?
// si un valor no existe en una lista, y se le aplica DeleteValue() a ese valor, que sucede?