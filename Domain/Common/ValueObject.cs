﻿namespace Domain.Common
{
    public abstract class ValueObject
    {
        public static bool EqualOperator(ValueObject left, ValueObject right)
        {
            return !(left is null ^ right is null) && left?.Equals(right) != false;
        }

        public static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() == GetType()) return false;
            var other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x is not null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
