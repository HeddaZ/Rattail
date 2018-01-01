using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Plusii.Shared
{
    /// <summary>
    /// 基于线程的工作类
    /// </summary>
    public class ThreadingWork : IDisposable
    {
        #region 属性

        /// <summary>
        /// 工作线程
        /// </summary>
        protected Thread WorkingThread
        {
            get;
            set;
        }
        /// <summary>
        /// 线程工作标志（便于线程资源释放）
        /// </summary>
        protected bool ThreadWorking
        {
            get;
            set;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 异常事件
        /// </summary>
        public event ErrorEventHandler Error;
        /// <summary>
        /// 触发异常事件
        /// </summary>
        /// <param name="sender">源</param>
        /// <param name="e">参数</param>
        protected virtual void OnError(object sender, ErrorEventArgs e)
        {
            if (this.Error != null)
            {
                this.Error(sender, e);
            }
        }

        #endregion

        /// <summary>
        /// 创建基于线程的工作对象
        /// </summary>
        protected ThreadingWork()
        {
        }

        /// <summary>
        /// 销毁
        /// </summary>
        ~ThreadingWork()
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

                    //

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
    }
}
