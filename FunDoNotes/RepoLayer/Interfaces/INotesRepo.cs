using CommonLayer.RequestModel;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interfaces
{
    public interface INotesRepo
    {
        public NoteEntity AddNotes(NotesReqModel model, int UserID);
        public bool UpdatePin(int Noteid, int UserID);
        public bool Updatetrash(int Noteid, int UserID);
        public NoteEntity SearchByTitle(string title, string Description);
        public int CountUserNotes(int userid);
        public string addColor(int Noteid, string colour);
        public bool deleteNote(int Noteid);
    }
}