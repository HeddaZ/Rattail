using System;
using System.Collections.Generic;
using System.Text;

namespace Plusii.Shared.Pattern
{
    /// <summary>
    /// 队列处理事件参数类
    /// </summary>
    public class QueueProcessEventArgs : EventArgs
    {
        #region 属性

        /// <summary>
        /// 参数
        /// </summary>
        public object Argument
        {
            get;
            private set;
        }

        #endregion

        /// <summary>
        /// 创建队列处理事件参数对象
        /// </summary>
        /// <param name="argument">参数</param>
        public QueueProcessEventArgs(object argument)
            : base()
        {
            this.Argument = argument;
        }
    }
}
