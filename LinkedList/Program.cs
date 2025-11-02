LinkedList linkedList = new();
linkedList.Add(1);
linkedList.Add(2);
linkedList.Add(3);
linkedList.Add(4);
linkedList.ListNodes();
linkedList.DeleteFirst();
linkedList.DeleteFirst();
linkedList.InsertLast(5);
linkedList.InsertLast(6);
linkedList.ListNodes();
Console.ReadLine();
public class Node
{
    public int Data { get; set; }
    public Node? Next { get; set; }
    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    #region Fields
    private int count = 0;
    #endregion
    #region Properties
    public Node? Head { get; set; }

    #endregion

    #region Constructors
    public LinkedList()
    {
        Head = null;
    }
    #endregion

    #region Methods
    public void Add(int data)
    {
        // create new node add the value
        var newNode = new Node(data);
        // put the old node in next
        newNode.Next = Head;
        // make the new node the head
        this.Head = newNode;
        this.count++;
    }

    public Node DeleteFirst()
    {
        if (this.Head == null)
        {
            throw new InvalidOperationException("head is empty");
        }

        var temp = this.Head;
        // make the next node the head
        this.Head = this.Head.Next;
        return temp;
    }

    public void ListNodes()
    {
        if (this.Head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        var current = this.Head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            // move to the next node
            current = current.Next;
        }
    }

    public void InsertLast(int data)
    {
        Node current = this.Head;
        while (current != null && current.Next != null)
        {
            current = current.Next;
        }
        Node newNode = new Node(data);
        current.Next = newNode;
    }

    #endregion
}
