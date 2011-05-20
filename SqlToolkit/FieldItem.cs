using System;
using System.Reflection;

namespace SqlToolkit
{
	public class FieldItem
	{
		public PropertyInfo Field {get; set;}
		public MethodInfo Converter {get; set;}
		public int[] ArgColumns {get; set;}
		
		public FieldItem(PropertyInfo field, MethodInfo conv, params int[] argColumns)
		{
			Field = field;
			Converter = conv;
			ArgColumns = argColumns;
		}
	}
}

