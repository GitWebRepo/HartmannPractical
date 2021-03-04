using System;

namespace HartmannPractical.Data
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OrderAttribute : Attribute
    {
        public int Position { get; set; }

        public OrderAttribute(int position)
        {
            Position = position;
        }
    }
}
