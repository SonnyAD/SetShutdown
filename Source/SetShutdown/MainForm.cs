using System;
using System.Windows.Forms;
using System.Drawing;

namespace SetShutdown
{
    public partial class MainForm : Form
    {
        private Point m_startDraggingPosition = Point.Empty;

        public MainForm()
        {
            InitializeComponent();

            m_listTiming.SelectedIndex = 3;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 10, 
                                      Screen.PrimaryScreen.Bounds.Height - this.Height - 35 );
            this.Opacity = 0.8;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents=false;
            proc.StartInfo.FileName="shutdown";

            switch (m_listTiming.SelectedIndex)
            {
                case 1:
                    proc.StartInfo.Arguments = "/s /t 1800";
                    break;
                case 2:
                    proc.StartInfo.Arguments = "/s /t 2700";
                    break;
                case 3:
                    proc.StartInfo.Arguments = "/s /t 3600";
                    break;
                case 4:
                    proc.StartInfo.Arguments = "/s /t 5400";
                    break;
                case 5:
                    proc.StartInfo.Arguments = "/s /t 7200";
                    break;
                case 0:
                default:
                    proc.StartInfo.Arguments = "/s /t 900";
                    break;

            }

            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "shutdown";
            proc.StartInfo.Arguments = "/a";
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                m_startDraggingPosition = e.Location;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_startDraggingPosition != Point.Empty)
            {
                this.Left = this.PointToScreen(e.Location).X - m_startDraggingPosition.X;
                this.Top = this.PointToScreen(e.Location).Y - m_startDraggingPosition.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            m_startDraggingPosition = Point.Empty;
        }
    }
}
