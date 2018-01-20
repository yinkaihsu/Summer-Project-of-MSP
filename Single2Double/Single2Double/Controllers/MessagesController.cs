﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.ProjectOxford.Face;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using MySql.Data;
using System.Data.Odbc;

namespace Single2Double
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }

    [BotAuthentication]
    public class MessagesController : ApiController
    {
        // string urid;
        private string faceid;

        private float Confidence_s;
        private float Confidence_ns;

        public string[,] inputValues = new string[2, 11];
        public string input1, input2, input3, input4, input5, input6, input7, input8, input9;

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            //連接資料庫
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "single2double.database.windows.net";
            cb.UserID = "yinkaihsu";
            cb.Password = "ian199412130@yahoo.com.tw";
            cb.InitialCatalog = "S2D";

            //var cb = new OdbcConnection("DRIVER={MySQL ODBC 5.3 unicode Driver}; Server=single2double.mysql.database.azure.com; Port=3306;" +
            //" Database=single2double; Uid=yinkaihsu@single2double; Pwd=Ian199412130@yahoo.com.tw; sslverify=0; Option=3;MULTI_STATEMENTS=1");

            Activity reply = activity.CreateReply();
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                //await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());

                if (activity.Attachments?.Count > 0 && activity.Attachments.First().ContentType.StartsWith("image"))
                {
                    //User傳送一張照片
                    ImageTemplate(reply, activity.Attachments.First().ContentUrl);
                }
                else if (activity.Text.ToString() == "請上傳一張照片")
                {
                    reply.Text = "請上傳一張照片";
                }
                else if (activity.Text.ToString() == "測試異性對我的喜好")
                {
                    CreateButtonOne(reply);
                    //await InvokeRequestResponseService(reply, inputValues);
                }
                else if (activity.Text.ToString() == "Female>1" || activity.Text.ToString() == "Male>1")
                {
                    // answer
                    inputValues[0, 0] = activity.Text.ToString().Split('>')[0];
                    inputValues[1, 0] = activity.Text.ToString().Split('>')[0];

                    // user ID
                    string ChanData = activity.ChannelData.ToString();
                    string ChanData2 = ChanData.Remove(0, 29);
                    string ChanData3 = ChanData2.Remove(16, ChanData2.Length - 16);

                    // insert value into database
                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            string sql = "INSERT INTO [single2double].[match_analysis] ([id],[question],[answer]) VALUES ('" + ChanData3 + "',1,'" + inputValues[0, 0] + "')";
                            //撰寫query
                            SqlCommand insertValue = new SqlCommand(sql, connection);
                            insertValue.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "您已回答過此問題";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    //show botton
                    CreateButtonTwo(reply);
                }
                else if (activity.Text.ToString() == "1>2" || activity.Text.ToString() == "2>2" || activity.Text.ToString() == "3>2" || activity.Text.ToString() == "4>2" || activity.Text.ToString() == "5>2" || activity.Text.ToString() == "6>2" || activity.Text.ToString() == "7>2")
                {
                    // answer
                    inputValues[0, 3] = activity.Text.ToString().Split('>')[0];
                    inputValues[1, 3] = activity.Text.ToString().Split('>')[0];
                    // user ID
                    string ChanData = activity.ChannelData.ToString();
                    string ChanData2 = ChanData.Remove(0, 29);
                    string ChanData3 = ChanData2.Remove(16, ChanData2.Length - 16);

                    // insert value into database
                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            string sql = "INSERT INTO [single2double].[match_analysis] ([id],[question],[answer]) VALUES ('" + ChanData3 + "',2,'" + inputValues[0, 3] + "')";
                            //撰寫query
                            SqlCommand insertValue = new SqlCommand(sql, connection);
                            insertValue.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "您已回答過此問題";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    // show botton
                    CreateButtonThree(reply);
                }
                else if (activity.Text.ToString() == "1>3" || activity.Text.ToString() == "2>3" || activity.Text.ToString() == "3>3" || activity.Text.ToString() == "4>3" || activity.Text.ToString() == "5>3" || activity.Text.ToString() == "6>3" || activity.Text.ToString() == "7>3" || activity.Text.ToString() == "8>3" || activity.Text.ToString() == "9>3" || activity.Text.ToString() == "10>3")
                {
                    // answer
                    inputValues[0, 4] = activity.Text.ToString().Split('>')[0];
                    inputValues[1, 4] = activity.Text.ToString().Split('>')[0];

                    // user ID
                    string ChanData = activity.ChannelData.ToString();
                    string ChanData2 = ChanData.Remove(0, 29);
                    string ChanData3 = ChanData2.Remove(16, ChanData2.Length - 16);

                    // insert value into database
                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            string sql = "INSERT INTO [single2double].[match_analysis] ([id],[question],[answer]) VALUES ('" + ChanData3 + "',3,'" + inputValues[0, 4] + "')";
                            //撰寫query
                            SqlCommand insertValue = new SqlCommand(sql, connection);
                            insertValue.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "您已回答過此問題";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    // show botton
                    CreateButtonFour(reply);
                }
                else if (activity.Text.ToString() == "1>4" || activity.Text.ToString() == "2>4" || activity.Text.ToString() == "3>4" || activity.Text.ToString() == "4>4" || activity.Text.ToString() == "5>4" || activity.Text.ToString() == "6>4" || activity.Text.ToString() == "7>4" || activity.Text.ToString() == "8>4" || activity.Text.ToString() == "9>4" || activity.Text.ToString() == "10>4")
                {
                    // answer
                    inputValues[0, 5] = activity.Text.ToString().Split('>')[0];
                    inputValues[1, 5] = activity.Text.ToString().Split('>')[0];

                    // user ID
                    string ChanData = activity.ChannelData.ToString();
                    string ChanData2 = ChanData.Remove(0, 29);
                    string ChanData3 = ChanData2.Remove(16, ChanData2.Length - 16);

                    // insert value into database
                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            string sql = "INSERT INTO [single2double].[match_analysis] ([id],[question],[answer]) VALUES ('" + ChanData3 + "',4,'" + inputValues[0, 5] + "')";
                            //撰寫query
                            SqlCommand insertValue = new SqlCommand(sql, connection);
                            insertValue.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "您已回答過此問題";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    // show botton
                    CreateButtonFive(reply);
                }
                else if (activity.Text.ToString() == "1>5" || activity.Text.ToString() == "2>5" || activity.Text.ToString() == "3>5" || activity.Text.ToString() == "4>5" || activity.Text.ToString() == "5>5" || activity.Text.ToString() == "6>5" || activity.Text.ToString() == "7>5" || activity.Text.ToString() == "8>5" || activity.Text.ToString() == "9>5" || activity.Text.ToString() == "10>5")
                {
                    // answer
                    inputValues[0, 6] = activity.Text.ToString().Split('>')[0];
                    inputValues[1, 6] = activity.Text.ToString().Split('>')[0];

                    // user ID
                    string ChanData = activity.ChannelData.ToString();
                    string ChanData2 = ChanData.Remove(0, 29);
                    string ChanData3 = ChanData2.Remove(16, ChanData2.Length - 16);

                    // insert value into database
                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            string sql = "INSERT INTO [single2double].[match_analysis] ([id],[question],[answer]) VALUES ('" + ChanData3 + "',5,'" + inputValues[0, 6] + "')";
                            //撰寫query
                            SqlCommand insertValue = new SqlCommand(sql, connection);
                            insertValue.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "您已回答過此問題";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    // show botton
                    CreateButtonSix(reply);
                }
                else if (activity.Text.ToString() == "1>6" || activity.Text.ToString() == "2>6" || activity.Text.ToString() == "3>6" || activity.Text.ToString() == "4>6" || activity.Text.ToString() == "5>6" || activity.Text.ToString() == "6>6" || activity.Text.ToString() == "7>6" || activity.Text.ToString() == "8>6" || activity.Text.ToString() == "9>6" || activity.Text.ToString() == "10>6")
                {
                    // answer
                    inputValues[0, 7] = activity.Text.ToString().Split('>')[0];
                    inputValues[1, 7] = activity.Text.ToString().Split('>')[0];

                    // user ID
                    string ChanData = activity.ChannelData.ToString();
                    string ChanData2 = ChanData.Remove(0, 29);
                    string ChanData3 = ChanData2.Remove(16, ChanData2.Length - 16);

                    // insert value into database
                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            string sql = "INSERT INTO [single2double].[match_analysis] ([id],[question],[answer]) VALUES ('" + ChanData3 + "',6,'" + inputValues[0, 7] + "')";
                            //撰寫query
                            SqlCommand insertValue = new SqlCommand(sql, connection);
                            insertValue.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "您已回答過此問題";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    // show botton
                    CreateButtonSeven(reply);
                }
                else if (activity.Text.ToString() == "1>7" || activity.Text.ToString() == "2>7" || activity.Text.ToString() == "3>7" || activity.Text.ToString() == "4>7" || activity.Text.ToString() == "5>7" || activity.Text.ToString() == "6>7" || activity.Text.ToString() == "7>7" || activity.Text.ToString() == "8>7" || activity.Text.ToString() == "9>7" || activity.Text.ToString() == "10>7")
                {
                    // answer
                    inputValues[0, 8] = activity.Text.ToString().Split('>')[0];
                    inputValues[1, 8] = activity.Text.ToString().Split('>')[0];

                    // user ID
                    string ChanData = activity.ChannelData.ToString();
                    string ChanData2 = ChanData.Remove(0, 29);
                    string ChanData3 = ChanData2.Remove(16, ChanData2.Length - 16);

                    // insert value into database
                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            string sql = "INSERT INTO [single2double].[match_analysis] ([id],[question],[answer]) VALUES ('" + ChanData3 + "',7,'" + inputValues[0, 8] + "')";
                            //撰寫query
                            SqlCommand insertValue = new SqlCommand(sql, connection);
                            insertValue.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "您已回答過此問題";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    // show botton
                    CreateButtonEight(reply);
                }
                else if (activity.Text.ToString() == "1>8" || activity.Text.ToString() == "2>8" || activity.Text.ToString() == "3>8" || activity.Text.ToString() == "4>8" || activity.Text.ToString() == "5>8" || activity.Text.ToString() == "6>8" || activity.Text.ToString() == "7>8" || activity.Text.ToString() == "8>8" || activity.Text.ToString() == "9>8" || activity.Text.ToString() == "10>8")
                {
                    // answer
                    inputValues[0, 9] = activity.Text.ToString().Split('>')[0];
                    inputValues[1, 9] = activity.Text.ToString().Split('>')[0];

                    // user ID
                    string ChanData = activity.ChannelData.ToString();
                    string ChanData2 = ChanData.Remove(0, 29);
                    string ChanData3 = ChanData2.Remove(16, ChanData2.Length - 16);

                    // insert value into database
                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            string sql = "INSERT INTO [single2double].[match_analysis] ([id],[question],[answer]) VALUES ('" + ChanData3 + "',8,'" + inputValues[0, 9] + "')";
                            //撰寫query
                            SqlCommand insertValue = new SqlCommand(sql, connection);
                            insertValue.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "您已回答過此問題";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    // show botton
                    CreateButtonNine(reply);
                }
                else if (activity.Text.ToString() == "1>9" || activity.Text.ToString() == "2>9" || activity.Text.ToString() == "3>9" || activity.Text.ToString() == "4>9" || activity.Text.ToString() == "5>9" || activity.Text.ToString() == "6>9" || activity.Text.ToString() == "7>9" || activity.Text.ToString() == "8>9" || activity.Text.ToString() == "9>9" || activity.Text.ToString() == "10>9")
                {
                    // answer
                    inputValues[0, 10] = activity.Text.ToString().Split('>')[0];
                    inputValues[1, 10] = activity.Text.ToString().Split('>')[0];

                    // user ID
                    string ChanData = activity.ChannelData.ToString();
                    string ChanData2 = ChanData.Remove(0, 29);
                    string ChanData3 = ChanData2.Remove(16, ChanData2.Length - 16);

                    // insert value into database
                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            string sql = "INSERT INTO [single2double].[match_analysis] ([id],[question],[answer]) VALUES ('" + ChanData3 + "',9,'" + inputValues[0, 10] + "')";
                            //撰寫query
                            SqlCommand insertValue = new SqlCommand(sql, connection);
                            insertValue.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "您已回答過此問題";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    // call data from database
                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            //撰寫query
                            StringBuilder sb1 = new StringBuilder();
                            sb1.Append("SELECT [answer] ");
                            sb1.Append("FROM [single2double].[match_analysis]");
                            sb1.Append("Where [id]= '" + ChanData3 + "' AND [question]=" + "1");
                            String sql = sb1.ToString();
                            using (var cmd = new SqlCommand(sql, connection))
                            {
                                input1 = (string)cmd.ExecuteScalar();
                            }
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "error with input1";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            //撰寫query
                            StringBuilder sb2 = new StringBuilder();
                            sb2.Append("SELECT [answer] ");
                            sb2.Append("FROM [single2double].[match_analysis]");
                            sb2.Append("Where [id]= '" + ChanData3 + "' AND [question]=" + "2");
                            String sql = sb2.ToString();
                            using (var cmd = new SqlCommand(sql, connection))
                            {
                                input2 = (string)cmd.ExecuteScalar();
                            }
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "error with input2";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            //撰寫query
                            StringBuilder sb3 = new StringBuilder();
                            sb3.Append("SELECT [answer] ");
                            sb3.Append("FROM [single2double].[match_analysis]");
                            sb3.Append("Where [id]= '" + ChanData3 + "' AND [question]=" + "3");
                            String sql = sb3.ToString();
                            using (var cmd = new SqlCommand(sql, connection))
                            {
                                input3 = (string)cmd.ExecuteScalar();
                            }
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "error with input3";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            //撰寫query
                            StringBuilder sb4 = new StringBuilder();
                            sb4.Append("SELECT [answer] ");
                            sb4.Append("FROM [single2double].[match_analysis]");
                            sb4.Append("Where [id]= '" + ChanData3 + "' AND [question]=" + "4");
                            String sql = sb4.ToString();
                            using (var cmd = new SqlCommand(sql, connection))
                            {
                                input4 = (string)cmd.ExecuteScalar();
                            }
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "error with input4";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            //撰寫query
                            StringBuilder sb5 = new StringBuilder();
                            sb5.Append("SELECT [answer] ");
                            sb5.Append("FROM [single2double].[match_analysis]");
                            sb5.Append("Where [id]= '" + ChanData3 + "' AND [question]=" + "5");
                            String sql = sb5.ToString();
                            using (var cmd = new SqlCommand(sql, connection))
                            {
                                input5 = (string)cmd.ExecuteScalar();
                            }
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "error with input5";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            //撰寫query
                            StringBuilder sb6 = new StringBuilder();
                            sb6.Append("SELECT [answer] ");
                            sb6.Append("FROM [single2double].[match_analysis]");
                            sb6.Append("Where [id]= '" + ChanData3 + "' AND [question]=" + "6");
                            String sql = sb6.ToString();
                            using (var cmd = new SqlCommand(sql, connection))
                            {
                                input6 = (string)cmd.ExecuteScalar();
                            }
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "error with input6";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            //撰寫query
                            StringBuilder sb7 = new StringBuilder();
                            sb7.Append("SELECT [answer] ");
                            sb7.Append("FROM [single2double].[match_analysis]");
                            sb7.Append("Where [id]= '" + ChanData3 + "' AND [question]=" + "7");
                            String sql = sb7.ToString();
                            using (var cmd = new SqlCommand(sql, connection))
                            {
                                input7 = (string)cmd.ExecuteScalar();
                            }
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "error with input7";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            //撰寫query
                            StringBuilder sb8 = new StringBuilder();
                            sb8.Append("SELECT [answer] ");
                            sb8.Append("FROM [single2double].[match_analysis]");
                            sb8.Append("Where [id]= '" + ChanData3 + "' AND [question]=" + "8");
                            String sql = sb8.ToString();
                            using (var cmd = new SqlCommand(sql, connection))
                            {
                                input8 = (string)cmd.ExecuteScalar();
                            }
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "error with input8";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            //建立資料庫連線
                            connection.Open();
                            //撰寫query
                            StringBuilder sb9 = new StringBuilder();
                            sb9.Append("SELECT [answer] ");
                            sb9.Append("FROM [single2double].[match_analysis]");
                            sb9.Append("Where [id]= '" + ChanData3 + "' AND [question]=" + "9");
                            String sql = sb9.ToString();
                            using (var cmd = new SqlCommand(sql, connection))
                            {
                                input9 = (string)cmd.ExecuteScalar();
                            }
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "error with input9";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    await InvokeRequestResponseService(reply, input1, "20", input2, input3, input4, input5, input6, input7, input8, input9);
                    ///reply.Text = input1 + "20" + input2 + input3 + input4 + input5 + input6 + input7 + input8 + input9;
                }
                else if (activity.Text == "我好孤單")
                {
                    string url = "";

                    try
                    {
                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {   //隨機選擇照片
                            Random rnd = new Random();
                            //目前資料庫的照片張數
                            int rd = rnd.Next(1, 767);
                            //建立資料庫連線
                            connection.Open();
                            //撰寫query
                            StringBuilder sb = new StringBuilder();
                            sb.Append("SELECT [image_url] ");
                            sb.Append("FROM [single2double].[beauty_image]");
                            sb.Append("Where [id]=" + rd);
                            String sql = sb.ToString();
                            using (var cmd = new SqlCommand(sql, connection))
                            {
                                url = (string)cmd.ExecuteScalar();
                            }
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {
                        reply.Text = "沒成功";
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    Attachment att = new Attachment();
                    att.ContentType = "image/png";
                    att.ContentUrl = url;
                    reply.Text = "請慢慢享用^^";

                    reply.Attachments.Add(att);
                }
                else if (activity.Text == "我只是想打招呼...")
                {
                    reply.Text = "你是不是很孤單啊? 別擔心, S2D永遠是你的好朋友呦~";
                }
                else
                {
                    if (activity.ChannelId == "facebook")
                    {
                        var fbData = JsonConvert.DeserializeObject<FBChannelModel>(activity.ChannelData.ToString());
                        Rootobject ttt = new Rootobject();

                        // ttt.faceId = faceid;
                        ttt.personGroupId = "loser";
                        ttt.personId = "8955d99f-7fd5-414a-acef-805b9971a4a6";
                        Rootobject winer = new Rootobject();
                        winer.personGroupId = "winner";
                        winer.personId = "2ae5cb06-e58c-46d5-8f29-6cf1afd0dd81";

                        if (fbData.postback != null && fbData.postback.payload.StartsWith("Analyze"))
                        {
                            //辨識圖片
                            var url = fbData.postback.payload.Split('>')[1];
                            //reply.Text = $"{url}";
                            // Custom Vision API

                            // Code to be finished...................

                            //string answer = await MakePredictionRequest(url);
                            //reply.Text = answer;

                            FaceServiceClient client = new FaceServiceClient("0a8700b757f44d2e9307914a800a11b1", "https://eastasia.api.cognitive.microsoft.com/face/v1.0");
                            var faces = await client.DetectAsync(
                                url,
                                true,
                                false
                                );

                            foreach (var face in faces)
                            {
                                var id = face.FaceId;

                                //reply.Text = "HI";
                                //reply.Text = $"{id}";
                                ttt.faceId = id.ToString();
                                winer.faceId = id.ToString();
                                string body = JsonConvert.SerializeObject(ttt).ToString();
                                string body2 = JsonConvert.SerializeObject(winer).ToString();
                                Confidence_s = await MakeRequest(body, activity, "單身", Confidence_s);
                                Confidence_ns = await MakeRequest(body2, activity, "不是單身", Confidence_ns);
                                // await connector.Conversations.ReplyToActivityAsync(reply);
                                Confidence_s = Confidence_s - Confidence_ns;
                                if (Confidence_s > 0)
                                {
                                    reply.Text = "預測您 ''單身'', 其機率比 ''不是單身'' 高出 " + Confidence_s * 100 + "%!";
                                    //reply.Text = "這個人應該是單身";
                                    //await connector.Conversations.ReplyToActivityAsync(reply);
                                }
                                if (Confidence_s < 0)
                                {
                                    reply.Text = "預測您 ''不是單身'', 其機率比 ''單身'' 高出 " + Confidence_s * -100 + "%!";
                                    //reply.Text = "這個人應該不是是單身";
                                    //await connector.Conversations.ReplyToActivityAsync(reply);
                                }
                            }

                            // Console.WriteLine("Hit ENTER to exit...");
                            // Console.ReadLine();
                        }
                        else if (fbData.postback != null && fbData.postback.payload.StartsWith("Face"))
                        {
                            //辨識圖片
                            var url = fbData.postback.payload.Split('>')[1];
                            FaceServiceClient client = new FaceServiceClient("0a8700b757f44d2e9307914a800a11b1", "https://eastasia.api.cognitive.microsoft.com/face/v1.0");
                            var result = await client.DetectAsync(url, true, false, new FaceAttributeType[] { FaceAttributeType.Age, FaceAttributeType.Gender });
                            reply.Text = $"預測您的年齡為 {result.Average(x => x.FaceAttributes.Age)} 歲!";
                        }
                    }
                }

                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                // HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        //verify
        private static async Task<float> MakeRequest(string body, Activity activity, string status, float Confidence)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            // Activity activity=new Activity();
            Activity datareply = activity.CreateReply();
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "0a8700b757f44d2e9307914a800a11b1");

            var uri = "https://eastasia.api.cognitive.microsoft.com/face/v1.0/verify?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(body);

            //response = await client.PostAsync(uri, new StringContent(body, Encoding.UTF8, "application/json"));
            //datareply.Text = await response.Content.ReadAsStringAsync();
            //await connector.Conversations.ReplyToActivityAsync(datareply);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

                datareply.Text = await response.Content.ReadAsStringAsync();
                JObject rss = JObject.Parse(datareply.Text);
                Confidence = (float)rss["confidence"];

                //datareply.Text = $"他跟{status}的人的長相有 {Confidence} 的相似度";
                //await connector.Conversations.ReplyToActivityAsync(datareply);
                return Confidence;
            }
        }

        private static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

        // Custom Vision API
        //Start
        private static async Task MakePredictionRequest(string imageFilePath)
        {
            var client = new HttpClient();

            // Request headers - replace this example key with your valid subscription key.
            client.DefaultRequestHeaders.Add("Prediction-Key", "736c7bdde9ff49a0912eead949a3a23c");

            // Prediction URL - replace this example URL with your valid prediction URL.
            string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.1/Prediction/98da1daa-936e-4f53-bb91-714c7cffc10a/url";

            HttpResponseMessage response;

            // Request body. Try this sample with a locally stored image.
            byte[] byteData = GetImageAsByteArray(imageFilePath);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(url, content);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        //Finish

        private void ImageTemplate(Activity reply, string url)

        {
            List<Attachment> att = new List<Attachment>();

            att.Add(new HeroCard()

            {
                Title = "Cognitive services",

                Subtitle = "Select from below",

                Images = new List<CardImage>() { new CardImage(url) },

                Buttons = new List<CardAction>()

                {
                    new CardAction(ActionTypes.PostBack, "預測年齡", value: $"Face>{url}"),

                    new CardAction(ActionTypes.PostBack, "確認感情狀態", value: $"Analyze>{url}")
                }
            }.ToAttachment());

            reply.Attachments = att;
        }

        private void CreateButtonOne(Activity reply)
        {
            List<Attachment> att = new List<Attachment>();

            att.Add(new HeroCard()

            {
                Title = "What is your gender?",
                Buttons = new List<CardAction>()

                {
                    new CardAction(ActionTypes.PostBack, "Male", value: "Male>1"),
                    new CardAction(ActionTypes.PostBack, "Female", value: "Female>1"),
                }
            }.ToAttachment());

            reply.Attachments = att;
        }

        private void CreateButtonTwo(Activity reply)
        {
            List<Attachment> att = new List<Attachment>();

            att.Add(new HeroCard()

            {
                Title = "How often do you go out?",
                Buttons = new List<CardAction>()

                {
                    new CardAction(ActionTypes.PostBack, "Many times / week", value: "1>2"),
                    new CardAction(ActionTypes.PostBack, "Twice / week", value: "2>2"),
                    new CardAction(ActionTypes.PostBack, "Once / week", value: "3>2"),
                    new CardAction(ActionTypes.PostBack, "Twice / month", value: "4>2"),
                    new CardAction(ActionTypes.PostBack, "Once / month", value: "5>2"),
                    new CardAction(ActionTypes.PostBack, "Many times / year", value: "6>2"),
                    new CardAction(ActionTypes.PostBack, "Almost never", value: "7>2"),
                }
            }.ToAttachment());

            reply.Attachments = att;
        }

        private void CreateButtonThree(Activity reply)
        {
            List<Attachment> att = new List<Attachment>();

            att.Add(new HeroCard()

            {
                Title = "How interested are you in Playing Sports?",
                Subtitle = "(1=not at all, 10 = highly)",
                Buttons = new List<CardAction>()

                {
                    new CardAction(ActionTypes.PostBack, "1", value: "1>3"),
                    new CardAction(ActionTypes.PostBack, "2", value: "2>3"),
                    new CardAction(ActionTypes.PostBack, "3", value: "3>3"),
                    new CardAction(ActionTypes.PostBack, "4", value: "4>3"),
                    new CardAction(ActionTypes.PostBack, "5", value: "5>3"),
                    new CardAction(ActionTypes.PostBack, "6", value: "6>3"),
                    new CardAction(ActionTypes.PostBack, "7", value: "7>3"),
                    new CardAction(ActionTypes.PostBack, "8", value: "8>3"),
                    new CardAction(ActionTypes.PostBack, "9", value: "9>3"),
                    new CardAction(ActionTypes.PostBack, "10", value: "10>3"),
                }
            }.ToAttachment());

            reply.Attachments = att;
        }

        private void CreateButtonFour(Activity reply)
        {
            List<Attachment> att = new List<Attachment>();

            att.Add(new HeroCard()

            {
                Title = "How interested are you in Watching Sports?",
                Subtitle = "(1=not at all, 10 = highly)",
                Buttons = new List<CardAction>()

                {
                    new CardAction(ActionTypes.PostBack, "1", value: "1>4"),
                    new CardAction(ActionTypes.PostBack, "2", value: "2>4"),
                    new CardAction(ActionTypes.PostBack, "3", value: "3>4"),
                    new CardAction(ActionTypes.PostBack, "4", value: "4>4"),
                    new CardAction(ActionTypes.PostBack, "5", value: "5>4"),
                    new CardAction(ActionTypes.PostBack, "6", value: "6>4"),
                    new CardAction(ActionTypes.PostBack, "7", value: "7>4"),
                    new CardAction(ActionTypes.PostBack, "8", value: "8>4"),
                    new CardAction(ActionTypes.PostBack, "9", value: "9>4"),
                    new CardAction(ActionTypes.PostBack, "10", value: "10>4"),
                }
            }.ToAttachment());

            reply.Attachments = att;
        }

        private void CreateButtonFive(Activity reply)
        {
            List<Attachment> att = new List<Attachment>();

            att.Add(new HeroCard()

            {
                Title = "How interested are you in Hiking/Camping?",
                Subtitle = "(1=not at all, 10 = highly)",
                Buttons = new List<CardAction>()

                {
                    new CardAction(ActionTypes.PostBack, "1", value: "1>5"),
                    new CardAction(ActionTypes.PostBack, "2", value: "2>5"),
                    new CardAction(ActionTypes.PostBack, "3", value: "3>5"),
                    new CardAction(ActionTypes.PostBack, "4", value: "4>5"),
                    new CardAction(ActionTypes.PostBack, "5", value: "5>5"),
                    new CardAction(ActionTypes.PostBack, "6", value: "6>5"),
                    new CardAction(ActionTypes.PostBack, "7", value: "7>5"),
                    new CardAction(ActionTypes.PostBack, "8", value: "8>5"),
                    new CardAction(ActionTypes.PostBack, "9", value: "9>5"),
                    new CardAction(ActionTypes.PostBack, "10", value: "10>5"),
                }
            }.ToAttachment());

            reply.Attachments = att;
        }

        private void CreateButtonSix(Activity reply)
        {
            List<Attachment> att = new List<Attachment>();

            att.Add(new HeroCard()

            {
                Title = "How interested are you in Gaming?)",
                Subtitle = "(1=not at all, 10 = highly)",
                Buttons = new List<CardAction>()

                {
                    new CardAction(ActionTypes.PostBack, "1", value: "1>6"),
                    new CardAction(ActionTypes.PostBack, "2", value: "2>6"),
                    new CardAction(ActionTypes.PostBack, "3", value: "3>6"),
                    new CardAction(ActionTypes.PostBack, "4", value: "4>6"),
                    new CardAction(ActionTypes.PostBack, "5", value: "5>6"),
                    new CardAction(ActionTypes.PostBack, "6", value: "6>6"),
                    new CardAction(ActionTypes.PostBack, "7", value: "7>6"),
                    new CardAction(ActionTypes.PostBack, "8", value: "8>6"),
                    new CardAction(ActionTypes.PostBack, "9", value: "9>6"),
                    new CardAction(ActionTypes.PostBack, "10", value: "10>6"),
                }
            }.ToAttachment());

            reply.Attachments = att;
        }

        private void CreateButtonSeven(Activity reply)
        {
            List<Attachment> att = new List<Attachment>();

            att.Add(new HeroCard()

            {
                Title = "How interested are you in Watching TV?",
                Subtitle = "(1=not at all, 10 = highly)",
                Buttons = new List<CardAction>()

                {
                    new CardAction(ActionTypes.PostBack, "1", value: "1>7"),
                    new CardAction(ActionTypes.PostBack, "2", value: "2>7"),
                    new CardAction(ActionTypes.PostBack, "3", value: "3>7"),
                    new CardAction(ActionTypes.PostBack, "4", value: "4>7"),
                    new CardAction(ActionTypes.PostBack, "5", value: "5>7"),
                    new CardAction(ActionTypes.PostBack, "6", value: "6>7"),
                    new CardAction(ActionTypes.PostBack, "7", value: "7>7"),
                    new CardAction(ActionTypes.PostBack, "8", value: "8>7"),
                    new CardAction(ActionTypes.PostBack, "9", value: "9>7"),
                    new CardAction(ActionTypes.PostBack, "10", value: "10>7"),
                }
            }.ToAttachment());

            reply.Attachments = att;
        }

        private void CreateButtonEight(Activity reply)
        {
            List<Attachment> att = new List<Attachment>();

            att.Add(new HeroCard()

            {
                Title = "How interested are you in Shopping?",
                Subtitle = "(1=not at all, 10 = highly)",
                Buttons = new List<CardAction>()

                {
                    new CardAction(ActionTypes.PostBack, "1", value: "1>8"),
                    new CardAction(ActionTypes.PostBack, "2", value: "2>8"),
                    new CardAction(ActionTypes.PostBack, "3", value: "3>8"),
                    new CardAction(ActionTypes.PostBack, "4", value: "4>8"),
                    new CardAction(ActionTypes.PostBack, "5", value: "5>8"),
                    new CardAction(ActionTypes.PostBack, "6", value: "6>8"),
                    new CardAction(ActionTypes.PostBack, "7", value: "7>8"),
                    new CardAction(ActionTypes.PostBack, "8", value: "8>8"),
                    new CardAction(ActionTypes.PostBack, "9", value: "9>8"),
                    new CardAction(ActionTypes.PostBack, "10", value: "10>8"),
                }
            }.ToAttachment());

            reply.Attachments = att;
        }

        private void CreateButtonNine(Activity reply)
        {
            List<Attachment> att = new List<Attachment>();

            att.Add(new HeroCard()

            {
                Title = "How interested are you in Yoga/Meditation?",
                Subtitle = "(1=not at all, 10 = highly)",
                Buttons = new List<CardAction>()

                {
                    new CardAction(ActionTypes.PostBack, "1", value: "1>9"),
                    new CardAction(ActionTypes.PostBack, "2", value: "2>9"),
                    new CardAction(ActionTypes.PostBack, "3", value: "3>9"),
                    new CardAction(ActionTypes.PostBack, "4", value: "4>9"),
                    new CardAction(ActionTypes.PostBack, "5", value: "5>9"),
                    new CardAction(ActionTypes.PostBack, "6", value: "6>9"),
                    new CardAction(ActionTypes.PostBack, "7", value: "7>9"),
                    new CardAction(ActionTypes.PostBack, "8", value: "8>9"),
                    new CardAction(ActionTypes.PostBack, "9", value: "9>9"),
                    new CardAction(ActionTypes.PostBack, "10", value: "10>9"),
                }
            }.ToAttachment());

            reply.Attachments = att;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }

        private static async Task InvokeRequestResponseService(Activity reply, string value1, string value2, string value3, string value4, string value5, string value6, string value7, string value8, string value9, string value10)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"gender", "dec_o", "age", "go_out", "sports", "tvsports", "hiking", "gaming", "tv", "shopping", "yoga"},
                                Values = new string[,] { { value1, "0", value2, value3, value4, value5, value6, value7, value8, value9, value10},
                                                                      { value1, "0", value2, value3, value4, value5, value6, value7, value8, value9, value10}, }
                             }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                const string apiKey = "8SM/8J2nOEAHLQ701i4uaR/XMa7RNIzfddElQ8ACBhVhnT6BU0LWf2NY2hDVUe/NQGsNxLNHhSfPQdsQrUzuhw=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/8438100c4a1042d8a0d4fc3e67721cbe/services/adc3ea3d48f849b4b2d3592286bd05f7/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)

                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string Scored, Scored2, Scored3;
                    string result = await response.Content.ReadAsStringAsync();

                    var res = JsonConvert.DeserializeObject<resultobject>(result);
                    Scored = res.Results.output1.value.Values[0][11];
                    Scored2 = Scored.Remove(0, 2);
                    Scored3 = Scored2.Remove(2, Scored2.Length - 2);
                    reply.Text = "您受異性喜好的程度為" + Scored3 + "%!";
                }
                else
                {
                    reply.Text = "您填的問卷有錯誤";
                    /*Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));
                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);*/
                }
            }
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }
}