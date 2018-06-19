using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ModelSecoundSample
{
    public partial class NovelList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckBoxItemsAscendantOrder();

        }


        private void CheckBoxItemsAscendantOrder()
        {

           
                string[] ascendentcheckbox =
                {
                "Sci-Fi", "Action", "Comedy", "Romance", "Adventure",
                "Drama", "Slice of Life", "Fantasy", "Magic" , "Supernatural",
                "Horror", "Mystery", "Psychological"
                };

                var queryAscBox = from a in ascendentcheckbox
                                  orderby a
                                  select a;
            

            if(GenreCheckBox.Items.Count == 0)
            {
                foreach (var array in queryAscBox)
                {
                    GenreCheckBox.Items.Add(array);

                }
            }

            
            


            


        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(NovelChapter.Text.Length >= 1 && NovelText.Text.Length > 2)
            {
                try
                {

                    using (var dataBase = new NovelsModelContainer())
                    {
                        var novelName = NovelText.Text;
                        int novelChapter;
                        if (!Int32.TryParse(NovelChapter.Text, out novelChapter))
                        {
                            Label4.Visible = true;
                        }
                        else
                        {
                            Label4.Visible = false;
                            var geen = "";
                            int counter = 1;
                            foreach (ListItem item in GenreCheckBox.Items)
                            {
                                if (item.Selected)
                                {
                                    if (counter > 1)
                                    {
                                        geen += ", " + item.Value;
                                    }

                                    else
                                    {
                                        geen += item.Value;
                                        counter++;
                                    }

                                }

                            }


                            var novel = new Novel { Name = novelName, Chapter = novelChapter, Genre = geen };
                            dataBase.Novels.Add(novel);
                            dataBase.SaveChanges();

                        }



                    }
                    NovelText.Text = null;
                    NovelChapter.Text = null;
                    foreach (ListItem item in GenreCheckBox.Items)
                    {
                        item.Selected = false;

                    }

                }
                catch (DbEntityValidationException d)
                {
                    foreach (var eve in d.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            else
            {
                Label4.Visible = true;
            }
           
        }
    }
}