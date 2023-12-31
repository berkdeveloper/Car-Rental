using Application.Utilities.Common.Responses.Abstract;
using Application.Utilities.Common.Responses.ComplexTypes;

namespace Application.Utilities.Common.Responses.Concrete
{
    public class GetByIdBaseResponse<T> : ResponseBase, IObjectResponse<T>
    {
        public T Data { get; }
    }
}
