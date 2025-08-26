namespace prjSearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<string> orgChart = new Tree<string>();
            orgChart.Root = new TreeNode<string> { Data = "CEO" };

            var vp = new TreeNode<string> { Data = "VP", Parent = orgChart.Root };
            var manager = new TreeNode<string> { Data = "manager", Parent = orgChart.Root };

            orgChart.Root.Children.AddRange(new[] { vp, manager });

            var jeff = new TreeNode<string> { Data = "Jeff", Parent = vp };
            vp.Children.Add(jeff);

            var john = new TreeNode<string> { Data = "John", Parent = vp };
            vp.Children.Add(john);

            var kim = new TreeNode<string> { Data = "Kim", Parent = manager };
            manager.Children.Add(kim);

            Console.WriteLine("---- Org Chart Structure ----");
            orgChart.PrintTree(orgChart.Root);
            Console.WriteLine("-----------------------------");

            Console.WriteLine();

            Console.WriteLine("------------ BFS ------------");
            List<string> bfsResult = orgChart.BreadthFirstSearch();
            Console.WriteLine(string.Join(" -> ", bfsResult));
            Console.WriteLine("-----------------------------");

            Console.WriteLine();

            Console.WriteLine("------------ BFS ------------");
            List<string> dfsResult = orgChart.DepthFirstSearch();
            Console.WriteLine(string.Join(" -> ", dfsResult));
            Console.WriteLine("-----------------------------");

            #region
            //IN CLASS EXAMPLE, IN WORD DOC
            Tree<string> complexTree = new Tree<string>();
            complexTree.Root = new TreeNode<string> { Data = "A" }; //ROOT

            //A'S CHILDREN
            var J = new TreeNode<string> { Data = "J", Parent = complexTree.Root };
            var B = new TreeNode<string> { Data = "B", Parent = complexTree.Root };
            var Y = new TreeNode<string> { Data = "Y", Parent = complexTree.Root };
            var H = new TreeNode<string> { Data = "H", Parent = complexTree.Root };
            var G = new TreeNode<string> { Data = "G", Parent = complexTree.Root };
            complexTree.Root.Children.AddRange(new[]  { J, B, Y, H, G });

            //J'S CHILDREN
            var Z = new TreeNode<string> { Data = "Z", Parent = J };
            var C = new TreeNode<string> { Data = "C", Parent = J };
            var K = new TreeNode<string> { Data = "K", Parent = J };
            J.Children.AddRange(new[] {Z, C, K });

            //C'S CHILDREN
            var X = new TreeNode<string> { Data = "X", Parent = C };
            var N = new TreeNode<string> { Data = "N", Parent = C };
            C.Children.AddRange(new[] { X, N });

            //K'S CHILD
            var L = new TreeNode<string> { Data = "L", Parent = K };
            K.Children.Add(L);

            //B'S CHILDREN
            var D = new TreeNode<string> { Data = "D", Parent = B };
            var F = new TreeNode<string> { Data = "F", Parent = B };
            B.Children.AddRange(new[] { D, F });

            //G'S CHILD
            var M = new TreeNode<string> { Data = "M", Parent = G };
            G.Children.Add(M);

            //D'S CHILD
            var E = new TreeNode<string> { Data = "E", Parent = D };
            D.Children.Add(E);

            //F'S CHILD
            var I = new TreeNode<string> { Data = "I", Parent = F };
            F.Children.Add(I);
            #endregion

            Console.WriteLine("---- Complex Tree Structure ----");
            orgChart.PrintTree(complexTree.Root);
            Console.WriteLine("-----------------------------");

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("------------ BFS ------------");
            List<string> bfsResultComplex = complexTree.BreadthFirstSearch();
            Console.WriteLine(string.Join(" -> ", bfsResultComplex));
            Console.WriteLine("-----------------------------");

            Console.WriteLine();

            Console.WriteLine("------------ BFS ------------");
            List<string> dfsResultComplex = complexTree.DepthFirstSearch();
            Console.WriteLine(string.Join(" -> ", dfsResultComplex));
            Console.WriteLine("-----------------------------");
        }
    }
}
