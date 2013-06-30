using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotionApp
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}
	}
	public class MyWork
	{
		BackgroundWorker _bgworker;
		public MyWork()
		{
			_bgworker.WorkerSupportsCancellation = true;
			_bgworker.WorkerReportsProgress = true;
			_bgworker.DoWork += (sender, e) => { 
			
			};
			
		}
		public void Start()
		{

		}

	}
}
