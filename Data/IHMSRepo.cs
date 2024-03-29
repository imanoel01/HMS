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

         User getUserByUserId(long userId);
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

        Customer getCustomerById(long id);
        #region Room Type
        void createRoomType(RoomType roomType);
        IEnumerable<RoomType> getAllRoomTypes();
        RoomType getRoomType(long id);
        void updateRoomType(RoomType roomtype);
        void deleteRoomType(RoomType roomType);
        #endregion
      
      #region Room
        void createRoom(Room room);
        IEnumerable<Room> getAllRooms();

        dynamic getreadRooms();
        Room getRoom(long id);
        void updateRoom(Room room);
        IEnumerable<Room> GetFreeRoom();

       void updateRoomStatus(long roomId, RoomStatusEnum roomstatusenum);
      #endregion
        void deleteCustomer(Customer customer);

        void updateCustomer(Customer customer);

        #region  Room Status
        void createRoomStatus(RoomStatus rooms);
        IEnumerable<RoomStatus> GetRoomStatus();
        RoomStatus GetRoomStatus(long id);
        
        #endregion

        #region Reservation
      void createReservation (Reservation reservation);
      IEnumerable<Reservation> GetReservations();

      Reservation GetReservation(long id);

        #endregion

        #region Bills
      dynamic GetBills();
        #endregion
    }
}