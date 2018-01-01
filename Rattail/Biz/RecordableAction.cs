using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Rattail.Biz
{
    /// <summary>
    /// 可记录的动作
    /// </summary>
    public class RecordableAction
    {
        #region 常量

        public static readonly RecordableAction Empty = new RecordableAction(RecordableActionEventType.N, string.Empty);

        #endregion

        #region 属性

        /// <summary>
        /// 事件类型
        /// </summary>
        public RecordableActionEventType EventType
        {
            get;
            private set;
        }
        /// <summary>
        /// 键
        /// </summary>
        public Keys Key
        {
            get;
            private set;
        }
        /// <summary>
        /// 位置
        /// </summary>
        public Point Location
        {
            get;
            private set;
        }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message
        {
            get;
            private set;
        }
        /// <summary>
        /// 时间戳
        /// </summary>
        public uint TimeStamp
        {
            get;
            private set;
        }
        /// <summary>
        /// 字符串格式
        /// </summary>
        private string StringFormat
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// 创建键盘动作
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="key"></param>
        /// <param name="timeStamp"></param>
        public RecordableAction(RecordableActionEventType eventType, Keys key, uint timeStamp)
        {
            this.EventType = eventType;
            this.Key = key;
            this.TimeStamp = timeStamp;
            if (eventType == RecordableActionEventType.D)
            {
                this.StringFormat = RtGlobal.KeyboardDownActionStringFormat;
            }
            else
            {
                this.StringFormat = RtGlobal.KeyboardUpActionStringFormat;
            }

            this.Location = Point.Empty;
            this.Message = string.Empty;
        }

        /// <summary>
        /// 创建鼠标动作
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="key"></param>
        /// <param name="location"></param>
        /// <param name="timeStamp"></param>
        public RecordableAction(RecordableActionEventType eventType, Keys key, Point location, uint timeStamp)
        {
            this.EventType = eventType;
            this.Key = key;
            this.Location = location;
            this.TimeStamp = timeStamp;
            if (eventType == RecordableActionEventType.D)
            {
                this.StringFormat = RtGlobal.MouseDownActionStringFormat;
            }
            else
            {
                this.StringFormat = RtGlobal.MouseUpActionStringFormat;
            }

            this.Message = string.Empty;
        }

        /// <summary>
        /// 创建消息动作
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="message"></param>
        public RecordableAction(RecordableActionEventType eventType, string message)
        {
            this.EventType = eventType;
            this.Message = message;
            this.StringFormat = RtGlobal.MessageActionStringFormat;

            this.Key = Keys.None;
            this.Location = Point.Empty;
            this.TimeStamp = 0;
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(this.StringFormat,
                this.EventType,
                this.Key,
                this.Location.X,
                this.Location.Y,
                this.Message,
                this.TimeStamp / 1000 //秒
                );
        }

        #region 静态方法

        /// <summary>
        /// 同一个按键动作的两个环节
        /// </summary>
        /// <param name="action1"></param>
        /// <param name="action2"></param>
        /// <returns></returns>
        public static bool IsOneActionOfKey(RecordableAction action1, RecordableAction action2)
        {
            return (action1.Key == action2.Key && action1.EventType == RecordableActionEventType.D && action2.EventType == RecordableActionEventType.U);
        }

        #endregion
    }
}
