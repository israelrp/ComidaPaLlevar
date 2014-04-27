using System;
using ComidaPaLlevar.Connection;
namespace ComidaPaLlevar.Dal.Implementation.Abstracts
{
	public abstract class BaseDaoImpl : IDisposable
	{
		DataContext context = new DataContext();
		public void Dispose()
		{
			if (context != null)
			{
				context.Dispose();
				context = null;
			}
		}
		public DataContext Context
		{
			get { return context; }
		}
	}
}
