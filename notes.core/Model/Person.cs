namespace Edward.Wilde.Note.For.Nurses.Core.Model
{
    public class Person
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the patient.
        /// </summary>
        /// <value>The name of the patient.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the patient.
        /// </summary>
        /// <value>The last name of the patient.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName
        {
            get
            {
                return string.Format("{0} ,{1}", this.LastName, this.FirstName);
            }
        }
    }
}