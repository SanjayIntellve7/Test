using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Services.CPPlusDahua
{
    public class CPPlusDahuaSDK
    {
        public CPPlusDahuaSDK()
        {
            //
            // TODO: 
            //
        }

        //struct//
        //LPNET_TIME
        [StructLayout(LayoutKind.Sequential)]
        public struct LPNET_TIME
        {
            public uint dwYear;
            public uint dwMonth;
            public uint dwDay;
            public uint dwHour;
            public uint dwMinute;
            public uint dwSecond;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DEVICEINFO
        {
            /// <summary>
            /// Serial Number[Length48]
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
            public byte[] sSerialNumber;

            /// <summary>
            /// DVR Alarm Input Number
            /// </summary>
            public byte byAlarmInPortNum;

            /// <summary>
            /// DVR Alarm Output Number
            /// </summary>
            public byte byAlarmOutPortNum;

            /// <summary>
            /// DVR HDD Number
            /// </summary>
            public byte byDiskNum;

            /// <summary>
            /// DVR Type
            /// </summary>
            public byte byDVRType;

            /// <summary>
            /// DVR Channel Number
            /// </summary>
            public byte byChanNum;

        }

        public delegate void fDisConnect(
        int lLoginID, StringBuilder pchDVRIP, int nDVRPort, IntPtr dwUser);
        public static fDisConnect disConnect;
        [DllImport(@"dhnetsdk.dll")]
        public static extern bool CLIENT_Init(fDisConnect cbDisConnect, IntPtr dwUser);

        [DllImport(@"dhnetsdk.dll")]
        private static extern Int32 CLIENT_GetLastError();

        /// <summary>
        ///Initialization SDK
        /// </summary>
        /// <param name="cbDisConnect">
        /// Disconnection callback function,See also commissioned<seealso cref="fDisConnect"/>
        /// </param>
        /// <param name="dwUser">User Information</param>
        /// <returns>true:success;false:failure</returns>
      
        /// <summary>
        /// Empty SDK, Releases the resources,After calling all SDK functions
        /// </summary>
        [DllImport(@"dhnetsdk.dll")]
        public static extern void CLIENT_Cleanup();

        [DllImport(@"dhnetsdk.dll")]
        public static extern int CLIENT_Login(string pchDVRIP, ushort wDVRPort, string pchUserName, string pchPassword, out NET_DEVICEINFO lpDeviceInfo, out int error);

        [DllImport(@"dhnetsdk.dll")]
        public static extern bool CLIENT_SetSecurityKey(Int32 lPlayHandle, string szKey, UInt32 nKeyLen);

        [DllImport(@"dhnetsdk.dll")]
        public static extern bool CLIENT_Logout(int lLoginID);

        /// <summary>
        /// And the device connected to the waiting time set
        /// </summary>
        /// <param name="nWaitTime">Connection waiting time[Unit:Millisecond]</param>
        /// <param name="nTryTimes">connection times</param>
        [DllImport(@"dhnetsdk.dll")]
        public static extern void CLIENT_SetConnectTime(int nWaitTime, int nTryTimes);

        [DllImport(@"dhnetsdk.dll")]
        public static extern bool CLIENT_SetupDeviceTime(int lLoginID, LPNET_TIME pDeviceTime);

    }
}

