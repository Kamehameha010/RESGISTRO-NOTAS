using System;
using System.Collections.Generic;
using System.Text;
using WsSchool.Core.Interfaces;
using WsSchool.Core.Models.DTOs;
using WsSchool.Core.Models.Entities;

using System.Linq;
using WsSchool.Core.Repository;
using WsSchool.Core.Utility;
using WsSchool.Core.Models.Mysql;

namespace WsSchool.Core.Services
{
#nullable enable
    public class ValidateUser : IValidate
    {
        //private readonly IUnitWork _unitWork;
        private readonly SchoolDbContext _context;
        private readonly IEncrypt _encrypt;
        public ValidateUser(SchoolDbContext context, IEncrypt encrypt)
        {
            _context = context;
            _encrypt = new EncryptSha256();
        }

        public LoginDTO? Validate(AccessDTO model)
        {
            return _context.Login.Where(x => x.Username.Equals(model.Username) && x.Password.Equals(_encrypt.EncryptString(model.Password)))
                .Select(x => new LoginDTO {
                    LoginId = 0,
                    Username = x.Username,
                    Password = "",
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
