namespace MyDataStructures
{
    //undirected unweighted
    class Graph<T>
    {
        private HashTable<T,DynArray<T>> _adjacencyList;

        public Graph()
        {
            _adjacencyList = new HashTable<T, DynArray<T>>();
        }

        public void AddVertex(T vertex)
        {
            if(vertex is null)
                throw new ArgumentNullException("Null vertex");
            
            try
            {
                _adjacencyList.Add(vertex, new DynArray<T>());
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Vertex already in Graph");
            }
        }

        public void AddEdge(T vertex1, T vertex2)
        {
            if(vertex1 is null || vertex2 is null )
                throw new ArgumentNullException("Null vertex");
            
            if(vertex1.Equals(vertex2))
                throw new InvalidOperationException("Cannot create edge from vertex to itself");

            if(!_adjacencyList.Contains(vertex1))
                throw new InvalidOperationException("Vertex is not in Graph");
            if(!_adjacencyList.Contains(vertex2))
                throw new InvalidOperationException("Vertex is not in Graph");

            if(_adjacencyList[vertex1].Contains(vertex2))
                throw new InvalidOperationException("Edge already exists");

            _adjacencyList[vertex1].Add(vertex2);
            _adjacencyList[vertex2].Add(vertex1);
        }

        public void RemoveEdge(T vertex1, T vertex2)
        {
            if(vertex1 is null || vertex2 is null )
                throw new ArgumentNullException("Null vertex");
            
            if(vertex1.Equals(vertex2))
                throw new InvalidOperationException("Cannot remove edge from vertex to itself");
            
            if(!_adjacencyList.Contains(vertex1))
                throw new InvalidOperationException("Vertex is not in Graph");
            if(!_adjacencyList.Contains(vertex2))
                throw new InvalidOperationException("Vertex is not in Graph");


            _adjacencyList[vertex1].Remove(vertex2);
            bool removed = _adjacencyList[vertex2].Remove(vertex1);
            if (!removed) 
                throw new InvalidOperationException("Edge does not exist");
        }

        public void RemoveVertex(T vertex)
        {
            if(vertex is null)
                throw new ArgumentNullException("Null vertex");

            if(!_adjacencyList.Contains(vertex))
                throw new InvalidOperationException("Vertex is not in Graph");

            while(_adjacencyList[vertex].Length > 0)
            {
                //take first elemnt at given vertex's list of connections
                var other = _adjacencyList[vertex][0];
                //removeEdge will remove the vertex from this list so 
                //we can take the first one each iteration and it will be a different connection.
                RemoveEdge(vertex, other!);
            }

            _adjacencyList.Remove(vertex);
        }

        public T?[] DepthFirstTraversal()
        {
            var result = new DynArray<T>();
            var visited = new HashTable<T, bool>();
            
            void DFTInternal(T node)
            {
                result.Add(node);
                visited.Add(node, true);
                var edgeList = _adjacencyList[node];

                if(edgeList.Length != 0)
                {
                    foreach (var connected in edgeList)
                    {
                        if(!visited.Contains(connected!))
                        {
                            DFTInternal(connected!);
                        }
                    }
                }
            }
            
            // This loop is present so the program doesnt get stuck if 
            //there is an unconnected vertex in the graph and doesnt miss it. 
            foreach (var node in _adjacencyList.Keys())
            {
                if(!visited.Contains(node))
                    DFTInternal(node);
            }
            return result.ToArray();
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