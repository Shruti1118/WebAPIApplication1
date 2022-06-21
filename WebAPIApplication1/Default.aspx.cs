using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebAPIApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strurltest = String.Format("https://jsonplaceholder.typicode.com/posts/1/comments");
            WebRequest requestObjGet = WebRequest.Create(strurltest);
            requestObjGet.Method = "Get";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();

            string strresulttest = null;
            using(Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresulttest = sr.ReadToEnd();
                sr.Close();
            }


            //Post
            String strurl = String.Format("https://jsonplaceholder.typicode.com/posts");
            WebRequest requestObjPost = WebRequest.Create(strurl);
            requestObjPost.Method = "Post";
            requestObjPost.ContentType = "application/json";
            string postData = "{\"title\":\"testdata\",\"body\":\"testbody\",\"userId\":\"50\"}";

            using (var streamWriter = new StreamWriter(requestObjPost.GetRequestStream()))
            {
                streamWriter.Write(postData);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)requestObjPost.GetResponse();

                using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result2 = streamReader.ReadToEnd();

                }
            }

        }
    }
}