using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RedUABot
{
    //Temp class to save windowsHandle data
    public class Handles
    {
        public IntPtr pointer;
        public string windowClass;

        public Handles(IntPtr _pointer, string _windowClass)
        {
            pointer = _pointer;
            windowClass = _windowClass;
        }
    }

    public class WindowHandleInfo
    {
        //To store the main handle
        private IntPtr _MainHandle;

        //functions
        private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);
        private delegate bool EnumedWindow(IntPtr handleWindow, ArrayList handles);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumedWindow lpEnumFunc, ArrayList lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumedWindow callback, ArrayList lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(HandleRef handle, out int processId);

        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder text, int count);

        private static bool GetWindowHandle(IntPtr windowHandle, ArrayList windowHandles)
        {
            windowHandles.Add(windowHandle);
            return true;
        }

        private WindowHandleInfo(IntPtr handle)
        {
            this._MainHandle = handle;
        }

        private List<IntPtr> GetAllChildHandles()
        {
            List<IntPtr> childHandles = new List<IntPtr>();

            GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
            IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);

            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(this._MainHandle, childProc, pointerChildHandlesList);
            }
            finally
            {
                gcChildhandlesList.Free();
            }

            return childHandles;
        }

        private bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);

            if (gcChildhandlesList == null || gcChildhandlesList.Target == null)
            {
                return false;
            }

            List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
            childHandles.Add(hWnd);

            return true;
        }

        //core function
        public static List<Handles> GetAllWindowsProcess(in Process p)
        {
            //wanted array windows
            string search = "ThunderRT6TextBox";
            //array to store the wanted windows
            List<Handles> final = new List<Handles>();

            //get id threadprocess of the 
            uint id = GetWindowThreadProcessId(p.MainWindowHandle, IntPtr.Zero);
            //get all SO windows
            var windowHandles = new ArrayList();
            EnumedWindow callBackPtr = GetWindowHandle;
            EnumWindows(callBackPtr, windowHandles);

            foreach (IntPtr windowHandle in windowHandles.ToArray())
            {
                EnumChildWindows(windowHandle, callBackPtr, windowHandles);
            }
            //starting to filter some data
            foreach (IntPtr pt in windowHandles)
            {
                uint t = (uint)p.Id;
                //if id is equals (window of RedUA.exe)
                if (GetWindowThreadProcessId(pt, IntPtr.Zero) == id)
                {
                    //if windows is in searching array
                    StringBuilder s = new StringBuilder(256);
                    GetClassName(pt, s, 256);
                    if (search.Equals(s.ToString()))
                    {
                        final.Add(new Handles(pt, s.ToString()));
                        //added
                    }
                }
            }

            return final;
        }
    }
}
