using TheGreatFamilyTree.Domain.Interfaces;

namespace TheGreatFamilyTree.Domain.Classes
{
    public class Person : IEntity
    {
        public Guid Id { get; set; }
        public int TreeLVL { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string ShortBiography { get; set; } = string.Empty;
        public DateOnly? Birthday { get; set; } = null;
        public DateOnly? DayOfDeath { get; set; } = null;
        public Guid? FatherId { get; set; } = null;
        public Guid? MotherId { get; set; } = null;
        public List<Chapter> Chapters { get; set; } = new List<Chapter>();
        private Person(Guid id, string firstName, string lastName, string surname, 
                        string shortBiography, DateOnly? birthday = null, DateOnly? death = null, Guid? father = null, Guid? mother = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Surname = surname;
            ShortBiography = shortBiography;
            FatherId = father;
            MotherId = mother;
        }

        public static (Person person, string error) Create(Guid id, string firstName, string lastName, string surname, 
                                                            string shortBiography, DateOnly? birthday = null, DateOnly? death = null, Guid ? father = null, Guid? mother = null)
        {
            string errorString = string.Empty;

            if(firstName.Length > Params._maxNameLength || lastName.Length > Params._maxNameLength || surname.Length > Params._maxNameLength)
            {
                errorString += $"Имя, Фамилия или отчество превышает лимита в {Params._maxNameLength} символов; ";
            }

            if(shortBiography.Length > Params._maxDescriptionLength)
            {
                errorString += $"Описание превышает лимит в {Params._maxDescriptionLength} символов; ";
            }

            return (new Person(id, firstName, lastName, surname, shortBiography, birthday, death, father, mother), errorString);
        }
    }
}
