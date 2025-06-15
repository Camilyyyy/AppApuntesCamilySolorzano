using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppApuntesCamilySolorzano.Models
{
    class AllNotes
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public AllNotes() => LoadNotes();
        public void LoadNotes()
        {
            Notes.Clear();
            string appDataPath=FileSystem.AppDataDirectory;
            IEnumerable<Note> notes=Directory.EnumerateFiles(appDataPath,"*.notes.txt").Select(filename => new Note() { FileName=filename,Text=File.ReadAllText(filename),Date=File.GetCreationTime(filename)}).OrderBy(note => note.Date );

            foreach( var note in notes) {
                Notes.Add(note);
            }
        }
    }
}
