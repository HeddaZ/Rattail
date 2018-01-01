using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Rattail.Biz
{
    /// <summary>
    /// 行为揣测助手
    /// </summary>
    public class BehaviorSurmiser : IDisposable
    {
        #region 常量

        /// <summary>
        /// 动作隧道容量
        /// </summary>
        private const int ActionTunnelCapacity = 3;

        #endregion

        #region 属性

        /// <summary>
        /// 动作隧道
        /// </summary>
        private List<RecordableAction> ActionTunnel
        {
            get;
            set;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 行为事件
        /// </summary>
        public event BehavingEventHandler Behaving;
        /// <summary>
        /// 触发行为事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnBehaving(object sender, BehavingEventArgs e)
        {
            if (this.Behaving != null)
            {
                this.Behaving(sender, e);
            }
        }

        #endregion

        /// <summary>
        /// 创建行为揣测助手对象
        /// </summary>
        public BehaviorSurmiser()
        {
            this.ActionTunnel = new List<RecordableAction>();
        }

        /// <summary>
        /// 销毁
        /// </summary>
        ~BehaviorSurmiser()
        {
            this.Dispose(false);
        }

        #region IDisposable Members

        /// <summary>
        /// 是否资源已释放
        /// </summary>
        private bool disposed = false;
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            //垃圾收集器
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">是否释放托管资源</param>
        protected virtual void Dispose(bool disposing)
        {
            //是否已释放
            if (!this.disposed)
            {
                if (disposing)
                {
                    #region 释放托管资源

                    try
                    {
                        this.ActionTunnel.Clear();
                    }
                    catch
                    {
                    }
                    finally
                    {
                        this.ActionTunnel = null;
                    }

                    #endregion
                }

                #region 释放非托管资源

                //

                #endregion

                //已释放
                this.disposed = true;
            }
        }

        #endregion

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="action">动作</param>
        public void Add(RecordableAction action)
        {
            this.ActionTunnel.Add(action);
            while (this.ActionTunnel.Count > ActionTunnelCapacity)
            {
                this.ActionTunnel.RemoveAt(0);
            }

            #region 揣测行为

            #region 复制

            int copyActionCount = 3;
            if (this.ActionTunnel.Count >= copyActionCount)
            {
                RecordableAction[] actions = new RecordableAction[copyActionCount];
                for (int i = 0; i < copyActionCount; i++)
                {
                    actions[i] = this.ActionTunnel[this.ActionTunnel.Count - copyActionCount + i];
                }

                if (
                    //Control↓ C↓ Control↑
                    (actions[0].EventType == RecordableActionEventType.D && (actions[0].Key == Keys.LControlKey || actions[0].Key == Keys.RControlKey)
                    && actions[1].EventType == RecordableActionEventType.D && actions[1].Key == Keys.C
                    && actions[2].EventType == RecordableActionEventType.U && (actions[2].Key == Keys.LControlKey || actions[2].Key == Keys.RControlKey))
                    ||
                    //Control↓ C↓ C↑
                    (actions[0].EventType == RecordableActionEventType.D && (actions[0].Key == Keys.LControlKey || actions[0].Key == Keys.RControlKey)
                    && actions[1].EventType == RecordableActionEventType.D && actions[1].Key == Keys.C
                    && actions[2].EventType == RecordableActionEventType.U && actions[2].Key == Keys.C)
                    ||
                    //RButton↑ LButton↓ LButton↑
                    (actions[0].EventType == RecordableActionEventType.U && actions[0].Key == Keys.RButton
                    && actions[1].EventType == RecordableActionEventType.D && actions[1].Key == Keys.LButton
                    && actions[2].EventType == RecordableActionEventType.U && actions[2].Key == Keys.LButton)
                    ||
                    //RButton↑ C↓ C↑
                    (actions[0].EventType == RecordableActionEventType.U && actions[0].Key == Keys.RButton
                    && actions[1].EventType == RecordableActionEventType.D && actions[1].Key == Keys.C
                    && actions[2].EventType == RecordableActionEventType.U && actions[2].Key == Keys.C)
                    )
                {
                    this.OnBehaving(this, new BehavingEventArgs(BehaviorType.Copy));
                }
            }

            #endregion

            #endregion
        }
    }
}
