using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Represents a Guild Wars 2 trait chat link.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct TraitChatLinkStruct
    {
        /// <summary>
        /// The trait id.
        /// </summary>
        [FieldOffset(0)]
        public uint TraitId;
    }
}
