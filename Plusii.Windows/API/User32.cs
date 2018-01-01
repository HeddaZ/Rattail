﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Plusii.Windows.API
{
    /// <summary>
    /// User32.dll
    /// </summary>
    public static class User32
    {
        /// <summary>
        /// Dll文件名
        /// </summary>
        public const string DllName = "user32.dll";

        #region WindowMessages 窗体消息

        public const uint WM_NULL                         =0x0000;
        public const uint WM_CREATE                       =0x0001;
        public const uint WM_DESTROY                      =0x0002;
        public const uint WM_MOVE                         =0x0003;
        public const uint WM_SIZE                         =0x0005;
        public const uint WM_ACTIVATE                     =0x0006;
        public const uint WM_SETFOCUS                     =0x0007;
        public const uint WM_KILLFOCUS                    =0x0008;
        public const uint WM_ENABLE                       =0x000A;
        public const uint WM_SETREDRAW                    =0x000B;
        public const uint WM_SETTEXT                      =0x000C;
        public const uint WM_GETTEXT                      =0x000D;
        public const uint WM_GETTEXTLENGTH                =0x000E;
        public const uint WM_PAINT                        =0x000F;
        public const uint WM_CLOSE                        =0x0010;
        public const uint WM_QUERYENDSESSION              =0x0011;
        public const uint WM_QUIT                         =0x0012;
        public const uint WM_QUERYOPEN                    =0x0013;
        public const uint WM_ERASEBKGND                   =0x0014;
        public const uint WM_SYSCOLORCHANGE               =0x0015;
        public const uint WM_ENDSESSION                   =0x0016;
        public const uint WM_SHOWWINDOW                   =0x0018;
        public const uint WM_WININICHANGE                 =0x001A;
        public const uint WM_SETTINGCHANGE                =WM_WININICHANGE;
        public const uint WM_DEVMODECHANGE                =0x001B;
        public const uint WM_ACTIVATEAPP                  =0x001C;
        public const uint WM_FONTCHANGE                   =0x001D;
        public const uint WM_TIMECHANGE                   =0x001E;
        public const uint WM_CANCELMODE                   =0x001F;
        public const uint WM_SETCURSOR                    =0x0020;
        public const uint WM_MOUSEACTIVATE                =0x0021;
        public const uint WM_CHILDACTIVATE                =0x0022;
        public const uint WM_QUEUESYNC                    =0x0023;
        public const uint WM_GETMINMAXINFO                =0x0024;
        public const uint WM_PAINTICON                    =0x0026;
        public const uint WM_ICONERASEBKGND               =0x0027;
        public const uint WM_NEXTDLGCTL                   =0x0028;
        public const uint WM_SPOOLERSTATUS                =0x002A;
        public const uint WM_DRAWITEM                     =0x002B;
        public const uint WM_MEASUREITEM                  =0x002C;
        public const uint WM_DELETEITEM                   =0x002D;
        public const uint WM_VKEYTOITEM                   =0x002E;
        public const uint WM_CHARTOITEM                   =0x002F;
        public const uint WM_SETFONT                      =0x0030;
        public const uint WM_GETFONT                      =0x0031;
        public const uint WM_SETHOTKEY                    =0x0032;
        public const uint WM_GETHOTKEY                    =0x0033;
        public const uint WM_QUERYDRAGICON                =0x0037;
        public const uint WM_COMPAREITEM                  =0x0039;
        public const uint WM_GETOBJECT                    =0x003D;
        public const uint WM_COMPACTING                   =0x0041;
        public const uint WM_WINDOWPOSCHANGING            =0x0046;
        public const uint WM_WINDOWPOSCHANGED             =0x0047;
        public const uint WM_POWER                        =0x0048;
        public const uint WM_COPYDATA                     =0x004A;
        public const uint WM_CANCELJOURNAL                =0x004B;
        public const uint WM_NOTIFY                       =0x004E;
        public const uint WM_INPUTLANGCHANGEREQUEST       =0x0050;
        public const uint WM_INPUTLANGCHANGE              =0x0051;
        public const uint WM_TCARD                        =0x0052;
        public const uint WM_HELP                         =0x0053;
        public const uint WM_USERCHANGED                  =0x0054;
        public const uint WM_NOTIFYFORMAT                 =0x0055;
        public const uint WM_CONTEXTMENU                  =0x007B;
        public const uint WM_STYLECHANGING                =0x007C;
        public const uint WM_STYLECHANGED                 =0x007D;
        public const uint WM_DISPLAYCHANGE                =0x007E;
        public const uint WM_GETICON                      =0x007F;
        public const uint WM_SETICON                      =0x0080;
        public const uint WM_NCCREATE                     =0x0081;
        public const uint WM_NCDESTROY                    =0x0082;
        public const uint WM_NCCALCSIZE                   =0x0083;
        public const uint WM_NCHITTEST                    =0x0084;
        public const uint WM_NCPAINT                      =0x0085;
        public const uint WM_NCACTIVATE                   =0x0086;
        public const uint WM_GETDLGCODE                   =0x0087;
        public const uint WM_SYNCPAINT                    =0x0088;
        public const uint WM_NCMOUSEMOVE                  =0x00A0;
        public const uint WM_NCLBUTTONDOWN                =0x00A1;
        public const uint WM_NCLBUTTONUP                  =0x00A2;
        public const uint WM_NCLBUTTONDBLCLK              =0x00A3;
        public const uint WM_NCRBUTTONDOWN                =0x00A4;
        public const uint WM_NCRBUTTONUP                  =0x00A5;
        public const uint WM_NCRBUTTONDBLCLK              =0x00A6;
        public const uint WM_NCMBUTTONDOWN                =0x00A7;
        public const uint WM_NCMBUTTONUP                  =0x00A8;
        public const uint WM_NCMBUTTONDBLCLK              =0x00A9;
        public const uint WM_KEYFIRST                     =0x0100;
        public const uint WM_KEYDOWN                      =0x0100;
        public const uint WM_KEYUP                        =0x0101;
        public const uint WM_CHAR                         =0x0102;
        public const uint WM_DEADCHAR                     =0x0103;
        public const uint WM_SYSKEYDOWN                   =0x0104;
        public const uint WM_SYSKEYUP                     =0x0105;
        public const uint WM_SYSCHAR                      =0x0106;
        public const uint WM_SYSDEADCHAR                  =0x0107;
        public const uint WM_KEYLAST                      =0x0108;
        public const uint WM_IME_STARTCOMPOSITION         =0x010D;
        public const uint WM_IME_ENDCOMPOSITION           =0x010E;
        public const uint WM_IME_COMPOSITION              =0x010F;
        public const uint WM_IME_KEYLAST                  =0x010F;
        public const uint WM_INITDIALOG                   =0x0110;
        public const uint WM_COMMAND                      =0x0111;
        public const uint WM_SYSCOMMAND                   =0x0112;
        public const uint WM_TIMER                        =0x0113;
        public const uint WM_HSCROLL                      =0x0114;
        public const uint WM_VSCROLL                      =0x0115;
        public const uint WM_INITMENU                     =0x0116;
        public const uint WM_INITMENUPOPUP                =0x0117;
        public const uint WM_MENUSELECT                   =0x011F;
        public const uint WM_MENUCHAR                     =0x0120;
        public const uint WM_ENTERIDLE                    =0x0121;
        public const uint WM_MENURBUTTONUP                =0x0122;
        public const uint WM_MENUDRAG                     =0x0123;
        public const uint WM_MENUGETOBJECT                =0x0124;
        public const uint WM_UNINITMENUPOPUP              =0x0125;
        public const uint WM_MENUCOMMAND                  =0x0126;
        public const uint WM_CTLCOLORMSGBOX               =0x0132;
        public const uint WM_CTLCOLOREDIT                 =0x0133;
        public const uint WM_CTLCOLORLISTBOX              =0x0134;
        public const uint WM_CTLCOLORBTN                  =0x0135;
        public const uint WM_CTLCOLORDLG                  =0x0136;
        public const uint WM_CTLCOLORSCROLLBAR            =0x0137;
        public const uint WM_CTLCOLORSTATIC               =0x0138;
        public const uint WM_MOUSEFIRST                   =0x0200;
        public const uint WM_MOUSEMOVE                    =0x0200;
        public const uint WM_LBUTTONDOWN                  =0x0201;
        public const uint WM_LBUTTONUP                    =0x0202;
        public const uint WM_LBUTTONDBLCLK                =0x0203;
        public const uint WM_RBUTTONDOWN                  =0x0204;
        public const uint WM_RBUTTONUP                    =0x0205;
        public const uint WM_RBUTTONDBLCLK                =0x0206;
        public const uint WM_MBUTTONDOWN                  =0x0207;
        public const uint WM_MBUTTONUP                    =0x0208;
        public const uint WM_MBUTTONDBLCLK                =0x0209;
        public const uint WM_MOUSEWHEEL                   =0x020A;
        public const uint WM_MOUSELAST                    =0x020A;
        public const uint WHEEL_DELTA                     =120;
        public const uint WHEEL_PAGESCROLL                =uint.MaxValue;
        public const uint WM_PARENTNOTIFY                 =0x0210;
        public const uint WM_ENTERMENULOOP                =0x0211;
        public const uint WM_EXITMENULOOP                 =0x0212;
        public const uint WM_NEXTMENU                     =0x0213;
        public const uint WM_SIZING                       =0x0214;
        public const uint WM_CAPTURECHANGED               =0x0215;
        public const uint WM_MOVING                       =0x0216;
        public const uint WM_POWERBROADCAST               =0x0218;
        public const uint WM_DEVICECHANGE                 =0x0219;
        public const uint WM_MDICREATE                    =0x0220;
        public const uint WM_MDIDESTROY                   =0x0221;
        public const uint WM_MDIACTIVATE                  =0x0222;
        public const uint WM_MDIRESTORE                   =0x0223;
        public const uint WM_MDINEXT                      =0x0224;
        public const uint WM_MDIMAXIMIZE                  =0x0225;
        public const uint WM_MDITILE                      =0x0226;
        public const uint WM_MDICASCADE                   =0x0227;
        public const uint WM_MDIICONARRANGE               =0x0228;
        public const uint WM_MDIGETACTIVE                 =0x0229;
        public const uint WM_MDISETMENU                   =0x0230;
        public const uint WM_ENTERSIZEMOVE                =0x0231;
        public const uint WM_EXITSIZEMOVE                 =0x0232;
        public const uint WM_DROPFILES                    =0x0233;
        public const uint WM_MDIREFRESHMENU               =0x0234;
        public const uint WM_IME_SETCONTEXT               =0x0281;
        public const uint WM_IME_NOTIFY                   =0x0282;
        public const uint WM_IME_CONTROL                  =0x0283;
        public const uint WM_IME_COMPOSITIONFULL          =0x0284;
        public const uint WM_IME_SELECT                   =0x0285;
        public const uint WM_IME_CHAR                     =0x0286;
        public const uint WM_IME_REQUEST                  =0x0288;
        public const uint WM_IME_KEYDOWN                  =0x0290;
        public const uint WM_IME_KEYUP                    =0x0291;
        public const uint WM_MOUSEHOVER                   =0x02A1;
        public const uint WM_MOUSELEAVE                   =0x02A3;
        public const uint WM_CUT                          =0x0300;
        public const uint WM_COPY                         =0x0301;
        public const uint WM_PASTE                        =0x0302;
        public const uint WM_CLEAR                        =0x0303;
        public const uint WM_UNDO                         =0x0304;
        public const uint WM_RENDERFORMAT                 =0x0305;
        public const uint WM_RENDERALLFORMATS             =0x0306;
        public const uint WM_DESTROYCLIPBOARD             =0x0307;
        public const uint WM_DRAWCLIPBOARD                =0x0308;
        public const uint WM_PAINTCLIPBOARD               =0x0309;
        public const uint WM_VSCROLLCLIPBOARD             =0x030A;
        public const uint WM_SIZECLIPBOARD                =0x030B;
        public const uint WM_ASKCBFORMATNAME              =0x030C;
        public const uint WM_CHANGECBCHAIN                =0x030D;
        public const uint WM_HSCROLLCLIPBOARD             =0x030E;
        public const uint WM_QUERYNEWPALETTE              =0x030F;
        public const uint WM_PALETTEISCHANGING            =0x0310;
        public const uint WM_PALETTECHANGED               =0x0311;
        public const uint WM_HOTKEY                       =0x0312;
        public const uint WM_PRINT                        =0x0317;
        public const uint WM_PRINTCLIENT                  =0x0318;
        public const uint WM_HANDHELDFIRST                =0x0358;
        public const uint WM_HANDHELDLAST                 =0x035F;
        public const uint WM_AFXFIRST                     =0x0360;
        public const uint WM_AFXLAST                      =0x037F;
        public const uint WM_PENWINFIRST                  =0x0380;
        public const uint WM_PENWINLAST                   =0x038F;
        public const uint WM_APP                          =0x8000;
        public const uint WM_USER                         =0x0400;

        #endregion


        #region RegisterHotKey

        #region Modifiers 组合键

        public const uint MOD_NONE                  =0x0000;
        public const uint MOD_ALT                   =0x0001;
        public const uint MOD_CONTROL               =0x0002;
        public const uint MOD_SHIFT                 =0x0004;
        public const uint MOD_WIN                   =0x0008;
        public const uint MOD_LEFT                  =0x8000;
        public const uint MOD_RIGHT                 =0x4000;
        public const uint MOD_ON_KEYUP              =0x0800;
        public const uint MOD_IGNORE_ALL_MODIFIER   =0x0400;

        #endregion

        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="id">热键ID</param>
        /// <param name="fsModifiers">组合键</param>
        /// <param name="vk">键</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        /// <summary>
        /// 注销热键
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="id">热键ID</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        #endregion

        #region GetForegroundWindow

        /// <summary>
        /// 获取最前窗体
        /// </summary>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// 设定窗体最前并激活
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion

        #region IsWindow

        /// <summary>
        /// 窗体有效
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern bool IsWindow(IntPtr hWnd);

        /// <summary>
        /// 窗体可见
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        #endregion

        #region ShowWindow

        #region ShowWindowCommands 窗体显示命令

        public const int SW_HIDE             =0;
        public const int SW_SHOWNORMAL       =1;
        public const int SW_NORMAL           =1;
        public const int SW_SHOWMINIMIZED    =2;
        public const int SW_SHOWMAXIMIZED    =3;
        public const int SW_MAXIMIZE         =3;
        public const int SW_SHOWNOACTIVATE   =4;
        public const int SW_SHOW             =5;
        public const int SW_MINIMIZE         =6;
        public const int SW_SHOWMINNOACTIVE  =7;
        public const int SW_SHOWNA           =8;
        public const int SW_RESTORE          =9;
        public const int SW_SHOWDEFAULT      =10;
        public const int SW_FORCEMINIMIZE    =11;
        public const int SW_MAX              =11;

        #endregion

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="nCmdShow">命令</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        #endregion

        #region GetWindowLong

        #region GetWindowLongIndex 窗体信息索引

        public const int GWL_WNDPROC         =-4;
        public const int GWL_HINSTANCE       =-6;
        public const int GWL_HWNDPARENT      =-8;
        public const int GWL_STYLE           =-16;
        public const int GWL_EXSTYLE         =-20;
        public const int GWL_USERDATA        =-21;
        public const int GWL_ID              =-12;

        #endregion
        #region ExtendedWindowStyles 扩展窗体样式值

        public const int WS_EX_DLGMODALFRAME     =0x00000001;
        public const int WS_EX_NOPARENTNOTIFY    =0x00000004;
        public const int WS_EX_TOPMOST           =0x00000008;
        public const int WS_EX_ACCEPTFILES       =0x00000010;
        public const int WS_EX_TRANSPARENT       =0x00000020;
        public const int WS_EX_MDICHILD          =0x00000040;
        public const int WS_EX_TOOLWINDOW        =0x00000080;
        public const int WS_EX_WINDOWEDGE        =0x00000100;
        public const int WS_EX_CLIENTEDGE        =0x00000200;
        public const int WS_EX_CONTEXTHELP       =0x00000400;
        public const int WS_EX_RIGHT             =0x00001000;
        public const int WS_EX_LEFT              =0x00000000;
        public const int WS_EX_RTLREADING        =0x00002000;
        public const int WS_EX_LTRREADING        =0x00000000;
        public const int WS_EX_LEFTSCROLLBAR     =0x00004000;
        public const int WS_EX_RIGHTSCROLLBAR    =0x00000000;
        public const int WS_EX_CONTROLPARENT     =0x00010000;
        public const int WS_EX_STATICEDGE        =0x00020000;
        public const int WS_EX_APPWINDOW         =0x00040000;
        public const int WS_EX_OVERLAPPEDWINDOW  =WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE;
        public const int WS_EX_PALETTEWINDOW     =WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST;
        public const int WS_EX_LAYERED           =0x00080000;
        public const int WS_EX_NOINHERITLAYOUT   =0x00100000;
        public const int WS_EX_LAYOUTRTL         =0x00400000;
        public const int WS_EX_COMPOSITED        =0x02000000;
        public const int WS_EX_NOACTIVATE        =0x08000000;

        #endregion

        /// <summary>
        /// 获取窗体信息
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="nIndex">索引</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        /// <summary>
        /// 设定窗体信息
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="nIndex">索引</param>
        /// <param name="dwNewLong">值</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        #endregion

        #region SetWindowPos

        #region 虚拟窗体句柄

        public const int HWND_TOP        =0;
        public const int HWND_BOTTOM     =1;
        public const int HWND_TOPMOST    =-1;
        public const int HWND_NOTOPMOST  =-2;

	    #endregion
        #region SetWindowPosFlags 窗体位置标志

        public const uint SWP_NOSIZE          =0x0001;
        public const uint SWP_NOMOVE          =0x0002;
        public const uint SWP_NOZORDER        =0x0004;
        public const uint SWP_NOREDRAW        =0x0008;
        public const uint SWP_NOACTIVATE      =0x0010;
        public const uint SWP_FRAMECHANGED    =0x0020;
        public const uint SWP_SHOWWINDOW      =0x0040;
        public const uint SWP_HIDEWINDOW      =0x0080;
        public const uint SWP_NOCOPYBITS      =0x0100;
        public const uint SWP_NOOWNERZORDER   =0x0200;
        public const uint SWP_NOSENDCHANGING  =0x0400;
        public const uint SWP_DRAWFRAME       =SWP_FRAMECHANGED;
        public const uint SWP_NOREPOSITION    =SWP_NOOWNERZORDER;
        public const uint SWP_DEFERERASE      =0x2000;
        public const uint SWP_ASYNCWINDOWPOS  =0x4000;

        #endregion

        /// <summary>
        /// 设定窗体位置
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="hWndInsertAfter">用来设定Z轴位置的相对窗体句柄</param>
        /// <param name="X">左(px)</param>
        /// <param name="Y">上(px)</param>
        /// <param name="cx">宽(px)</param>
        /// <param name="cy">高(px)</param>
        /// <param name="uFlags">标志</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        #endregion

        #region SetLayeredWindowAttributes

        #region LayeredWindowAttributesFlags 层式窗体属性标志

        public const uint LWA_COLORKEY          =0x00000001;
        public const uint LWA_ALPHA             =0x00000002;

        #endregion

        /// <summary>
        /// 设定层式窗体属性
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="crKey">透明色</param>
        /// <param name="bAlpha">透明度</param>
        /// <param name="dwFlags">标志</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        #endregion

        #region SetWindowsHookEx

        #region WindowsHook 钩子类型

        public const int WH_MIN              =-1;
        public const int WH_MSGFILTER        =-1;
        public const int WH_JOURNALRECORD    =0;
        public const int WH_JOURNALPLAYBACK  =1;
        public const int WH_KEYBOARD         =2;
        public const int WH_GETMESSAGE       =3;
        public const int WH_CALLWNDPROC      =4;
        public const int WH_CBT              =5;
        public const int WH_SYSMSGFILTER     =6;
        public const int WH_MOUSE            =7;
        public const int WH_HARDWARE         =8;
        public const int WH_DEBUG            =9;
        public const int WH_SHELL            =10;
        public const int WH_FOREGROUNDIDLE   =11;
        public const int WH_CALLWNDPROCRET   =12;
        public const int WH_KEYBOARD_LL      =13;
        public const int WH_MOUSE_LL         =14;
        public const int WH_MAX              =14;
        public const int WH_MINHOOK          =WH_MIN;
        public const int WH_MAXHOOK          =WH_MAX;

        #endregion
        #region HookCodes 钩子代码

        public const int HC_ACTION           =0;
        public const int HC_GETNEXT          =1;
        public const int HC_SKIP             =2;
        public const int HC_NOREMOVE         =3;
        public const int HC_NOREM            =HC_NOREMOVE;
        public const int HC_SYSMODALON       =4;
        public const int HC_SYSMODALOFF      =5;

        #endregion

        /// <summary>
        /// 安装钩子
        /// </summary>
        /// <param name="idHook">钩子类型</param>
        /// <param name="lpfn">钩子程序</param>
        /// <param name="hMod">钩子程序所在模块</param>
        /// <param name="dwThreadId">线程ID（0表示全局）</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HOOKPROC lpfn, IntPtr hMod, uint dwThreadId);

        /// <summary>
        /// 卸载钩子
        /// </summary>
        /// <param name="hhk">钩子</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        /// <summary>
        /// 启动下一个钩子
        /// </summary>
        /// <param name="hhk">钩子（可省略）</param>
        /// <param name="nCode">钩子代码</param>
        /// <param name="wParam">消息参数</param>
        /// <param name="lParam">消息参数</param>
        /// <returns></returns>
        [DllImport(User32.DllName)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        #endregion
    }
}
