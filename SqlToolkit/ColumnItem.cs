using System;

namespace SqlToolkit
{
	public class ColumnItem
	{
		public string Name {get; private set;}
		public Type Type {get; private set;}
		
		
		public ColumnItem(string name, Type type)
		{
			Name = name;
			Type = type;
		}
	}
}

