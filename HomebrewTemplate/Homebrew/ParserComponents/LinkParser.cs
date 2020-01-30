using System;
using System.IO;
using System.Net;
using System.Text;

namespace Homebrew
{

    /// <summary>
    /// Парсер ссылок.
    /// Принимает HttpWebRequest в конструктор
    /// </summary>
    /// <seealso cref="ReqParametres"/>
    public class LinkParser
    {
        private int _repeatCount = 0;
        public String Data { get; private set; }
        private HttpWebRequest request;
        private Encoding _encoding = Encoding.UTF8;
        public void SetEncodingMethod(Encoding encoding)
        {
            _encoding = encoding;            
        }
        public LinkParser(HttpWebRequest httpRequest)
        {
            request = httpRequest;
            StartParsing();
        }
        private void StartParsing()
        {
            try
            {
                string data;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream;
                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, _encoding);
                    }
                    data = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                }
                else
                {
                    data = "";
                }
                Data = data;
            }
            catch(Exception error)
            {
                Data = "";
            }
        }

    }
}
