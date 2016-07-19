/* JSON API for the all devices */
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace IS_DRP_JSONWebAPI  {
    public class IS_DRP_RestAPI {
       private const string urlString = "http://115.28.68.57:8012/is_Handler.ashx";
       private const int bufferSize = 4096;
       private string Load(string contents)
       {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlString);
            req.AllowWriteStreamBuffering = true;
            req.Method = "POST";
            req.Timeout = 60000;
            Stream outStream = req.GetRequestStream();
            StreamWriter outStreamWriter = new StreamWriter(outStream);
            outStreamWriter.Write(contents);
            outStreamWriter.Flush();
            outStream.Close();
            WebResponse res = req.GetResponse();
            Stream httpStream = res.GetResponseStream();
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                byte[] buff = new byte[bufferSize];
                int readedBytes = httpStream.Read(buff, 0, buff.Length);
                while (readedBytes > 0)
                {
                    memoryStream.Write(buff, 0, readedBytes);
                    readedBytes = httpStream.Read(buff, 0, buff.Length);
                }
            }
            finally
            {
                if (httpStream != null)
                {
                    httpStream.Close();
                }

                if (memoryStream != null)
                {
                    memoryStream.Close();
                }
            }
            byte[] data = memoryStream.ToArray();
            string result = Encoding.UTF8.GetString(data, 0, data.Length);
            return result;
        }

        public JObject GetCheckNum(string phoneNum,string IP,string module) {
            JObject result = null;
            JObject o = new JObject();
            JObject p = new JObject();
            o["interface"] = "IS_DRP_RestAPI";
            o["method"]= "GetCheckNum";
            p["phoneNum"]= JToken.FromObject(phoneNum);
            p["IP"]= JToken.FromObject(IP);
            p["module"]= JToken.FromObject(module);
            o["parameters"] = p;
            string s = JsonConvert.SerializeObject(o);
            string r = Load(s);
            result = JObject.Parse(r);
            return result;
        }

        public JObject CheckCode(string phoneNum,string checkNum,string module) {
            JObject result = null;
            JObject o = new JObject();
            JObject p = new JObject();
            o["interface"] = "IS_DRP_RestAPI";
            o["method"]= "CheckCode";
            p["phoneNum"]= JToken.FromObject(phoneNum);
            p["checkNum"]= JToken.FromObject(checkNum);
            p["module"]= JToken.FromObject(module);
            o["parameters"] = p;
            string s = JsonConvert.SerializeObject(o);
            string r = Load(s);
            result = JObject.Parse(r);
            return result;
        }

        public JObject UserReg(string mobileNo,string userName,string userPwd,string distrName,string contactName,string telNo,string emailAddr,string areaNo) {
            JObject result = null;
            JObject o = new JObject();
            JObject p = new JObject();
            o["interface"] = "IS_DRP_RestAPI";
            o["method"]= "UserReg";
            p["mobileNo"]= JToken.FromObject(mobileNo);
            p["userName"]= JToken.FromObject(userName);
            p["userPwd"]= JToken.FromObject(userPwd);
            p["distrName"]= JToken.FromObject(distrName);
            p["contactName"]= JToken.FromObject(contactName);
            p["telNo"]= JToken.FromObject(telNo);
            p["emailAddr"]= JToken.FromObject(emailAddr);
            p["areaNo"]= JToken.FromObject(areaNo);
            o["parameters"] = p;
            string s = JsonConvert.SerializeObject(o);
            string r = Load(s);
            result = JObject.Parse(r);
            return result;
        }

        public JObject testUserReg(string mobileNo,string userName,string userPwd,string distrName,string contactName,string telNo,string emailAddr,string areaNo) {
            JObject result = null;
            JObject o = new JObject();
            JObject p = new JObject();
            o["interface"] = "IS_DRP_RestAPI";
            o["method"]= "testUserReg";
            p["mobileNo"]= JToken.FromObject(mobileNo);
            p["userName"]= JToken.FromObject(userName);
            p["userPwd"]= JToken.FromObject(userPwd);
            p["distrName"]= JToken.FromObject(distrName);
            p["contactName"]= JToken.FromObject(contactName);
            p["telNo"]= JToken.FromObject(telNo);
            p["emailAddr"]= JToken.FromObject(emailAddr);
            p["areaNo"]= JToken.FromObject(areaNo);
            o["parameters"] = p;
            string s = JsonConvert.SerializeObject(o);
            string r = Load(s);
            result = JObject.Parse(r);
            return result;
        }

    }


}
