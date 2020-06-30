using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchMe
{
    public partial class GameCatchMe : Form
    {
        public Controller m_GameController;
        int m_CurrentScore;
        Button currentButton;

        public GameCatchMe()
        {
            InitializeComponent();
            m_CurrentScore = 0;
        }

        

        private void CatchMe_Click(object sender, EventArgs e)
        {
            m_CurrentScore++;
            updateScore();
            m_GameController.GetNewCordForButtonPos((sender as Button).Width, (sender as Button).Height);
        }

        private void updateScore()
        {
            this.Text = string.Format(@"CatchMe" + "  Score : {0}", m_CurrentScore);
        }

        public void PlaceButton(int i_NewWidth, int i_NewHeight)
        {
            currentButton.Top = i_NewHeight;
            currentButton.Left = i_NewWidth;
        }

        private void CatchMe_MouseEnter(object sender, EventArgs e)
        {
            currentButton = sender as Button;
            Point cursorPos = Cursor.Position;
            bool checkForMargin = (cursorPos.X < currentButton.Left + currentButton.Width && cursorPos.X > currentButton.Left + currentButton.Width - 20);
            checkForMargin = checkForMargin || ((cursorPos.X > currentButton.Left && cursorPos.X < currentButton.Left + 20));
            if (!checkForMargin)
            {
                m_GameController.GetNewCordForButtonPos(currentButton.Width, currentButton.Height);
            }
        }
    }
}
