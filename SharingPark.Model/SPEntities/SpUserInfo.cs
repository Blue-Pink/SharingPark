using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace SharingPark.Model.SPEntities
{
    [SugarTable("sp_user_info")]
    public class SpUserInfo
    {
        [SugarColumn(IsPrimaryKey = true, ColumnName = "nickname")]
        public string NickName { get; set; }
        [SugarColumn(ColumnName = "phone_number")]
        public string PhoneNumber { get; set; }
        [SugarColumn(ColumnName = "mailbox")]
        public string Mailbox { get; set; }
        [SugarColumn(ColumnName = "password")]
        public string Password { get; set; }
        [SugarColumn(ColumnName = "gender_mark")]
        public int GenderMark { get; set; }
        [SugarColumn(ColumnName = "face_mark")]
        public int FaceMark { get; set; }
        [SugarColumn(ColumnName = "introduction")]
        public string Introduction { get; set; }
        [SugarColumn(ColumnName = "register_date")]
        public DateTime RegisterDate { get; set; }
        [SugarColumn(ColumnName = "update_date")]
        public DateTime UpdateDate { get; set; }
    }
}
