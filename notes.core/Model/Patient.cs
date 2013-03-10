using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edward.Wilde.Note.For.Nurses.Core.Model
{
    /// <summary>
    /// Represents a patient
    /// </summary>
    public class Patient : Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Patient" /> class.
        /// </summary>
        public Patient()
        {
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
        }

        /// <summary>
        /// Gets or sets the date of birth of the patient.
        /// </summary>
        /// <value>The date of birth of the patient.</value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets the index used to display patients in a list.
        /// Currently patients are grouped by <see cref="Person.LastName"/>
        /// when displayed in a list.
        /// </summary>
        /// <value>The index to group by.</value>
        public string Index
        {
            get
            {
                return this.LastName.Length == 0 ? "A" : this.LastName[0].ToString().ToUpper();
            }
        }

        public virtual string DisplaySummary
        {
            get
            {
                return string.Empty;
            }
        }

        public string ImageUrl { get; set; }

        public string MedicalHistory { get; set; }
    }
}
