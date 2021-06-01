using AutoMapper;

namespace Server.Infrastructure.Mappings.Contracts
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}