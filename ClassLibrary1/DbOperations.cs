using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_v1
{
    class DbOperations
    {
        Model1 db;
        public DbOperations()
        {
            db = new Model1();
        }
        public DbSet<Client> GetAllClient()
        {
            return db.Clients;
        }
        public  DbSet<Kategory> GetAllKategory()
        {
            return db.Kategory;
        }
        public  DbSet<Log> GetAllLog()
        {
            return db.Log;
        }
        public DbSet<Number> GetAllNumber()
        {
            return db.Number;
        }
        public  DbSet<Pay> GetAllPay()
        {
            return db.Pay;
        }
        public  DbSet<Service> GetAllService()
        {
            return db.Service;
        }
        public  DbSet<Status> GetAllStatus()
        {
            return db.Status;
        }
        public  DbSet<Uchet> GetAllUchet()
        {
            return db.Uchet;
        }
        public DbSet<Worker> GetAllWorker()
        {
            return db.Worker;
        }
        public Status FindStatus(int id)
        {
           return db.Status.Find(id);
        }
        public Client FindClient(int id)
        {
            return db.Clients.Find(id);
        }
        public Kategory FindKategory(int id)
        {
            return db.Kategory.Find(id);
        }
        public void RemoveClient(Client client)
        {
            db.Clients.Remove(client);
        }
        public void AddClient(Client client)
        {
            db.Clients.Add(client);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
