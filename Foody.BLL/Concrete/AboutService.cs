using Foody.BLL.Abstract;
using Foody.CORE.Entities;
using Foody.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutService(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public int Create(About entity)
        {
            return _aboutDal.Create(entity);
        }

        public int Delete(int id)
        {
            return _aboutDal.Delete(id);
        }

        public List<About> GetAll(Expression<Func<About, bool>> filter = null)
        {
            return _aboutDal.GetAll(filter);
        }

        public About GetOne(int Id)
        {
            return _aboutDal.GetOne(Id);
        }

        public int Update()
        {
            return _aboutDal.Update();
        }
    }
}
