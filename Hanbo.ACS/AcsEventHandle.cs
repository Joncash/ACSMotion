using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hanbo.ACS
{
	public class AcsEventHandle
	{
		
	}

	public delegate void AxisEnableEventHandler(object sender, object eventArgs);
	public delegate void XAxisMoveEventHandler(object sender, double position);
	public delegate void YAxisMoveEventHandler(object sender, double position);
	public delegate void ZAxisMoveEventHandler(object sender, double position);
	public delegate void AxisHaltEventHandler(object sender, object eventArgs);
	public delegate void ErrorEventHandler(object sender, COMException exception);
	public delegate void InitMotionEventHandler(object sender, string eventArgs);
	public delegate void DisableAxisAllMotionEventHandler(object sender, string eventArgs);
	public delegate void ResetEventHandler(object sender, string eventArgs);

}
