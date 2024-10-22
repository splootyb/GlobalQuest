using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest
{
    internal static class Multipart
    {
        public static byte[] Read(byte[] Data, HttpListenerContext Context)
        {
            Log.Warn("This wasn't finished!! Dont' use this for multipart data :sob: use library");
            string PostData = Encoding.UTF8.GetString(Data);
            string Boundary = Context.Request.ContentType.Split("boundary=")[0].Replace("\"", "");
            byte[] BoundaryBytes = Encoding.UTF8.GetBytes("--" + Boundary);
            return ReadResult(Data, BoundaryBytes);
        }

        public static string GetBoundary(byte[] Data, HttpListenerContext Context)
        {
            string PostData = Encoding.UTF8.GetString(Data);
            string Boundary = PostData.Split(Environment.NewLine).FirstOrDefault(A => A.StartsWith("-")).Replace("-","");
            Log.Debug("Boundary: " + Boundary);
            return Boundary;
        }

        static byte[] ReadResult(byte[] Data, byte[] Boundary)
        {
            bool Read = false;
            int I = 0;
            byte End = Encoding.UTF8.GetBytes(Environment.NewLine)[Encoding.UTF8.GetBytes(Environment.NewLine).Count() - 1];
            byte ReadEnd = Encoding.UTF8.GetBytes("-")[Encoding.UTF8.GetBytes("-").Count() - 1];
            List<byte> Result = new List<byte>();

            string Length = Encoding.UTF8.GetString(Data);

            Console.WriteLine(Length);

            Length = Length.Split("Content-Length:")[1].Substring(0, 5).Replace(" ", "");

            Console.WriteLine(Length);

            int IntLength = int.Parse(Length);

            foreach (var item in Data)
            {
                if (Read)
                {
                    if (Result.Count < IntLength)
                    {
                        Result.Add(item);
                    }
                    else
                    {
                        break;
                    }
                }
                else if (item == End)
                {
                    if (I == 4)
                    {
                        Read = true;
                    }
                    else
                    {
                        I += 1;
                    }
                }
            }
            return Result.ToArray();
        }
    }
}
