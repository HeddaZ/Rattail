using System;
using System.Collections.Generic;
using System.Text;

namespace Plusii.Shared
{
    /// <summary>
    /// 异常事件委托
    /// </summary>
    /// <param name="sender">源</param>
    /// <param name="e">参数</param>
    public delegate void ErrorEventHandler(object sender, ErrorEventArgs e);
}
