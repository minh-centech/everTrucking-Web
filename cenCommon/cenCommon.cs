using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace cenCommon
{
    public static class cenCommon
    {
        public static string EncryptString(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            // Buoc 1: Bam chuoi su dung MD5

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(GlobalVariables.EncryptPhase));

            // Step 2. Tao doi tuong TripleDESCryptoServiceProvider moi
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider
            {

                // Step 3. Cai dat bo ma hoa
                Key = TDESKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            // Step 4. Convert chuoi (Message) thanh dang byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Ma hoa chuoi
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                //Xoa moi thong tin ve Triple DES va HashProvider de dam bao an toan
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Tra ve chuoi da ma hoa bang thuat toan Base64
            return Convert.ToBase64String(Results);
        }
        public static string DecryptString(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. Bam chuoi su dung MD5

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(GlobalVariables.EncryptPhase));

            // Step 2. Tao doi tuong TripleDESCryptoServiceProvider moi
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider
            {

                // Step 3. Cai dat bo giai ma
                Key = TDESKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            // Step 4. Convert chuoi (Message) thanh dang byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Bat dau giai ma chuoi
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Xoa moi thong tin ve Triple DES va HashProvider de dam bao an toan
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Tra ve ket qua bang dinh dang UTF8
            return UTF8.GetString(Results);
        }
        public static String TraTuDien(String Ma)
        {
            if (Ma == null) return "";
            String rWord = Ma;
            if (GlobalVariables.dtTuDien != null && GlobalVariables.dtTuDien.Rows.Count > 0)
            {
                DataRow[] drTuDien = GlobalVariables.dtTuDien.Select("Ma = '" + Ma + "'");
                if (drTuDien != null && drTuDien.Length > 0)
                    rWord = drTuDien[0]["Ten"].ToString();
            }
            return rWord;
        }
        //Khai báo biến khác
        static readonly string[] strDigit = { "không ", "một ", "hai ", "ba ", "bốn ", "năm ", "sáu ", "bảy ", "tám ", "chín " };
        static readonly string[] strGroup = { "nghìn ", "triệu ", "tỷ " };
        /// <summary>
        /// Đọc group 3 số
        /// </summary>
        /// <param name="iNum">Số cần đọc</param>
        /// <returns></returns>
        private static String Group3(short iNum)
        {
            string iNumStr = null;
            byte[] iDg = new byte[3];
            string[] sResult = new string[3];
            if (iNum == 0)
            {
                return "";
            }
            iNumStr = iNum.ToString();
            while (iNumStr.Length < 3)
            {
                iNumStr = "0" + iNumStr;
            }

            iDg[2] = Convert.ToByte(iNumStr[0].ToString());
            iDg[1] = Convert.ToByte(iNumStr[1].ToString());
            iDg[0] = Convert.ToByte(iNumStr[2].ToString());

            sResult[2] = strDigit[iDg[2]] + "trăm ";
            if (iDg[1] >= 2)
            {
                sResult[1] = strDigit[iDg[1]] + "mươi ";
            }
            else if (iDg[1] == 1)
            {
                sResult[1] = "mười ";
            }
            else if (iDg[1] == 0)
            {
                sResult[1] = "lẻ ";
            }

            sResult[0] = strDigit[iDg[0]];

            if (iDg[0] == 0)
            {
                sResult[0] = "";
                if (iDg[1] == 0)
                {
                    sResult[1] = "";
                }
            }
            else if (iDg[0] == 1 && iDg[1] >= 2)
            {
                sResult[0] = "mốt ";
            }
            else if (iDg[0] == 5 && iDg[1] >= 1)
            {
                sResult[0] = "lăm ";
            }

            return sResult[2] + sResult[1] + sResult[0];
        }
        /// <summary>
        /// Đọc tiền bằng chữ
        /// </summary>
        /// <param name="iNum">Chuỗi tiền</param>
        /// <returns></returns>
        public static String SoTienBangChu(string iNum)
        {
            try
            {
                short iG = 0;
                byte k = 0;
                string st = null;
                string s = "";
                bool negative = false;
                //Xử lí số âm
                if (iNum.StartsWith("-"))
                {
                    negative = true;
                    iNum = iNum.Replace("-", "");
                }

                for (short i = Convert.ToInt16((iNum.Length - 6)); i >= iNum.Length % 3; i += -3)
                {
                    iG = short.Parse(iNum.Substring(i, 3));
                    st = Group3(iG);
                    if (!string.IsNullOrEmpty(st))
                    {
                        st += strGroup[k];
                    }
                    else if (k % 3 == 2)
                    {
                        st = strGroup[k];
                    }
                    k = Convert.ToByte(((k + 1) % 3));
                    s = st + s;
                }
                if (iNum.Length % 3 != 0 && iNum.Length > 3)
                {
                    iG = short.Parse(iNum.Substring(0, iNum.Length % 3));
                    st = Group3(iG);
                    st += strGroup[k];
                    s = st + s;
                }
                s = s + Group3(short.Parse(iNum.Substring(Math.Max(iNum.Length - 3, 0))));
                if (string.IsNullOrEmpty(s))
                {
                    s = "không";
                }
                else if (s.Substring(0, 13) == "không trăm lẻ")
                {
                    s = s.Substring(14);
                }
                else if (s.Substring(0, 11) == "không trăm ")
                {
                    s = s.Substring(11);
                }
                s = s.Substring(0, 1).ToUpper() + s.Substring(1);

                if (negative)
                    s = "Âm " + s;
                return s;
            }
            catch (Exception ex)
            {
                ErrorMessageOkOnly(ex.Message);
                return null;
            }
        }
        //Đổi màu từ UInt sang Color - dùng để bôi màu column header và detail bold
        public static Color UIntToColor(uint color)
        {
            byte a = (byte)(color >> 24);
            byte r = (byte)(color >> 16);
            byte g = (byte)(color >> 8);
            byte b = (byte)(color >> 0);
            return Color.FromArgb(a, r, g, b);
        }
        public static uint ColorToUInt(Color color)
        {
            return (uint)((color.A << 24) | (color.R << 16) |
                          (color.G << 8) | (color.B << 0));
        }
        /// <summary>
        /// Thông báo lỗi, OkOnly, lấy theo MessageID hoặc Message nếu MessageID=0
        /// </summary>
        /// <param name="Message">Chuỗi hiển thị nếu MessageID=0</param>
        public static void ErrorMessageOkOnly(string Message)
        {
            MessageBox.Show(Message, "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Yêu cầu xác nhận
        /// </summary>
        /// <param name="Message">Chuỗi hiển thị</param>
        /// /// <param name="Caption">Chuỗi hiển thị tiêu đề cửa sổ</param>
        /// <param name="DialogType">0: YesNo, 1: YesNoCancel</param>
        public static DialogResult QuestionMessage(string Message, Byte DialogType)
        {
            DialogResult KetQua;
            KetQua = MessageBox.Show(Message, "Xác nhận!", (DialogType == 0) ? MessageBoxButtons.YesNo : MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            return KetQua;
        }
        public static void InfoMessage(string Message)
        {
            UltraDesktopAlert uDA = new UltraDesktopAlert
            {
                UseAppStyling = false,
                UseOsThemes = DefaultableBoolean.False
            };
            UltraDesktopAlertShowWindowInfo uDAInfo = new UltraDesktopAlertShowWindowInfo
            {
                ScreenPosition = ScreenPosition.TopRight,
                Caption = "Thông báo",
                Text = Message
            };
            uDA.Show(uDAInfo);
        }
        public static void filterGrid(UltraGrid ug, String filterText)
        {
            UltraGridBand uBand = null;
            uBand = (ug != null && ug.DisplayLayout.Bands.Count > 0) ? ug.DisplayLayout.Bands[0] : null;
            if (uBand != null && uBand.Columns.Exists("filterColumn"))
            {
                uBand.Columns["filterColumn"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                uBand.ColumnFilters["filterColumn"].FilterConditions.Clear();
                uBand.ColumnFilters["filterColumn"].FilterConditions.Add(FilterComparisionOperator.Contains, filterText);
                if (ug.Rows.GetFilteredInNonGroupByRows().Count() > 0)
                {
                    ug.ActiveRow = ug.Rows.GetFilteredInNonGroupByRows()[0];
                    ug.ActiveRow.Selected = true;
                }
                else
                {
                    ug.ActiveRow = null;
                }
            }
        }
        public static void ExportGrid2Excel(UltraGrid ug)
        {
            String FileName = OpenSaveFileDialog("Chọn file lưu kết quả export", "", "Excel file (*.xls)|*.xls");
            if (FileName != "")
            {
                UltraGridExcelExporter ugE = new UltraGridExcelExporter();
                ugE.Export(ug, FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003);
                ugE.Dispose();
                cenCommon.InfoMessage("Kết xuất thành công!");
            }
        }
        public static String OpenSaveFileDialog(String Title, String FileName, String FileExtension)
        {
            SaveFileDialog openFileDlg = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = FileExtension,
                Title = Title,
                FileName = FileName,
                RestoreDirectory = true
            };
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                return openFileDlg.FileName;
            }
            else
                return DBNull.Value.ToString();
        }
        public static String OpenFileDialog(String Title, String FileName, String FileExtension)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = FileExtension,
                Title = Title,
                FileName = FileName,
                RestoreDirectory = true
            };
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                return openFileDlg.FileName;
            }
            else
                return DBNull.Value.ToString();
        }
        public static Object NgayHachToan()
        {
            DateTime Ngay;
            try
            {
                SqlConnection connection = new SqlConnection(GlobalVariables.ConnectionString);
                SqlCommand sqlCMD = new SqlCommand("select GetDate()", connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                Ngay = Convert.ToDateTime(sqlCMD.ExecuteScalar());
                connection.Close();
                return Ngay;
            }
            catch
            {
                return DateTime.Now;
            }
        }
        public static String ChuanHoaChuoi(String Chuoi)
        {
            Chuoi = Chuoi.Trim();
            Chuoi = Chuoi.Replace("\n", "");
            return Chuoi;
        }
        public static String ChuanHoaChuoiUpper(String Chuoi)
        {
            Chuoi = Chuoi.Trim();
            Chuoi = Chuoi.Replace("\n", "");
            Chuoi = Chuoi.ToUpper();
            return Chuoi;
        }
        public static String ChuoiNgayDDMMYYY(String ChuoiNgay)
        {
            String Ngay = ChuoiNgay.Substring(0, 2);
            String Thang = ChuoiNgay.Substring(3, 2);
            String Nam = ChuoiNgay.Substring(6, 4);
            String Gio = (ChuoiNgay.Length == 10) ? "00" : ChuoiNgay.Substring(11, 2);
            String Phut = (ChuoiNgay.Length == 10) ? "00" : ChuoiNgay.Substring(14, 2);
            String Giay = (ChuoiNgay.Length == 10) ? "00" : ChuoiNgay.Substring(17, 2);
            return Nam + "/" + Thang + "/" + Ngay + " " + Gio + ":" + Phut + ":" + Giay;
        }
        public static Decimal Convert2Decimal(object DecNum)
        {
            if (DecNum == null || DecNum == DBNull.Value)
                return 0;
            else
            {
                Decimal.TryParse(DecNum.ToString(), out decimal dNum);
                return dNum;
            }
        }
        public static Double Convert2Double(object DecNum)
        {
            if (DecNum == null || DecNum == DBNull.Value)
                return 0;
            else
            {
                Double.TryParse(DecNum.ToString(), out double dNum);
                return dNum;
            }
        }
        public static Boolean CheckNumberNullOrZero(object DecNum)
        {
            if (DecNum == null || DecNum == DBNull.Value)
                return true;
            else
            {
                return Convert.ToDecimal(DecNum) == 0;
            }
        }
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static void SetGridColumnWidth(UltraGridColumn column)
        {
            String ColumnKey = column.Key.ToUpper();
            if (column.DataType == typeof(string))
            {
                if (ColumnKey == "SO" || ColumnKey == "MA" || ColumnKey == "KYHIEU" || ColumnKey == "LOAIMANHINH" || ColumnKey == "DEBITNOTE" || ColumnKey == "TENLOAIHANG" || ColumnKey == "BIENSO" || ColumnKey.StartsWith("MADANHMUC") || ColumnKey.StartsWith("DONVITINH") || ColumnKey.StartsWith("NGAY") || ColumnKey.StartsWith("GIO"))
                    column.Width = GlobalVariables.DoRongCotMaGrid;
                else
                    column.Width = GlobalVariables.DoRongCotDienGiaiGrid;
            }
            else
            {
                if (ColumnKey.StartsWith("DONGIA") || ColumnKey.StartsWith("SOTIEN") || ColumnKey.StartsWith("TONG"))
                    column.Width = GlobalVariables.DoRongCotMaGrid;
                else
                    column.Width = GlobalVariables.DoRongCotKhacGrid;
                if (column.DataType == typeof(bool))
                {
                    column.Width = 50;
                }
            }

        }
        public static void SetGridColumnMask(UltraGridColumn column)
        {
            String ColumnKey = column.Key.ToUpper();
            if (column.DataType == typeof(DateTime))
                column.MaskInput = GlobalVariables.MaskInputDate;
            if (column.DataType == typeof(Double) || column.DataType == typeof(float) || column.DataType == typeof(byte) || column.DataType == typeof(int) || column.DataType == typeof(long))
            {
                column.CellAppearance.TextHAlign = HAlign.Right;
                if (ColumnKey.StartsWith("DONGIA") || ColumnKey.StartsWith("THANHTIEN") || ColumnKey.StartsWith("SOTIEN"))
                {
                    column.Format = GlobalVariables.FormatTien;
                    column.MaskInput = GlobalVariables.DinhDangNhapTien;
                }
                else if (ColumnKey.StartsWith("STT") || ColumnKey == "SOLUONG" || ColumnKey == "SOLUONGDUYET" || ColumnKey == "KICHTHUOCDAI" || ColumnKey == "KICHTHUOCDAIDUYET" || ColumnKey == "KICHTHUOCRONG" || ColumnKey == "KICHTHUOCRONGDUYET" || ColumnKey == "LENGTH" || ColumnKey == "WIDTH" || ColumnKey == "THUTU" || ColumnKey == "THUTUHIENTHI" || ColumnKey == "SEQ" || ColumnKey == "LANTAMUNG")
                {
                    column.Format = "##,##0";
                    column.MaskInput = "-nnn,nnn,nnn,nnn";
                }
                else
                {
                    column.Format = GlobalVariables.FormatSoLuong;
                    column.MaskInput = GlobalVariables.DinhDangNhapSoLuong;
                }
            }
        }
        public static bool IsNull(object obj)
        {
            return (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "" || obj.ToString().ToUpper() == "NULL");
        }
        public static string stringParse(object value)
        {
            return (IsNull(value)) ? "" : value.ToString();
        }
        public static byte? stringParseByte(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (byte.TryParse(value.ToString(), out byte t))
                    return t;
                else
                    return null;
            }
        }
        public static int? stringParseInt(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (int.TryParse(value.ToString(), out int t))
                    return t;
                else
                    return null;
            }
        }
        public static long? stringParseLong(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (long.TryParse(value.ToString(), out long t))
                    return t;
                else
                    return null;
            }
        }
        public static double? stringParseDouble(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (double.TryParse(value.ToString(), out double t))
                    return t;
                else
                    return null;
            }
        }
        public static decimal? stringParseDecimal(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (decimal.TryParse(value.ToString(), out decimal t))
                    return t;
                else
                    return null;
            }
        }
        public static float? stringParseFloat(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (float.TryParse(value.ToString(), out float t))
                    return t;
                else
                    return null;
            }
        }
        public static bool stringParseBoolean(object value)
        {
            if (IsNull(value))
            {
                return false;
            }
            else
            {
                if (bool.TryParse(value.ToString(), out bool t))
                    return t;
                else
                    return false;
            }
        }
        public static DateTime? stringParseDateTime(object value)
        {
            if (IsNull(value))
                return null;
            else
            {
                if (DateTime.TryParse(value.ToString(), out DateTime t))
                    return t;
                else
                    return null;
            }
        }
        public static byte byteParse(object value)
        {
            if (IsNull(value))
                return 0;
            else
            {
                if (byte.TryParse(value.ToString(), out byte t))
                    return t;
                else
                    return 0;
            }
        }
        public static int intParse(object value)
        {
            if (IsNull(value))
                return 0;
            else
            {
                if (int.TryParse(value.ToString(), out int t))
                    return t;
                else
                    return 0;
            }
        }
        public static long longParse(object value)
        {
            if (IsNull(value))
                return 0;
            else
            {
                if (long.TryParse(value.ToString(), out long t))
                    return t;
                else
                    return 0;
            }
        }
        public static double doubleParse(object value)
        {
            if (IsNull(value))
                return 0;
            else
            {
                if (double.TryParse(value.ToString(), out double t))
                    return t;
                else
                    return 0;
            }
        }
        public static decimal decimalParse(object value)
        {
            if (IsNull(value))
                return 0;
            else
            {
                if (decimal.TryParse(value.ToString(), out decimal t))
                    return t;
                else
                    return 0;
            }
        }
        public static float floatParse(object value)
        {
            if (IsNull(value))
                return 0;
            else
            {
                if (float.TryParse(value.ToString(), out float t))
                    return t;
                else
                    return 0;
            }
        }
        public static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null) return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public static string AllPropertiesAndValues(object obj)
        {
            string strPropertiesAndValues = string.Empty;
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (!prop.Name.StartsWith("ID") && prop.Name != "HinhAnh" && prop.Name != "CreateDate" && prop.Name != "EditDate" && prop.Name != "DataRowState" && !prop.Name.StartsWith("MaDanhMucNguoiSuDung") && !prop.Name.StartsWith("TenDanhMucNguoiSuDung") && !IsNull(prop.GetValue(obj, null)))
                    strPropertiesAndValues += prop.Name + ": " + prop.GetValue(obj, null) + "; ";
            }
            return strPropertiesAndValues;
        }
        public static int MaxTempID(DataTable dt)
        {
            int MaxTempID = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.RowState != DataRowState.Deleted && int.TryParse(dr["ID"].ToString(), out int tempID))
                    MaxTempID = Math.Min(MaxTempID, tempID);
            }
            return MaxTempID - 1;
        }
    }
    public static class LoaiManHinh
    {
        //Kinh doanh
        public const string IDHopDongVanChuyen = "101";
        public const string NameHopDongVanChuyen = "Hợp đồng vận chuyển";
        public const string IDDonHang = "102";
        public const string NameDonHang = "Đơn hàng";
        public const string IDThanhToanTamUng = "103";
        public const string NameThanhToanTamUng = "Theo dõi thanh toán tạm ứng";
        public const string IDChotDoanhThuGuiKeToan = "104";
        public const string NameChotDoanhThuGuiKeToan = "Chốt doanh thu gửi kế toán";
        //Điều vận
        public const string IDTrangThaiXe = "201";
        public const string NameTrangThaiXe = "Trạng thái xe";
        public const string IDQuanLyDau = "202";
        public const string NameQuanLyDau = "Quản lý dầu";
        public const string IDPhieuDoNhienLieu = "203";
        public const string NamePhieuDoNhienLieu = "Phiếu đổ nhiên liệu";
        public const string IDSuaChua = "204";
        public const string NameSuaChua = "Sửa chữa";
        public const string IDChiPhiVanTai = "205";
        public const string NameChiPhiVanTai = "Chi phí vận tải";
        public const string IDChotChiPhiVanTaiGuiKeToan = "206";
        public const string NameChotChiPhiVanTaiGuiKeToan = "Chốt chi phí vận tải gửi kế toán";
        public const string IDChiPhiVanTaiBoSung = "207";
        public const string NameChiPhiVanTaiBoSung = "Chi phí vận tải bổ sung";
        public const string IDChotChiPhiVanTaiBoSungGuiKeToan = "208";
        public const string NameChotChiPhiVanTaiBoSungGuiKeToan = "Chốt chi phí vận tải bổ sung gửi kế toán";
        public const string IDTamUng = "209";
        public const string NameTamUng = "Tạm ứng";
        public const string IDDieuHanh = "210";
        public const string NameDieuHanh = "Điều hành";
        public const string IDHotline = "211";
        public const string NameHotline = "Hotline";
        public const string IDInGiayVanTai = "212";
        public const string NameInGiayVanTai = "In giấy vận tải";
        public const string IDKeHoachVanTai = "213";
        public const string NameKeHoachVanTai = "Kế hoạch vận tải";
        //Kế toán
        public const string IDDuyetTamUngHoanUngKinhDoanh = "301";
        public const string NameDuyetTamUngHoanUngKinhDoanh = "Duyệt tạm ứng, hoàn ứng kinh doanh";
        public const string IDDuyetDeNghiThanhToanKinhDoanh = "302";
        public const string NameDuyetDeNghiThanhToanKinhDoanh = "Duyệt đề nghị thanh toán kinh doanh";
        public const string IDDuyetDoanhThuKinhDoanh = "303";
        public const string NameDuyetDoanhThuKinhDoanh = "Duyệt doanh thu kinh doanh";
        public const string IDDuyetTamUngChuyenDieuVan = "304";
        public const string NameDuyetTamUngChuyenDieuVan = "Duyệt tạm ứng chuyển điều vận";
        public const string IDDuyetDeNghiThanhToanChuyenDieuVan = "305";
        public const string NameDuyetDeNghiThanhToanChuyenDieuVan = "Duyệt đề nghị thanh toán chuyển điều vận";
        public const string IDDuyetChiPhiDieuVan = "306";
        public const string NameDuyetChiPhiDieuVan = "Duyệt chi phí điều vận";
        public const string IDDuyetChiPhiDieuVanBoSung = "307";
        public const string NameDuyetChiPhiDieuVanBoSung = "Duyệt chi phí điều vận bổ sung";
        public const string IDDuyetTamUngDieuVan = "308";
        public const string NameDuyetTamUngDieuVan = "Duyệt tạm ứng điều vận";
    }
    public static class LoaiBaoCao
    {
        //Tham số danh mục báo cáo
        public const String BC_DOANHTHU_KD = "rep_BC_DOANHTHU_KD";
        public const String BC_DOANHTHU_KD_CNKH = "rep_BC_DOANHTHU_KD_CNKH";
        public const String BC_CHI_PHI_VAN_TAI = "rep_BC_CHI_PHI_VAN_TAI";
        public const String BC_CHI_PHI_VAN_TAI_BO_SUNG = "rep_BC_CHI_PHI_VAN_TAI_BO_SUNG";
        public const String BC_DOANHTHU_KT = "rep_BC_DOANHTHU_KT";
        public const String BC_LOINHUAN_KD = "rep_BC_LOINHUAN_KD";
        public const String BC_SUACHUA = "rep_BC_SUACHUA";
        public const String BC_TU_QT = "rep_BC_TU_QT";
        public const String BC_TU_TIENDUONG = "rep_BC_TU_TIENDUONG";
    }
    public static class ThamSoHeThong
    {
        //Tham số danh mục loại đối tượng
        public const String MaThamSoLoaiDoiTuongTinhThanh = "MaLoaiDoiTuong_TinhThanh";
        public const String MaThamSoLoaiDoiTuongNhienLieu = "MaLoaiDoiTuong_NhienLieu";
        public const String MaThamSoLoaiDoiTuongNhomXe = "MaLoaiDoiTuong_NhomXe";
        public const String MaThamSoLoaiDoiTuongChiPhiDieuVanThuongXuyen = "MaLoaiDoiTuong_ChiPhiDieuVanThuongXuyen";
        public const String MaThamSoLoaiDoiTuongNhomHangVanChuyen = "MaLoaiDoiTuong_NhomHangVanChuyen";
        public const String MaThamSoLoaiDoiTuongSuaChuaThayTheDoDau = "MaLoaiDoiTuong_SuaChuaThayTheDoDau";
        public const String MaThamSoLoaiDoiTuongTrangThaiXe = "MaLoaiDoiTuong_TrangThaiXe";
        public const String MaThamSoLoaiDoiTuongChiPhiHaiQuanKinhDoanh = "MaLoaiDoiTuong_ChiPhiHaiQuanKinhDoanh";
        public const String MaThamSoLoaiDoiTuongHangTau = "MaLoaiDoiTuong_HangTau";
        public const String MaThamSoLoaiDoiTuongNhaCungCapTrich1PhanTram = "MaLoaiDoiTuong_NhaCungCapTrich1%";
        public const String MaThamSoLoaiDoiTuongTinhTrangLamViec = "MaLoaiDoiTuong_TinhTrangLamViec";
        public const String MaThamSoLoaiDoiTuongPhanLoaiDoiTuong = "MaLoaiDoiTuong_PhanLoaiDoiTuong";
        public const String MaThamSoLoaiDoiTuongPhongBan = "MaLoaiDoiTuong_PhongBan";
        public const String MaThamSoLoaiDoiTuongPhanLoaiChucVu = "MaLoaiDoiTuong_PhanLoaiChucVu";
        public const String MaThamSoLoaiDoiTuongXe = "MaLoaiDoiTuong_Xe";
        public const String MaThamSoLoaiDoiTuongMooc = "MaLoaiDoiTuong_Mooc";
        public const String MaThamSoLoaiDoiTuongTaiXe = "MaLoaiDoiTuong_TaiXe";
        public const String MaThamSoLoaiDoiTuongKhachHang = "MaLoaiDoiTuong_KhachHang";
        public const String MaThamSoLoaiDoiTuongKhachHangPhanCap = "MaLoaiDoiTuong_KhachHangPhanCap";
        public const String MaThamSoLoaiDoiTuongTuyenVanTai = "MaLoaiDoiTuong_TuyenVanTai";
        public const String MaThamSoLoaiDoiTuongGiaNhienLieu = "MaLoaiDoiTuong_GiaNhienLieu";
        public const String MaThamSoLoaiDoiTuongHangHoa = "MaLoaiDoiTuong_HangHoa";
        public const String MaThamSoLoaiDoiTuongDinhMucChiPhiHaiQuan = "MaLoaiDoiTuong_DinhMucChiPhiHaiQuan";
        public const String MaThamSoLoaiDoiTuongDinhMucChiPhi = "MaLoaiDoiTuong_DinhMucChiPhi";
        public const String MaThamSoLoaiDoiTuongXeDinhMucNhienLieu = "MaLoaiDoiTuong_XeDinhMucNhienLieu";
        public const String MaThamSoLoaiDoiTuongNhanSu = "MaLoaiDoiTuong_NhanSu";
        public const String MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucNhienLieu = "MaLoaiDoiTuong_TuyenVanTaiDinhMucNhienLieu";
        public const String MaThamSoLoaiDoiTuongTuyenVanTaiDinhMucChiPhi = "MaLoaiDoiTuong_TuyenVanTaiDinhMucChiPhi";
        public const String MaThamSoLoaiDoiTuongCangICD = "MaLoaiDoiTuong_CangICD";
        public const String MaThamSoLoaiDoiTuongKho = "MaLoaiDoiTuong_Kho";
        public const String MaThamSoLoaiDoiTuongThauPhu = "MaLoaiDoiTuong_ThauPhu";
        public const String MaThamSoLoaiDoiTuongDonViCungCapNhienLieu = "MaLoaiDoiTuong_DonViCungCapNhienLieu";
        public const String MaThamSoLoaiDoiTuongLoaiContainer = "MaLoaiDoiTuong_LoaiContainer";
        //Tham số danh mục chứng từ
        public const string MaThamSoChungTuHopDongVanChuyen = "MaChungTu_HopDongVanChuyen";
        public const string MaThamSoChungTuDonHang = "MaChungTu_DonHang";
        public const string MaThamSoChungTuThanhToanTamUng = "MaChungTu_ThanhToanTamUng";
        public const string MaThamSoChungTuChotDoanhThuGuiKeToan = "MaChungTu_ChotDoanhThuGuiKeToan";
        //
        public const string MaThamSoChungTuTrangThaiXe = "MaChungTu_TrangThaiXe";
        public const string MaThamSoChungTuQuanLyDau = "MaChungTu_QuanLyDau";
        public const string MaThamSoChungTuPhieuDoNhienLieu = "MaChungTu_PhieuDoNhienLieu";
        public const string MaThamSoChungTuSuaChua = "MaChungTu_SuaChua";
        public const string MaThamSoChungTuChiPhiVanTai = "MaChungTu_ChiPhiVanTai";
        public const string MaThamSoChungTuChotChiPhiVanTai = "MaChungTu_ChotChiPhiVanTai";
        public const string MaThamSoChungTuChiPhiVanTaiBoSung = "MaChungTu_ChiPhiVanTaiBoSung";
        public const string MaThamSoChungTuChotChiPhiVanTaiBoSung = "MaChungTu_ChotChiPhiVanTaiBoSung";
        public const string MaThamSoChungTuTamUng = "MaChungTu_TamUng";
        public const string MaThamSoChungTuDieuHanh = "MaChungTu_DieuHanh";
        public const string MaThamSoChungTuHotline = "MaChungTu_Hotline";
        public const string MaThamSoChungTuInGiayVanTai = "MaChungTu_InGiayVanTai";
        public const string MaThamSoChungTuKeHoachVanTai = "MaChungTu_KeHoachVanTai";
        //
        public const string MaThamSoChungTuDuyetTamUngHoanUngKinhDoanh = "MaChungTu_DuyetTamUngHoanUngKinhDoanh";
        public const string MaThamSoChungTuDuyetDeNghiThanhToanKinhDoanh = "MaChungTu_DuyetDeNghiThanhToanKinhDoanh";
        public const string MaThamSoChungTuDuyetDoanhThuKinhDoanh = "MaChungTu_DuyetDoanhThuKinhDoanh";
        public const string MaThamSoChungTuDuyetTamUngChuyenDieuVan = "MaChungTu_DuyetTamUngChuyenDieuVan";
        public const string MaThamSoChungTuDuyetDeNghiThanhToanChuyenDieuVan = "MaChungTu_DuyetDeNghiThanhToanChuyenDieuVan";
        public const string MaThamSoChungTuDuyetChiPhMaThamSoChungTuieuVan = "MaChungTu_DuyetChiPhiDieuVan";
        public const string MaThamSoChungTuDuyetChiPhMaThamSoChungTuieuVanBoSung = "MaChungTu_DuyetChiPhiDieuVanBoSung";
        public const string MaThamSoChungTuDuyetTamUngDieuVan = "MaChungTu_DuyetTamUngDieuVan";

    }
    public static class ThamSoNguoiSuDung
    {
        public const string ctDonHang_TuNgay = "ctDonHang_TuNgay";
        public const string ctDonHang_DenNgay = "ctDonHang_DenNgay";

        public const string ctHopDongVanChuyen_TuNgay = "ctHopDongVanChuyen_TuNgay";
        public const string ctHopDongVanChuyen_DenNgay = "ctHopDongVanChuyen_DenNgay";

        public const string ctSuaChua_TuNgay = "ctSuaChua_TuNgay";
        public const string ctSuaChua_DenNgay = "ctSuaChua_DenNgay";
    }
    public static class ThaoTacDuLieu
    {
        public const int Xem = 0;
        public const string DienGiaiXem = "Xem";
        public const int Them = 1;
        public const string DienGiaiThem = "Thêm mới";
        public const int Sua = 2;
        public const string DienGiaiSua = "Chỉnh sửa";
        public const int Copy = 3;
        public const string DienGiaiCopy = "Sao chép";
        public const int Xoa = 4;
        public const string DienGiaiXoa = "Xóa";
    }
    public static class GlobalVariables
    {
        //Chuỗi kết nối
        public static string ConnectionString = @"Data Source=sangtaoketnoi.vn;Initial Catalog=everTRUCKING-2021;Persist Security Info=True;User ID=everTRUCKING-2021;Password=everTRUCKING-2021;Connect Timeout=60";
        //Tiền tố
        public const String prefix_DataRelation = "rlt";
        //Tham số định dạng cột dữ liệu
        public static String TenCotNgayThang = "";
        public static String TenCotThoiGian = "";
        public static String TenCotSoLuong = "";
        public static String TenCotKhoiLuong = "";
        public static String TenCotTrongLuong = "";
        public static String TenCotTien = "";
        public static String TenCotGia = "";
        public static String TenCotMaSo = "";
        public static String TenCotDienGiai = "";
        //
        public static string DefaultFixedColumn = "[Stt][MaDanhMucXe][TenDanhMucNguonGocXe][TenDanhMucLoaiXe][TenDanhMucBai]";
        //
        public static Int16 DoRongCotMaGrid = 120;
        public static Int16 DoRongCotDienGiaiGrid = 200;
        public static Int16 DoRongCotKhacGrid = 80;
        //
        public static Double DoRongCotNgayThangReport = 1;
        public static Double DoRongCotSoLuongReport = 1.5;
        public static Double DoRongCotKhoiLuongReport = 1.5;
        public static Double DoRongCotTrongLuongReport = 1.5;
        public static Double DoRongCotTienReport = 1.5;
        public static Double DoRongCotGiaReport = 1;
        public static Double DoRongCotMaSoReport = 1;
        public static Double DoRongCotDienGiaiReport = 4;

        public static String TenCotDropdown = "(IDDanhMucToCongNhan)(TenChuHang)";
        //Từ điển
        public static DataTable dtTuDien;
        //Tham số thông tin đơn vị
        public static string IDDonVi = "1";
        //Tham số ngôn ngữ
        public static CultureInfo ci = CultureInfo.CreateSpecificCulture("vi-VN");

        public static String FormatThoiGian = "dd/MM/yyyy HH:mm:ss"; //Chuỗi định dạng thời gian
        public static String FormatNgayThangNam = "dd/MM/yyyy"; //Chuỗi định dạng ngày tháng năm
        public static String FormatNgayThang = "dd/mm"; //Chuỗi định dạng ngày tháng

        public static String MaskInputDateTime = "dd/mm/yyyy hh:mm:ss"; //Chuỗi định dạng ngày giờ
        public static String MaskInputDate = "dd/mm/yyyy"; //Chuỗi định dạng ngày tháng
        public static String MaskInputTime = "hh:mm"; //Chuỗi định dạng giờ

        public static String DecimalSymbol = ","; //Dấu phân cách hàng thập phân
        public static String DigitSymbol = "."; //Dấu phân cách hàng nghìn
        public static String FormatTien = "##,##0"; //Format 
        public static String DinhDangNhapTien = "-nnn,nnn,nnn,nnn,nnn";
        public static String FormatGia = "##,##0";
        public static String DinhDangNhapGia = "-nnn,nnn,nnn,nnn";
        public static String FormatSoLuong = "##,##0";
        public static String DinhDangNhapSoLuong = "-nnn,nnn,nnn,nnn";
        public static String FormatTrongLuong = "##,##0";
        public static String DinhDangNhapTrongLuong = "-nnn,nnn,nnn,nnn,nnn,nnn";
        public static String FormatKhoiLuong = "##,##0";
        public static String DinhDangNhapKhoiLuong = "-nnn,nnn,nnn,nnn,nnn,nnn";

        public static Int16 LamTronSoLuong = 3;
        public static Int16 LamTronTrongLuong = 3;
        public static Int16 LamTronKhoiLuong = 3;
        public static Int16 LamTronDonGia = 3;
        public static Int16 LamTronSoTien = 0;

        //Than số người sử dụng đăng nhập
        public static object IDDanhMucNguoiSuDung = "";
        public static String MaDanhMucNguoiSuDung = "";
        public static String TenDanhMucNguoiSuDung = "";
        public static String Password = "";
        public static object IDDanhMucPhanQuyen = "";
        public static Boolean isAdmin = false;
        public static Boolean Logged = false;
        public static Boolean CanLogout = true;
        //Tham số đường dẫn chứa file kết xuất
        public static String OutputDir = Application.StartupPath + @"\Output";
        //Tham số đường dẫn chứa file tạm
        public static String TempDir = Application.StartupPath + @"\Temp\";
        //Tham số đường dẫn chứa file excel mẫu báo cáo
        public static String ExcelTemplateDir = Application.StartupPath + @"\FileMauExcel\";
        //Tham số đường dẫn report
        public static String reportPath = Application.StartupPath + @"\Reports\";
        public static String ChungTuReportPath = Application.StartupPath + @"\Reports\ChungTu\";
        public static String BaoCaoReportPath = Application.StartupPath + @"\Reports\BaoCao\";
        //Tham số file report in chứng từ
        public static String rptChungTuBanHang = ChungTuReportPath + "rpt_chungtu_banhang.rpt";
        //
        public static String importFileName = "";
        public static String importSheetName = "";
        public static Int32 importFromRow = 2;
        public static Int32 importToRow = 0;
        //Danh sách tham số hệ thống toàn cục
        public const String GlobalSqlParametersList = "(@IDDONVI)(@IDDANHMUCDONVI)(@IDDANHMUCNGUOISUDUNGCREATE)(@IDDANHMUCNGUOISUDUNGEDIT)(@CREATEDATE)(@EDITDATE)(@NAMLAMVIEC)(@IDDANHMUCNGONNGU)";
        //Chuỗi mã hóa
        public const string EncryptPhase = "c@e1n2t3e4c5h6";
        //
        public const string DeleteConfirmMsg = "Dữ liệu đã xóa sẽ không thể khôi phục lại được, bạn có muốn xóa hay không?";
        //
        //Trạng thái đơn hàng

        public const string ctHotline_DangDiDongTra = "0";
        public const string ctHotline_DangChoDongTra = "1";
        public const string ctHotline_DaXong = "2";
        public const string ctHotline_DienGiaiDangDiDongTra = "Đang đi đóng/trả";
        public const string ctHotline_DienGiaiDangChoDongTra = "Đang chờ đóng/trả";
        public const string ctHotline_DienGiaiDaXong = "Đã xong";

        public const int RecordPerPage = 50;

        public const string InvalidLoginMsg = "Tên đăng nhập hoặc password không hợp lệ!";
    }

}
