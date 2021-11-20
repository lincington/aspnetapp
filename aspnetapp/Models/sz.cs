using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DockerWeb.Models
{
    public class sz
    {
        string namenum;
        string name;
        decimal todayK;
        decimal lastS;
        decimal price;
        decimal todayH;
        decimal todayL;
        decimal todayJB;
        decimal todayJS;
        decimal todayNum;
        decimal todaySalay;
        decimal todayJBON;
        decimal todayJBOP;
        decimal todayJBTN;
        decimal todayJBTP;
        decimal todayJBTHN;
        decimal todayJBTHP;
        decimal todayJBFN;
        decimal todayJBFP;
        decimal todayJBFIN;
        decimal todayJBFIP;

        decimal todayJSON;
        decimal todayJSOP;
        decimal todayJSTN;
        decimal todayJSTP;
        decimal todayJSTHN;
        decimal todayJSTHP;
        decimal todayJSFN;
        decimal todayJSFP;
        decimal todayJSFIN;
        decimal todayJSFIP;

        string date;
        string time;
        ObjectId id;
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get => id; set => id = value; }
        /// <summary>
        /// 股票名字
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 今日开盘
        /// </summary>
        public decimal TodayK { get => todayK; set => todayK = value; }
        /// <summary>
        /// 昨日收盘价
        /// </summary>
        public decimal LastS { get => lastS; set => lastS = value; }
        /// <summary>
        /// 当前价格
        /// </summary>
        public decimal Price { get => price; set => price = value; }
        /// <summary>
        /// 今日最高
        /// </summary>
        public decimal TodayH { get => todayH; set => todayH = value; }
        /// <summary>
        /// 今日最低
        /// </summary>
        public decimal TodayL { get => todayL; set => todayL = value; }
        /// <summary>
        /// 竞买价，即“买一”报价
        /// </summary>
        public decimal TodayJB { get => todayJB; set => todayJB = value; }
        /// <summary>
        /// 竞卖价，即“卖一”报价；
        /// </summary>
        public decimal TodayJS { get => todayJS; set => todayJS = value; }
        /// <summary>
        /// 成交的股票数，由于股票交易以一百股为基本单位，所以在使用时，通常把该值除以一百
        /// </summary>
        public decimal TodayNum { get => todayNum; set => todayNum = value; }
        /// <summary>
        /// 成交金额，单位为“元”，为了一目了然，通常以“万元”为成交金额的单位，所以通常把该值除以一万；
        /// </summary>
        public decimal TodaySalay { get => todaySalay; set => todaySalay = value; }
        /// <summary>
        /// “买一”申请4695股，即47手；
        /// </summary>
        public decimal TodayJBON { get => todayJBON; set => todayJBON = value; }
        /// <summary>
        /// “买一”报价；
        /// </summary>
        public decimal TodayJBOP { get => todayJBOP; set => todayJBOP = value; }
        /// <summary>
        /// “买二” 股数
        /// </summary>
        public decimal TodayJBTN { get => todayJBTN; set => todayJBTN = value; }
        /// <summary>
        /// “买二” 价格
        /// </summary>
        public decimal TodayJBTP { get => todayJBTP; set => todayJBTP = value; }

        /// <summary>
        /// “买三” 股数
        /// </summary>
        public decimal TodayJBTHN { get => todayJBTHN; set => todayJBTHN = value; }
        /// <summary>
        /// “买三” 价格
        /// </summary>
        public decimal TodayJBTHP { get => todayJBTHP; set => todayJBTHP = value; }
        /// <summary>
        /// 买四 股数
        /// </summary>
        public decimal TodayJBFN { get => todayJBFN; set => todayJBFN = value; }
        /// <summary>
        /// 买四 价格
        /// </summary>
        public decimal TodayJBFP { get => todayJBFP; set => todayJBFP = value; }
        /// <summary>
        /// 买五 股数
        /// </summary>
        public decimal TodayJBFIN { get => todayJBFIN; set => todayJBFIN = value; }
        /// <summary>
        /// 买五 价格
        /// </summary>
        public decimal TodayJBFIP { get => todayJBFIP; set => todayJBFIP = value; }
        /// <summary>
        /// “卖一”申报3100股，即31手；
        /// </summary>
        public decimal TodayJSON { get => todayJSON; set => todayJSON = value; }
        /// <summary>
        /// “卖一”价格
        /// </summary>
        public decimal TodayJSOP { get => todayJSOP; set => todayJSOP = value; }
        /// <summary>
        /// “卖二”申报3100股，即31手；
        /// </summary>
        public decimal TodayJSTN { get => todayJSTN; set => todayJSTN = value; }
        /// <summary>
        /// “卖二”价格
        /// </summary>
        public decimal TodayJSTP { get => todayJSTP; set => todayJSTP = value; }
        /// <summary>
        ///  “卖三”股数
        /// </summary>
        public decimal TodayJSTHN { get => todayJSTHN; set => todayJSTHN = value; }
        /// <summary>
        /// 卖三价格
        /// </summary>
        public decimal TodayJSTHP { get => todayJSTHP; set => todayJSTHP = value; }
        /// <summary>
        /// 卖四 股数
        /// </summary>
        public decimal TodayJSFN { get => todayJSFN; set => todayJSFN = value; }
        /// <summary>
        /// 卖四 价格
        /// </summary>
        public decimal TodayJSFP { get => todayJSFP; set => todayJSFP = value; }
        /// <summary>
        /// 卖五 股数
        /// </summary>
        public decimal TodayJSFIN { get => todayJSFIN; set => todayJSFIN = value; }
        /// <summary>
        /// 卖五 价格
        /// </summary>
        public decimal TodayJSFIP { get => todayJSFIP; set => todayJSFIP = value; }
        public string Date { get => date; set => date = value; }
        public string Time { get => time; set => time = value; }
        public string Namenum { get => namenum; set => namenum = value; }
    }


}
