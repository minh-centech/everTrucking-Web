using everTrucking_Web.Code.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace everTrucking_Web.Code
{
    public class Common
    {
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
    }
    public class GlobalVariables
    {
        public static object IDDanhMucNguoiSuDung = "7";
        public static string webConnectionString = @"Data Source=sangtaoketnoi.vn;Initial Catalog=everTRUCKING-2021;Persist Security Info=True;User ID=everTRUCKING-2021;Password=everTRUCKING-2021;Connect Timeout=60";
        public static string IDDonVi = "1";
        //
        public static string IDDanhMucLoaiDoiTuongKhachHang = "69";
        public static string IDDanhMucLoaiDoiTuongNhanSu = "268";
        public static string IDDanhMucLoaiDoiTuongKho = "12069";
        public static string IDDanhMucLoaiDoiTuongCangICD = "4054";
        //
        public static string IDDanhMucChungTuKeHoachVanTai = "151";
        public static string IDDanhMucChungTuDonHang = "153";
        //
        public static List<DanhMucKhachHang> listKhachHang = null;
    }
}