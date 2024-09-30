using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinarySearchTree
    {
        public class IllegalArgException : Exception { }
        public class EmptyTreeException : Exception { }
        public class Node
        {
            public int Value;
            public Node Left;
            public Node Right;
            public Node(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }

        }

        public class BST
        {
            public Node Root;

            public BST()
            {
                Root = null;
            }
            public Node MaxLeft(Node a)
            {
                Node current2 = a;
                if (a == null)
                {
                    throw new EmptyTreeException();
                }
                else
                {
                    while(current2.Right != null) {current2 = current2.Left;
                    if (current2 != null) 
                    { 
                        while (current2.Right != null)
                      {
                        current2 = current2.Right;
                      } 
                    } }
                    
                   
                    return current2;
                }
            }
            public Node MinRight(Node a)
            {
                Node current1=a;
                if (a == null)
                {
                    throw new EmptyTreeException();
                }
                else
                {
                    while(current1.Left != null) 
                    {
                        current1 = current1.Left;
                        if(current1!= null)
                        { 
                            while (current1.Left != null)
                            {
                                 current1 = current1.Left;
                            }

                        } 
                    }
                    
                    return current1;
                }
                
                
                
            }

            public void Insert(int value)
            {

                if (value.GetType() != typeof(Int32))
                {
                    throw new IllegalArgException();
                }
                    Node newnode = new Node(value);
                    if (Root == null)
                    {
                        Root = newnode;
                    }
                    else
                    {
                        Node current = Root;
                        Node parent;
                        while (true)
                        {
                            parent = current;

                            if (current.Value > value)
                            {

                                current = current.Left;
                                if (current == null)
                                {
                                    parent.Left = newnode;
                                    break;
                                }
                            }
                            else
                            {
                                current = current.Right;
                                if (current == null)
                                {
                                    parent.Right = newnode;
                                    break;
                                }
                            }
                        }
                    }
                
            }
            public bool Search(int value)

            {
                if (Root == null)
                {
                    return false;
                }
                else
                {
                    Node current = Root;
                    while (current != null)
                    {
                        if (current.Value == value)
                        {
                            return true;
                            break;
                        }
                        else if (current.Value > value)
                        {
                            current = current.Left;
                        }
                        else
                        {
                            current = current.Right;
                        }

                    }
                    return false;
                }
            }
            public bool Remove(int value)
            {
                if (Root == null)
                {
                    throw new EmptyTreeException();
                   
                }
                else
                {
                    Node current = Root;
                    Node parent = null;

                    while (current.Value != value && current != null)
                    {
                        parent = current;

                        if (value < current.Value)
                        {
                            current = current.Left;

                        }
                        else
                        {
                            current = current.Right;

                        }

                    }
                    if (current == null)
                    {
                        return false;

                    }
                    //no left, no right
                    if (current.Right == null && current.Left == null)
                    {
                        if (parent == null) { Root = null; }
                        else if (parent.Left == current)
                        {
                            parent.Left = null;
                        }
                        else { parent.Right = null; }
                    }
                    /*Left ,No right?How to remove it if it doesn't have a right child in left subtree: Remove(80)
                     60
                  /        \
                30          80
              /   \        /
            20     40   70
                       /
                     60
                    /
                   50
                     */

                    else if ((current.Right == null) && (current.Left != null))
                    {


                        Node successor =MaxLeft(current.Left);
                        current.Value = successor.Value;
                        parent = current;
                        current = current.Left;
                        if (current.Right == null) { parent.Left = current.Left; }
                        else
                        {
                            while (current.Right != null)
                            {
                                parent = current;
                                current = current.Right;
                            }
                            parent.Right = null;
                        }


                    }
                    /*right, no left
                     How to remove the node if its subtree doesn't have a left child:
                    60
                   /  \
                 30   80
                        \
                        90
                          \
                          100 Remove(80)
                     */
                    else if (current.Left == null && current.Right != null)
                    {
                        Node successor = MinRight(current.Right);
                        current.Value = successor.Value;
                        parent = current;
                        current = current.Right;
                        if (current.Left == null) { parent.Right = current.Right; }
                        else
                        {
                            while (current.Left != null)
                            {
                                parent = current;
                                current = current.Left;

                            }
                        }
                        parent.Left = null;

                    }
                    //right and left
                    else
                    {
                        if (parent == null)
                        {
                            Node successor = MinRight(current.Right);
                            current.Value = successor.Value;
                            current = current.Right;

                            while (current.Left != null)
                            {
                                parent = current;
                                current = current.Left;
                            }
                            parent.Left = null;
                        }
                        else
                        {
                            if (current.Right != null)
                            {
                                Node successor= MinRight(current.Right);
                                current.Value = successor.Value;
                                parent = current;
                                current = current.Right;

                                if (current.Left == null)
                                {
                                    parent.Right = null;
  
                                }
                                else
                                {while (current.Left != null)
                                {
                                    parent = current;
                                    current = current.Left;
                                }
                                parent.Left = null;

                                }
                                
                                
                            }
                            /*else
                            {
                                if (parent.Left == current)
                                {
                                    parent.Left = current.Left;
                                }
                                else
                                {
                                    parent.Right = current.Right;
                                }
                            }*/
                        }
                    }
                    return true;
                }
            }
            public string PreOrder(Node a)
            {
                if (a == null)
                {
                    return "";
                }

                string repres = $"Node {a.Value} ";

                if (a.Left != null || a.Right != null)
                {
                    repres += ":(";
                    if (a.Left != null)
                    {
                        repres += $"Left: {PreOrder(a.Left)} ";
                    }

                    if (a.Right != null)
                    {
                        repres += $"Right: {PreOrder(a.Right)}";
                    }
                    repres += ")";
                }

                return repres;
            }

        }
    }
}

