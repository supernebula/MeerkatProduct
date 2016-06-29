using System;

namespace Nebula.Common
{
    public struct InterfaceClassPair
    {
        public bool Equals(InterfaceClassPair other)
        {
            return this == other;
        }

        public override bool Equals(object other)
        {
            return other is InterfaceClassPair && this == (InterfaceClassPair)other;
        }

        public override int GetHashCode()
        {
            return (InterfaceType?.GetHashCode() ?? 0) ^ (ClassType?.GetHashCode() ?? 0);
        }

        public Type InterfaceType { get; set; }

        public Type ClassType { get; set; }

        public static bool operator ==(InterfaceClassPair value1, InterfaceClassPair value2)
        {
            return value1.InterfaceType == value2.InterfaceType && value1.ClassType == value2.ClassType;
        }

        public static bool operator !=(InterfaceClassPair value1, InterfaceClassPair value2)
        {
            return value1.InterfaceType != value2.InterfaceType || value1.ClassType != value2.ClassType;
        }
    }
}
