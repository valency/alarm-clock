using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Alarm_Clock {
    public partial class Form1 : Form {
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        public Form1() {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Tick += new EventHandler(alarm);
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Start();
        }

        public void alarm(object sender, EventArgs e) {
            System.DateTime time = System.DateTime.Now;
            label1.Text = time.ToLongTimeString();
            if (numericUpDown1.Value == 0 && numericUpDown2.Value == 0) return;
            if (player.playState != WMPLib.WMPPlayState.wmppsPlaying && time.Hour >= numericUpDown1.Value && time.Minute >= numericUpDown2.Value) {
                button1_Click(sender, e);
            }
        }

        private void textBox1_Click(object sender, EventArgs e) {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e) {
            player.URL = textBox1.Text;
            player.controls.play();
        }

        private void button2_Click(object sender, EventArgs e) {
            player.controls.stop();
        }
    }
}
