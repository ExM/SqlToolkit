using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace SqlToolkit
{
	public class DbProvider<TConn, TCmd>
		where TConn: DbConnection
		where TCmd: DbCommand
	{

		public InsertCommandBuilder<TConn, TCmd, TTable> Insert<TTable>(TTable tableSchema)
		{

			return new InsertCommandBuilder<TConn, TCmd, TTable>(this, tableSchema);
		}
	}
}
