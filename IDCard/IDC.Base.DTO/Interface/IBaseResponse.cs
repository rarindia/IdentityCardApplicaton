using System.Collections.Generic;

namespace IDC.Base.DTO
{
    public interface IBaseResponse
    {
        List<MessageDTO> Message
        {
            get;
            set;
        }
    }
}
