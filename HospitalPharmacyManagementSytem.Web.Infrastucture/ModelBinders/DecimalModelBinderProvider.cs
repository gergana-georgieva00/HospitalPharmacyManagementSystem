using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HospitalPharmacyManagementSytem.Web.Infrastucture.ModelBinders
{
    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(decimal)
                || context.Metadata.ModelType == typeof(decimal?))
            {
                return new DecimalModelBinder();
            }

            return null!;
        }
    }
}
