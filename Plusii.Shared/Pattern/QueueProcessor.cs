using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Plusii.Shared.Pattern
{
    /// <summary>
    /// 队列处理机
    /// </summary>
    public class QueueProcessor : ThreadingWork
    {
        #region 属性

        /// <summary>
        /// 内部队列
        /// </summary>
        private Queue<QueueProcessPackage> BaseQueue
        {
            get;
            set;
        }
        /// <summary>
        /// 处理延时（毫秒）
        /// </summary>
        private int Delay
        {
            get;
            set;
        }
        /// <summary>
        /// 重试次数
        /// </summary>
        private int Retry
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// 创建队列处理机对象
        /// </summary>
        /// <param name="delay">处理延时（毫秒）</param>
        /// <param name="retry">重试次数</param>
        public QueueProcessor(int delay, int retry)
            : base()
        {
            //初始化队列
            this.BaseQueue = new Queue<QueueProcessPackage>();

            //属性
            this.Delay = delay;
            this.Retry = retry;

            //工作线程
            this.ThreadWorking = true;
            this.WorkingThread = new Thread(new ThreadStart(this.WorkingThreadProcess));
            this.WorkingThread.IsBackground = true;
            this.WorkingThread.Start();
        }

        /// <summary>
        /// 销毁
        /// </summary>
        ~QueueProcessor()
        {
            this.Dispose(false);
        }

        #region Override IDisposable Members

        /// <summary>
        /// 是否资源已释放
        /// </summary>
        private bool disposed = false;
        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">是否释放托管资源</param>
        protected override void Dispose(bool disposing)
        {
            //是否已释放
            if (!this.disposed)
            {
                if (disposing)
                {
                    #region 释放托管资源

                    if (this.ThreadWorking)
                    {
                        this.ThreadWorking = false;
                    }
                    if (this.WorkingThread != null)
                    {
                        try
                        {
                            this.WorkingThread.Abort();
                        }
                        catch
                        {
                        }
                        finally
                        {
                            this.WorkingThread = null;
                        }
                    }
                    if (this.BaseQueue != null)
                    {
                        try
                        {
                            this.BaseQueue.Clear();
                        }
                        catch
                        {
                        }
                        finally
                        {
                            this.BaseQueue = null;
                        }
                    }

                    #endregion
                }

                #region 释放非托管资源

                //

                #endregion

                //已释放
                this.disposed = true;
            }

            //释放基类资源
            base.Dispose(disposing);
        }

        #endregion

        #region 处理

        /// <summary>
        /// 工作线程处理
        /// </summary>
        private void WorkingThreadProcess()
        {
            while (this.ThreadWorking)
            {
                //有待处理项
                if (this.BaseQueue.Count > 0)
                {
                    //队列处理包出队
                    QueueProcessPackage queueProcessPackage = this.BaseQueue.Dequeue();

                    #region 支持重试的处理

                    int tryCount = 0;
                    while (this.ThreadWorking)
                    {
                        tryCount++; //本次尝试
                        try
                        {
                            queueProcessPackage.EventHandler(this, queueProcessPackage.EventArgs);

                            //成功
                            break;
                        }
                        catch (Exception error)
                        {
                            //允许重试
                            if (tryCount < this.Retry + 1)
                            {
                                Thread.Sleep(this.Delay);
                            }
                            else
                            {
                                //报告异常（由队列处理包产生的异常）
                                this.OnError(queueProcessPackage, new ErrorEventArgs(error));
                                break;
                            }
                        }
                    }

                    #endregion
                }

                //延时
                Thread.Sleep(this.Delay);
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 添加队列处理事务
        /// </summary>
        /// <param name="package">包</param>
        public void Add(QueueProcessPackage package)
        {
            this.BaseQueue.Enqueue(package);
        }

        /// <summary>
        /// 添加队列处理事务
        /// </summary>
        /// <param name="eventHandler">事件委托</param>
        /// <param name="argument">参数</param>
        public void Add(QueueProcessEventHandler eventHandler, object argument)
        {
            this.Add(new QueueProcessPackage(eventHandler, new QueueProcessEventArgs(argument)));
        }

        #endregion
    }
}
