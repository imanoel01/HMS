using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Model;

namespace HMS.Data
{
    public class MockHMSRepo : IHMSRepo
    {
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void createCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void createRoomStatus(RoomStatus rooms)
        {
            throw new NotImplementedException();
        }

        public void createRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public void createRoomType(RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public void createUser(User User)
        {
            throw new NotImplementedException();
        }

        public void deleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DisposeTransaction()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> getAllCustomers()
        {

            List<Customer> customers = new List<Customer>(){

new Customer{FirstName="James",LastName="Bill",MiddleName="U"},
new Customer{FirstName="Oinko",LastName="Walie", MiddleName="I"},
new Customer{FirstName="James",LastName="Bill",MiddleName="U"},
new Customer{FirstName="DOnald",LastName="Joe", MiddleName="I"},
new Customer{FirstName="Trump",LastName="Biden",MiddleName="U"},
new Customer{FirstName="JUnior",LastName="Harris", MiddleName="I"},
            };
            return customers;
        }

        public IEnumerable<Room> getAllRooms()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomType> getAllRoomTypes()
        {
            throw new NotImplementedException();
        }

        public Customer getCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer getCustomerByNamePhoneEmail(string Phone)
        {
            throw new NotImplementedException();
        }

        public Room getRoom(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomStatus> GetRoomStatus()
        {
            throw new NotImplementedException();
        }

        public RoomStatus GetRoomStatus(int id)
        {
            throw new NotImplementedException();
        }

        public RoomType getRoomType(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> getUser()
        {
            throw new NotImplementedException();
        }

        public User getUserByToken(string token)
        {
            throw new NotImplementedException();
        }

        public User getUserByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public User getUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public User getUserbyUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        public RefreshToken getUserRefreshToken(User user, string token)
        {
            throw new NotImplementedException();
        }

        public void RollBackTransaction()
        {
            throw new NotImplementedException();
        }

        public bool saveChanges()
        {
            throw new NotImplementedException();
        }

        public void updateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void deleteRoomType(RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public void updateRoomType(RoomType roomtype)
        {
            throw new NotImplementedException();
        }

        public void updateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetFreeRoom()
        {
            throw new NotImplementedException();
        }

        public void createReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetReservations()
        {
            throw new NotImplementedException();
        }

        public Reservation GetReservation(int id)
        {
            throw new NotImplementedException();
        }

        public dynamic getreadRooms()
        {
            throw new NotImplementedException();
        }
    }
}