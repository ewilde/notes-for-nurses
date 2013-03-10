using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edward.Wilde.Note.For.Nurses.Core.Model
{
    public class Pupil : Patient
    {
        public Pupil(Teacher teacher)
        {
            this.Teacher = teacher;
        }

        public override string DisplaySummary
        {
            get
            {
                return string.Format("Class {0}, {1} (teacher)", this.Teacher.ClassName, this.Teacher.DisplayName);
            }
        }

        /// <summary>
        /// Gets or sets the teacher associated with this person.
        /// </summary>
        /// <value>
        /// The teacher.
        /// </value>
        public Teacher Teacher { get; set; }
    }
}
