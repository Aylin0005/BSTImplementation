using  static BinarySearchTree.BinarySearchTree.BST;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
            public void Insert_ValidInput_RootNotNull()
            {
                // Arrange
                BinarySearchTree.BinarySearchTree.BST bst = new BinarySearchTree.BinarySearchTree.BST();

                // Act
                bst.Insert(5);

                // Assert
                Assert.IsNotNull(bst.Root);
            }

            [TestMethod]
            public void Insert_InvalidInput_ThrowsIllegalArgException()
            {
                // Arrange
                var bst = new BinarySearchTree.BinarySearchTree.BST();

                // Act & Assert
                
           
        }

            [TestMethod]
            public void Search_ExistingValue_ReturnsTrue()
            {
                // Arrange
                var bst = new BinarySearchTree.BinarySearchTree.BST();
                bst.Insert(5);

                // Act
                var result = bst.Search(5);

                // Assert
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void Search_NonExistingValue_ReturnsFalse()
            {
                // Arrange
                var bst = new BinarySearchTree.BinarySearchTree.BST();
                bst.Insert(5);

                // Act
                var result = bst.Search(10);

                // Assert
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void Remove_RootNode_RemovesNode()
            {
                // Arrange
                var bst = new BinarySearchTree.BinarySearchTree.BST();
                bst.Insert(5);

                // Act
                var result = bst.Remove(5);

                // Assert
                Assert.IsTrue(result);
                Assert.IsNull(bst.Root);
            }

            [TestMethod]
            public void PreOrder_EmptyTree_ReturnsEmptyString()
            {
                // Arrange
                var bst = new BinarySearchTree.BinarySearchTree.BST();

                // Act
                var result = bst.PreOrder(bst.Root);

                // Assert
                Assert.AreEqual("", result);
            }

            [TestMethod]
            public void PreOrder_TreeWithNodes_ReturnsCorrectString()
            {
                // Arrange
                var bst = new BinarySearchTree.BinarySearchTree.BST();
                bst.Insert(5);
                bst.Insert(3);
                bst.Insert(7);

                // Act
                var result = bst.PreOrder(bst.Root);

                // Assert
                Assert.AreEqual("Node 5 :(Left: Node 3  Right: Node 7 )", result);
            }
        }
    }

