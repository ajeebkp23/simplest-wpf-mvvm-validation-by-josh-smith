using System.ComponentModel;

namespace InputConversionDemo
{

    public class Person : IDataErrorInfo
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; set; }

        #region IDataErrorInfo Members

        public string Error
        {
            get { return null; }
        }

        public string this[string propertyName]
        {
            get
            {
                if (propertyName == "Age")
                {
                    if (this.Age < 0)
                        return "Age cannot be less than 0.";

                    if (120 < this.Age)
                        return "Age cannot be greater than 120.";
                }

                return null;
            }
        }

        #endregion // IDataErrorInfo Members
    }

}