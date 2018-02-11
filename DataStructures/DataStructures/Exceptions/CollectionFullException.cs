using System;

namespace DataStructures.Exceptions
{
    public class CollectionFullException : Exception
    {
        public override string Message
        {
            get
            {
                return "Collection cannot have more than Int32.MaxValue + 1 elements.";
            }
        }
    }
}
