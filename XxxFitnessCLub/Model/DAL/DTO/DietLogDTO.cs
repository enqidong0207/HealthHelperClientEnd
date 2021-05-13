using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XxxFitnessCLub.Model.DAL.DTO
{
    public class DietLogDTO : DietLog
    {

        public DietLogDTO()
        {
        }
        public DietLogDTO(DietLog Dl)
        {
            foreach (var propertyInfo in typeof(DietLog).GetProperties())
            {
                propertyInfo.SetValue(this, propertyInfo.GetValue(Dl));
            }

        }
        public byte[] 圖片 { get; set; }
        public DateTime 日期 { get; set; }
        public string 時段 { get; set; }
        
        public string 餐點名稱 { get; set; }
        public int 每100克卡路里 { get; set; }
        public double 份量 { get; set; }
        public int 總卡路里 { get; set; }





    }
}
