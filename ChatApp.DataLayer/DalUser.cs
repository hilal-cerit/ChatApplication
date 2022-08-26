using ChatApp.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq.Expressions;


namespace ChatApp.DataLayer
{
    public class DalUser : IDalBase<User>
    {
        public ChatAppContext _context;

        public DalUser(ChatAppContext context)
        {
            _context = context;
        }


           public User? GetBy(int? id=null,string? email=null,string? userName=null)
        {

            return _context.Users.Where(x => (!id.HasValue || x.UserId==id) &&
                                             (string.IsNullOrEmpty(email) || x.Email==email)&&
                                               (string.IsNullOrEmpty(userName) || x.Username == userName)).FirstOrDefault();
        }



        public void Add(User entity)
        {
            var addedEntity = _context.Entry(entity);

            addedEntity.State = EntityState.Added;
            int returnValue =_context.SaveChanges();
            if (returnValue > 0)
            {
                String.Format("{0} User profiles have been updated successfully.", returnValue);



            }
            else
            {
                throw new Exception("No updates have been written to the database.");

            }
        }


        public void Delete(User entity)
        {
            var deleteddEntity = _context.Entry(entity);
            deleteddEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

     

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return filter == null
              ? _context.Set<User>().ToList()
              : _context.Set<User>().Where(filter).ToList();
        }

        public void Update(User entity)
        { 
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool Login(string Username, string Password)
        {
            if (Username != null || Password != null)
            {
                if ( _context.Users.Where(p => (p.Username == Username)  && (p.Password == Password)).FirstOrDefault()!=null)
                {
                    return true;

                }
                return false;
            }
            else { return false; }
        }








        public User Get(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        //public bool Login(string Username, string Password)
        //{
        //    string _username = Username;
        //    string _password = Password;
        //    string _Query = "SELECT * FROM User'" + "' WHERE Username='" + _username + "'AND Password='" + _password + "'";

        //    SqlConnection Con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=ChatApp;Trusted_Connection=True;");
        //    Con.Open();
        //    SqlCommand cmd = new SqlCommand(_Query, _context.Users);
        //    SqlDataReader dataReader = cmd.ExecuteReader();
        //    while (dataReader.Read())
        //    {
        //        if (_username == dataReader["Username"].ToString() && _password == dataReader["Password"].ToString())
        //        {
        //            return true;
        //        }
        //    }
        //    return false;


    }
}
