using DAL;

namespace API.Services.Base;

public abstract class Service
{
    protected DataContext Context { get; set; }
}