using CommonLayer.RequestModel;
using RepoLayer.Context;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoLayer.Context;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interfaces;
using System.Xml;

namespace RepoLayer.Services
{
    public class NoteServices : INotesRepo
    {
        public readonly FunDoContext FunDoContext;
        public NoteServices(FunDoContext FunDoContext)
        {
            this.FunDoContext = FunDoContext;
            
        }

        public NoteEntity AddNotes(NotesReqModel model,int UserID)
        {
            try
            {
                var user = FunDoContext.UserTable.FirstOrDefault(x => x.UserId == UserID);
                if (user == null)
                {
                    throw new Exception("User not reg");
                }
                NoteEntity notesobj = new NoteEntity();

                notesobj.NoteTitle = model.NoteTitle;
                notesobj.NoteDescription = model.NoteDescription;
                notesobj.background = "";
                notesobj.colour = "White";
                notesobj.IsPin = false;
                notesobj.IsArchive = false;
                notesobj.IsTrash = false;
                notesobj.CreatedAt = DateTime.Now;
                notesobj.UpdatedAt = DateTime.Now;
                notesobj.Remainder = DateTime.Now.AddHours(5);
                notesobj.UserId = UserID;
                FunDoContext.NotesTable.Add(notesobj);
                FunDoContext.SaveChanges();

                return notesobj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }




    }
}
