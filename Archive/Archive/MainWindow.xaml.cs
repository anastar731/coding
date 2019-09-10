using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Reflection;
using Archive;
using System.Data;



namespace Archive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void gridArchive_Loaded(object sender, RoutedEventArgs e)
        {
            List<DocArchive> result = new List<DocArchive>(3);
            result.Add(new DocArchive(1, "325", "Заявка", "02.02.2019", "C:\\Users\\Administrator\\Documents\\Заявка1"));

            gridArchive.ItemsSource = result;
            /*DataSet tArchiveDataSet = DataProvider.ReadFile("C:\\Users\\Administrator\\Documents\\Visual Studio 2013\\Projects\\WpfApplication1\\tdldata_documents.xml");
            gridArchive.ItemsSource = tArchiveDataSet.Tables["row"].DefaultView;
            tArchiveDataSet.Tables["row"].Columns["ID"];*/
        }

        private void gridFilter_Loaded(object sender, RoutedEventArgs e)
        {
            List<Filter> result = new List<Filter>(3);
            result.Add(new Filter("И", "Тип документа", "=", "Путевой лист"));

            gridFilter.ItemsSource = result;
        }

        private void gridArchive_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string displayName = GetPropertyDisplayName(e.PropertyDescriptor);
            if (!string.IsNullOrEmpty(displayName))
            {
                e.Column.Header = displayName;
            }

        }

        public static string GetPropertyDisplayName(object descriptor)
        {

            PropertyDescriptor pd = descriptor as PropertyDescriptor;
            if (pd != null)
            {
                DisplayNameAttribute dn = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;
                if (dn != null && dn != DisplayNameAttribute.Default)
                {
                    return dn.DisplayName;
                }
            }
            else
            {
                PropertyInfo pi = descriptor as PropertyInfo;
                if (pi != null)
                {
                    Object[] attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    for (int i = 0; i < attributes.Length; ++i)
                    {
                        DisplayNameAttribute dn = attributes[i] as DisplayNameAttribute;
                        if (dn != null && dn != DisplayNameAttribute.Default)
                        {
                            return dn.DisplayName;
                        }
                    }
                }
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddDocument AddDocument = new AddDocument();
            AddDocument.Show();
        }


    }
    class DocArchive
    {
        public DocArchive(int Id, string NumOrder, string DocType, string DocDate, String Path)
        {
            this.Id = Id;
            this.NumOrder = NumOrder;
            this.DocType = DocType;
            this.DocDate = DocDate;
            this.Path = Path;
        }
        [DisplayName("Номер документа")]
        public int Id { get; set; }
        [DisplayName("Номер заказа")]
        public string NumOrder { get; set; }
        [DisplayName("Тип документа")]
        public string DocType { get; set; }
        [DisplayName("Дата создания")]
        public string DocDate { get; set; }
        [DisplayName("Путь к документу")]
        public String Path { get; set; }
    }

    class Filter
    {
        public Filter(string Relation, string Field, string Condition, string Value)
        {
            this.Relation = Relation;
            this.Field = Field;
            this.Condition = Condition;
            this.Value = Value;
        }
        [DisplayName("Связь")]
        public string Relation { get; set; }
        [DisplayName("Поле")]
        public string Field { get; set; }
        [DisplayName("Условие")]
        public string Condition { get; set; }
        [DisplayName("Значение")]
        public string Value { get; set; }


    }
}


