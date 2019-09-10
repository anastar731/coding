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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Markup;
using System.Globalization;



namespace Archive
{
    public enum DocTypes
    {
        [Description ("Заявка")]
        request,
        [Description ("Распоряжение")]
        order,
        [Description ("Путевой лист")]
        trackinglist
    }
    public class ColumnParse
    {
        public string Value { set; get; }
        public DocTypes ValueType { set; get; }
    }
    public class EnumToItemsSource : MarkupExtension
    {
        private readonly Type _type;

        public EnumToItemsSource(Type type)
        {
            _type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _type.GetMembers().SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>()).Select(x => x.Description).ToList();
        }
    }
    public static class EnumExtension
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }              
            }
            return null; // could also return string.Empty
        }
    }
    /// <summary>
    /// Interaction logic for AddDocument.xaml
    /// </summary>
    public partial class AddDocument : Window
    {
        public AddDocument()
        {
            InitializeComponent();
            ColumnParse Var_parser = new ColumnParse();
            this.DataContext = Var_parser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             dbDocArchiveEntities1 context = new dbDocArchiveEntities1();
            tbldata_documents data = new tbldata_documents();
            data.doctype = (int)this.ComboBoxDocType.SelectedValue;

        }
    }
}
    
