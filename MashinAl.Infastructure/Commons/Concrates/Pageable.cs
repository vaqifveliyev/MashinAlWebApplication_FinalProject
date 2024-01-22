using MashinAl.Infastructure.Commons.Abstracts;

namespace MashinAl.Infastructure.Commons.Concrates
{
    public abstract class Pageable : IPageable
    {
        int page = 1, size = 2;
        public int Page
        {
            get
            {
                return page;
            }
            set
            {
                this.page = value > page ? value : page;
            }
        }
        public virtual int Size
        {
            get
            {
                return size;
            }
            set
            {
                this.size = value > size ? value : size;
            }
        }
    }
}
