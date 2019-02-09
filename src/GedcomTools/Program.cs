using GedcomParser.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedcomTools
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrange
            var currentDir = Directory.GetCurrentDirectory();
            var baseDir = currentDir.Substring(0, currentDir.IndexOf(@"\bin\Debug"));
            //var filePath = Path.Combine(baseDir, "Resources", "StefanFamily.ged");
            //var filePath = Path.Combine(baseDir, "Resources", "StefanFamilyAll.ged");
            //var filePath = Path.Combine(baseDir, "Resources", "Windsor.ged");
            //var filePath = Path.Combine(baseDir, "Resources", "Kennedy.ged");
            //var filePath = Path.Combine(baseDir, "Resources", "TGC551.ged");
            var filePath = Path.Combine(@"C:\Users\ennob\Dropbox", "Untitled_1.ged");
            var fileParser = new FileParser();

            // Act
            fileParser.Parse(filePath);

            // Assert
            var relationCount = fileParser.PersonContainer.ChildRelations.Count + fileParser.PersonContainer.SpouseRelations.Count + fileParser.PersonContainer.SiblingRelations.Count;
            //var childStatusChildren = fileParser.Relations.OfType<ChildRelation>().Where(c => !string.IsNullOrEmpty(c.Pedigree)).ToList();
            //Assert.IsTrue(childStatusChildren.Count > 0);
            Debug.WriteLine("======================================================================");
            Debug.WriteLine($"GEDCOM file processed: '{filePath}'");
            Debug.WriteLine($"{fileParser.PersonContainer.Persons.Count} persons successfully parsed with {relationCount} relations detected");
            Debug.WriteLine("======================================================================");
        }
    }
}
