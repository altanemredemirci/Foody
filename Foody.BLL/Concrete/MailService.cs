using Foody.BLL.Abstract;
using Foody.CORE.Entities;
using Foody.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Concrete
{
    public class MailService : IMailService
    {
        private readonly IMailDal _mailDal;

        public MailService(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public int Sendmail(string mail)
        {
            return _mailDal.Sendmail(mail);
        }
    }
}
