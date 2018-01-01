using System;
using System.Collections.Generic;
using System.Text;

namespace Rattail.Biz
{
    /// <summary>
    /// 行为事件参数
    /// </summary>
    public class BehavingEventArgs : EventArgs
    {
        #region 属性

        /// <summary>
        /// 行为类型
        /// </summary>
        public BehaviorType Behavior
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// 创建行为事件参数对象
        /// </summary>
        /// <param name="behavior">行为类型</param>
        public BehavingEventArgs(BehaviorType behavior)
        {
            this.Behavior = behavior;
        }
    }
}
