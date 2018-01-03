using System;
using System.Collections.Generic;

namespace BlogSampleV2.Domain.Enteties
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public List<Skill> Skills { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum Skill
    {
        English,
        Math,
        History,
        Physics,
        Art
    }
}
