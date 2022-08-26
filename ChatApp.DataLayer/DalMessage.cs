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
    public class DalMessage : IDalBase<Message>
    {
        public ChatAppContext _context;

        public DalMessage(ChatAppContext context)
        {
            _context = context;
        }


      

        public void Delete(Message entity)
        {

            var deleteddEntity = _context.Entry(entity);
            deleteddEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Message Get(Expression<Func<Message, bool>> filter)
        {

            return _context.Set<Message>().SingleOrDefault(filter);


        }

        public List<Message> GetAll(Expression<Func<Message, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<Message>().ToList()
                : _context.Set<Message>().Where(filter).ToList();
        }

        public void Update(Message entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(Message entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }








        public Message? GetBy(int? id = null, string? email = null, string? userName = null)
        {
            throw new NotImplementedException();
        }
    }
}
