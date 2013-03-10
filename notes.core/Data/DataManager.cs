using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edward.Wilde.Note.For.Nurses.Core.Data
{
    using Edward.Wilde.Note.For.Nurses.Core.Model;

    public class DataManager
    {
        public static IEnumerable<Pupil> GetPupils()
        {
            var teacher1 = new Teacher { Id = 1, FirstName = "Bill", LastName = "Hicks", ClassName = "Goat" };
            var teacher2 = new Teacher { Id = 2, FirstName = "Susan", LastName = "Monet", ClassName = "Giraffe" };
            return new List<Pupil>
                       {
                           new Pupil(teacher1) { Id = 3, FirstName = "Bill", LastName = "Jones" },
                           new Pupil(teacher2) { Id = 4, FirstName = "Brian", LastName = "Blessed" },
                           new Pupil(teacher1) { Id = 5, FirstName = "Phil", LastName = "Tufnell"},
                           new Pupil(teacher2) { Id = 6, FirstName = "Nora", LastName = "Jones"}
                       };
        }

        public static Pupil GetPupil(int id)
        {
            return GetPupils().FirstOrDefault(item => item.Id.Equals(id));
        }
    }
}
