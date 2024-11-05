using CSharpMinesweeper.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinesweeper
{
    public class MineButton : Button
    {
        public bool IsMine { get; set; }
        public int Value { get; set; }
        public State State { get; set; }
        public bool IsOpened { get; set; }

        public MineButton(float fontSize)
        {
            this.BackColor = Color.Gold;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = Color.White;
            this.Font = new Font("Times New Roman", fontSize, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.Text = string.Empty;
        }

        public void ShowValue()
        {
            switch (Value)
            {
                case 1:
                    this.BackgroundImage = Resources._1;
                    break;

                case 2:
                    this.BackgroundImage = Resources._2;
                    break;

                case 3:
                    this.BackgroundImage = Resources._3;
                    break;

                case 4:
                    this.BackgroundImage = Resources._4;
                    break;

                case 5:
                    this.BackgroundImage = Resources._5;
                    break;

                case 6:
                    this.BackgroundImage = Resources._6;
                    break;

                case 7:
                    this.BackgroundImage = Resources._7;
                    break;

                case 8:
                    this.BackgroundImage = Resources._8;
                    break;

                default:
                    this.BackgroundImage = null;
                    break;
            }
        }
    }
}
