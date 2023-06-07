using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TechnologyTests.Linq;

public class CircularList<T>
{
    public int Size { get; private set; }
    public Node<T>? First { get; set; }
    public Node<T>? Last { get; set; }

    public CircularList()
    {
        Size = 0;
        First = null;
        Last = First;
    }

    public void Add(T? data)
    {
        if(Size == 0)
        {
            First = new(data);
            Last = First;
            Size = 1;
            return;
        }

        var node = new Node<T>(First!, data);

        if (Size == 1)
        {
            Last = node;
            First!.next = Last;
        }
        else
        {
            Last!.next = node;
            Last = node;
        }            

        Size++;
    }
}

public class Node<T>
{
    public Node<T> next { get; set; }
    public T? data { get; set; }

    public Node(T? data)
    {
        next = this;
        this.data = data;
    }

    public Node(Node<T> next, T? data)
    {
        this.next = next;
        this.data = data;
    }    
}