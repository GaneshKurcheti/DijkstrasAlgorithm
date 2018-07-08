using System.Collections.Generic;
using System.Linq;

namespace DijkstraAlgoritm
{
	class Node
    {
        public Node(int index, bool isStartNode = false)
        {
            this.Index = index;
			IsFixed = isStartNode ? true: false;
			TotalDistance = isStartNode ? 0 : int.MaxValue;
			Parent =  -1;
			Path = new List<int>(); 
		}

		public int Index { get; set; }
		public int Parent { get; set; }
		public int TotalDistance { get; set; }
		public bool IsFixed { get; set; }
		public List<int> Path { get; set; }
		public string PathToString
		{
			get
			{
				return string.Join("->", this.Path.Select(i => (i+1).ToString()).ToArray())+ "->"+(this.Index+1);
			}
		}

	}
}
