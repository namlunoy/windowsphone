using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyQuiz
{
    public class Category
    {

        [XmlIgnore]
        public static ObservableCollection<Category> ListCategories = new ObservableCollection<Category>();

        [XmlIgnore]
        public Uri ImageUri { get { return new Uri(ImageUriString, UriKind.RelativeOrAbsolute); } }
        public string ImageUriString { get; set; }
        public string Name { get; set; }
        public List<Quiz> Quizzes { get; set; }


        public Category()
        {
            Quizzes = new List<Quiz>();
            ImageUriString = "//Assets//logo.png";
        }

        public static Category GetCategoryByName(string name)
        { return ListCategories.Where(c => c.Name.Equals(name)).FirstOrDefault(); }

        public static async Task LoadCategoriesAsync()
        { ListCategories = await DataHelper<Category>.readXMLAsync("categories.xml"); }

        public static async Task SaveCategoriesAsync()
        { await DataHelper<Category>.writeXMLAsync(ListCategories, "categories.xml"); }

        public override string ToString()
        {
            return Name;
        
        }


    }
}
