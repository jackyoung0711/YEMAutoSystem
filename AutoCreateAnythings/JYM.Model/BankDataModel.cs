using System.Collections.Generic;

namespace JYM.Model
{
    public class BankDataModel
    {
        //"pageSize": 20,
        //"pageNum": 10,
        //"totalPage": 183,
        //"page": 1

        public int page { get; set; }
        public int pageNum { get; set; }
        public string pageSize { get; set; }
        public int totalPage { get; set; }
        public List<userTrades> userTrades { get; set; }
    }

    public class userTrades
    {
        public string amount { get; set; }

        public string gmtCreate { get; set; }
        public string transType { get; set; }
    }
}