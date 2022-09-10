using System;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Implementations
{
    public class CustomPageInfo : ICustomPageInfo
    {
        private bool? _hasPrevious;
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious
        {
            get => _hasPrevious ?? CurrentPage > 1;
            set => _hasPrevious = value;
        }
        public bool HasNext { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int) Math.Ceiling(Convert.ToDecimal(TotalRecords)/PageSize);
    }
}