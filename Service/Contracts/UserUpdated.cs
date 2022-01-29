namespace Contracts
{
    using System;
    public record UserUpdated
    {
        public int EmployeeId { get; init; }
        public string Name { get; init; }
        public DateTime LastLogin{get;set;}
    }
}