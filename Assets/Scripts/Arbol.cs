using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

[System.Serializable]
public class Arbol
{
    public Nodo Root;


    #region Insert
    public void Insert(int value)
    {
        Root = InsertRec(Root, value);
    }

    private Nodo InsertRec(Nodo node, int value)
    {
        if (node == null) return new Nodo(value);

        if (value < node.Value) node.Left = InsertRec(node.Left, value);
        else if (value > node.Value) node.Right = InsertRec(node.Right, value);

        return node;
    }
    #endregion

    #region Order Traversals

    public List<int> InOrder()
    {
        var r = new List<int>();
        return InOrderRec(Root, r);
    }

    private List<int> InOrderRec(Nodo node, List<int> r)
    {
        if (node == null) return r;

        InOrderRec(node.Left, r);
        r.Add(node.Value);
        InOrderRec(node.Right, r);

        return r;
    }

    public List<int> PreOrder()
    {
        var r = new List<int>();
        return PreOrderRec(Root, r);
    }
    private List<int> PreOrderRec(Nodo node, List<int> r)
    {
        if (node == null) return r;

        r.Add(node.Value);
        PreOrderRec(node.Left, r);
        PreOrderRec(node.Right, r);

        return r;
    }

    public List<int> PostOrder()
    {
        var r = new List<int>();
        return PostOrderRec(Root, r);
    }

    private List<int> PostOrderRec(Nodo node, List<int> r)
    {
        if (node == null) return r;

        PostOrderRec(node.Left, r);
        PostOrderRec(node.Right, r);
        r.Add(node.Value);

        return r;
    }

    public List<int> LevelOrder()
    {
        var r = new List<int>();
        var q = new Queue<Nodo>();

        if (Root != null) q.Enqueue(Root);

        while (q.Count > 0)
        {
            var node = q.Dequeue();
            r.Add(node.Value);
            if (node.Left != null) q.Enqueue(node.Left);
            if (node.Right != null) q.Enqueue(node.Right);
        }

        return r;
    }

    #endregion

    public bool Contains(int value) => ContainsRec(Root, value);

    private bool ContainsRec(Nodo node, int value)
    {
        if (node == null) return false;
        if (node.Value == value) return true;

        return value < node.Value ? ContainsRec(node.Left, value) : ContainsRec(node.Right, value);
    }

    public void Remove(int value) => Root = RemoveRec(Root, value);

    private Nodo RemoveRec(Nodo nodo, int value)
    {
        if (nodo == null) return nodo;

        if (value < nodo.Value)
            nodo.Left = RemoveRec(nodo.Left, value);
        else if (value > nodo.Value)
            nodo.Right = RemoveRec(nodo.Right, value);
        else
        {
            //Caso 1: Nodo sin hijos (hoja)
            if (nodo.Left == null && nodo.Right == null) return null;
            //Caso 2: Nodo con un hijo
            if (nodo.Left == null) return nodo.Right;
            if (nodo.Right == null) return nodo.Left;
            //Caso 3: Nodo con dos hijos
            Nodo parent = nodo;
            Nodo successor = nodo.Left;
            while (successor.Right != null)
            {
                parent = successor;
                successor = successor.Right;
            }
            nodo.Value = successor.Value;
            if (parent == nodo) parent.Left = successor.Left;
            else parent.Right = successor.Left;
        }
        return nodo;
    }
}