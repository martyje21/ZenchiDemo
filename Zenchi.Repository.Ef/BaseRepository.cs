namespace Zenchi.Repository.Ef
{
    public class BaseRepository
    {
        private MappingUtility _mapper = null;
                
        protected MappingUtility Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    _mapper = new MappingUtility();
                }
                return _mapper;
            }
        }
    }
}
