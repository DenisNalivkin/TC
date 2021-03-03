using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {/// <summary>
     /// Enum TypeOFLesson  stores types lesson.
     /// </summary>
        public enum TypeOFLesson : int
        {
            TextLesson,
            VideoLeson,
        }
        /// <summary>
        /// Enum VideOFormat  stores types of video for lesson.
        /// </summary>
        public enum VideOFormat : int
        {
            Unknown,
            Avi,
            Mp4,
            Flv,
        }
        /// <summary>
        /// Enum TypeOfReference  stores types of references for lesson.
        /// </summary>
        public enum TypeOfReference : int
        {
            Unknown,
            Html,
            Image,
            Audio,
            Video,
        }
        static void Main(string[] args)
        {
        }
    }

}
