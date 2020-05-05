using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaUniversityDatabase
{
    class addCourseObject
    {
        public int ID { get; set; }
        public string department { get; set; }
        public int creditHours { get; set; }
        public int courseName { get; set; }
        public static ObservableCollection<addCourseObject> getCourse()
        {
            var courseObject = new ObservableCollection<addCourseObject>();
            return courseObject;
        }
    }
}
