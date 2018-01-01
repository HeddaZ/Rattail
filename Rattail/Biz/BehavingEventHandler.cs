using System;
using System.Collections.Generic;
using System.Text;

namespace Rattail.Biz
{
    /// <summary>
    /// 行为事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void BehavingEventHandler(object sender, BehavingEventArgs e);
}
