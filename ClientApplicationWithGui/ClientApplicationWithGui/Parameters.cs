using ClientApplication.ControllerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplicationWithGui
{
    public static class Parameters
    {
        public static bool IsTimeoutHappened = false;
        public static int Timeout = 500 * 60;//timeout for service response if client waits response is 30 seconds
        public static StorageManager storageManager;
        public static BufferAddress bufferAddress;
        public static string pathForRequest = "C:\\DomainDrivenDesignDemo\\Buffers\\bufferForRequest.txt";
        public static string pathForResponse = "C:\\DomainDrivenDesignDemo\\Buffers\\bufferForResponse.txt";
    }
}
