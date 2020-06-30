using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchMe
{
    public class Controller
    {
        private GameCatchMe m_GameForm;
        private Random rnd = new Random();
        public Controller()
        {
            m_GameForm = new GameCatchMe();
            m_GameForm.m_GameController = this;
        }

        private void initialize()
        {
          
        }

        private int getClientXSize()
        {
            return m_GameForm.ClientSize.Width;
        }

        public void Run()
        {
            initialize();
            m_GameForm.ShowDialog();
        }

        private int getClientYSize()
        {
            return m_GameForm.ClientSize.Height;
        }

        private int randNumberInLimits(int i_Limit)
        {
            return rnd.Next(i_Limit);
        }

        public void GetNewCordForButtonPos(int i_ButtonWidth, int i_ButtonHeight)
        {
            int newWidth = randNumberInLimits(getClientXSize());
            int newHeight = randNumberInLimits(getClientYSize());
             
            if (newWidth > i_ButtonWidth)
            {
                newWidth -= i_ButtonWidth;
            }
            if (newHeight > i_ButtonHeight)
            {
                newHeight -= i_ButtonHeight;
            }
            m_GameForm.PlaceButton(newWidth, newHeight);

        }
    }
}
