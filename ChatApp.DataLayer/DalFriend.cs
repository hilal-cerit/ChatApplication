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
    public class DalFriend //: IDalBase<Friend>
    {

        public ChatAppContext _context;

        public DalFriend(ChatAppContext context)
        {
            _context = context;
        }

        public void Add(Friend entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(Friend entity)
        {
            var deleteddEntity = _context.Entry(entity);
            deleteddEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Friend Get(Expression<Func<Friend, bool>> filter)
        {
            return _context.Set<Friend>().SingleOrDefault(filter);
        }

        public List<Friend> GetAll(Expression<Func<Friend, bool>> filter = null)
        {
            return filter == null
               ? _context.Set<Friend>().ToList()
               : _context.Set<Friend>().Where(filter).ToList();
        }

        public void Update(Friend entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
