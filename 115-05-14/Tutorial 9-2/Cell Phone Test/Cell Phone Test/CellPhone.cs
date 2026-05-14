using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Phone_Test
{
    // CellPhone 類別：代表一支手機，包含品牌、型號、價格三項屬性
    class CellPhone
    {
        // 品牌屬性的私有欄位
        private string _brand;
        
        // 型號屬性的私有欄位
        private string _model;
        
        // 價格屬性的私有欄位
        private decimal _price;

        // CellPhone 建構子：初始化新的手機物件
        public CellPhone()
        {
            _brand = string.Empty;
            _model = string.Empty;
            _price = 0m;
        }

        // 品牌屬性：提供讀取與寫入品牌資訊的方法
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
    
        // 型號屬性：提供讀取與寫入型號資訊的方法
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        // 價格屬性：提供讀取與寫入價格資訊的方法
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}