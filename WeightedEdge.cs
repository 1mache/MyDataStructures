namespace MyDataStructures
{
    internal struct WeightedEdge<TVertex> 
    {
        public TVertex ToVertex { get; private set; }
        public int Weight { get; private set; }

        public WeightedEdge(TVertex toVertex, int weight)
        {
            if(toVertex is null) throw new ArgumentNullException();
            ToVertex = toVertex;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"[{ToVertex},{Weight}]";
        }
    }
}