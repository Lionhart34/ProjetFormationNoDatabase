using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjetFormationDebug.Converter
{
    public class EnumStringConverter : IValueConverter
    {
        // data -> ui
        //OuiNonBoolConverter
        // Enum -> string
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Param = parameter as string;

            bool ToUpper = false;

            if (!string.IsNullOrEmpty(Param))
            {
                ToUpper = Param.ToLower().Trim() == "toupper";
            }

            string retour = GetEnumValueDescription((Enum)value);
            return (ToUpper ? retour.ToUpper() : retour);
        }

        // string -> Enum
        // impossible de faire un retour quand on ne connais pas le type de l'emun
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        private string GetEnumValueDescription(Enum enumValue)
        {
            FieldInfo fInfo = enumValue.GetType().GetField(enumValue.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length == 0)
            {
                return enumValue.ToString();
            }
            else
            {
                return attributes[0].Description;
            }
        }
    }

    public class EnumConverter : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType.IsAssignableFrom(typeof(Boolean)) && targetType.IsAssignableFrom(typeof(String)))
                // throw new ArgumentException("EnumConverter can only convert to boolean or string.");
                return value.ToString();

            if (targetType == typeof(String))
                return value.ToString();

            return String.Compare(value.ToString(), (String)parameter, StringComparison.InvariantCultureIgnoreCase) == 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {

                if (targetType.IsAssignableFrom(typeof(Boolean)) && targetType.IsAssignableFrom(typeof(String)))
                    throw new ArgumentException("EnumConverter can only convert back value from a string or a boolean.");
                if (!targetType.IsEnum)
                    throw new ArgumentException("EnumConverter can only convert value to an Enum Type.");

                if (value.GetType() == typeof(String))
                {
                    return Enum.Parse(targetType, (String)value, true);
                }
                else
                {
                    //We have a boolean, as for binding to a checkbox. we use parameter
                    if ((Boolean)value)
                        return Enum.Parse(targetType, (String)parameter, true);
                }
            }
            return null;
        }

        #endregion
    }

    public class EnumToDescriptionConverter : IValueConverter
    {
        static readonly Dictionary<Type, Dictionary<object, string>> DescriptionCache = new Dictionary<Type, Dictionary<object, string>>();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            Dictionary<object, string> descriptions = ObtenirDescription(value);

            string realDescription;
            if (descriptions.TryGetValue(value, out realDescription))
            {
                return realDescription;
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            Dictionary<object, string> descriptions = ObtenirDescription(value);
            var correspondingPair = descriptions.FirstOrDefault(pair => string.Equals(value, pair.Value));
            return correspondingPair.Key;
        }
        private static Dictionary<object, string> ObtenirDescription(object value)
        {
            Type enumType = value.GetType();
            Dictionary<object, string> descriptions;

            if (!DescriptionCache.TryGetValue(enumType, out descriptions))
            {
                descriptions = new Dictionary<object, string>();
                var fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);

                foreach (var field in fields)
                {
                    //Obtention de la valeur du champ dans l'enum
                    object fieldValue = field.GetValue(null);
                    if (fieldValue == null) continue;

                    //Obtention de la valeur descriptio de l'element field
                    var att = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                .FirstOrDefault() as DescriptionAttribute;

                    string description = (att != null) ? att.Description : field.Name;

                    //Ajout de la descriotion de la valeur courante au resultat
                    descriptions.Add(fieldValue, description);
                }
                DescriptionCache.Add(enumType, descriptions);
            }
            return descriptions;
        }

    }
}
