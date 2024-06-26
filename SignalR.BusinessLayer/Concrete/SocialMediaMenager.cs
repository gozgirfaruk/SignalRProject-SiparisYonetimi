using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class SocialMediaMenager : ISocialMediaService
    {
        private readonly ISocialMediaDal _mediaDal;

        public SocialMediaMenager(ISocialMediaDal mediaDal)
        {
            _mediaDal = mediaDal;
        }

        public void TDelete(SocialMedia entity)
        {
           _mediaDal.Delete(entity);
        }

        public SocialMedia TGetById(int id)
        {
            return _mediaDal.GetById(id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return _mediaDal.GetListAll();
        }

        public void TInsert(SocialMedia entity)
        {
            _mediaDal.Insert(entity);
        }

        public void TUpdate(SocialMedia entity)
        {
            _mediaDal.Update(entity);
        }
    }
}
