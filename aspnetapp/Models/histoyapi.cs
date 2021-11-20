using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DockerWeb.Models
{
    public class histoyapi
    {
        ObjectId id;
        DateTime thedate;
        double bp;
        double ep;
        double hl;
        double hlr;
        double lp;
        double hp;
        double num;
        double numsaly;
        double chang;

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get => id; set => id = value; }
        public DateTime Thedate { get => thedate; set => thedate = value; }
        public double Bp { get => bp; set => bp = value; }
        public double Ep { get => ep; set => ep = value; }
        public double Hl { get => hl; set => hl = value; }
        public double Hlr { get => hlr; set => hlr = value; }
        public double Lp { get => lp; set => lp = value; }
        public double Hp { get => hp; set => hp = value; }
        public double Num { get => num; set => num = value; }
        public double Numsaly { get => numsaly; set => numsaly = value; }
        public double Chang { get => chang; set => chang = value; }
    }
}
