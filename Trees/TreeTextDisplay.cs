namespace MyDataStructures;

class TreeTextDisplay
{
    private const string SIDE_LINE = "-";
    private const string DOWN_LINE = "|";

    public string TreeToString<T>(ITree<T> tree, Func<T,string>? valueToString = null)
    {
        return TreeToString<T>(tree.GetRoot(), valueToString);
    }

    public string TreeToString<T>(ITreeNode<T>? root, Func<T,string>? valueToString = null)
    {
        string result = "";
        
        if(root is null)
            return "";

        result += root.TextDisplay(valueToString);
        result += String.Concat(Enumerable.Repeat(SIDE_LINE, 8));
        result += "\n";

        return result;
    }
}