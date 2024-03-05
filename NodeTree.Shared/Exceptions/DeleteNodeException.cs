namespace NodeTree.Shared.Exceptions
{
    public class DeleteNodeException() : SecureException("You have to delete all children nodes first") { }
}