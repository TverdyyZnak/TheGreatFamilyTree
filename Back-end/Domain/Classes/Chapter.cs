using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGreatFamilyTree.Domain.Interfaces;

namespace TheGreatFamilyTree.Domain.Classes
{
    public class Chapter : IEntity
    {
        public Guid Id { get; set; }
        public int SerialNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly? StartDate { get; set; } = null;
        public DateOnly? EndDate { get; set; } = null;
        public List<FileResource> Files { get; set; } = new List<FileResource>();
            

        private Chapter(Guid id, int serial, string title, string description, DateOnly? startDate = null, DateOnly? endDate = null)
        {
            Id = id;
            SerialNumber = serial;
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
        public static (Chapter chapter, string error) Create(Guid id, int serial, string title, string description, DateOnly? startDate = null, DateOnly? endDate = null)
        {
            string errorString = string.Empty;

            if(title.Length > Params._maxNameLength)
            {
                errorString += $"Название главы привышает лимит в {Params._maxNameLength} символов; ";
            }

            if(description.Length > Params._maxFullDescriptionLength)
            {
                errorString += $"Описание главы привышает лимит в {Params._maxFullDescriptionLength} символов; ";
            }

            return (new Chapter(id, serial, title, description, startDate, endDate), errorString);
        }
    }
}
