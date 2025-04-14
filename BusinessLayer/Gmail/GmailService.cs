using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DTOs;
using MailKit.Net.Smtp;
using MimeKit;

namespace BusinessLayer.Gmail
{
    public class GmailService
    {
        private BorrowReturnBookRepository _borrowRepo;
        private ReaderRepository _readerRepo;

        public GmailService ()
        {
            _borrowRepo = new BorrowReturnBookRepository();
            _readerRepo = new ReaderRepository();
        }
        public List<(ReaderDTO Reader, BorrowReturnBookDTO Borrow)> GetReadersToNotify(int daysBefore = 3)
        {
            var allBorrows = _borrowRepo.GetAllBorrowReturnBooks(); // hoặc GetActive()
            var readers = _readerRepo.GetAllReaders();

            var result = new List<(ReaderDTO, BorrowReturnBookDTO)>();

            foreach (var borrow in allBorrows)
            {
                if (borrow.StatusID == 1 &&
                     borrow.DateReturn.Date <= DateTime.Today.AddDays(daysBefore) &&
                        borrow.DateReturn.Date >= DateTime.Today)

                {
                    var reader = readers.FirstOrDefault(r => r.ReaderID == borrow.ReaderID);
                    if (reader != null && !string.IsNullOrEmpty(reader.Gmail))
                        result.Add((reader, borrow));
                }
            }
            return result;
        }
        public void SendEmailReminder(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Library Admin", "nodpou7@gmail.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("nodpou7@gmail.com", "crht wsrb brrx tqbu");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
