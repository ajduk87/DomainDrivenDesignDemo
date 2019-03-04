using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientApplication.ControllerClasses
{
    public class BufferAddress
    {
        private static BufferAddress instance;
        private string _pathForRequestBuff = string.Empty;
        private string _pathForResponseBuff = string.Empty;

        public BufferAddress(string pathForRequestBuff, string pathForResponseBuff)
        {
            _pathForRequestBuff = pathForRequestBuff;
            _pathForResponseBuff = pathForResponseBuff;
        }

        public static BufferAddress GetInstance(string pathForRequestBuff, string pathForResponseBuff) 
        {
            if (instance == null)
            {
                instance = new BufferAddress(pathForRequestBuff, pathForResponseBuff);
            }
            return instance;
        }

        public string PathForRequestBuff
        {
            get { return _pathForRequestBuff; }
            set { _pathForRequestBuff = value; }
        }

        public string PathForResponseBuff
        {
            get { return _pathForResponseBuff; }
            set { _pathForResponseBuff = value; }
        }
    }
}
