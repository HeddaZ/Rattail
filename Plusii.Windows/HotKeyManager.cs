using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Plusii.Windows.API;

namespace Plusii.Windows
{
    /// <summary>
    /// 热键管理器
    /// </summary>
    public class HotKeyManager : IMessageFilter, IDisposable
    {
        #region 属性

        /// <summary>
        /// 窗体句柄
        /// </summary>
        private IntPtr Handle
        {
            get;
            set;
        }
        /// <summary>
        /// 热键登记表
        /// </summary>
        private Dictionary<ushort, string> HotKeys
        {
            get;
            set;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 热键事件
        /// </summary>
        public event HotKeyEventHandler HotKey;
        /// <summary>
        /// 触发热键事件
        /// </summary>
        /// <param name="sender">源</param>
        /// <param name="e">参数</param>
        protected virtual void OnHotKey(object sender, HotKeyEventArgs e)
        {
            if (this.HotKey != null)
            {
                this.HotKey(sender, e);
            }
        }

        #endregion

        #region IMessageFilter Members

        /// <summary>
        /// 预过滤消息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool PreFilterMessage(ref Message m)
        {
            if ((uint)m.Msg == User32.WM_HOTKEY)
            {
                ushort id = (ushort)m.WParam; //热键ID
                if (this.HotKeys.ContainsKey(id))
                {
                    //触发热键事件
                    this.OnHotKey(this, new HotKeyEventArgs(this.HotKeys[id]));
                    return true;
                }
            }
            return false;
        }

        #endregion

        /// <summary>
        /// 创建热键管理器对象
        /// </summary>
        /// <param name="handle">窗体句柄</param>
        public HotKeyManager(IntPtr handle)
        {
            this.Handle = handle;
            this.HotKeys = new Dictionary<ushort, string>();

            //将自身添加为本应用程序消息过滤器
            Application.AddMessageFilter(this);
        }

        /// <summary>
        /// 销毁
        /// </summary>
        ~HotKeyManager()
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
                        this.Clear();
                    }
                    catch
                    {
                    }
                    finally
                    {
                        this.HotKeys = null;
                    }
                    try
                    {
                        Application.RemoveMessageFilter(this);
                    }
                    catch
                    {
                    }
                    if (this.Handle != IntPtr.Zero)
                    {
                        this.Handle = IntPtr.Zero;
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
        /// 注册
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="modifier">组合键</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool Register(string name, Modifiers modifier, Keys key)
        {
            ushort id;

            //名称标识
            string uniqueName = this.GetUniqueName(name);
            bool globalAtomExist = GlobalAtom.TryFind(uniqueName, out id);
            if (!globalAtomExist)
            {
                //添加全局原子
                id = GlobalAtom.Add(uniqueName);
            }

            //注册热键
            uint modifierValue = (uint)modifier;
            uint keyValue = (uint)key;
            if (User32.RegisterHotKey(this.Handle, id, modifierValue, keyValue))
            {
                //保存到热键登记表
                this.HotKeys.Add(id, name);
                return true;
            }
            else
            {
                if (!globalAtomExist)
                {
                    //删除已存在的全局原子
                    GlobalAtom.Delete(id);
                }
                return false;
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool Register(string name, Keys key)
        {
            return this.Register(name, Modifiers.MOD_NONE, key);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public bool Unregister(string name)
        {
            ushort id;

            //名称标识
            string uniqueName = this.GetUniqueName(name);
            if (GlobalAtom.TryFind(uniqueName, out id))
            {
                //注销热键
                if (User32.UnregisterHotKey(this.Handle, id))
                {
                    //从热键登记表中删除
                    this.HotKeys.Remove(id);
                    //删除对应的全局原子
                    GlobalAtom.Delete(id);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            foreach (ushort id in this.HotKeys.Keys)
            {
                //注销热键
                User32.UnregisterHotKey(this.Handle, id);
                //删除对应的全局原子
                GlobalAtom.Delete(id);
            }
            //清空热键表
            this.HotKeys.Clear();
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetUniqueName(string name)
        {
            return string.Format("{{{0}}}{1}",
                this.Handle,
                name
                );
        }

        #endregion
    }
}
