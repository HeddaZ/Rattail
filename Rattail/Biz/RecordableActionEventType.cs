using System;
using System.Collections.Generic;
using System.Text;

namespace Rattail.Biz
{
    /// <summary>
    /// 可记录的动作事件类型
    /// </summary>
    public enum RecordableActionEventType
    {
        /// <summary>
        /// None
        /// </summary>
        N,
        /// <summary>
        /// Down
        /// </summary>
        D,
        /// <summary>
        /// Up
        /// </summary>
        U,
        /// <summary>
        /// Copy
        /// </summary>
        C,
        /// <summary>
        /// Begin Record
        /// </summary>
        B,
        /// <summary>
        /// End Record
        /// </summary>
        E,
        /// <summary>
        /// Exception
        /// </summary>
        X
    }
}
