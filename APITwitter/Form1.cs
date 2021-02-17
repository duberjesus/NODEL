using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;
using Tweetinvi.Models;

namespace APITwitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Auth.SetUserCredentials("tPhuYUlVME2IjA1rYsh26yXpa", "dS7zZIp1Jgq9dB3inxerM5GcDB85tC0CoyyOBch0aDCJPGm4PT",
                "1146457499954044928-uVK4oBmxpb4SqAXRvtd8TwmJoE8SiR", "rn6LaX48qT3Gk1q47hSSTgGOqw9EahZitxX9DOgNkc2VH");

        }

        public string[] hashtags = { "#VacunaCOVID19", "#sismo", "#WandaVision", "#UKlockdown3", "#Indonesia", "#iPhone", "#CES2021",
            "#Adictosdigitales", "#Tech", "#innovation", "#iphone", "#EE.U"};

        ListView listView1 = null;

        public string usuario = null;
        public int followers;
        public DateTime fechaPost;
        public string idioma;
        public string ContenidoPost = null;
        public int Retweets;
        public int Favorites;

        private void Form1_Load(object sender, EventArgs e)
        {
            var user = User.GetAuthenticatedUser();

            foreach (var ht in hashtags)
            {
                cboHashtags.Items.Add(ht);
            }

            lstTweets.Columns.Add("Usuario").Width = 100;
            lstTweets.Columns.Add("Followers").Width = 60;
            lstTweets.Columns.Add("FechaPost").Width = 120;
            lstTweets.Columns.Add("IdiomaPost").Width = 85;
            lstTweets.Columns.Add("ContenidoPost").Width = 260;
            lstTweets.Columns.Add("Retweets").Width = 60;
            lstTweets.Columns.Add("Favorites").Width = 60;


            lstIdiomas.Columns.Add("Idioma").Width = 85;
            lstIdiomas.Columns.Add("Total").Width = 60;

            lstSeguidores.Columns.Add("Usuario").Width = 100;
            lstSeguidores.Columns.Add("Total").Width = 60;

            lstFecha.Columns.Add("Fecha").Width = 120;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboHashtags.SelectedIndex > -1)
                {
                    lstTweets.Items.Clear();
                    lstIdiomas.Items.Clear();
                    lstSeguidores.Items.Clear();
                    lstFecha.Items.Clear();

                    var searchParameter = Search.CreateTweetSearchParameter(cboHashtags.Text);

                    searchParameter.MaximumNumberOfResults = 25;
                    searchParameter.Until = new DateTime(2021, 02, 08);

                    var tweets = Search.SearchTweets(searchParameter);

                    var listFollowers = new List<int>();
                    var listFecha = new List<string>();

                    foreach (var tweet in tweets)
                    {
                        if (tweet.RetweetedTweet != null)
                        {
                            usuario = tweet.RetweetedTweet.CreatedBy.ScreenName;
                            followers = tweet.RetweetedTweet.CreatedBy.FollowersCount;
                            fechaPost = tweet.RetweetedTweet.CreatedAt.Date;
                            idioma = tweet.RetweetedTweet.Language.Value.ToString();
                            ContenidoPost = tweet.RetweetedTweet.FullText;
                            Retweets = tweet.RetweetedTweet.RetweetCount;
                            Favorites = tweet.RetweetedTweet.FavoriteCount;
                        }
                        else
                        {
                            usuario = tweet.CreatedBy.ScreenName;
                            followers = tweet.CreatedBy.FollowersCount;
                            fechaPost = tweet.CreatedAt.Date;
                            idioma = tweet.Language.Value.ToString();
                            ContenidoPost = tweet.FullText;
                            Retweets = tweet.RetweetCount;
                            Favorites = tweet.FavoriteCount;
                        }

                        listFollowers.Add(followers);
                        listFecha.Add(fechaPost.ToString());

                        lstTweets.Items.Add(new ListViewItem(new string[] { usuario, followers.ToString(), fechaPost.ToString(), idioma,
                                                                        ContenidoPost, Retweets.ToString(), Favorites.ToString()}));

                    }

                    int Cont = 0;

                    var fecha = listFecha.GroupBy(item => item)
                          .Select(item => new
                          {
                              Name = item.Key,
                              Count = item.Count()
                          })
                          .OrderByDescending(item => item.Count)
                          .ThenBy(item => item.Name)
                          .ToList();

                    foreach (var item in fecha)
                    {
                        lstFecha.Items.Add(new ListViewItem(new string[] { item.Name }));
                        break;
                    }

                    var noDupes = listFollowers.Distinct().ToList();

                    noDupes.Sort();
                    noDupes.Reverse();

                    for (int i = 0; Cont < 5; i++)
                    {
                        string follList1 = noDupes[i].ToString();
                        for (int j = 0; j < lstTweets.Items.Count; j++)
                        {
                            string follList2 = lstTweets.Items[j].SubItems[1].Text;
                            if (follList1 == follList2)
                            {
                                lstSeguidores.Items.Add(new ListViewItem(new string[] { lstTweets.Items[j].SubItems[0].Text, follList2 }));
                                Cont++;
                                break;
                            }
                        }
                    }

                    Cont = 0;

                    var myList = new List<string>();
                    var duplicates = new List<string>();

                    for (int i = 0; i < lstTweets.Items.Count; i++)
                    {
                        string s;
                        if (lstTweets.Items[i].SubItems[3].Text != "")
                        {
                            s = lstTweets.Items[i].SubItems[3].Text;

                            if (!myList.Contains(s))
                                myList.Add(s);
                            else
                                duplicates.Add(s);
                        }
                    }

                    var result = duplicates.GroupBy(item => item)
                          .Select(item => new
                          {
                              Name = item.Key,
                              Count = item.Count()
                          })
                          .OrderByDescending(item => item.Count)
                          .ThenBy(item => item.Name)
                          .ToList();

                    foreach (var item in result)
                    {
                        if (Cont < 3)
                        {
                            lstIdiomas.Items.Add(new ListViewItem(new string[] { item.Name, item.Count.ToString() }));
                            Cont++;
                        }
                    }

                    // Get number of objects
                    var nbTweets = tweets.Count();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Por favor intente nuevamente.");
            }
            
        }

        private void CreateMyListView(TabPage tabpage)
        {
            // Create a new ListView control.
            //ListView listView1 = new ListView();
            listView1.Dock = DockStyle.Top;
            // Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display check boxes.
            listView1.CheckBoxes = true;
            // Display grid lines.
            listView1.GridLines = true;
            // Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending;

            listView1.Columns.Add("Usuario").Width = -2;
            listView1.Columns.Add("Followers").Width = -2;
            listView1.Columns.Add("FechaPost").Width = -2;
            listView1.Columns.Add("IdiomaPost").Width = -2;
            listView1.Columns.Add("ContenidoPost").Width = -2;
            listView1.Columns.Add("Retweets").Width = -2;
            listView1.Columns.Add("Favorites").Width = -2;

            // Add the ListView to the control collection.
            tabpage.Controls.Add(listView1);
        }

        private void CreateIdiomaRank(TabPage tabpage)
        {
            listView1.Bounds = new Rectangle(new Point(400, 200), new Size(300, 150));
            //listView1.Dock = DockStyle.Fill;
            // Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display check boxes.
            listView1.CheckBoxes = true;
            // Display grid lines.
            listView1.GridLines = true;
            // Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending;

            listView1.Columns.Add("Top").Width = -2;
            listView1.Columns.Add("Idioma").Width = -2;

            // Add the ListView to the control collection.
            tabpage.Controls.Add(listView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var myList = new List<string>();
            var duplicates = new List<string>();

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string s;
                if (listView1.Items[i].SubItems[3].Text != "")
                {
                    s = listView1.Items[i].SubItems[3].Text;

                    if (!myList.Contains(s))
                        myList.Add(s);
                    else
                        duplicates.Add(s);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
