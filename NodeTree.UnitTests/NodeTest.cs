using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NodeTree.UnitTests
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        // Root (1) -->
        // Total Value Expected = 1
        public void SingleNode()
        {
            // Arrange
            // Single node with value 1
            Node rootNode = new Node(1);

            // Act
            int totalTreeValue = rootNode.TreeValue;

            // Assert
            Assert.IsTrue(totalTreeValue == 1);
        }

        [TestMethod]
        // Root (1) -->
        //         Child1 (2) -->
        //                        Leaf1 (3)
        //                        Leaf2 (4)
        //         Child2 (3) -->
        //                        Leaf3 (5)
        // Total Value Expected = 18
        public void ThreeLevelsOfNodes()
        {
            // Arrange
            // Root node with value 1
            Node rootNode = new Node(1);

            // 2 child nodes to root nodes with value 2 each
            Node rootChild1 = (Node)rootNode.CreateAndAddChildNode(2);
            Node rootChild2 = (Node)rootNode.CreateAndAddChildNode(3);

            // children of rootChild1
            Node leaf1 = (Node)rootChild1.CreateAndAddChildNode(3);
            Node leaf2 = (Node)rootChild1.CreateAndAddChildNode(4);

            // child of rootChild2
            Node leaf3 = (Node)rootChild2.CreateAndAddChildNode(5);

            // Act
            // Lets get the tree value from rootChild2 instead of root
            int totalTreeValue = rootChild2.TreeValue;

            // Assert
            Assert.IsTrue(totalTreeValue == 18);
            // Assert that the tree value property from any node is the same
            Assert.IsTrue(rootNode.TreeValue == leaf1.TreeValue);
        }

        [TestMethod]
        // Root (1) -->
        //         Child1 (2)
        //         Child2 (2)
        // Total Value Expected = 5
        public void TwoLevelsOfNodes()
        {
            // Arrange
            // Root node with value 1
            Node rootNode = new Node(1);

            // 2 child nodes to root nodes with value 2 each
            Node rootChild1 = (Node)rootNode.CreateAndAddChildNode(2);
            Node rootChild2 = (Node)rootNode.CreateAndAddChildNode(2);

            // Act
            int totalTreeValue = rootNode.TreeValue;

            // Assert
            Assert.IsTrue(totalTreeValue == 5);
        }
    }
}