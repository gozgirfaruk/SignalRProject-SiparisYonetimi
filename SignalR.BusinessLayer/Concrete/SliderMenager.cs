using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class SliderMenager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderMenager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void TDelete(Slider entity)
        {
            _sliderDal.Delete(entity);
        }

        public Slider TGetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public List<Slider> TGetListAll()
        {
            return _sliderDal.GetListAll();
        }

        public void TInsert(Slider entity)
        {
           _sliderDal.Insert(entity);
        }

        public void TUpdate(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}
