using System.Collections.Generic;
using System.Linq;

namespace DijkstraAlgoritm
{
	class Algorithm
    {
		/// <summary>
		/// Calculates the minimum possible distance from root node to all other nodes.
		/// </summary>
		/// <param name="nodes"></param>
		/// <param name="graph"></param>
		/// <param name="startIndex"></param>
		/// <returns></returns>
		private List<Node> DistanceFinder(List<Node> nodes, int[,] graph,int startIndex)
        {
			foreach (var element in nodes)
            {
				if (element.IsFixed!=true)
                {
					if (graph[startIndex,element.Index]!=0)
                    {
						Node parentItem = nodes.Where((x) => x.Index == startIndex).First();
						if (element.TotalDistance > graph[startIndex, element.Index] + parentItem.TotalDistance)
						{
							element.Path.Clear();
							element.Path.AddRange(parentItem.Path);
							element.Parent = parentItem.Index;
							element.Path.Add(parentItem.Index);
							element.TotalDistance = graph[startIndex, element.Index] + parentItem.TotalDistance;
						}

                    }
                }
            }
			List<Node> unReachedNodes = nodes.Where((x) => x.IsFixed == false).ToList();
            int minDistance=unReachedNodes.Min((x) => x.TotalDistance);
			Node nodeWithMinimumDistance = nodes.Where((x) => x.TotalDistance == minDistance).First();
            nodeWithMinimumDistance.IsFixed=true;
            if (unReachedNodes.Count() != 1)
            {
                DistanceFinder(nodes, graph, nodeWithMinimumDistance.Index);
            }          
            return nodes;          
        }
		/// <summary>
		/// Creates the nodes and the initiates the shortest path calculation process.
		/// </summary>
		/// <param name="graph"></param>
		/// <param name="vertices"></param>
		/// <param name="startIndex"></param>
		/// <returns></returns>
		public List<Node> DijkstraAlgo(int[,] graph,int vertices,int startIndex)
        {
            List<Node> nodes = new List<Node>();
			for (int i = 0; i < vertices; i++)
			{
				nodes.Add((i == startIndex) ? (new Node(i, true)) : (new Node(i)));

			}
			return DistanceFinder(nodes, graph, startIndex);    
        }
    }
}
