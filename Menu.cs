using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Menu
    {
        
        public Menu()
        {
            BinarySearchTree.BST btree = new BinarySearchTree.BST();
            int button = 0;
            while (button != 5)
            {

                Console.WriteLine("Choose the operation on BST.");
                Console.WriteLine("1.Insert.");
                Console.WriteLine("2.Search in the tree.");
                Console.WriteLine("3.Remove from the tree.");
                Console.WriteLine("4.Pre-order traversal.");
                Console.WriteLine("5.Exit");
                button = Convert.ToInt32(Console.ReadLine());
                if (button > 0 && button < 6)
                {
                    switch (button)
                    {
                        case 1:

                            Console.WriteLine("Which node do you want to insert? ");
                            try 
                            {
                                int num1 = Convert.ToInt32(Console.ReadLine());
                                btree.Insert(num1); 
                            }
                            catch (Exception IllegalArgException) { Console.WriteLine("The node needs to have an integer value."); }
                            
                            break;
                        case 2:
                            Console.WriteLine("Which node do you want to check if it is in the tree? ");
                            int num2 = Convert.ToInt32(Console.ReadLine());
                            if (btree.Search(num2))
                            {
                                Console.WriteLine("The node is in the tree.");

                            }
                            else { Console.WriteLine("The node is not in the tree."); }
                            break;
                        case 3:
                            try
                            {
                                Console.WriteLine("Which node do you want to remove? ");
                                int num3 = Convert.ToInt32(Console.ReadLine());
                                btree.Remove(num3);
                            }catch(Exception EmptyTreeException) { Console.WriteLine("The tree is empty."); }
                            break;
                        case 4:
                            Console.WriteLine("The Tree: ");
                            Console.WriteLine(btree.PreOrder(btree.Root));
                            break;
                    }
                }
                else { Console.WriteLine("Choose a button from the menu."); }
                
            }Console.WriteLine("The program exited.");
        }
    }
}
    
       
