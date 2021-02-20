using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Model;

namespace HMS.Data
{
    public interface IHMSRepo
    {

        bool saveChanges();

        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();

        void DisposeTransaction();

         User getUserByUserId(string userId);
         User getUserByToken(string token);
         void UpdateUser(User user);
         RefreshToken getUserRefreshToken(User user,string token);

         User getUserbyUsernameAndPassword(string username, string password);
         
         IEnumerable<User> getUser();
          User getUserByUsername(string username);

           void createUser(User User);

        IEnumerable<Customer> getAllCustomers();
        
        void createCustomer(Customer customer);

        Customer getCustomerByNamePhoneEmail(string Phone);

        void createRoomType(RoomType roomType);
        IEnumerable<RoomType> getAllRoomTypes();
        RoomType getRoomType(int id);

    }
}