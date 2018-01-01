using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Plusii.Windows.API
{
    /// <summary>
    /// Kernel32.dll
    /// </summary>
    public static class Kernel32
    {
        /// <summary>
        /// Dll文件名
        /// </summary>
        public const string DllName = "kernel32.dll";


        #region GlobalAddAtom

        /// <summary>
        /// 添加全局原子
        /// </summary>
        /// <param name="lpString">特征字符串</param>
        /// <returns>全局原子</returns>
        [DllImport(Kernel32.DllName)]
        public static extern ushort GlobalAddAtom(string lpString);

        /// <summary>
        /// 查找全局原子
        /// </summary>
        /// <param name="lpString">特征字符串</param>
        /// <returns>全局原子</returns>
        [DllImport(Kernel32.DllName)]
        public static extern ushort GlobalFindAtom(string lpString);

        /// <summary>
        /// 删除全局原子
        /// </summary>
        /// <param name="nAtom">全局原子</param>
        /// <returns>0</returns>
        [DllImport(Kernel32.DllName)]
        public static extern ushort GlobalDeleteAtom(ushort nAtom);

        #endregion
    }
}
