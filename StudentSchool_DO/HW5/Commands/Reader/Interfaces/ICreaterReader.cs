﻿using ServiceModels.Responses.Reader;
using ServiceModels.Requests;
using WebLibrary.Commands.Common_interfaces;

namespace WebLibrary.Commands.Reader.Interfaces;

public interface ICreaterReader : ICreater<CreateReaderRequest, CreateReaderResponse>
{
}
