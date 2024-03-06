using CommonLayer.RequestModel;
using ManagerLayer.Interfaces;
using RepoLayer.Entity;
using RepoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Services
{
    public class NotesManager : INotesManager
    {
        public readonly INotesRepo NotesManagerobj;

        public NotesManager (INotesRepo NotesManagerobj)
        {
            this.NotesManagerobj = NotesManagerobj;
        }

        public NoteEntity AddNotes(NotesReqModel model, int UserID)
        {
            return NotesManagerobj.AddNotes(model,UserID);
        }

        public bool UpdatePin(int Noteid, int UserID)
        {
            return NotesManagerobj.UpdatePin(Noteid,UserID);
        }

        public NoteEntity SearchByTitle(string title, string Description)
        {
            return NotesManagerobj.SearchByTitle(title, Description);
        }

        public int CountUserNotes(int userid)
        {
            return NotesManagerobj.CountUserNotes(userid);
        }

    }
}
