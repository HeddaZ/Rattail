using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Plusii.Windows.API
{
    /// <summary>
    /// 键盘底层钩子信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KBDLLHOOKSTRUCT
    {
        /// <summary>
        /// 虚拟键值
        /// </summary>
        public uint vkCode;
        /// <summary>
        /// 硬件扫描码
        /// </summary>
        public uint scanCode;
        /// <summary>
        /// 扩展键标志
        /// </summary>
        public uint flags;
        /// <summary>
        /// 时间戳
        /// </summary>
        public uint time;
        /// <summary>
        /// 额外信息
        /// </summary>
        public IntPtr dwExtraInfo;
    }
}
