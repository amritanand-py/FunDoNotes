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


    }
}
