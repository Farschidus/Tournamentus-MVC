using FluentValidation.Results;
using System.Collections.Generic;

namespace Tournamentus.Core.Contracts
{
    public interface IResponseBase
    {
        IEnumerable<ValidationFailure> Errors { get; set; }

        bool IsValid { get; set; }
    }

    public interface IResponseBase<TResult> : IResponseBase
    {
        TResult Result { get; set; }
    }
}
