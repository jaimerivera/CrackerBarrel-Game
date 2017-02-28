using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrackerBarrelGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BoardAI ai = new BoardAI();
            Board board = new Board();
            
            board.Positions[0] = Convert.ToInt32(checkBox0.Checked);
            board.Positions[1] = Convert.ToInt32(checkBox1.Checked);
            board.Positions[2] = Convert.ToInt32(checkBox2.Checked);
            board.Positions[3] = Convert.ToInt32(checkBox3.Checked);
            board.Positions[4] = Convert.ToInt32(checkBox4.Checked);
            board.Positions[5] = Convert.ToInt32(checkBox5.Checked);
            board.Positions[6] = Convert.ToInt32(checkBox6.Checked);
            board.Positions[7] = Convert.ToInt32(checkBox7.Checked);
            board.Positions[8] = Convert.ToInt32(checkBox8.Checked);
            board.Positions[9] = Convert.ToInt32(checkBox9.Checked);
            board.Positions[10] = Convert.ToInt32(checkBox10.Checked);
            board.Positions[11] = Convert.ToInt32(checkBox11.Checked);
            board.Positions[12] = Convert.ToInt32(checkBox12.Checked);
            board.Positions[13] = Convert.ToInt32(checkBox13.Checked);
            board.Positions[14] = Convert.ToInt32(checkBox14.Checked);
            textBox2.Text = null ;
            textBox1.Text = null;
            this.Refresh();
            this.Cursor = Cursors.WaitCursor;
            textBox2.Text = ai.GetBoardSolutions(board).ToString();
            textBox1.Text = ai.GetBranchesCount.ToString();
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox0.Checked = false;
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
            checkBox6.Checked = true;
            checkBox7.Checked = true;
            checkBox8.Checked = true;
            checkBox9.Checked = true;
            checkBox10.Checked = true;
            checkBox11.Checked = true;
            checkBox12.Checked = true;
            checkBox13.Checked = true;
            checkBox14.Checked = true;
            
        }
    }
}
