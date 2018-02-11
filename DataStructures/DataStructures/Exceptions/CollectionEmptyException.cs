using System;

namespace DataStructures.Exceptions
{
    public class CollectionEmptyException : Exception
    {
        public override string Message
        {
            get
            {
                return "Elements cannot be retrieved or removed from an empty collection";
            }
        }
    }
}
