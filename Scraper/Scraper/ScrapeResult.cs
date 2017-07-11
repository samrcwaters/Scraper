using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Scraper
{
    public partial class ScrapeResult : Form
    {
        public ScrapeResult()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string fullScrape = "";

            //WebProxy wb = new WebProxy();
            //Uri uri = new Uri("http://fr.proxymesh.com");
            //ICredentials ic = new NetworkCredential("ibrenly", "Renly1234");
            //wb.Credentials = ic;
            //UriBuilder urib = new UriBuilder("fr.proxymesh.com");
            //urib.Port = 31280;
            //wb.Address = urib.Uri;

            //TEXAS
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                    fullScrape += selectText(Post("https://www.tdlr.texas.gov/LicenseSearch/SearchResultsListBrowse.asp?from=search"));
                /*else
                    fullScrape += selectText(GetUsingClient("https://www.tdlr.texas.gov/LicenseSearch/SearchResultsListBrowse.asp?pageNo=" + (i.ToString()) + "&pageDir=N&k=" + (i.ToString()) + "&j=" + ((i + 25).ToString()), null));*/
            }
            txt1.Text = fullScrape;
        }

        //scrape2
        private void button1_Click(object sender, EventArgs e)
        {

        }



        private string Get(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            request.KeepAlive = true;
            request.Host = "www.tdlr.texas.gov";

            CookieContainer cc1 = new CookieContainer();
            Uri target = new Uri("https://www.tdlr.texas.gov/LicenseSearch/SearchResultsListBrowse.asp?pageNo=1&pageDir=N&k=0&j=25");

            cc1.Add(new Cookie("ASPSESSIONIDSGCSRRCS", "KBOLBJNANPEDJNKBHGNDAJOC") { Domain = target.Host });
            cc1.Add(new Cookie("_ga", "GA1.3.566836355.1498254413") { Domain = target.Host });
            cc1.Add(new Cookie("_gid", "GA1.3.1236182035.1498582802") { Domain = target.Host });
            request.CookieContainer = cc1;

            string result = string.Empty;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            WebHeaderCollection header = response.Headers;


            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }


        //Texas
        public static string GetUsingClient(string strPageUrl, WebProxy proxy)
        {
            CookieAwareWebClient objClient = new CookieAwareWebClient();
            objClient.Proxy = proxy;
            objClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            //objClient.Headers.Add("user-agent", "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 58.0.3029.110 Safari / 537.36)");


            Uri target = new Uri(strPageUrl);

            Cookie c1 = new Cookie();
            objClient.CookieContainer.Add(new Cookie("ASPSESSIONIDQECTSQDT", "PCPGAFKBOKPIPIDHPHMAJJDG") { Domain = target.Host });
            objClient.CookieContainer.Add(new Cookie("_ga", "GA1.3.155819001.1498682767") { Domain = target.Host });
            objClient.CookieContainer.Add(new Cookie("_gid", "GA1.3.1150811410.1498682767") { Domain = target.Host });

            string strSource = string.Empty;
            strSource = objClient.DownloadString(strPageUrl);
            return strSource;
        }

        private string Post(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";
            httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";

            var postData = "tdlr_status=COSMOS";
            var data = Encoding.ASCII.GetBytes(postData);

            using (var streamWriter = httpWebRequest.GetRequestStream())
            {
                //string json = GetParameters(ht);

                streamWriter.Write(data, 0, data.Length);
                streamWriter.Flush();
                streamWriter.Close();

            }

            string result;

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }

        private string Postv2(string url, Hashtable ht)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";
            httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            httpWebRequest.Host = "apps.sd.gov";

            Uri target = new Uri(url);
            string d = "apps.sd.gov";

            httpWebRequest.CookieContainer = new CookieContainer();

            httpWebRequest.CookieContainer.Add(new Cookie("ASP.NET_SessionId", "rt551zxb4f4mbx5wvds05cgr") { Domain = d });
            httpWebRequest.CookieContainer.Add(new Cookie("NID", "106=M9ZVimsLykNm89auJWZOwRW9-nu9RlWz6ggXtbkI385TwlJiI-z0Y7BNS2oqh94dtQPPIY5kJaQTFCMOg_20ZuQrCybEwtSQyJSz6kH729ZZvp2gq38vqq9sjch-Tpta") { Domain = ".google.com" });
            httpWebRequest.CookieContainer.Add(new Cookie("__utma", "107011410.1211691278.1498688238.1498688238.1498688238.1") { Domain = d });
            httpWebRequest.CookieContainer.Add(new Cookie("__utmb", "107011410.1211691278.1498688238.1498688238.1498688238.1") { Domain = d });
            httpWebRequest.CookieContainer.Add(new Cookie("__utmc", "107011410") { Domain = d });
            httpWebRequest.CookieContainer.Add(new Cookie("__utmt", "1") { Domain = d });
            httpWebRequest.CookieContainer.Add(new Cookie("__utmz", "107011410.1498688238.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)") { Domain = d });

            using (var streamWriter = httpWebRequest.GetRequestStream())
            {
                var json = GetParameters(ht);

                streamWriter.Write(json, 0, json.Length);
                streamWriter.Flush();
                streamWriter.Close();
            }

            string result;

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }

        private byte[] GetParameters(Hashtable ht)
        {
            int counter = 0;
            StringBuilder objString = new StringBuilder();
            objString.Append("{\"properties\":[");
            foreach (DictionaryEntry de in ht)
            {
                string strParameterName = string.Format(@"@{0}", de.Key.ToString());

                if (counter > 0)
                    objString.Append(",");

                string key = de.Key.ToString();
                string value = de.Value.ToString();

                objString.Append("{");
                objString.AppendFormat("\"name\": \"{0}\", ", key);
                objString.AppendFormat("\"value\": \"{0}\"", value);
                objString.Append("}");
                counter++;
            }

            objString.Append("]}");
            return Encoding.ASCII.GetBytes(objString.ToString());
        }



        public string GetStringBetween(string strString, string strStart, string strEnd, out int intEnd)
        {
            try
            {
                string strResult = string.Empty;
                int intStart = strString.IndexOf(strStart);
                int intStart2 = intStart + strStart.Length;
                intEnd = strString.IndexOf(strEnd, intStart2);
                strResult = strString.Substring(intStart2, intEnd - intStart2);
                return strResult;
            }

            catch
            {
                intEnd = 0;
                return string.Empty;
            }
        }

        public List<string> GetAllBetween(string strString, string strStart, string strEnd)
        {
            List<string> lstResult = new List<string>();
            int counter = 0;
            string strResult = string.Empty;
            int intStart = strString.IndexOf(strStart);

            if (intStart > -1)
            {
                int intStart2 = intStart + strStart.Length;
                int intEnd = strString.IndexOf(strEnd, intStart2);

                if (intEnd > -1)
                {
                    strResult = strString.Substring(intStart2, intEnd - intStart2);
                    lstResult.Add(strResult);

                    strString = strString.Substring(intEnd);

                    while (strString.IndexOf(strStart) != -1)
                    {
                        int intEnd2;
                        string strResult2 = GetStringBetween(strString, strStart, strEnd, out intEnd2);
                        if (strResult2 != "")
                            lstResult.Add(strResult2);
                        //SaveElement(strResult2);
                        strString = strString.Substring(intEnd2);
                        counter++;
                    }
                }
            }

            return lstResult;
        }

        //Texas
        public string selectText(string sourceText)
        {
            //gets stuff within td tags
            List<string> tdList = new List<string>();
            tdList = GetAllBetween(sourceText, "<td", "/td>");
            string tdScrape = makeString(tdList);

            //return tdScrape;
            
            //gets stuff within any tags
            List<string> textList = new List<string>();
            textList = GetAllBetween(tdScrape, ">", "<");
            string textScrape = makeString(textList);

            //return textScrape;

            //gets only info
            List<string> infoList = new List<string>();
            infoList = GetAllBetween(textScrape, "hone", "If");
            string finalScrape = makeString(infoList);

            //return finalScrape;

            //list of TableData objects
            List<TableData> tdObjList = new List<TableData>();

            for (int item = 0; item < textList.Count; item++)
            {
                if (textList.ElementAt(item).IndexOf("COS - ") > -1)
                {
                    //if this row isn't inactive, add that
                    if ((textList.ElementAt(item + 2) != "Inactive") && (textList.ElementAt(item + 2) != "Expired"))
                    {
                        //make obj
                        TableData td = new TableData();
                        td.License = textList.ElementAt(item);
                        td.Date = textList.ElementAt(item + 1);
                        td.Name = textList.ElementAt(item + 2);
                        td.Zip = textList.ElementAt(item + 4);
                        td.Phone = textList.ElementAt(item + 6);

                        tdObjList.Add(td);
                    }
                }
            }

            //var tdObjList2 = tdObjList.Where(x => x.RegDate.ToLower().Contains("inactive") == false).ToList();

            string scrape5 = "";
            //MessageBox.Show(tdObjList.Count.ToString());
            for (int i = 0; i < tdObjList.Count; i++)
            {
                scrape5 += tdObjList.ElementAt(i).License + " -- " + tdObjList.ElementAt(i).Date + " -- " + tdObjList.ElementAt(i).Name + " -- " + tdObjList.ElementAt(i).Zip + " -- " + tdObjList.ElementAt(i).Phone + "        \n";
            }
            
            //creates json string
            string jsonStr = createJsonString(tdObjList);

            //writes json string to file
            System.IO.File.WriteAllText(@"C:\Users\Renly\Desktop\jsonTest.txt", jsonStr);

            return scrape5;
        }

        public string makeString(List<string> strList)
        {
            string result = "";
            for (int i = 0; i < strList.Count; i++)
            {
                result += strList.ElementAt(i);
            }
            return result;
        }

        private string createJsonString(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }

    public class CookieAwareWebClient : WebClient
    {
        public CookieAwareWebClient()
        {
            CookieContainer = new CookieContainer();
        }
        public CookieContainer CookieContainer { get; private set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.CookieContainer = CookieContainer;
            return request;
        }
    }

    public class TableData
    {
        public string License { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
    }
}


