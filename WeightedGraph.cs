namespace MyDataStructures
{
    //undirected, weighted in int 
    class WeightedGraph<TVertex>
    {
        private HashTable<TVertex,DynArray<WeightedEdge<TVertex>>> _adjacencyList;
        private DynArray<TVertex> _verteciesList;

        public WeightedGraph()
        {
            _adjacencyList = new HashTable<TVertex, DynArray<WeightedEdge<TVertex>>>();
            _verteciesList = new DynArray<TVertex>();
        }

        public void AddVertex(TVertex vertex)
        {
            if(vertex is null)
                throw new ArgumentNullException("Null vertex");
            
            try
            {
                _adjacencyList.Add(vertex, new DynArray<WeightedEdge<TVertex>>());
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Vertex already in Graph");
            }

            _verteciesList.Add(vertex);
        }

        public void AddEdge(TVertex vertex1, TVertex vertex2, int weight)
        {
            if(vertex1 is null || vertex2 is null )
                throw new ArgumentNullException("Null vertex");
            
            if(vertex1.Equals(vertex2))
                throw new InvalidOperationException("Cannot create edge from vertex to itself");

            if(!_adjacencyList.Contains(vertex1))
                throw new InvalidOperationException("Vertex is not in Graph");
            if(!_adjacencyList.Contains(vertex2))
                throw new InvalidOperationException("Vertex is not in Graph");

            var edge12 = new WeightedEdge<TVertex>(vertex2, weight);
            var edge21 = new WeightedEdge<TVertex>(vertex1, weight);

            foreach (var edge in _adjacencyList[vertex1])
            {
                if(edge.ToVertex!.Equals(vertex2))
                    throw new InvalidOperationException("Edge already exists");
            }

            _adjacencyList[vertex1].Add(edge12);
            _adjacencyList[vertex2].Add(edge21);
        }

        public int DijkstrasShortest(TVertex vertex1, TVertex vertex2)
        {
            if(_verteciesList.Length == 0)
                throw new InvalidOperationException("Graph is empty!");
            if(!_adjacencyList.Contains(vertex1) || !_adjacencyList.Contains(vertex2))
                throw new InvalidOperationException("Invalid vertex");
            if(vertex1 is null || vertex2 is null)
                throw new InvalidOperationException("WHAT THE HELL IS WRONG WITH YOU");

            var distQueue = new PriorityQueue<int, TVertex>();
            var distTable = new HashTable<TVertex, int>();
            var visited = new HashTable<TVertex, bool>();
            var previous = new HashTable<TVertex, TVertex?>();

            foreach (var vertex in _verteciesList)
            {
                if(vertex1.Equals(vertex))
                {
                    distQueue.Enqueue(0, vertex!);
                    distTable.Add(vertex!, 0);
                }
                else
                    distTable.Add(vertex! ,int.MaxValue); //infinityDistance
                previous.Add(vertex!, default(TVertex));
            }

            var current = distQueue.Dequeue();
            //stop after the last vertex
            while(visited.Length < _verteciesList.Length -1)
            {
                foreach (var edge in _adjacencyList[current])
                {
                    var neighbor = edge.ToVertex;
                    if(!visited.Contains(neighbor))
                    {
                        var neighborDist = distTable[current] + edge.Weight;
                        if(distTable[neighbor] > neighborDist)
                        {
                            distQueue.Enqueue(neighborDist, neighbor);

                            distTable.Remove(neighbor);
                            distTable.Add(neighbor, neighborDist);

                            previous.Remove(neighbor);
                            previous.Add(neighbor, current);
                        }
                    }
                }

                visited.Add(current, true);
                var next = distQueue.Dequeue();
                while(visited.Contains(next))
                {
                    next = distQueue.Dequeue();
                }
                current = next;
            }

            return distTable[vertex2];
        }

        public override string ToString()
        {
            string result = "";

            foreach (var key in _adjacencyList.Keys())
            {
                result += $"({key!.ToString()})";
                result += $" => {_adjacencyList[key].ToString()}";
                result += "\n";    
            }
            return result;
        }
    }
}