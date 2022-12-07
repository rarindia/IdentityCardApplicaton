using IDC.Base.DTO;
using IDC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IDC.DataProvider
{
    public interface IStudentIdentityCardDataProvider
    {
        IBaseEntityResponse<StudentIdentityCard> InsertStudentIdentityCard(StudentIdentityCard item);
        IBaseEntityResponse<StudentIdentityCard> UpdateStudentIdentityCard(StudentIdentityCard item);
        IBaseEntityResponse<StudentIdentityCard> DeleteStudentIdentityCard(StudentIdentityCard item);
        IBaseEntityCollectionResponse<StudentIdentityCard> GetStudentIdentityCardBySearch(StudentIdentityCardSearchRequest searchRequest);
        IBaseEntityResponse<StudentIdentityCard> GetStudentIdentityCardByID(StudentIdentityCard item);
        IBaseEntityCollectionResponse<StudentIdentityCard> GetOrganisationStudyCentreList(StudentIdentityCardSearchRequest searchRequest);
    }
}
