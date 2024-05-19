using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendBox(string p);
        List<Message> GetListAdminInbox();
        List<Message> GetListAdminSendbox();
        void Add(Message message);
        Message GetByID(int id);
        void Delete(Message message);
        void Update(Message message);
    }
}
