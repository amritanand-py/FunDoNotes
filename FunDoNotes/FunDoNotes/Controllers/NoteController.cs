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
                var user = Convert.ToInt32(User.FindFirst("UserId").Value);
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
    }
}
