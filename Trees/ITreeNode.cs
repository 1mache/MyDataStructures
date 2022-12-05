namespace MyDataStructures;

interface ITreeNode<T>
{
    public T? Value{get; set;}
    public ITreeNode<T>[] GetChildren();
}