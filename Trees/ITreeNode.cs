namespace MyDataStructures;

interface ITreeNode<T>
{
    public T? Value{get; set;}
    public ITreeNode<T>[] GetChildren();
    public string? TextDisplay(Func<T,string>? valueToString = null);
}