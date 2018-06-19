using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ModelSecoundSample
{
    public partial class Overview : System.Web.UI.Page
    {
        string novelinformation = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            datamagnet();
            TextBox1.Text = novelinformation;
            
        }

        public void datamagnet()
        {
            using (var dataBase = new NovelsModelContainer())
            {

                var queryNovel = from a in dataBase.Novels
                                 orderby a.Name
                                 select a;


                foreach (var item in queryNovel)
                {
                    novelinformation +=  item.Name + "\n" +"Chapters : "+ item.Chapter + "\n" + "Genres : " + item.Genre + "\n\n";
                }
            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           using(var dataBase = new NovelsModelContainer())
            {
                var queryNovel = from a in dataBase.Novels
                                 orderby a.Name
                                 select a;
                foreach(var item in queryNovel)
                {
                    if(TextBox2.Text == item.Name)
                    {
                        dataBase.Novels.Remove(item);
                    }
                }
                dataBase.SaveChanges();
                

            }
            Response.Redirect(Request.RawUrl);

        }
    }
}