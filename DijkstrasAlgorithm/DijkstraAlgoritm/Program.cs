using System;
using System.Collections.Generic;
using TableParser;

namespace DijkstraAlgoritm
{
	class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Enter the total number of nodes present in the graph");
			int totalNodes = Convert.ToInt32(Console.ReadLine());

			// Instructions to the user.
			Console.WriteLine("//Enter distance from each node to all other node");
			Console.WriteLine("//If there is no way from one node to other node give a distance of '0'");
			Console.WriteLine("//Distance from one node to  all other node must be given as space seperated values");
			Console.WriteLine("//Example: 0 0 7 8 9 0 1 1 1 1");
			Console.WriteLine("//Distance to the self is '0' all the distance must be positive ");

			int[,] distanceGraph = new int[totalNodes, totalNodes];
			string[] distanceString;

			for (int i = 0; i < totalNodes; i++)
			{
				Console.WriteLine("Enter the distance from #{0} Node to all other Nodes", i + 1);
				distanceString = Console.ReadLine().Split(' ');
				if (distanceString.Length != totalNodes)
				{
					Console.WriteLine("Probably something went wrong please re-enter");
					i--;
				}
				else
				{
					for (int j = 0; j < totalNodes; j++)
					{
						if (Convert.ToInt32(distanceString[j]) >= 0)
						{
							distanceGraph[i, j] = Convert.ToInt32(distanceString[j]);
						}
						else
						{
							Console.WriteLine("Probably something went wrong please re-enter");
							i--;
						}
					}
				}

			}
			Console.WriteLine("Enter the starting Node");
			int startNodeIndex = Convert.ToInt32(Console.ReadLine());
			while (startNodeIndex < 1 || startNodeIndex > totalNodes)
			{
				Console.WriteLine("Start Node is not present. Please re enter starting node");
				startNodeIndex = Convert.ToInt32(Console.ReadLine());
			}
       
            List<Node> resultSet=new Algorithm().DijkstraAlgo(distanceGraph, totalNodes, startNodeIndex-1);
			Console.WriteLine(resultSet.ToStringTable(new[] { "Node", " Parent", "Total Distance","Path" },a => a.Index+1, a => a.Parent+1, a => a.TotalDistance, a=>a.PathToString??"No Way"));
			Console.ReadLine();
        }
    }
}
