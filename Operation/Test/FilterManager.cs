using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Operation.Test
{
    public class FilterManager : IResponseFilter
    {
        //private static Dictionary<string, IResponseFilter> dataList = new Dictionary<string, IResponseFilter>();

        //public static IResponseFilter CreateFilter(string guid)
        //{
        //    lock (dataList)
        //    {
        //        var filter = new AppendResponseFilter("", "");
        //        dataList.Add(guid, filter);

        //        return filter;
        //    }
        //}

        //public static IResponseFilter GetFileter(string guid)
        //{
        //    lock (dataList)
        //    {
        //        return dataList[guid];
        //    }
        //}


        public event Action<byte[]> NotifyData;
        private int contentLength = 0;
        private List<byte> dataAll = new List<byte>();

        public void SetContentLength(int contentLength)
        {
            this.contentLength = contentLength;
        }


        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public FilterStatus Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {
            try
            {
                if (dataIn == null)
                {
                    dataInRead = 0;
                    dataOutWritten = 0;

                    return FilterStatus.Done;
                }

                dataInRead = dataIn.Length;
                dataOutWritten = Math.Min(dataInRead, dataOut.Length);

                dataIn.CopyTo(dataOut);
                dataIn.Seek(0, SeekOrigin.Begin);
                byte[] bs = new byte[dataIn.Length];
                dataIn.Read(bs, 0, bs.Length);
                dataAll.AddRange(bs);

                if (dataAll.Count == this.contentLength)
                {
                    // 通过这里进行通知  
                    NotifyData(dataAll.ToArray());

                    return FilterStatus.Done;
                }
                else if (dataAll.Count < this.contentLength)
                {
                    dataInRead = dataIn.Length;
                    dataOutWritten = dataIn.Length;

                    return FilterStatus.NeedMoreData;
                }
                else
                {
                    return FilterStatus.Error;
                }
            }
            catch (Exception ex)
            {
                dataInRead = dataIn.Length;
                dataOutWritten = dataIn.Length;

                return FilterStatus.Done;
            }
        }

        public bool InitFilter()
        {
            return true;
        }
    }
}
