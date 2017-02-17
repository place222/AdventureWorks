using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DomainModels
{
    public class BasePageInput: IPageInput
    {
        private int _pageNumber;
        private int _pageSize;
        public int PageNumber
        {
            get
            {
                if (_pageNumber <= 1)
                    return 1;
                return _pageNumber;  
            }
            set
            {
                if (value <= 1)
                    _pageNumber = 1;
                _pageNumber = value;
            }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }
    }
}
