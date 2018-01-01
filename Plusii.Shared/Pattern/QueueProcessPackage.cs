using System;
using System.Collections.Generic;
using System.Text;

namespace Plusii.Shared.Pattern
{
    /// <summary>
    /// 队列处理包类
    /// </summary>
    public class QueueProcessPackage
    {
        #region 属性

        /// <summary>
        /// 事件委托
        /// </summary>
        public QueueProcessEventHandler EventHandler
        {
            get;
            private set;
        }
        /// <summary>
        /// 事件参数
        /// </summary>
        public QueueProcessEventArgs EventArgs
        {
            get;
            private set;
        }

        #endregion

        /// <summary>
        /// 创建队列处理包对象
        /// </summary>
        /// <param name="eventHandler">事件委托</param>
        /// <param name="eventArgs">事件参数</param>
        public QueueProcessPackage(QueueProcessEventHandler eventHandler, QueueProcessEventArgs eventArgs)
        {
            this.EventHandler = eventHandler;
            this.EventArgs = eventArgs;
        }
    }
}
