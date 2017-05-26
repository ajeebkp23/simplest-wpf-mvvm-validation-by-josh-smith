using System.Windows;

namespace InputConversionDemo
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            Person fordPrefect = new Person("Ford Prefect", 42);
            base.DataContext = new PersonViewModel(fordPrefect);
        }
    }
}