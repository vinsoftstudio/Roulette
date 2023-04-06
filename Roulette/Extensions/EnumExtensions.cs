using System.ComponentModel;
using System.Reflection;

namespace Roulette.Extensions
{
	public static class EnumExtensions
	{
		public static string GetDescription(this Enum value)
		{
			FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

			object[] attribArray = fieldInfo.GetCustomAttributes(false);

			if (attribArray.Length == 0)
			{
				return value.ToString();
			}
			else
			{
				DescriptionAttribute attrib = attribArray[0] as DescriptionAttribute;
				return attrib.Description;
			}
		}
	}
}
