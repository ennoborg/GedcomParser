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
            var userDir = Environment.UserName;
            //var filePath = Path.Combine(baseDir, "Resources", "StefanFamily.ged");
            //var filePath = Path.Combine(baseDir, "Resources", "StefanFamilyAll.ged");
            //var filePath = Path.Combine(baseDir, "Resources", "Windsor.ged");
            //var filePath = Path.Combine(baseDir, "Resources", "Kennedy.ged");
            //var filePath = Path.Combine(baseDir, "Resources", "TGC551.ged");
            var filePath1 = Path.Combine(@"C:\Users", userDir, "Dropbox", "Untitled_1.ged");
            var filePath2 = Path.Combine(@"C:\Users", userDir, "Documents", "fs.ged");

            var fileParser1 = new FileParser();
            var fileParser2 = new FileParser();

            // Act
            fileParser1.Parse(filePath1);
            Debug.WriteLine($"File {filePath1} has {fileParser1.PersonContainer.Persons.Count} persons.");

            fileParser2.Parse(filePath2);
            Debug.WriteLine($"File {filePath2} has {fileParser2.PersonContainer.Persons.Count} persons.");

            // Check what's new
            foreach (var newId in fileParser2.PersonContainer.UidPersons)
            {
                //Debug.WriteLine($"Checking ID {newId.Key}");
                Console.Write(".");

                if (fileParser1.PersonContainer.UidPersons.ContainsKey(newId.Key))
                {
                    var person = fileParser1.PersonContainer.UidPersons[newId.Key];

                    newId.Value.Matched = true;
                    newId.Value.MatchedId = person.Id;
                    Console.WriteLine($"Found match for {person.FirstName} {person.LastName}");
                }
                else
                {
                    var newPerson = fileParser2.PersonContainer.UidPersons[newId.Key];

                    Debug.WriteLine($"Found new person {newPerson.Id}: {newPerson.FirstName}{newPerson.LastName}");
                    foreach (var person in newPerson.Children.Where(p => p.Matched == true))
                    {
                        Debug.WriteLine($"Parent of {person.Id}: {person.FirstName}{person.LastName} = {person.MatchedId}");
                    }
                    foreach (var person in newPerson.Parents.Where(p => p.Matched == true))
                    {
                        Debug.WriteLine($"Child of {person.Id}: {person.FirstName}{person.LastName} = {person.MatchedId}");
                    }
                    foreach (var person in newPerson.Spouses.Where(p => p.Matched == true))
                    {
                        Debug.WriteLine($"Spouse of {person.Id}: {person.FirstName}{person.LastName} = {person.MatchedId}");
                    }
                }
            }

            // Summarize
            // Assert
            //var relationCount = fileParser.PersonContainer.ChildRelations.Count + fileParser.PersonContainer.SpouseRelations.Count + fileParser.PersonContainer.SiblingRelations.Count;
            ////var childStatusChildren = fileParser.Relations.OfType<ChildRelation>().Where(c => !string.IsNullOrEmpty(c.Pedigree)).ToList();
            ////Assert.IsTrue(childStatusChildren.Count > 0);
            //Debug.WriteLine("======================================================================");
            //Debug.WriteLine($"GEDCOM file processed: '{filePath}'");
            //Debug.WriteLine($"{fileParser.PersonContainer.Persons.Count} persons successfully parsed with {relationCount} relations detected");
            //Debug.WriteLine("======================================================================");

            //int[] uidCounts = new int[45];

            //foreach (var person in fileParser.PersonContainer.Persons)
            //{
            //    var index = person.Uids.Count;
            //    if (index > 0 && index < 45)
            //    {
            //        uidCounts[index]++;
            //    }
            //    else
            //    {
            //        Debug.WriteLine($"Person {person.Id} has {index} UIDs");
            //    }
            //}

            //for (var i=0; i < 45; i++)
            //{
            //    Debug.WriteLine($"{uidCounts[i]} persons have {i} UIDs");
            //}
        }
    }
}
