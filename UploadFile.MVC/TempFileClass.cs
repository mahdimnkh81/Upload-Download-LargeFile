using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace UploadFile.MVC
{
    public static class TempFileClass
    {
 
        private static List<Stream> streamListFile = new List<Stream>();
        private static List<int> IntList = new List<int>();

        public static void AddItem(Stream stream)
        {
            streamListFile.Add(stream);
        }
        public static void AddItemInt(int stream)
        {
            IntList.Add(stream);
        }
        public static void ClearList()
        {
            streamListFile = new List<Stream>();
        }
        public static List<Stream> GetList()
        {
            return streamListFile;
        }
    }
}