namespace ValidationAttributes.Utilities
{
    using System.Linq;
    using System.Reflection;

    using ValidationAttributes.Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;   
            }

            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var propertyAttributes = property.GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (MyValidationAttribute propertyAttribute in propertyAttributes)
                {
                    var value = property.GetValue(obj);
                    if (!propertyAttribute.IsValid(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
