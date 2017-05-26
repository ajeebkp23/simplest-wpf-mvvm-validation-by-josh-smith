using System;
using System.ComponentModel;

namespace InputConversionDemo
{
    public class PersonViewModel
        : INotifyPropertyChanged,
          IDataErrorInfo
    {
        readonly Person _person;
        

        public PersonViewModel(Person person)
        {
            _person = person;
            _ageText = person.Age.ToString();
        }

        public string Name
        {
            get { return _person.Name; }
        }

        string _ageText;

        public string Age
        {
            get { return _ageText; }
            set
            {
                if (value == _ageText)
                    return;

                _ageText = value;

                this.OnPropertyChanged("Age");
            }
        }

        #region IDataErrorInfo Members

        public string Error
        {
            get { return _person.Error; }
        }

        public string this[string propertyName]
        {
            get
            {
                if (propertyName == "Age")
                {
                    int age;
                    string msg = this.ValidateAge(out age);
                    if (!String.IsNullOrEmpty(msg))
                        return msg;

                    // Apply the age value now so that the 
                    // Person object can also validate it.
                    _person.Age = age;
                }

                return _person[propertyName];
            }
        }

        string ValidateAge(out int age)
        {
            age = -1;
            string msg = null;

            if (String.IsNullOrEmpty(_ageText))
                msg = "Age is missing.";

            if (!Int32.TryParse(_ageText, out age))
                msg = "Age is not a whole number.";

            return msg;
        }

        #endregion // IDataErrorInfo Members

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }
}