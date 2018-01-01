using System;
using System.Collections.Generic;
using System.Text;

namespace Plusii.Shared
{
    /// <summary>
    /// 异常事件参数类
    /// </summary>
    public class ErrorEventArgs : EventArgs
    {
        #region 属性

        /// <summary>
        /// 异常
        /// </summary>
        public Exception Exception
        {
            get;
            private set;
        }

        #endregion

        /// <summary>
        /// 创建异常事件参数对象
        /// </summary>
        /// <param name="exception">异常</param>
        public ErrorEventArgs(Exception exception)
            : base()
        {
            this.Exception = exception;
        }
    }
}
