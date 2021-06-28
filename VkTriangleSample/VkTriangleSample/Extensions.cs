using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Vulkan;

namespace VkTriangleSample
{
    public unsafe static class Extensions
    {
        public static byte* ToVk(this string text) => new VkString(text).Pointer;
    }
}
