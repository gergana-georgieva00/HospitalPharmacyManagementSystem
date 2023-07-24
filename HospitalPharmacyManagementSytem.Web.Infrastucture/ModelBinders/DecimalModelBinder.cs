using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace HospitalPharmacyManagementSytem.Web.Infrastucture.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext? bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None
                && !string.IsNullOrWhiteSpace(valueResult.FirstValue))
            {
                decimal parsedValue = 0m;
                bool success = false;

                try
                {
                    string formDecimalValue = valueResult.FirstValue;
                    formDecimalValue = formDecimalValue.Replace(",", CultureInfo.CurrentCulture
                        .NumberFormat.NumberDecimalSeparator);
                    formDecimalValue = formDecimalValue.Replace(".", CultureInfo.CurrentCulture
                        .NumberFormat.NumberDecimalSeparator);

                    parsedValue = Convert.ToDecimal(formDecimalValue);
                    success = true;
                }
                catch (FormatException e)
                {
                    bindingContext.ModelState.AddModelError(
                        bindingContext.ModelName, e, bindingContext.ModelMetadata);
                }

                if (success) 
                {
                    bindingContext.Result = ModelBindingResult.Success(parsedValue);
                }
            }

            return Task.CompletedTask;
        }
    }
}
