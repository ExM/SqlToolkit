using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlToolkit
{
	public class Column<T>
	{
		public string Name { get; private set;}

		public Column(string name)
		{
			Name = name;
		}
	}
}
