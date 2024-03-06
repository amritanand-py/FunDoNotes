using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Entity;

namespace FunDoNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        public readonly INotesManager notesManager;



        public NoteController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }

        [HttpPost]
        [Authorize]
        [Route("AddNotes")]
        public ActionResult AddNotes(NotesReqModel model)
        {
            try
            {
                var user = Convert.ToInt32(User.FindFirst("UserId").Value);  /// user verification
                var response = notesManager.AddNotes(model, user);
                if (response != null)
                {
                    return Ok(new FunDoResponse<NoteEntity> { Success = true, Message = "Note add Successful", Data = response });

                }
                return BadRequest(new FunDoResponse<NoteEntity> { Success = false, Message = "Note add Unsuccessful", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new FunDoResponse<NoteEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPut]
        [Authorize]
        [Route("Pin")]
        public ActionResult editpin(int noteid)
        {
            var user = Convert.ToInt32(User.FindFirst("UserId").Value);
            var response = notesManager.UpdatePin(user, noteid);
            if (response != null)
            {
                return Ok(new FunDoResponse<bool> { Success = true, Message = "Note pin Successful", Data = response });

            }
            return BadRequest(new FunDoResponse<bool> { Success = false, Message = "Note pin Unsuccessful", Data = false });
        }



        [HttpPost]
        [Authorize]
        [Route("ReviewSearchBytitle")]
        public ActionResult SearchBytitleandDesc(NotesReqModel model)
        {
            var user = Convert.ToInt32(User.FindFirst("UserId").Value);
            var response = notesManager.SearchByTitle(model.NoteTitle,model.NoteDescription);
            if (response != null)
            {
                return Ok(new FunDoResponse<NoteEntity> { Success = true, Message = "NOte Found", Data = response });

            }
            return BadRequest(new FunDoResponse<NoteEntity> { Success = false, Message = "Unable to find", Data = null });
        }

        [HttpPut]
        [Authorize]
        [Route("ReviewCountNotes")]
        public ActionResult TotalnoOFNOtes(int userid)

        {
            var response = notesManager.CountUserNotes(userid);
            if (response != null)
            {
                return Ok(new FunDoResponse<int> { Success = true, Message = "success", Data = response });

            }
            return BadRequest(new FunDoResponse<int> { Success = false, Message = "unsucess", Data = 0 });
        }
    }
}


