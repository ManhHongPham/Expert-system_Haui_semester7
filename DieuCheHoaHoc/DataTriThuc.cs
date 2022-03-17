using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieuCheHoaHoc
{
    internal class DataTriThuc
    {
        //độc từ file và quản lý các luât
        public static string triThucPath = @"D\School\Haui\semster 7\expert systems\Nhom 23_HCG dieu che chat hoa hoc theo suy dien tien\Nhom 23_Chuong trinh\tap_tin_tri_thuc.txt";
        private List<PhanUng> phanUngs;
        
        /**
         * ghi toàn bộ file 
         */
        public static void toFile(List<PhanUng> pus) {
            StreamWriter sw = new StreamWriter(triThucPath);
            foreach (PhanUng pu in pus) {
                sw.WriteLine(pu.ToText());
            }
            sw.Close();
        }

        public DataTriThuc() {
            // lay data tu file
            phanUngs = new List<PhanUng>();

            StreamReader sr = new StreamReader(triThucPath);
            while (!sr.EndOfStream) {
                phanUngs.Add(new PhanUng(sr.ReadLine()));
            }
            sr.Close();
        }

        public List<ChatHoaHoc> GetChatHoaHocs() {
            List<ChatHoaHoc> chh = new List<ChatHoaHoc>();
            foreach (PhanUng phanUng in phanUngs) {
                chh.AddRange(phanUng.GetChatHoaHocs());
            }
            HashSet<ChatHoaHoc> setchh = new HashSet<ChatHoaHoc>(chh);
            chh = setchh.ToList();
            chh.Sort();
            return chh;
        }

        public List<PhanUng> GetPhanUngs() {
            return phanUngs;
        }
    }
}