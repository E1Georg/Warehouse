namespace Warehouse.Application.Common.Exceptions
{
    public class EntityСannotUpdatedException : Exception
    {
        public EntityСannotUpdatedException(string name, object key) : base($"Entity \"{name}\" ({key}) can not updated.") { }
    }
}
