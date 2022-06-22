using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel;

using Newtonsoft.Json;

namespace WebAPIApplication1
{
    public class Post
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //PostMethod();
        }

        public static Task<string> CallMethod() {
            string strurltest = String.Format("https://jsonplaceholder.typicode.com/posts/1/comments");
            WebRequest requestObjGet = WebRequest.Create(strurltest);
            requestObjGet.Method = "Get";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();

            string strresulttest = null;
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresulttest = sr.ReadToEnd();
                return Task.FromResult(strresulttest);
                sr.Close();
            }
        }

      
        //Post
        public static Task<string> PostMethod(int i)
        {
            List<String> Titlelist = new List<string>() { "a","b","c","d","e","f","g","h","i","j"};
            List<String> Bodylist = new List<string>() { "Hello a","Hello b","Hello c","Hello d","Hello e","Hello f","Hello g","Hello h","Hello i","Hello j"};
            List<int> UserIdlist = new List<int>() { 1,2,3,4,5,6,7,8,9,10};

            String strurl = String.Format("https://jsonplaceholder.typicode.com/posts");
            WebRequest requestObjPost = WebRequest.Create(strurl);
            requestObjPost.Method = "Post";
            requestObjPost.ContentType = "application/json";
            
                var newPost = new Post()
                {
                    Title = Titlelist[i],
                    Body = Bodylist[i],
                    UserId = UserIdlist[i]
                };
                
                var newPostJSON = JsonConvert.SerializeObject(newPost);
                using (var streamWriter = new StreamWriter(requestObjPost.GetRequestStream()))
                {
                    streamWriter.Write(newPostJSON.ToString());
                    streamWriter.Flush();
                    streamWriter.Close();

                    var httpResponse = (HttpWebResponse)requestObjPost.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result2 = streamReader.ReadToEnd();

                        //_Default.TextBox1.Text = results;
                        return Task.FromResult(result2);
                    }
                }
            
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            String resulfinal = await _Default.CallMethod();
            Label1.Text = resulfinal;
        }

        protected async void Button2_Click(object sender, EventArgs e)
        {
            string postresult="";
            List<String> results = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                 postresult = await _Default.PostMethod(i);
                results.Add(postresult);
            }

            ListBox1.DataSource = results;
            ListBox1.DataBind();
            
        }
    }
}