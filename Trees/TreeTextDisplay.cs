namespace MyDataStructures;

class TreeTextDisplay
{
    private const string SIDE_LINE = "-";
    private const string DOWN_LINE = "|";

    public string TreeToString<T>(ITree<T> tree, Func<ITreeNode<T>,string> nodeToText)
    {
        return TreeToString<T>(tree.GetRoot(), nodeToText);
    }

    public string TreeToString<T>(ITreeNode<T>? root, Func<ITreeNode<T>,string> nodeToText)
    {
        string result = "";
        
        if(root is null)
            return "";

        result += nodeToText(root);
        result += String.Concat(Enumerable.Repeat(SIDE_LINE, 8));
        result += "\n";

        return result;
    }
}