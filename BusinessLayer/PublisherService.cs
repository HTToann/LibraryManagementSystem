using DataLayer;
using DTOs;
using System.Collections.Generic;
namespace BusinessLayer
{
    public class PublisherService
    {
        private PublisherRepository _repo;
        public PublisherService()
        {
            _repo = new PublisherRepository();
        }
        public List<PublisherDTO> GetAllPublishers()
        {

            return _repo.GetAllPublishers();
        }
        public bool InsertPublisher(PublisherDTO publisher)
        {
            return _repo.InsertPublisher(publisher);
        }
        public bool UpdatePublisherr(PublisherDTO publisher)
        {
            return _repo.UpdatePublisher(publisher);
        }
        public bool DeletePublisher(int publisherId)
        {
            return _repo.DeletePublisher(publisherId);
        }
        public List<PublisherDTO> GetPublisherByName(string kw)
        {
            return _repo.SearchPublisherByName(kw);
        }
        public PublisherDTO GetPublisherById(int id)
        {
            return _repo.SearchPublisherById(id);
        }
    }
}
