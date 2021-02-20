using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Model;

namespace HMS.Data
{
    public class SQLHMSRepo : IHMSRepo
    {
        private readonly HMSDbContext _context;

        public SQLHMSRepo(HMSDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void DisposeTransaction()
        {
            _context.Database.CurrentTransaction.Dispose();
        }



        public void RollBackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public bool saveChanges()
        {
            return (_context.SaveChanges() > 0);
        }


        public User getUserByUserId(string userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);

        }

        public User getUserByToken(string token)
        {
            return _context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
        }

        public void UpdateUser(User user)
        {

            _context.Update(user);
        }

        public RefreshToken getUserRefreshToken(User user, string token)
        {
            return user.RefreshTokens.Single(x => x.Token == token);
        }

        public User getUserbyUsernameAndPassword(string username, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }

        public IEnumerable<User> getUser()
        {
            return _context.Users.ToList();
        }

        public User getUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public void createUser(User user)
        {
            var userExist = _context.Users.FirstOrDefault(u => u.Username == user.Username);
            if (userExist != null)
            {
                throw new Exception("Username Already Exists");

            }
            user.Username = user.Username.ToLower();
            _context.Users.Add(user);
        }

        public IEnumerable<Customer> getAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public void createCustomer(Customer customer)
        {
            var customerExist= _context.Customers.FirstOrDefault(
                c =>c.Phone == customer.Phone
                ||c.Email ==customer.Email
                );

                if (customerExist !=null)
                {
                    throw new Exception("User Already Exist. Please update User");
                }
                customer.Email =customer.Email.ToLower();
                _context.Add(customer);

        }

        public Customer getCustomerByNamePhoneEmail(string Phone)
        {
            return _context.Customers.FirstOrDefault(
                c=>c.Phone ==Phone
                );
        }

        public void createRoomType(RoomType roomType)
        {
            _context.RoomType.Add(roomType);
        }

        public IEnumerable<RoomType> getAllRoomTypes()
        {
            return _context.RoomType.ToList();
        }

        public RoomType getRoomType(int id)
        {
            return _context.RoomType.FirstOrDefault(rt =>rt.Id ==id);
        }
    }
}