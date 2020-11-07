using System;
using System.Collections.Generic;
using System.Text;

namespace SharingPark.Model.SQLServerTest
{
    public partial class T_Users
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public string NickName { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string HotVersion { get; set; }
        public string APKVersion { get; set; }
        public string LoginDeviceId { get; set; }
        public Nullable<System.DateTime> VCDate { get; set; }
        public string VerificationCode { get; set; }
        public string IP { get; set; }
        public string BossId { get; set; }
        public string ThirdUserId { get; set; }
        public string DeviceMode { get; set; }
        public string SystemVersion { get; set; }
        public string DeviceType { get; set; }
        public Nullable<int> UserType { get; set; }
        public Nullable<int> SignNum { get; set; }
        public Nullable<int> SexType { get; set; }
        public Nullable<int> SubscribeStatus { get; set; }
        public string WeiXin { get; set; }
        public string QQ { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<System.DateTime> CreatTime { get; set; }
        public string Desc { get; set; }
        public Nullable<int> VCodeNum { get; set; }
        public string OldAppVersion { get; set; }
        public Nullable<bool> IsNewAccount { get; set; }
        public string UserName { get; set; }
        public string IDCard { get; set; }
        public int VerifyStatus { get; set; }
        public string FirstBossId { get; set; }
        public string FirstWuid { get; set; }
        public int CountryId { get; set; }
    }
}
