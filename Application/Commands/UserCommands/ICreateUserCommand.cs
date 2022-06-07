﻿using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.UserCommands
{
    public interface ICreateUserCommand : ICommand<CreateUserDto>
    {
    }
}
