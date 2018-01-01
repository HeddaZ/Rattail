using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Plusii.Windows.API;

namespace Plusii.Windows
{
    /// <summary>
    /// 钩子服务类
    /// </summary>
    public class Hook : IDisposable
    {
        #region 属性

        /// <summary>
        /// 钩子类型
        /// </summary>
        public int WindowsHook
        {
            get;
            private set;
        }
        /// <summary>
        /// 内部钩子
        /// </summary>
        private IntPtr BaseHook
        {
            get;
            set;
        }
        /// <summary>
        /// 钩子程序句柄
        /// </summary>
        private GCHandle HookProcHandle
        {
            get;
            set;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 钩住事件
        /// </summary>
        public event HookingEventHandler Hooking;
        /// <summary>
        /// 触发钩住事件
        /// </summary>
        /// <param name="nCode">钩子代码</param>
        /// <param name="wParam">消息参数</param>
        /// <param name="lParam">消息参数</param>
        /// <param name="defaultResult"></param>
        /// <returns></returns>
        private IntPtr OnHooking(int nCode, IntPtr wParam, IntPtr lParam, IntPtr defaultResult)
        {
            if (this.Hooking != null)
            {
                return this.Hooking(nCode, wParam, lParam, defaultResult);
            }
            else
            {
                return defaultResult;
            }
        }

        #endregion

        /// <summary>
        /// 创建钩子服务对象
        /// </summary>
        /// <param name="windowsHook">钩子类型</param>
        public Hook(int windowsHook)
        {
            this.WindowsHook = windowsHook;
            this.BaseHook = IntPtr.Zero;
            this.HookProcHandle = GCHandle.Alloc(new HOOKPROC(this.HookProcProcess)); //使用GCHandle保护内存中的钩子程序
        }

        /// <summary>
        /// 销毁
        /// </summary>
        ~Hook()
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
                        this.Stop();
                    }
                    catch
                    {
                    }
                    finally
                    {
                    }
                    try
                    {
                        this.HookProcHandle.Free();
                    }
                    catch
                    {
                    }
                    finally
                    {
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

        #region 操作

        /// <summary>
        /// 启动
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            if (this.BaseHook == IntPtr.Zero)
            {
                HOOKPROC hookProc = (HOOKPROC)this.HookProcHandle.Target;
                //安装钩子
                this.BaseHook = User32.SetWindowsHookEx(
                    this.WindowsHook,
                    hookProc,
                    Marshal.GetHINSTANCE(hookProc.Method.Module),
                    0
                    );
            }
            return (this.BaseHook != IntPtr.Zero);
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            if (this.BaseHook != IntPtr.Zero)
            {
                //卸载钩子
                if (User32.UnhookWindowsHookEx(this.BaseHook))
                {
                    this.BaseHook = IntPtr.Zero;
                }
            }
            return (this.BaseHook == IntPtr.Zero);
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 钩子程序处理
        /// </summary>
        /// <param name="nCode">钩子代码</param>
        /// <param name="wParam">消息参数</param>
        /// <param name="lParam">消息参数</param>
        /// <returns></returns>
        private IntPtr HookProcProcess(int nCode, IntPtr wParam, IntPtr lParam)
        {
            //不影响钩子链处理消息的返回值
            IntPtr defaultResult = User32.CallNextHookEx(this.BaseHook, nCode, wParam, lParam);

            if (nCode < 0)
            {
                return defaultResult;
            }
            else
            {
                return this.OnHooking(nCode, wParam, lParam, defaultResult);
            }
        }

        #endregion
    }
}
