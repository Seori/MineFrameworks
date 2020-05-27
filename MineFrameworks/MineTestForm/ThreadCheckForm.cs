using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineTestForm
{
    public partial class ThreadCheckForm : Form
    {
        public ThreadCheckForm()
        {
            InitializeComponent();
        }

        private void ThreadCheckForm_Load(object sender, EventArgs e)
        {
            Process proc = Process.GetCurrentProcess();
            ProcessThreadCollection ptc = proc.Threads;

            tbThreadInfo.AppendText("현재 프로세스에서 실행중인 스레드수 : " + ptc.Count + "\r\n");

            if (proc.Id == 5660)
            {
                ThreadInfo(ptc);
            }
            
        }

        private void ThreadInfo(ProcessThreadCollection ptc)
        {
            int i = 1;
            foreach (ProcessThread pt in ptc)
            {
                tbThreadInfo.AppendText("***********" + i++ + " 번째 쓰레드정보 **********\r\n");
                tbThreadInfo.AppendText("쓰레드 ID : " + pt.Id + "\r\n");
                tbThreadInfo.AppendText("쓰레드 시작시간 : " + pt.StartTime + "\r\n");
                tbThreadInfo.AppendText("쓰레드 우선순위 : " + pt.BasePriority + "\r\n");
                tbThreadInfo.AppendText("쓰레드 상태 : " + pt.ThreadState + "\r\n");
            }
        }
    }
}
