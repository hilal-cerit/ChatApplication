
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
    public class DalGroupMember// : IDalBase<GroupMember>
    {
        public ChatAppContext _context;
        public DalGroupMember(ChatAppContext context)
        {
            _context = context;
        }

        public void Add(GroupMember entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
            _context.SaveChanges();
        }

        public void Delete(GroupMember entity)
        {
            var deleteddEntity = _context.Entry(entity);
            deleteddEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public GroupMember Get(Expression<Func<GroupMember, bool>> filter)
        {
            return _context.Set<GroupMember>().SingleOrDefault(filter);
        }

        public List<GroupMember> GetAll(Expression<Func<GroupMember, bool>> filter = null)
        {
            return filter == null
              ? _context.Set<GroupMember>().ToList()
              : _context.Set<GroupMember>().Where(filter).ToList();
        }

        public void Update(GroupMember entity)
        {

            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
