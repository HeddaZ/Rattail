using System;
using System.Collections.Generic;
using System.Text;
using Plusii.Windows.API;

namespace Plusii.Windows
{
    /// <summary>
    /// 全局原子服务类
    /// </summary>
    public class GlobalAtom
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ushort Add(string key)
        {
            return Kernel32.GlobalAddAtom(key);
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ushort Find(string key)
        {
            return Kernel32.GlobalFindAtom(key);
        }

        /// <summary>
        /// 尝试查找
        /// </summary>
        /// <param name="key"></param>
        /// <param name="atom"></param>
        /// <returns></returns>
        public static bool TryFind(string key, out ushort atom)
        {
            atom = GlobalAtom.Find(key);
            return (atom != 0);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="atom"></param>
        public static void Delete(ushort atom)
        {
            Kernel32.GlobalDeleteAtom(atom);
        }
    }
}
