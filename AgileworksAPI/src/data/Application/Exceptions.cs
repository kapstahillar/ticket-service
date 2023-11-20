
namespace AgileworksAPI.Application.Exceptions;


[Serializable]
class NotFoundException : Exception
{
    public NotFoundException() : base("Entity not found") { }

    public NotFoundException(string text)
        : base(text)
    { }
}



