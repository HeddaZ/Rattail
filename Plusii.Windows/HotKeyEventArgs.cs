using System;
using System.Collections.Generic;
using System.Text;

namespace Plusii.Windows
{
    /// <summary>
    /// 热键事件参数类
    /// </summary>
    public class HotKeyEventArgs : EventArgs
    {
        #region 属性

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        #endregion

        /// <summary>
        /// 创建热键事件参数对象
        /// </summary>
        /// <param name="name">名称</param>
        public HotKeyEventArgs(string name)
            : base()
        {
            this.Name = name;
        }
    }
}
