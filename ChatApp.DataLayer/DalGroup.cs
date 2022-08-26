
using ChatApp.DataLayer.Entity;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = ChatApp.DataLayer.Entity.Group;

namespace ChatApp.DataLayer
{
    public class DalGroup //: IDalBase<Group>
    {
        public ChatAppContext _context;

        public DalGroup(ChatAppContext context)
        {
               _context= context;       
        }


        public void Add(Group entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(Group entity)
        {

            var deleteddEntity = _context.Entry(entity);
            deleteddEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Group Get(Expression<Func<Group, bool>> filter)
        {

            return _context.Set<Group>().SingleOrDefault(filter);

            
        }

        public List<Group> GetAll(Expression<Func<Group, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<Group>().ToList()
                : _context.Set<Group>().Where(filter).ToList();
        }

        public void Update(Group entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
