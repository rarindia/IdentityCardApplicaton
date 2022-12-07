namespace IDC.Base.DTO
{
   public interface IValidateBusinessRuleResponse:IBaseResponse
    {
       bool Passed { get; set; }           
    }
}
