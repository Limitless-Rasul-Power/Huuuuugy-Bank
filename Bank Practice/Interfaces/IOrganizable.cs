using Bank_Practice.Entities;

namespace Bank_Practice.Interfaces
{
    public interface IOrganizable
    {
        void Organize(in Worker[] workers);
    }
}
