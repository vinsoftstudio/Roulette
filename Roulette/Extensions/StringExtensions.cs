using System.ComponentModel;
using System.Reflection;

namespace Roulette.Extensions
{
	public static class StringExtensions
	{
		public static T GetEnumValueFromDescription<T>(this string description)
		{
			MemberInfo[] fis = typeof(T).GetFields();

			foreach (var fi in fis)
			{
				DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

				if (attributes != null && attributes.Length > 0 && attributes[0].Description == description)
					return (T)Enum.Parse(typeof(T), fi.Name);
			}

			throw new Exception("Not found");
		}
	}
}
