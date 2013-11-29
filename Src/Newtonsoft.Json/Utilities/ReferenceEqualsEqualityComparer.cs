using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities {
    internal class ReferenceEqualsEqualityComparer : IEqualityComparer<object>
    {
        internal static IEqualityComparer<object> Instance = new ReferenceEqualsEqualityComparer();

        private ReferenceEqualsEqualityComparer() {
        }

        bool IEqualityComparer<object>.Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }

        int IEqualityComparer<object>.GetHashCode(object obj)
        {
#if !(NETFX_CORE)
            // put objects in a bucket based on their reference
            return RuntimeHelpers.GetHashCode(obj);
#else
    // put all objects in the same bucket so ReferenceEquals is called on all
    return -1;
#endif
        }
	}
}
