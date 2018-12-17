using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM.Infrastructure;

namespace WpfMVVM.Models
{
    class ViewModelStudent : INotifyPropertyChanged
    {
        StorageStudent storage;

        Student m_SelectedItem;
        public Student SelectedItem
        {
            get
            { return m_SelectedItem; }
            set
            {

                m_SelectedItem = value;
                Notify("SelectedItem");
            }
        }


        public ObservableCollection<Student> collection { get; set; }
        public ViewModelStudent()
        {
            storage = new StorageStudent();
            collection = storage.collection;
            addStudent = new RelayCommand(
                s =>
                {
                    Student st = new Student() { FullName = "?", Age = 25 };
                    collection.Add(st);
                    SelectedItem = st;
                });

            removeStudent = new RelayCommand(
                s =>
                {
                    //Student st = (Student)s;
                    collection.Remove(SelectedItem);
                    SelectedItem = collection.FirstOrDefault();
                }, 
                s=>
                {
                    return (SelectedItem != null);
                }
                );
        }

        RelayCommand addStudent;
        public RelayCommand AddStudent
        {
            get
            {
                return addStudent;
            }
        }

        RelayCommand removeStudent;
        public RelayCommand RemoveStudent
        {
            get
            {
                return removeStudent;
            }
        }
        public void Notify([CallerMemberName]string s = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
