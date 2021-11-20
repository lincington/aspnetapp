using DockerWeb.Models;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace DockerWeb.ComHelper
{
    public class ConnHelper
    {

        static  MongoDBHelper mongoDBHelper = null;
        static  SqlServerDbHelper sqlServerDbHelper = null;
        string MonConnectionString = AppConfigurtaionServices.Configuration.GetSection("DatabaseSettings:MonConnectionString").Value;
        string SqlServerConnectionString= AppConfigurtaionServices.Configuration.GetSection("DatabaseSettings:SqlServerConnectionString").Value;
        public  ConnHelper()
        {
            try
            {
                mongoDBHelper = new MongoDBHelper(MonConnectionString, "EveryDateInfo");
                sqlServerDbHelper = new SqlServerDbHelper(SqlServerConnectionString);
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error(ex.ToString());        
            }
        }
        public static async Task AsyncFunc2(string num)
        {
            await Task.Run(() =>
            {
                try
                {
                    string apiUrl = "http://hq.sinajs.cn/list=sz{0}";
                    if (Convert.ToInt32(num) < 400000)
                    {
                    }
                    else
                    {
                        apiUrl = "http://hq.sinajs.cn/list=sh{0}";
                    }
                    apiUrl = string.Format(apiUrl, num);
                    Console.WriteLine(num);
                    HttpClient myHttpClient = new HttpClient();
                    myHttpClient.BaseAddress = new Uri(apiUrl);
                    HttpResponseMessage response = myHttpClient.GetAsync(apiUrl).Result;
                    string result = "";
                    if (response.IsSuccessStatusCode)
                    {
                        result = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                    }
                    if (result.Length < 40)
                    {
                    }
                    else
                    {
                        sz ss = new sz();
                        string[] dd = result.Split(',');
                        ss.Id = ObjectId.GenerateNewId();
                        string demo = dd[0].Split('=')[0];
                        ss.Namenum = demo.Substring(demo.Length - 6, 6);
                        ss.Name = dd[0].Split('"')[1];

                        ss.TodayK = Convert.ToDecimal(dd[1]);
                        ss.LastS = Convert.ToDecimal(dd[2]);
                        ss.Price = Convert.ToDecimal(dd[3]);
                        ss.TodayH = Convert.ToDecimal(dd[4]);
                        ss.TodayL = Convert.ToDecimal(dd[5]);
                        ss.TodayJB = Convert.ToDecimal(dd[6]);
                        ss.TodayJS = Convert.ToDecimal(dd[7]);
                        ss.TodayNum = Convert.ToDecimal(dd[8]);
                        ss.TodaySalay = Convert.ToDecimal(dd[9]);
                        ss.TodayJBON = Convert.ToDecimal(dd[10]);
                        ss.TodayJBOP = Convert.ToDecimal(dd[11]);
                        ss.TodayJBTN = Convert.ToDecimal(dd[12]);
                        ss.TodayJBTP = Convert.ToDecimal(dd[13]);
                        ss.TodayJBTHN = Convert.ToDecimal(dd[14]);
                        ss.TodayJBTHP = Convert.ToDecimal(dd[15]);
                        ss.TodayJBFN = Convert.ToDecimal(dd[16]);
                        ss.TodayJBFP = Convert.ToDecimal(dd[17]);
                        ss.TodayJBFIN = Convert.ToDecimal(dd[18]);
                        ss.TodayJBFIP = Convert.ToDecimal(dd[19]);
                        ss.TodayJSON = Convert.ToDecimal(dd[20]);
                        ss.TodayJSOP = Convert.ToDecimal(dd[21]);
                        ss.TodayJSTN = Convert.ToDecimal(dd[22]);
                        ss.TodayJSTP = Convert.ToDecimal(dd[23]);
                        ss.TodayJSTHN = Convert.ToDecimal(dd[24]);
                        ss.TodayJSTHP = Convert.ToDecimal(dd[25]);
                        ss.TodayJSFN = Convert.ToDecimal(dd[26]);
                        ss.TodayJSFP = Convert.ToDecimal(dd[27]);
                        ss.TodayJSFIN = Convert.ToDecimal(dd[28]);
                        ss.TodayJSFIP = Convert.ToDecimal(dd[29]);
                        ss.Date = dd[30];
                        ss.Time = dd[31];
                        var roomdatadocument = new BsonDocument(ss.ToBsonDocument());
                        string date = DateTime.Now.ToShortDateString();
                        var collection = mongoDBHelper.database.GetCollection<BsonDocument>(date);
                        collection.InsertOneAsync(roomdatadocument);
                    }
                }
                catch (Exception)
                {
                }
            });
        }


        public static async Task<string> AsyncFunc1(string num)
        {
            return await Task.Run(() =>
            {
                //提交当前地址的webapi
                //string apiUrl = ConfigurationManager.AppSettings["SSOPassport"];
                string apiUrl = "https://q.stock.sohu.com/hisHq?code=cn_{0}&start=20100101&end={1}";
                apiUrl = string.Format(apiUrl, num, DateTime.Now.AddDays(1).ToString("yyyyMMdd"));
                Console.WriteLine(num);
                //向用户中心提交部门
                //后台client方式GET提交
                try
                {
                    HttpClient myHttpClient = new HttpClient();
                    myHttpClient.BaseAddress = new Uri(apiUrl);
                    HttpResponseMessage response = myHttpClient.GetAsync(apiUrl).Result;
                    string result = "";
                    if (response.IsSuccessStatusCode)
                    {
                        result = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        return num.ToString();
                    }
                    if (result.Length < 140)
                    {
                        return num.ToString();
                    }
                    else
                    {
                        JArray Jhqljson = (JArray)Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                        List<BsonDocument> docunemts = new List<BsonDocument>();
                        JToken JDON = Jhqljson.First();
                        int intstatus = JDON["status"].ToObject<int>();
                        List<List<string>> hqzz = JDON["hq"].ToObject<List<List<string>>>();
                        string code = JDON["code"].ToObject<string>();
                        foreach (List<string> dd in hqzz)
                        {
                            histoyapi ddd = new histoyapi();
                            ddd.Id = ObjectId.GenerateNewId();
                            ddd.Thedate = Convert.ToDateTime(dd[0]);
                            ddd.Bp = Convert.ToDouble(dd[1]);
                            ddd.Ep = Convert.ToDouble(dd[2]);
                            ddd.Hl = Convert.ToDouble(dd[3]);
                            if (dd[4].Length > 1)
                            { ddd.Hlr = Convert.ToDouble(dd[4].Substring(0, dd[4].Length - 1)) / 100; }
                            else
                            { ddd.Hlr = 0; }
                            ddd.Lp = Convert.ToDouble(dd[5]);
                            ddd.Hp = Convert.ToDouble(dd[6]);
                            ddd.Num = Convert.ToDouble(dd[7]);
                            ddd.Numsaly = Convert.ToDouble(dd[8]);
                            if (dd[9].Length > 1)
                            { ddd.Chang = Convert.ToDouble(dd[9].Substring(0, dd[9].Length - 1)) / 100; }
                            else
                            {
                                ddd.Chang = 0;
                            }
                            var roomdatadocument = new BsonDocument(ddd.ToBsonDocument());
                            docunemts.Add(roomdatadocument);
                        }
                        //SqlHelper.PgSqlfsql.Insert<sz>().AppendData(ss).ExecuteIdentity();
                        var collection = mongoDBHelper.database.GetCollection<BsonDocument>(code);
                        collection.InsertManyAsync(docunemts);
                    }
                }
                catch (Exception)
                {
                }
                return "这是返回值";
            });

        }


        public static void StockNumdata()
        {
           // string chuangye = "300";
            string h1 = "600";
            string h2 = "601";
            string h3 = "603";
            string s = "000";
            string zx = "002";
            List<string> st = new List<string>();
           // st.Add(chuangye);
            st.Add(h1);
            st.Add(h2);
            st.Add(h3);
            st.Add(s);
            st.Add(zx);
            IDatabase db = StackExchangeRedisHelper.Instance.GetDatabase();
            int j = 0;
            foreach (string dd in st)
            {
                for (int i = 0; i < 1000; i++)
                {
                    string num = "";
                    num = dd + i.ToString("D3");

                    try
                    {
                        string apiUrl = "http://hq.sinajs.cn/list=sz{0}";
                        if (Convert.ToInt32(num) > 400000)
                        {
                            apiUrl = "http://hq.sinajs.cn/list=sh{0}";
                        }
                        apiUrl = string.Format(apiUrl, num);
                        Console.WriteLine(num);
                        HttpClient myHttpClient = new HttpClient();
                        myHttpClient.BaseAddress = new Uri(apiUrl);
                        HttpResponseMessage response = myHttpClient.GetAsync(apiUrl).Result;
                        string result = "";
                        if (response.IsSuccessStatusCode)
                        {
                            result = response.Content.ReadAsStringAsync().Result;
                        }
                        else
                        {
                        }
                        if (result.Length < 40)
                        {
                        }
                        else
                        {
                            string[] ddt = result.Split(',');

                            if (!(ddt[0].Split('"')[1].Contains("退") || ddt[0].Split('"')[1].Contains("ST")))
                            {
                                j++;
                                db.StringSet(j.ToString("D6"), num);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Default.Error("0001",ex.ToString());
                    }
                }
            }
        }
    }
}
