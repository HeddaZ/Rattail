using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Plusii.Windows
{
    /// <summary>
    /// 全局服务类
    /// </summary>
    public class Global : Plusii.Shared.Global
    {
        #region 属性

        /// <summary>
        /// 应用程序工作目录路径
        /// </summary>
        public static string ApplicationWorkingDirectoryPath
        {
            get
            {
                return Directory.GetCurrentDirectory().TrimEnd('\\') + "\\";
            }
        }

        /// <summary>
        /// 用户临时目录路径
        /// </summary>
        public static string UserTempDirectoryPath
        {
            get
            {
                return Path.GetTempPath().TrimEnd('\\') + "\\";
            }
        }

        #endregion
    }
}
