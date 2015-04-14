using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannup.Model
{
    public class MyData : INotifyPropertyChanged
    {
        private List<Category> listCategory;

        public List<Category> ListCategory
        {
            get { return listCategory; }
            set { listCategory = value;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("ListCategory"));
            }
        }

        public  void LoadData()
        {
            ListCategory = new List<Category>();
            ListCategory.Add(new Category() { name = "Trang Chủ", LinkString = "http://guu.vn/", Type = 0 });
            ListCategory.Add(new Category() { name = "My Guu", LinkString = "http://guu.vn/myguu", Type = 1 });

            ListCategory.Add(new Category() { name = "Guu Cuộc Sống ", LinkString = "http://guu.vn/guu-cuoc-song", Type = 0 });
            ListCategory.Add(new Category() { name = "Guu Tâm Sự", LinkString = "http://guu.vn/guu-tam-su", Type = 1 });
            ListCategory.Add(new Category() { name = "Guu Văn Hóa", LinkString = "http://guu.vn/guu-van-hoa", Type = 1 });
            ListCategory.Add(new Category() { name = "Guu Ăn Chơi", LinkString = "http://guu.vn/guu-an-choi", Type = 1 });
            ListCategory.Add(new Category() { name = "Guu Khéo Tay", LinkString = "http://guu.vn/guu-kheo-tay", Type = 1 });
            ListCategory.Add(new Category() { name = "Guu Mua Sắm", LinkString = "http://guu.vn/guu-mua-sam", Type = 1 });

            ListCategory.Add(new Category() { name = "Làm Đẹp", LinkString = "http://guu.vn/lam-dep", Type = 0 });
            ListCategory.Add(new Category() { name = "Tóc Đẹp", LinkString = "http://guu.vn/toc-dep", Type = 1 });
            ListCategory.Add(new Category() { name = "Móng Tay Đẹp", LinkString = "http://guu.vn/mong-tay-dep", Type = 1 });
            ListCategory.Add(new Category() { name = "Trang Điểm", LinkString = "http://guu.vn/trang-diem", Type = 1 });
            ListCategory.Add(new Category() { name = "Dưỡng Da", LinkString = "http://guu.vn/duong-da", Type = 1 });
            ListCategory.Add(new Category() { name = "Giảm Cân", LinkString = "http://guu.vn/giam-can", Type = 1 });

            ListCategory.Add(new Category() { name = "Thời Trang Nữ", LinkString = "http://guu.vn/thoi-trang-nu", Type = 0 });
            ListCategory.Add(new Category() { name = "Phối Đồ Thời Trang", LinkString = "http://guu.vn/phoi-do-thoi-trang", Type = 1 });
            ListCategory.Add(new Category() { name = "Thời Trang Công Sở", LinkString = "http://guu.vn/thoi-trang-cong-so", Type = 1 });
            ListCategory.Add(new Category() { name = "Phụ Kiện Thời Trang", LinkString = "http://guu.vn/phu-kien-thoi-trang", Type = 1 });
            ListCategory.Add(new Category() { name = "Thời Trang Cưới Hỏi", LinkString = "http://guu.vn/thoi-trang-cuoi-hoi", Type = 1 });
            ListCategory.Add(new Category() { name = "Guu Ngôi Sao", LinkString = "http://guu.vn/guu-ngoi-sao", Type = 1 });
            ListCategory.Add(new Category() { name = "Guu Sàn Diễn", LinkString = "http://guu.vn/guu-san-dien", Type = 1 });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
