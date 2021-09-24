using System;
using System.Collections.Generic;
using System.Text;
using WsSchool.Core.Interfaces;
using WsSchool.Core.Models.DTOs;
using WsSchool.Core.Models.Entities;
using WsSchool.Core.Models.Mysql;
using System.Linq;
using WsSchool.Core.Repository;
using WsSchool.Core.Utility;

namespace WsSchool.Core.Services
{
#nullable enable
    public class ValidateUser : IValidate<LoginDTO>, IDisposable
    {
        //private readonly IUnitWork _unitWork;
        private readonly SchoolDbContext _context;
        private readonly IEncrypt _encrypt;
        public ValidateUser()
        {
            _context = new SchoolDbContext();
            _encrypt = new EncryptSha256();
        }

        public LoginDTO? Validate(LoginDTO model)
        {
            return _context.Login.Where(x => x.Username.Equals(model.Username) && x.Password.Equals(_encrypt.EncryptString(model.Password)))
                .Select(x => new LoginDTO {
                    Username = x.Username,
                    RolId = x.RolId
                }).FirstOrDefault();
        }
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
#nullable disable
}
