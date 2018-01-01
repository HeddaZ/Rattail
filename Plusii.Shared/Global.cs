using System;
using System.Collections.Generic;
using System.Text;

namespace Plusii.Shared
{
    /// <summary>
    /// 全局服务类
    /// </summary>
    public class Global
    {
        #region 常量

        /// <summary>
        /// 默认缓冲区尺寸
        /// </summary>
        public const int DefaultBufferSize = 1024;
        /// <summary>
        /// 默认分隔符
        /// </summary>
        public const char DefaultSeparator = '|';
        /// <summary>
        /// 默认间隔时间（毫秒）
        /// </summary>
        public const int DefaultInterval = 1000;
        /// <summary>
        /// 默认日期格式
        /// </summary>
        public const string DefaultDateFormat = "yyyy-MM-dd";
        /// <summary>
        /// 默认时间格式
        /// </summary>
        public const string DefaultTimeFormat = "HH:mm:ss";

        #endregion

        #region 方法

        /// <summary>
        /// 枚举转换为字符串
        /// </summary>
        /// <param name="enumObject"></param>
        /// <returns></returns>
        public static string EnumToString(object enumObject)
        {
            return enumObject.ToString();
        }

        /// <summary>
        /// 字符串转换为枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="enumString"></param>
        /// <returns></returns>
        public static T StringToEnum<T>(string enumString)
        {
            return (T)Enum.Parse(typeof(T), enumString, true); //忽略大小写
        }

        /// <summary>
        /// 生成时间ID（例如：20081122112233000999）
        /// </summary>
        /// <returns></returns>
        public static string GenerateTimeID()
        {
            return string.Format("{0}{1}",
                DateTime.Now.ToString("yyyyMMddHHmmssfff"), //时间17位
                (new Random()).Next(999).ToString().PadLeft(3, '0')  //随机数3位
                );
        }

        #endregion
    }
}
