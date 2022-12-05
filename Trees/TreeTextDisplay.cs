namespace MyDataStructures;

class TreeTextDisplay
{
    private const string SIDE_LINE = "-";
    private const string DOWN_LINE = "|";

    public string TreeToString<T>(ITree<T> tree, Func<T?,string> displayNodeValue)
    {
        return TreeToString<T>(tree.GetRoot(), displayNodeValue);
    }

    public string TreeToString<T>(ITreeNode<T>? root, Func<T?,string> displayNodeValue)
    {
        string result = "";
        
        if(root is null)
            return "";

        result += displayNodeValue(root.Value);
        result += String.Concat(Enumerable.Repeat(SIDE_LINE, 8));
        result += "\n";

        return result;
    }
}