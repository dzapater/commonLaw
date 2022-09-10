namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces
{
    public interface ICustomPageInfo
    {
        int CurrentPage { get; set; }

        int PageSize { get; set; }

        bool HasPrevious { get; set; }

        bool HasNext { get; set; }
        
        int TotalRecords { get; set; }
    }
}