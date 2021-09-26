using System;
using WsSchool.Core.Models.DTOs;

namespace WsSchool.Core.Interfaces
{
#nullable enable
    public interface IValidate : IDisposable
    {
        LoginDTO? Validate(AccessDTO model);
    }
#nullable disable
}
