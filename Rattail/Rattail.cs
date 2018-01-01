using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Plusii.Shared.Pattern;
using Plusii.Windows;
using Plusii.Windows.API;
using Rattail.Biz;

namespace Rattail
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class Rattail : Form
    {
        #region 常量

        private const string StartRecordHotKeyName = "StartRecord";
        private const string StopRecordHotKeyName = "StopRecord";
        private const string ExitHotKeyName = "Exit";

        #endregion

        #region 属性

        /// <summary>
        /// 已完成视觉初始化
        /// </summary>
        private bool VisualInitialized
        {
            get;
            set;
        }

        /// <summary>
        /// 热键
        /// </summary>
        private HotKeyManager HotKeys
        {
            get;
            set;
        }

        /// <summary>
        /// 键盘钩子
        /// </summary>
        private Hook KeyboardHook
        {
            get;
            set;
        }
        /// <summary>
        /// 鼠标钩子
        /// </summary>
        private Hook MouseHook
        {
            get;
            set;
        }
        /// <summary>
        /// 记录器
        /// </summary>
        private QueueProcessor Recorder
        {
            get;
            set;
        }
        /// <summary>
        /// 最后一次动作
        /// </summary>
        private RecordableAction LastAction
        {
            get;
            set;
        }
        /// <summary>
        /// 揣测器
        /// </summary>
        private BehaviorSurmiser Surmiser
        {
            get;
            set;
        }
        /// <summary>
        /// 获取剪贴板文本
        /// </summary>
        private GetClipboardTextEventHandler GetClipboardText
        {
            get;
            set;
        }

        #endregion

        public Rattail()
        {
            InitializeComponent();
        }
        private void Rattail_Load(object sender, EventArgs e)
        {
            this.VisualInitialized = false;
            //初始化
            this.Initialize();
        }
        private void Rattail_Shown(object sender, EventArgs e)
        {
            //窗体须显示一次，才完成视觉初始化
            if (!this.VisualInitialized)
            {
                this.Hide();
                this.VisualInitialized = true;
            }
        }

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            this.Size = RtGlobal.IndicatorSize; //运行后，才可设置为超小尺寸
            this.Text = RtGlobal.Title;

            //本地包装，便于跨线程调用
            this.GetClipboardText = new GetClipboardTextEventHandler(Clipboard.GetText);

            #region 揣测器

            this.Surmiser = new BehaviorSurmiser();
            this.Surmiser.Behaving += new BehavingEventHandler(Surmiser_Behaving);

            this.LastAction = RecordableAction.Empty;

            #endregion

            #region 记录器

            this.Recorder = new QueueProcessor(RtGlobal.RecorderDelay, RtGlobal.RecorderRetry);
            this.Recorder.Error += new Plusii.Shared.ErrorEventHandler(Recorder_Error);

            #endregion

            #region 钩子

            this.KeyboardHook = new Hook(User32.WH_KEYBOARD_LL);
            this.KeyboardHook.Hooking += new HookingEventHandler(KeyboardHook_Hooking);
            this.MouseHook = new Hook(User32.WH_MOUSE_LL);
            this.MouseHook.Hooking += new HookingEventHandler(MouseHook_Hooking);

            #endregion

            #region 热键

            this.HotKeys = new HotKeyManager(this.Handle);
            this.HotKeys.HotKey += new HotKeyEventHandler(HotKeys_HotKey);
            //启动记录
            this.HotKeys.Register(
                StartRecordHotKeyName,
                RtGlobal.StartRecordHotKeyModifier,
                RtGlobal.StartRecordHotKeyKey
                );
            //停止记录
            this.HotKeys.Register(
                StopRecordHotKeyName,
                RtGlobal.StopRecordHotKeyModifier,
                RtGlobal.StopRecordHotKeyKey
                );
            //退出
            this.HotKeys.Register(
                ExitHotKeyName,
                RtGlobal.ExitHotKeyModifier,
                RtGlobal.ExitHotKeyKey
                );

            #endregion
        }

        #endregion

        #region 退出

        private void Rattail_FormClosing(object sender, FormClosingEventArgs e)
        {
            //钩子
            if (this.KeyboardHook != null)
            {
                try
                {
                    this.KeyboardHook.Dispose();
                }
                catch
                {
                }
                finally
                {
                    this.KeyboardHook = null;
                }
            }
            if (this.MouseHook != null)
            {
                try
                {
                    this.MouseHook.Dispose();
                }
                catch
                {
                }
                finally
                {
                    this.MouseHook = null;
                }
            }

            //揣测器
            if (this.Surmiser != null)
            {
                try
                {
                    this.Surmiser.Dispose();
                }
                catch
                {
                }
                finally
                {
                    this.Surmiser = null;
                }
            }
            this.LastAction = null;

            //记录器
            if (this.Recorder != null)
            {
                try
                {
                    this.Recorder.Dispose();
                }
                catch
                {
                }
                finally
                {
                    this.Recorder = null;
                }
            }

            //热键
            if (this.HotKeys != null)
            {
                try
                {
                    this.HotKeys.Dispose();
                }
                catch
                {
                }
                finally
                {
                    this.HotKeys = null;
                }
            }

            this.GetClipboardText = null;
        }

        #endregion

        #region 事件响应

        /// <summary>
        /// 热键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HotKeys_HotKey(object sender, HotKeyEventArgs e)
        {
            switch (e.Name)
            {
                case StartRecordHotKeyName:
                    this.Visible = true;
                    break;

                case StopRecordHotKeyName:
                    this.Visible = false;
                    break;

                case ExitHotKeyName:
                    if (MessageBox.Show(this, "确定要退出吗？", "Microsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else
                    {
                        return; //取消
                    }
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// 键盘钩子
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="defaultResult"></param>
        /// <returns></returns>
        IntPtr KeyboardHook_Hooking(int nCode, IntPtr wParam, IntPtr lParam, IntPtr defaultResult)
        {
            try
            {
                uint message = (uint)wParam;
                if (message == User32.WM_KEYDOWN || message == User32.WM_SYSKEYDOWN || message == User32.WM_KEYUP || message == User32.WM_SYSKEYUP)
                {
                    KBDLLHOOKSTRUCT hookInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                    RecordableActionEventType eventType;
                    if (message == User32.WM_KEYDOWN || message == User32.WM_SYSKEYDOWN)
                    {
                        eventType = RecordableActionEventType.D;
                    }
                    else
                    {
                        eventType = RecordableActionEventType.U;
                    }
                    RecordableAction action = new RecordableAction(eventType, (Keys)hookInfo.vkCode, hookInfo.time);
                    this.AddForRecord(action);
                }
            }
            catch (Exception error)
            {
                RecordableAction action = new RecordableAction(RecordableActionEventType.X, "KeyboardHook_Hooking:" + error.Message);
                this.AddForRecord(action);
            }

            return defaultResult;
        }
        /// <summary>
        /// 鼠标钩子
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="defaultResult"></param>
        /// <returns></returns>
        IntPtr MouseHook_Hooking(int nCode, IntPtr wParam, IntPtr lParam, IntPtr defaultResult)
        {
            try
            {
                uint message = (uint)wParam;
                if (message == User32.WM_LBUTTONDOWN || message == User32.WM_LBUTTONUP || message == User32.WM_RBUTTONDOWN || message == User32.WM_RBUTTONUP)
                {
                    MSLLHOOKSTRUCT hookInfo = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    RecordableAction action;
                    if (message == User32.WM_LBUTTONDOWN)
                    {
                        action = new RecordableAction(RecordableActionEventType.D, Keys.LButton, hookInfo.pt, hookInfo.time);
                    }
                    else if (message == User32.WM_LBUTTONUP)
                    {
                        action = new RecordableAction(RecordableActionEventType.U, Keys.LButton, hookInfo.pt, hookInfo.time);
                    }
                    else if (message == User32.WM_RBUTTONDOWN)
                    {
                        action = new RecordableAction(RecordableActionEventType.D, Keys.RButton, hookInfo.pt, hookInfo.time);
                    }
                    else
                    {
                        action = new RecordableAction(RecordableActionEventType.U, Keys.RButton, hookInfo.pt, hookInfo.time);
                    }
                    this.AddForRecord(action);
                }
            }
            catch (Exception error)
            {
                RecordableAction action = new RecordableAction(RecordableActionEventType.X, "MouseHook_Hooking:" + error.Message);
                this.AddForRecord(action);
            }

            return defaultResult;
        }
        /// <summary>
        /// 记录器异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Recorder_Error(object sender, Plusii.Shared.ErrorEventArgs e)
        {
            try
            {
                Plusii.Shared.Log log = new Plusii.Shared.Log(RtGlobal.LogPath, "RecorderError", "时间", "错误信息", "原始参数");
                log.Write(
                    DateTime.Now,
                    e.Exception.Message,
                    ((QueueProcessPackage)sender).EventArgs
                    );
            }
            catch { }
        }
        /// <summary>
        /// 记录处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecordProcess(object sender, QueueProcessEventArgs e)
        {
            RecordableAction action = (RecordableAction)e.Argument;
            try
            {
                //入揣测器
                this.Surmiser.Add(action);
                //非同一动作
                if (!RecordableAction.IsOneActionOfKey(this.LastAction, action))
                {
                    this.WriteRecord(action);
                }
            }
            finally
            {
                //更新最后一次动作
                this.LastAction = action;
            }
        }
        /// <summary>
        /// 行为发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Surmiser_Behaving(object sender, BehavingEventArgs e)
        {
            switch (e.Behavior)
            {
                case BehaviorType.Copy:
                    RecordableAction action = new RecordableAction(RecordableActionEventType.C, (string)this.Invoke(this.GetClipboardText));
                    this.AddForRecord(action);
                    break;
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 开关标志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rattail_VisibleChanged(object sender, EventArgs e)
        {
            if (this.VisualInitialized)
            {
                if (this.Visible)
                {
                    //启动记录
                    this.KeyboardHook.Start();
                    this.MouseHook.Start();
                    RecordableAction action = new RecordableAction(RecordableActionEventType.B, "\r\n★ " + DateTime.Now.ToString() + " ------------------------------\r\n");
                    this.AddForRecord(action);
                }
                else
                {
                    //停止记录
                    this.KeyboardHook.Stop();
                    this.MouseHook.Stop();
                    RecordableAction action = new RecordableAction(RecordableActionEventType.E, "\r\n☆ " + DateTime.Now.ToString() + " ------------------------------\r\n\r\n");
                    this.AddForRecord(action);
                }
            }
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 添加到记录处理
        /// </summary>
        /// <param name="action"></param>
        private void AddForRecord(RecordableAction action)
        {
            this.Recorder.Add(this.RecordProcess, action);
        }
        /// <summary>
        /// 写记录
        /// </summary>
        /// <param name="action"></param>
        private void WriteRecord(RecordableAction action)
        {
            DateTime today = DateTime.Today;
            //路径
            string filePath = string.Format("{0}{1}\\",
                RtGlobal.RecordPath,
                today.ToString("yyyyMM")
                );
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            //文件
            string fileName = string.Format("{0}{1}.txt",
                filePath,
                today.ToString("yyyyMMdd")
                );
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.Write(action.ToString());
            }
        }

        #endregion
    }
}
