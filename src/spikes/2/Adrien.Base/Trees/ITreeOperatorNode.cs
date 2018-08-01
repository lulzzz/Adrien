namespace Adrien.Trees
{
    public interface ITreeOperatorNode<TOp> : ITreeNode
    {
        TOp Op { get; }
    }
}