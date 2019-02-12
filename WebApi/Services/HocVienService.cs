using WebApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class HocVienService
    {
        private readonly IMongoCollection<HocViens> _hocVien;
        public HocVienService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Demo1"));
            var database = client.GetDatabase("Demo1");
            _hocVien = database.GetCollection<HocViens>("HocViens");
        }
        public List<HocViens> Get()
        {
            return _hocVien.Find(HocViens => true).ToList();
        }
        public HocViens Get(string id)
        {
            return _hocVien.Find(HocViens => HocViens.Id == id).FirstOrDefault();
        }
        public HocViens Create(HocViens hocVien)
        {
            _hocVien.InsertOne(hocVien);
            return hocVien;
        }
        public void Update(string id,HocViens hocVien)
        {
            _hocVien.ReplaceOne(HocViens => HocViens.Id == id, hocVien);
        }
        public void Remove(HocViens hocVien)
        {
            _hocVien.DeleteOne(HocViens=>HocViens.Id==hocVien.Id);
        }
        public void Remove(string Id)
        {
            _hocVien.DeleteOne(HocViens => HocViens.Id == Id);
        }
    }
}
