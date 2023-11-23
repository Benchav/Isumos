namespace Infrastructure.Endpoint.Builders
{
    public enum SqlWriteOperation
    {
        Create, 
        Update,
        Delete
    }

    public enum SqlReadOperation
    {
        Select,  
        SelectById 
    }
}