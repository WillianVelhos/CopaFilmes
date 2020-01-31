using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace CopaFilmes.WebApi.Data_Annotations
{
    public class EnsureEightElementAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count == 8;
            }
            return false;
        }
    }
}
