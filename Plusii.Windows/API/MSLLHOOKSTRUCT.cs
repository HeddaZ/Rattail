using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Plusii.Windows.API
{
    /// <summary>
    /// 鼠标底层钩子信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MSLLHOOKSTRUCT
    {
        /// <summary>
        /// 点
        /// </summary>
        public Point pt;
        /// <summary>
        /// 鼠标数据
        /// </summary>
        public uint mouseData;
        /// <summary>
        /// 事件注入标志
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
