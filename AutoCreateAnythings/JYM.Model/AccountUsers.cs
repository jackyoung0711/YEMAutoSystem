namespace JYM.Model
{
    public class AccountUsers
    {
        public string BankCardNo { get; set; }

        //,[CellPhone]
        public string CellPhone { get; set; }

        //,[CgCellPhone]
        public string CgCellPhone { get; set; }

        //,[CredentialNo]
        public string CredentialNo { get; set; }

        //,[BankCardNo]
        public int Id { get; set; }

        //,[InviteBy]
        public string InviteBy { get; set; }

        //,[InviteFor]
        public string InviteFor { get; set; }

        //,[IsActivity]
        public int IsActivity { get; set; }

        //,[IsAuthInvest]
        public int IsAuthInvest { get; set; }

        //,[IsAuthWithdraw]
        public int IsAuthWithdraw { get; set; }

        //,[IsVerifed]
        public int IsVerifed { get; set; }

        //,[Pwd]
        public string Pwd { get; set; }

        //,[RealName]
        public string RealName { get; set; }

        //,[RechargeAmount]
        public long RechargeAmount { get; set; }

        //,[RechargeNums]
        public int RechargeNums { get; set; }

        //  [Id]
        public string RigisterTime { get; set; }

        //,[UserIdentifier]
        public string UserIdentifier { get; set; }

        //,[RigisterTime]
        //,[UserMac]
        public string UserMac { get; set; }
    }
}