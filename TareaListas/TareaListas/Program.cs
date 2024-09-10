#nullable disable

// nota: nombre la interfaz "ILista" en vez de "IList" como en los requerimientos por que al parecer C# tiene una interfaz/clase o algo(? llamado IList ya.
public interface ILista
{
    public void InsertInOrder();
    public int DeleteFirst();
    public int DeleteLast();
    public bool DeleteValue();
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

}


public class Program
{
    public static void Main()
    {
        DoublyLinkedList doubleList = new DoublyLinkedList();

    }
}
