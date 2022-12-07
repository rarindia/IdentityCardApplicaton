﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDC.Base.DTO
{
  public  interface IBaseEntityResponse<T> where T:IBaseDTO
    {
        T Entity { get; set; }

        IList<IMessageDTO> Message { get; set; }
    }
}
