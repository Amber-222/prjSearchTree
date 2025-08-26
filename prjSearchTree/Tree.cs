using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace prjSearchTree
{
    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }

        public void PrintTree(TreeNode<T> node, string indent = "", bool last = true)
        {
            if (node == null) return;
            Console.WriteLine($"{indent}+-{node.Data}");
            indent += last ? "  " : "| ";

            for (int i = 0; i < node.Children.Count; i++)
            {
                PrintTree(node.Children[i], indent, i == node.Children.Count - 1);
            }
        }

        public TreeNode<T> FindNode(TreeNode<T> node, T value)
        {
            if (node == null) return null; //if the node passed in is empty it returns empty

            if (node.Data.Equals(value)) return node; //else if the current given node already matches the value looking form return it as is

            foreach (var child in node.Children) //loop through all the children of the given node until the value is found
            {
                var result = FindNode(child, value); //run the method to look at the value of each of the children 
                if (result != null) return result; //until it finally finds a value that matches the parameters
            }
            return null;
        }

        public void PrintTree(TreeNode<T> node, TreeNode<T> highlightNode, string indent = "", bool last = true)
        {
            if (node == null) return;

            if (node.Equals(highlightNode))
            {
                Console.WriteLine($"{indent}+- [{node.Data}]");
            }
            else
            {
                Console.WriteLine($"{indent}+- {node.Data}");
            }

            indent += last ? "   " : "| ";

            for (int i = 0; i < node.Children.Count; i++)
            {
                PrintTree(node.Children[i], highlightNode, indent, i == node.Children.Count - 1);
            }
        }

        //BREADTH FIRST SEARCH
        public List<T> BreadthFirstSearch()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            var visited = new List<T>(); //stores which nodes have been looked at 
            var queue = new Queue<TreeNode<T>>(); //use a queue for bfs
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                TreeNode<T> currentNode = queue.Dequeue(); //get next node in the queue
                visited.Add(currentNode.Data); //visit it, store that its been looked at

                //add all its children at the back of the queue
                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return visited;
        }

        //DEPTH FIRST SEARCH
        public List<T> DepthFirstSearch()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            var visited = new List<T>();
            dfsHelper(Root, visited); //start recursive search from root node
            return visited;
        }

        //dfs helper method
        private void dfsHelper(TreeNode<T> node, List<T> visited)
        {
            if (node == null) return;

            visited.Add(node.Data); //viist current node

            //recursively visit each child to delve deeper into the tree
            foreach (var child in node.Children)
            {
                dfsHelper(child, visited);
            }
        }
    }
}
