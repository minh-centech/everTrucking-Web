namespace cenDTO.DatabaseCore
{
    public class DanhMucNguoiSuDung : BaseDTO
    {
        public string IDDanhMucPhanQuyen { get; set; }
        public string MaDanhMucPhanQuyen { get; set; }
        public string TenDanhMucPhanQuyen { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string Password { get; set; }
        public string isAdmin { get; set; }

        public const string tableName = "DanhMucNguoiSuDung";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string getIDProcedureName = "Get_" + tableName + "_ID";
        public const string updatePasswordProcedureName = "Update_" + tableName + "_Password";
    }
}
