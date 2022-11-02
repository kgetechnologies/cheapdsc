using System.Globalization;
using System.Threading;
using System.Web.SessionState;

namespace cheapdscin.Resources
{
	public class CultureHelper
	{
		protected HttpSessionState session;

		//constructor   
		public CultureHelper(HttpSessionState httpSessionState)
		{
			session = httpSessionState;
		}
		// Properties  
		public static int CurrentCulture
		{
			get
			{
				if (Thread.CurrentThread.CurrentUICulture.Name == "en-GB")
				{
					return 1;
				}			
				else
				{
					return 0;
				}
			}
			set
			{

				if (value == 1)
				{
					Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
				}
				else
				{
					Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
				}

				Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
			}
		}
	}
}