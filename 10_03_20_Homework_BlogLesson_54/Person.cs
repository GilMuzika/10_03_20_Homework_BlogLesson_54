using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _10_03_20_Homework_BlogLesson_54
{
    class Person
    {
        public event EventHandler<GlobalEventArgs> CallBackEvent;

        private BooleanToStringConverter _conv = new BooleanToStringConverter("Smoking");

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                CallBackEvent?.Invoke(this, new GlobalEventArgs { Name = value });
            }
        }
        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                CallBackEvent?.Invoke(this, new GlobalEventArgs { Age = value.ToString() });
            }
         }
        private int _height;
        public int Height
        {
            get => _height;
            set
            {
                _height = value;
                CallBackEvent?.Invoke(this, new GlobalEventArgs { Height = value.ToString() });
            }
        }
        private string _smoker;
        public string Smoker
        {
            get => _smoker;
            set
            {
                _smoker = value;
                CallBackEvent?.Invoke(this, new GlobalEventArgs { Smoker = value });
            }
        }

        private bool _isSmoking;
        public bool IsSmoking
        {
            get => _isSmoking;
            set
            {
                _isSmoking = value;
                CallBackEvent?.Invoke(this, new GlobalEventArgs { IsSmoke = value });
            }
        }

        private string _getProperties;
        public string GetProperties
        {
            get => _getProperties;
            set
            {
                _getProperties = this.ToString();
            }
        }


        public Person(string name, int age, int height, bool smokerBool)
        {
            Name = name;
            Age = age;
            Height = height;
            IsSmoking = smokerBool;

            Smoker = (string)_conv.Convert(smokerBool, typeof(string), new object(), new System.Globalization.CultureInfo(0x00000C0A)); ;

            GetProperties = this.ToString();
        }

        public override string ToString()
        {
            string str = string.Empty;
            string comma = ", ";
            for(int i = 0; i < this.GetType().GetProperties().Length - 2; i++)
            {
                if (i == this.GetType().GetProperties().Length - 3) comma = string.Empty;
                str += $"{this.GetType().GetProperties()[i].Name}: {this.GetType().GetProperties()[i].GetValue(this)}{comma}";
            }
            return str;
        }
    }
}
