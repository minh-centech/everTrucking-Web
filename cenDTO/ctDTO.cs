namespace cenDTO
{
    public class ctDTO
    {
        //Properties

        public object ID { set; get; }
        public object IDDanhMucDonVi { set; get; }
        public object IDDanhMucChungTu { set; get; }
        public object IDDanhMucChungTuTrangThai { get; set; }

        public object So { get; set; }
        public object NgayLap { get; set; }

        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { set; get; }
        public string MaDanhMucNguoiSuDungCreate { set; get; }
        public string TenDanhMucNguoiSuDungCreate { set; get; }
        public object CreateDate;
        public object IDDanhMucNguoiSuDungEdit { set; get; }
        public string MaDanhMucNguoiSuDungEdit { set; get; }
        public string TenDanhMucNguoiSuDungEdit { set; get; }
        public object EditDate;
    }
}
