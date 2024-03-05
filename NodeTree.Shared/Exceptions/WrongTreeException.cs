namespace NodeTree.Shared.Exceptions
{
    public class WrongTreeException() 
        : SecureException($"Requested node was found, but it doesn't belong to your tree") { }
}