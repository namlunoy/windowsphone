using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace private_notes
{
    public class Note
    {
        public String Id { get; set; }
        public String Time { set; get; }
        public String Title { get; set; }
        public String Content { get; set; }
    }

    public class ListNote
    {
        public ObservableCollection<Note> Notes = new ObservableCollection<Note>();
        public Note GetNote(String id)
        {
            foreach (Note note in Notes)
            {
                if (note.Id.Equals(id))
                    return note;
            }
            return null;
        }

        

        public async Task AddNote(Note note)
        {
            foreach (var item in Notes)
            {
                if (item.Id.Equals(note.Id))
                {
                    item.Title = note.Title;
                    item.Time = note.Time;
                    item.Content = note.Content;
                    await Helper.writeXMLAsync(Notes, "data.xml");
                    return;
                }
            }

            Notes.Add(note);
            await Helper.writeXMLAsync(Notes, "data.xml");
        }

        public async Task Save()
        {
            await Helper.writeXMLAsync(Notes, "data.xml");
        }
    }
}
