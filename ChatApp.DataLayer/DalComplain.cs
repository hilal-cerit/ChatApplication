using ChatApp.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.DataLayer
{
    public class DalComplain //: IDalBase<Complain>
    {
        public ChatAppContext _context;

        public DalComplain(ChatAppContext context)
        {
            _context = context;
        }

        public void Add(Complain entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(Complain entity)
        {

            var deleteddEntity = _context.Entry(entity);
            deleteddEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }
        /*
        public Complain Get(Expression<Func<Complain, bool>> filter)
        {

            return _context.Set<Complain>().SingleOrDefault(filter);


        }
        */
        public List<Complain> GetAll(Expression<Func<Complain, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<Complain>().ToList()
                : _context.Set<Complain>().Where(filter).ToList();
        }


        public void Update(Complain entity)
        { var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
    
        }
    }
}
