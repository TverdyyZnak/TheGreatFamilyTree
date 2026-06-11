using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGreatFamilyTree.Domain.Interfaces;

namespace TheGreatFamilyTree.Domain.Classes
{
    public class FileResource : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ResourceUrl { get; set; } = string.Empty;

        private FileResource(Guid id, string title, string url = "")
        {
            Id = id;
            Title = title;
            ResourceUrl = url;
        }

        public static (FileResource file, string error) Create(Guid id, string title, string resourceUrl = "")
        {
            string errorString = string.Empty;

            if(title.Length > Params._maxNameLength)
            {
                errorString += $"Название ресурса привышает лимит в {Params._maxNameLength} символов; ";
            }

            return (new FileResource(id, title, resourceUrl), errorString);
        }
    }
}
