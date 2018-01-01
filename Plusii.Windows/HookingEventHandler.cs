using System;
using System.Collections.Generic;
using System.Text;

namespace Plusii.Windows
{
    /// <summary>
    /// 钩住事件委托
    /// </summary>
    /// <param name="nCode">钩子代码</param>
    /// <param name="wParam">消息参数</param>
    /// <param name="lParam">消息参数</param>
    /// <param name="defaultResult"></param>
    /// <returns></returns>
    public delegate IntPtr HookingEventHandler(int nCode, IntPtr wParam, IntPtr lParam, IntPtr defaultResult);
}
