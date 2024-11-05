using CSharpMinesweeper.Properties;
using System.Runtime.InteropServices;

namespace CSharpMinesweeper
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private const int SIZE = 640;
        private const bool TEST_MODE = false;

        private int blockCount = 10;
        private int blockSize = 64;
        private int mineCount = 10;
        private float fontSize = 20F;

        private int opened = 0;
        private int flagged = 0;

        private Random rnd = new Random();

        private void frmMain_Load(object sender, EventArgs e)
        {
            cmbSize.SelectedIndex = 0;

            Bitmap flag = Resources.red_flag;
            flag.RotateFlip(RotateFlipType.Rotate180FlipY);
            pctFlag.BackgroundImage = flag;

            pctMine.BackgroundImage = Resources.mine;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SetGameConfigurations();
            pnlCanvas.Controls.Clear();

            for (int i = 0; i < blockCount; i++)
            {
                for (int j = 0; j < blockCount; j++)
                {
                    MineButton btn = new MineButton(fontSize);
                    btn.Size = new Size(blockSize, blockSize);
                    btn.Location = new Point(j * blockSize, i * blockSize);
                    btn.MouseDown += btnMine_MouseDown;
                    pnlCanvas.Controls.Add(btn);
                }
            }

            lblMineCount.Text = mineCount.ToString();
            CreateMines();

            btnStart.Text = "Restart";
        }

        private void btnMine_MouseDown(object? sender, MouseEventArgs e)
        {
            MineButton curButton = (sender != null ? (MineButton)sender : new(fontSize));

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (curButton.State == State.Empty)
                    {
                        if (curButton.IsMine)
                        {
                            curButton.BackColor = Color.Red;
                            LoseGame();
                        }

                        else
                        {
                            OpenButton(curButton);
                        }
                    }
                    break;

                case MouseButtons.Right:
                    switch (curButton.State)
                    {
                        case State.Empty:
                            Bitmap flag = Resources.red_flag;
                            flag.RotateFlip(RotateFlipType.Rotate180FlipY);
                            curButton.BackgroundImage = flag;
                            curButton.State = State.Flag;
                            flagged++;
                            break;

                        case State.Flag:
                            curButton.BackgroundImage = Resources.question;
                            curButton.State = State.Question;
                            flagged--;
                            break;

                        case State.Question:
                            curButton.BackgroundImage = null;
                            curButton.State = State.Empty;
                            break;
                    }
                    lblFlagCount.Text = flagged.ToString();
                    break;

                default:
                    break;
            }

            CheckGameOver();
        }

        private void SetGameConfigurations()
        {
            opened = 0;
            flagged = 0;

            switch (cmbSize.SelectedIndex)
            {
                case 0:
                    blockCount = 10;
                    mineCount = 10;
                    fontSize = 20F;
                    break;

                case 1:
                    blockCount = 20;
                    mineCount = 40;
                    fontSize = 10F;
                    break;
            }

            blockSize = SIZE / blockCount;
        }

        private void CreateMines()
        {
            MineButton curButton;
            int mines = mineCount;
            int index;

            while (mines > 0)
            {
                index = rnd.Next(blockCount * blockCount);
                curButton = (MineButton)pnlCanvas.Controls[index];

                if (curButton.IsMine == false)
                {
                    curButton.IsMine = true;
                    mines--;

                    /*
                       Add 1 to the neighbor's Value.

                       +1  +1  +1
                       +1  (X) +1
                       +1  +1  +1
                    */

                    if (index >= blockCount)
                    {
                        if (index % blockCount != 0)
                            ((MineButton)pnlCanvas.Controls[index - blockCount - 1]).Value++;

                        ((MineButton)pnlCanvas.Controls[index - blockCount]).Value++;

                        if (index % blockCount != blockCount - 1)
                            ((MineButton)pnlCanvas.Controls[index - blockCount + 1]).Value++;
                    }

                    if (index % blockCount != 0)
                        ((MineButton)pnlCanvas.Controls[index - 1]).Value++;
                    if (index % blockCount != blockCount - 1)
                        ((MineButton)pnlCanvas.Controls[index + 1]).Value++;

                    if (index < blockCount * (blockCount - 1))
                    {
                        if (index % blockCount != 0)
                            ((MineButton)pnlCanvas.Controls[index + blockCount - 1]).Value++;

                        ((MineButton)pnlCanvas.Controls[index + blockCount]).Value++;

                        if (index % blockCount != blockCount - 1)
                            ((MineButton)pnlCanvas.Controls[index + blockCount + 1]).Value++;
                    }
                }
            }
        }

        private void OpenButton(MineButton btn)
        {
            if (!btn.IsOpened)
            {
                btn.ShowValue();
                btn.BackColor = Color.Gainsboro;
                btn.Enabled = false;
                btn.IsOpened = true;
                opened++;

                if (btn.Value == 0)
                {
                    int index = pnlCanvas.Controls.IndexOf(btn);

                    if (index >= blockCount)
                    {
                        if (index % blockCount != 0)
                            OpenButton((MineButton)pnlCanvas.Controls[index - blockCount - 1]);

                        OpenButton((MineButton)pnlCanvas.Controls[index - blockCount]);

                        if (index % blockCount != blockCount - 1)
                            OpenButton((MineButton)pnlCanvas.Controls[index - blockCount + 1]);
                    }

                    if (index % blockCount != 0)
                        OpenButton((MineButton)pnlCanvas.Controls[index - 1]);
                    if (index % blockCount != blockCount - 1)
                        OpenButton((MineButton)pnlCanvas.Controls[index + 1]);

                    if (index < blockCount * (blockCount - 1))
                    {
                        if (index % blockCount != 0)
                            OpenButton((MineButton)pnlCanvas.Controls[index + blockCount - 1]);

                        OpenButton((MineButton)pnlCanvas.Controls[index + blockCount]);

                        if (index % blockCount != blockCount - 1)
                            OpenButton((MineButton)pnlCanvas.Controls[index + blockCount + 1]);
                    }
                }
            }
        }

        private void LoseGame()
        {
            foreach (MineButton btn in pnlCanvas.Controls)
            {
                btn.Enabled = false;

                if (btn.IsMine)
                    btn.BackgroundImage = Resources.mine;
            }

            MessageBox.Show("YOU LOST!");
        }

        private void CheckGameOver()
        {
            if (opened == blockCount * blockCount - mineCount && flagged == mineCount)
            {
                foreach (MineButton btn in pnlCanvas.Controls)
                {
                    btn.Enabled = false;
                }

                MessageBox.Show("YOU WON!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
