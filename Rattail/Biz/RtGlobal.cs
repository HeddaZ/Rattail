using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;
using Plusii.Windows;
using Plusii.Windows.API;

namespace Rattail.Biz
{
    /// <summary>
    /// Rattail全局服务类
    /// </summary>
    public class RtGlobal : Global
    {
        #region 常量

        /// <summary>
        /// 标题
        /// </summary>
        public const string Title = "Rattail 老鼠尾巴";

        #endregion

        #region 属性

        /// <summary>
        /// 指示器尺寸
        /// </summary>
        public static Size IndicatorSize
        {
            get
            {
                string[] sizes = ConfigurationManager.AppSettings["IndicatorSize"].Split(',');
                return new Size(int.Parse(sizes[0]), int.Parse(sizes[1]));
            }
        }

        /// <summary>
        /// 记录器延时
        /// </summary>
        public static int RecorderDelay
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["RecorderDelay"]);
            }
        }
        /// <summary>
        /// 记录器重试次数
        /// </summary>
        public static int RecorderRetry
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["RecorderRetry"]);
            }
        }

        /// <summary>
        /// 日志路径
        /// </summary>
        public static string LogPath
        {
            get
            {
                return RtGlobal.ApplicationWorkingDirectoryPath + "Log\\";
            }
        }
        /// <summary>
        /// 记录路径
        /// </summary>
        public static string RecordPath
        {
            get
            {
                return RtGlobal.ApplicationWorkingDirectoryPath + "Record\\";
            }
        }

        #region 动作格式

        /// <summary>
        /// 键盘按下动作字符串格式
        /// </summary>
        public static string KeyboardDownActionStringFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["KeyboardDownActionStringFormat"];
            }
        }
        /// <summary>
        /// 键盘弹起动作字符串格式
        /// </summary>
        public static string KeyboardUpActionStringFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["KeyboardUpActionStringFormat"];
            }
        }
        /// <summary>
        /// 鼠标按下动作字符串格式
        /// </summary>
        public static string MouseDownActionStringFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["MouseDownActionStringFormat"];
            }
        }
        /// <summary>
        /// 鼠标弹起动作字符串格式
        /// </summary>
        public static string MouseUpActionStringFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["MouseUpActionStringFormat"];
            }
        }
        /// <summary>
        /// 消息动作字符串格式
        /// </summary>
        public static string MessageActionStringFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["MessageActionStringFormat"];
            }
        } 

        #endregion
        
        #region 热键

        /// <summary>
        /// 启动记录热键组合键
        /// </summary>
        public static Modifiers StartRecordHotKeyModifier
        {
            get
            {
                return RtGlobal.StringToEnum<Modifiers>(ConfigurationManager.AppSettings["StartRecordHotKeyModifier"]);
            }
        }
        /// <summary>
        /// 启动记录热键键
        /// </summary>
        public static Keys StartRecordHotKeyKey
        {
            get
            {
                return RtGlobal.StringToEnum<Keys>(ConfigurationManager.AppSettings["StartRecordHotKeyKey"]);
            }
        }
        /// <summary>
        /// 停止记录热键组合键
        /// </summary>
        public static Modifiers StopRecordHotKeyModifier
        {
            get
            {
                return RtGlobal.StringToEnum<Modifiers>(ConfigurationManager.AppSettings["StopRecordHotKeyModifier"]);
            }
        }
        /// <summary>
        /// 停止记录热键键
        /// </summary>
        public static Keys StopRecordHotKeyKey
        {
            get
            {
                return RtGlobal.StringToEnum<Keys>(ConfigurationManager.AppSettings["StopRecordHotKeyKey"]);
            }
        }
        /// <summary>
        /// 退出热键组合键
        /// </summary>
        public static Modifiers ExitHotKeyModifier
        {
            get
            {
                return RtGlobal.StringToEnum<Modifiers>(ConfigurationManager.AppSettings["ExitHotKeyModifier"]);
            }
        }
        /// <summary>
        /// 退出热键键
        /// </summary>
        public static Keys ExitHotKeyKey
        {
            get
            {
                return RtGlobal.StringToEnum<Keys>(ConfigurationManager.AppSettings["ExitHotKeyKey"]);
            }
        }

        #endregion

        #endregion
    }
}
