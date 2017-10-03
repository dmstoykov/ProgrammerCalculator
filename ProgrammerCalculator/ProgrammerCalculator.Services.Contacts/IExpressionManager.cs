using System;

namespace ProgrammerCalculator.Services.Contacts
{
    public interface IExpressionManager
    {
        long CurrentResult { get; }

        string LastInputString { get; }
    }
}
