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

        public bool UpdatePin(int Noteid,int UserID) 
        { 
            var note = FunDoContext.NotesTable.FirstOrDefault(x => x.NoteId == Noteid);
            if (note == null)
            {
                throw new Exception("note not avail");

            }
            if(note.UserId == UserID)
            {
                note.IsPin = true;
                
            }
            else
            {
                note.IsPin = false;
            }
            note.UpdatedAt = DateTime.Now;
            FunDoContext.SaveChanges();
            return true;
        }
        public bool Updatetrash(int Noteid, int UserID)
        {
            var note = FunDoContext.NotesTable.FirstOrDefault(x => x.NoteId == Noteid);
            if (note == null)
            {
                throw new Exception("note not avail");

            }
            if (note.UserId == UserID)
            {
                note.IsTrash = true;

            }
            else
            {
                note.IsTrash = false;
            }
            note.UpdatedAt = DateTime.Now;
            FunDoContext.SaveChanges();
            return true;
        }



        public string addColor (int Noteid,string colour)
        {
            var findingNote = FunDoContext.NotesTable.FirstOrDefault(x => x.NoteId == Noteid);
            if (findingNote == null)
            {
                throw new Exception("note not avail");

            }
            findingNote.colour = colour;
            FunDoContext.SaveChanges();
            return findingNote.colour;

        }

        public bool deleteNote(int Noteid)
        {
            var findingNote = FunDoContext.NotesTable.FirstOrDefault(x => x.NoteId == Noteid);
            if (findingNote == null)
            {
                throw new Exception("note not avail");

            }
            FunDoContext.NotesTable.Remove(findingNote);
            FunDoContext.SaveChanges() ;
            return true;
        }




        // Review 

        public NoteEntity SearchByTitle(string title,string Description)
        {
            try
            {
                var note = FunDoContext.NotesTable.FirstOrDefault(x => x.NoteTitle == title && x.NoteDescription == Description);
                return note;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int CountUserNotes(int userid)
        {
            return FunDoContext.NotesTable.Count(x => x.UserId == userid);

        } 
        

        
       
        
}


    }

