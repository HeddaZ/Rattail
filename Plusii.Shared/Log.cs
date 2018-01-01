using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Plusii.Shared
{
    /// <summary>
    /// 日志服务类
    /// </summary>
    public class Log
    {
        #region 属性

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get;
            private set;
        }

        /// <summary>
        /// 编码
        /// </summary>
        public Encoding Encoding
        {
            get;
            private set;
        }

        #endregion

        /// <summary>
        /// 创建日志服务类对象
        /// </summary>
        /// <param name="path"></param>
        /// <param name="catalog"></param>
        /// <param name="encoding"></param>
        /// <param name="headers"></param>
        public Log(string path, string catalog, Encoding encoding, params object[] headers)
        {
            DateTime today = DateTime.Today;
            string filePath = string.Format("{0}{1}\\{2}\\",
                path,
                today.ToString("yyyyMM"),
                catalog
                );
            //文件名
            this.FileName = string.Format("{0}{1}.csv",
                filePath,
                today.ToString("yyyyMMdd")
                );
            //编码
            this.Encoding = encoding;

            #region 初始化

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            if (!File.Exists(this.FileName))
            {
                using (StreamWriter writer = new StreamWriter(this.FileName, false, this.Encoding))
                {
                    writer.WriteLine(this.GetLine(headers));
                }
            }

            #endregion
        }

        /// <summary>
        /// 创建日志服务类对象
        /// </summary>
        /// <param name="path"></param>
        /// <param name="catalog"></param>
        /// <param name="headers"></param>
        public Log(string path, string catalog, params object[] headers)
            : this(path, catalog, Encoding.Default, headers)
        {
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="contents"></param>
        public void Write(params object[] contents)
        {
            using (StreamWriter writer = new StreamWriter(this.FileName, true, this.Encoding))
            {
                writer.WriteLine(this.GetLine(contents));
            }
        }

        #region 内部方法

        /// <summary>
        /// 获取行
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        private string GetLine(object[] contents)
        {
            StringBuilder result = new StringBuilder();
            foreach (string content in contents)
            {
                result.AppendFormat("\"{0}\",", //csv文件行："abc","def","12\n34","hij""klmn"
                    content.Replace("\"", "\"\"")
                    );
            }
            return result.ToString().Trim(',');
        }

        #endregion
    }
}
