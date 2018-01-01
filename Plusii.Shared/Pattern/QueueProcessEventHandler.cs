using System;
using System.Collections.Generic;
using System.Text;

namespace Plusii.Shared.Pattern
{
    /// <summary>
    /// 队列处理事件委托
    /// </summary>
    /// <param name="sender">源</param>
    /// <param name="e">参数</param>
    public delegate void QueueProcessEventHandler(object sender, QueueProcessEventArgs e);
}
