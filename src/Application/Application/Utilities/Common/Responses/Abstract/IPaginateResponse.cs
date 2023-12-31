namespace Application.Utilities.Common.Responses.Abstract;

public interface IPaginateResponse
{
    public int Size { get; }
    public int Index { get; }
    public int Count { get; }
    public int Pages { get; }
    //public IList<T> Items { get; set; }
    ////public bool HasPrevious => Index > 0;
    ////public bool HasNext => Index + 1 < Pages;
    public bool HasPrevious { get; }
    public bool HasNext { get; }
}
