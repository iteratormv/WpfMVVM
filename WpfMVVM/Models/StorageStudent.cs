using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM.Models
{
    class StorageStudent
    {
        ObservableCollection<Student> m_collection;
        public ObservableCollection<Student> collection
        {
            get
            {
                return m_collection;
            }
            set
            {
                m_collection = value;
            }
        }

        public StorageStudent()
        {
            m_collection = new ObservableCollection<Student>()
            {
                new Student() {  FullName="Masha", Age=21},
                new Student() {  FullName="Semen", Age=22},
                new Student() {  FullName="Dasha", Age=23},
                new Student() {  FullName="Pasha", Age=19},
            };
        }
    }
}
