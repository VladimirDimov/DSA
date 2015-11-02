namespace TreeRead
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int longestPath;

        static void Main()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            var nodes = new Dictionary<int, TreeNode<int>>();

            // We put all nodes in a dictionary with a key - the value of the node.
            // Each time we add new node we check if we have it in the dictionary.
            // We find the root as we cycle through the diction and find the node with no parent.
            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                var currentNodes = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray<int>();
                var currentParentValue = currentNodes[0];
                var currentChildValue = currentNodes[1];
                TreeNode<int> currentParent;
                TreeNode<int> currentChild;

                if (nodes.ContainsKey(currentParentValue))
                {
                    currentParent = nodes[currentParentValue];
                }
                else
                {
                    currentParent = new TreeNode<int>(currentParentValue);
                    nodes.Add(currentParentValue, currentParent);
                }

                if (nodes.ContainsKey(currentChildValue))
                {
                    currentChild = nodes[currentChildValue];
                }
                else
                {
                    currentChild = new TreeNode<int>(currentChildValue);
                    nodes.Add(currentChildValue, currentChild);
                }

                currentParent.AddChild(currentChild);
            }

            // The root
            var root = GetRoot(nodes);

            Console.WriteLine("The root has value: {0}", root.Value);

            // The tree with the root
            var tree = CreateTree(root);

            var leafs = new List<int>();
            var middleNodes = new List<int>();
            var allPathsWithSum = new List<List<int>>();

            Console.WriteLine("Tree");
            PrinTree(tree.Root);

            GetTreeLeafs(tree.Root, leafs);
            Console.WriteLine("Leafs: {0}", string.Join(", ", leafs));

            GetTreeMiddleNodes(tree.Root, middleNodes);
            Console.WriteLine("Middle nodes: {0}", string.Join(", ", middleNodes));

            GetLongestPath(tree.Root, 0);
            Console.WriteLine("Longest path: {0}", longestPath);

            GetPathsBySum(tree.Root, 6, new List<int>(), allPathsWithSum);
            Console.WriteLine("All paths with sum {0}", 6);
            foreach (var path in allPathsWithSum)
            {
                Console.WriteLine(string.Join(", ", path));
            }


            Console.WriteLine("All nodes with sum 12:");
            var nodesWithSum = GetAllNodesWithSum(tree.Root, 12, new List<TreeNode<int>>());
            foreach (var item in nodesWithSum)
            {
                Console.WriteLine("Node:");
                PrinTree(item);
            }
        }

        private static TreeNode<int> GetRoot(Dictionary<int, TreeNode<int>> roots)
        {
            foreach (var item in roots)
            {
                if (!item.Value.HasParent)
                {
                    return item.Value;
                }
            }

            throw new ArgumentException();
        }

        private static Tree<int> CreateTree(TreeNode<int> root)
        {
            var tree = new Tree<int>(root);
            return tree;
        }

        private static void GetTreeLeafs(TreeNode<int> node, List<int> leafs)
        {
            if (node.Children.Count == 0)
            {
                leafs.Add(node.Value);
            }

            foreach (var child in node.Children)
            {
                GetTreeLeafs(child, leafs);
            }
        }

        private static void GetTreeMiddleNodes(TreeNode<int> node, List<int> middleNodes)
        {
            if (node.Children.Count != 0 && node.HasParent)
            {
                middleNodes.Add(node.Value);
            }

            foreach (var child in node.Children)
            {
                GetTreeMiddleNodes(child, middleNodes);
            }
        }

        private static void GetLongestPath(TreeNode<int> node, int path)
        {
            path++;
            foreach (var child in node.Children)
            {
                GetLongestPath(child, path);
            }

            if (path > longestPath)
            {
                longestPath = path;
            }
        }

        private static void GetPathsBySum(TreeNode<int> root, int requestedSum, List<int> currentPath, List<List<int>> resultingPaths)
        {
            currentPath.Add(root.Value);
            var currentPathSum = currentPath.Sum();

            if (currentPathSum > requestedSum)
            {
                return;
            }

            if (currentPathSum == requestedSum)
            {
                resultingPaths.Add(currentPath);
            }

            foreach (var child in root.Children)
            {
                GetPathsBySum(child, requestedSum, new List<int>(), resultingPaths);
                GetPathsBySum(child, requestedSum, new List<int>(currentPath), resultingPaths);
            }
        }

        private static void PrinTree(TreeNode<int> node, int indentation = 0)
        {
            Console.WriteLine(new string(' ', indentation) + node.Value);
            foreach (var child in node.Children)
            {
                PrinTree(child, indentation + 2);
            }
        }

        private static int CalculateTreeSum(TreeNode<int> node, int sum = 0)
        {
            sum += node.Value;

            foreach (var subNode in node.Children)
            {
                sum += CalculateTreeSum(subNode);
            }

            return sum;
        }

        private static List<TreeNode<int>> GetAllNodesWithSum(TreeNode<int> node, int requestedSum, List<TreeNode<int>> result)
        {
            var currentNodeSUm = CalculateTreeSum(node);
            if (currentNodeSUm == requestedSum)
            {
                result.Add(node);
            }

            foreach (var child in node.Children)
            {
                GetAllNodesWithSum(child, requestedSum, result);
            }

            return result;
        }
    }
}
