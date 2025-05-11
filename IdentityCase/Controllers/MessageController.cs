using IdentityCase.Context;
using IdentityCase.Entities;
using IdentityCase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using X.PagedList.Extensions;

namespace IdentityCase.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public MessageController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        public async Task<IActionResult> Inbox(int page = 1,string searchString="")
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            int pageSize = 10;

            var userEmail = user.Email;
            var messages = _context.Messages
            .Where(m => m.ReceiverEmail == userEmail && m.isDeleted == false)
            .OrderBy(m => m.IsRead) // önce okunmamışlar (IsRead = false)
            .ThenByDescending(m => m.SendDate);
            if(!String.IsNullOrEmpty(searchString))
            {
                messages = (IOrderedQueryable<Message>)messages.Where(m => m.Subject.Contains(searchString) || m.SenderEmail.Contains(searchString));
            }

            var pagedMessages = messages.ToPagedList(page, pageSize);

            return View(pagedMessages);
        }

        [HttpGet("Message/MessageDetail/{id}")]
        public  async Task<IActionResult> MessageDetailPartial(int id)
        {
            var message = await _context.Messages.Where(i =>i.MessageID == id).FirstOrDefaultAsync();
            if (message == null)
            {
                return NotFound(); 
            }
            return PartialView("_MessageDetailPartial", message);
        }

        [HttpPost]
        public IActionResult UpdateReadStatus(int id, bool isRead)
        {
            var message = _context.Messages.FirstOrDefault(m => m.MessageID == id );
            if (message == null)
                return NotFound();

            message.IsRead = isRead;
            _context.SaveChanges();
            return Ok();
        }


        public async Task<IActionResult> SendBox(int page = 1, string searchString = "")
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string emailValues = values.Email;
            int pageSize = 10;

            var sendMessages =  _context.Messages.Where(x => x.SenderEmail == emailValues && x.isDeleted == false);
            if (!String.IsNullOrEmpty(searchString))
            {
                sendMessages = (IOrderedQueryable<Message>)sendMessages.Where(m => m.Subject.Contains(searchString) || m.ReceiverEmail.Contains(searchString));
            }
            var pagedMessages = sendMessages.ToPagedList(page, pageSize);
            return View(pagedMessages);
        }

        public async Task<IActionResult> TrashBox(int page = 1, string searchString = "")
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userEmail = user.Email;
            int pageSize = 10;
            var trashMessages = _context.Messages.Where(m => (m.ReceiverEmail == userEmail||m.SenderEmail == userEmail) && m.isDeleted == true);
            if (!String.IsNullOrEmpty(searchString))
            {
                trashMessages = (IOrderedQueryable<Message>)trashMessages.Where(m => m.Subject.Contains(searchString) || m.ReceiverEmail.Contains(searchString));
            }
            var pagedMessages = trashMessages.ToPagedList(page, pageSize);
            return View(pagedMessages);
        }


        //[HttpGet]


        //public async Task<IActionResult> DeleteMessage(int id)
        //{
           
        //    var deletedMessage = await _context.Messages.FindAsync(id);
        //    if (deletedMessage == null)
        //    {
        //        return NotFound();
        //    }
        //    deletedMessage.isDeleted = true;
        //    _context.Messages.Update(deletedMessage);
        //    await _context.SaveChangesAsync();
        //    ViewBag.MessageDeleted = "Mesaj başarıyla silindi!";
        //    return RedirectToAction(nameof(Inbox));
        //}

        [HttpPost]
        public IActionResult DeleteMessage(int id)
        {
            var message = _context.Messages.Find(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
                return Json(new { success = true, message = "Mesaj başarıyla silindi." });
            }

            return Json(new { success = false, message = "Mesaj bulunamadı." });
        }


        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
           
                message.SenderEmail = user.Email;
                message.SendDate = DateTime.Now;
                message.IsRead = false;

                _context.Messages.Add(message);
                await _context.SaveChangesAsync();

                ViewBag.MessageSent = "Mesaj başarıyla gönderildi!";
                return View(); 
            
        }


        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new LoginViewModel
            {
                Username = user.UserName,
                Name = user.Name,
                Surname = user.SurName,
                Email = user.Email

            };

            return View(model);
        }
    }
}
