using Application.Utilities.Common.Responses.Abstract;

namespace Application.Utilities.Common.Responses.Concrete;

public class PagedListBaseResponse<T> : ListBaseResponse<T>, IPaginateResponse
{
    public int Size { get; set; }

    public int Index { get; set; }

    public int Count { get; set; }

    public int Pages { get; set; }

    public bool HasPrevious => Index > 0;

    public bool HasNext => Index + 1 < Pages;
}
