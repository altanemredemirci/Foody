using Foody.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Abstract
{
    public interface IMailService
    {
        int Sendmail(string mail);
    }
}
