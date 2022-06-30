using System;

namespace SecurityLending.models
{
    public abstract class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
    }
}
