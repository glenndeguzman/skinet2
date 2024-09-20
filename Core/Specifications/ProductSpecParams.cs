using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductSpecParams
    {

        private List<string> _brands = [];
        private List<string> _types = [];
        private const int MaxPageSize = 50;
        private int _pageSize = 6;
        public int PageIndex { get; set; } = 1;

        public List<string> Brands
        {
            get { return _brands; } // brands=nike,adidas
            set
            {
                _brands = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
        }

        public List<string> Types
        {
            get { return _types; } // types=boards,gloves
            set
            {
                _types = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
        }

        public string? Sort { get; set; }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        private string? _search;
        public string Search
        {
            get { return _search ?? string.Empty; }
            set { _search = value.ToLower(); }
        }


    }
}