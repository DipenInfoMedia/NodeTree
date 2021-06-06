using System.Collections.Generic;

namespace NodeTree
{
    public class Node
    {
        public Node()
        {
        }

        // Constructor to instantiate a node with its value
        public Node(int value)
        {
            Value = value;
        }

        // Child Nodes under this node. If ChildNodes count is 0 then it is the leaf node.
        public List<Node> ChildNodes { get; set; } = new List<Node>();

        // Parent of this node. If parent is null then it is the root node
        public Node Parent { get; set; }

        // Property that identifies the root.
        public Node Root
        {
            get { return (Parent == null) ? this : Parent.Root; }
        }

        // Property that gives the full tree value irrespective of the current node location
        public int TreeValue
        {
            get { return Root.GetTreeValueFromHere(); }
        }

        // Integer value of this node
        public int Value { get; set; }

        /// <summary>
        /// This function adds a child node to the current node and returns the child node object
        /// </summary>
        /// <param name="childValue"></param>
        /// <returns></returns>
        public Node CreateAndAddChildNode(int childValue)
        {
            // Create a child node assigning the current node as the parent.
            Node childNode = new Node(childValue) { Parent = this };
            ChildNodes.Add(childNode);
            return childNode;
        }

        /// <summary>
        /// This function returns the value of the tree below this node, including the current node value
        /// </summary>
        /// <returns></returns>
        public int GetTreeValueFromHere()
        {
            // Start with the current node value
            int treeValue = Value;

            // Get the values of all the nodes below this node
            if (ChildNodes != null && ChildNodes.Count > 0)
            {
                ((List<Node>)ChildNodes).ForEach(n => treeValue += n.GetTreeValueFromHere());
            }

            return treeValue;
        }
    }
}