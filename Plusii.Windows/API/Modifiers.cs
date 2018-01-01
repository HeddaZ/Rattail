using System;
using System.Collections.Generic;
using System.Text;

namespace Plusii.Windows.API
{
    /// <summary>
    /// 组合键
    /// </summary>
    public enum Modifiers : uint
    {
        MOD_NONE    =User32.MOD_NONE    ,
        MOD_ALT     =User32.MOD_ALT     ,
        MOD_CONTROL =User32.MOD_CONTROL ,
        MOD_SHIFT   =User32.MOD_SHIFT   ,
        MOD_WIN     =User32.MOD_WIN
    }
}
