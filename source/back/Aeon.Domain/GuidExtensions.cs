using System;

namespace Aeon.Domain
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid guid) => guid == Guid.Empty;
    }
}
