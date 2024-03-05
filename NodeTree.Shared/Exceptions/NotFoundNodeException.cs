namespace NodeTree.Shared.Exceptions
{
    public class NotFoundNodeException(int nodeId) 
        : SecureException($"Node with ID = {nodeId} was not found") { }
}