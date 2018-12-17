using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM.Models
{
    class Student : INotifyPropertyChanged
    {
        string m_FullName;
        public string FullName
        {
            get
            { return m_FullName; }
            set {


                m_FullName = value;
                Notify("FullName");
            }
        }
        int m_Age;
        public int Age
        {
            get
            { return m_Age; }
            set
            {


                m_Age = value;
                Notify("Age");
            }
        }

        //https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/caller-information 
        //- об информационном  аттрибуте CallerMemberName 
        public void Notify([CallerMemberName]string s = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
