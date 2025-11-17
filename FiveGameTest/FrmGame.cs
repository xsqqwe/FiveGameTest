using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FiveGameTest.Properties;
using FiveGameTest.Network;

namespace FiveGameTest
{
    public partial class FrmGame : Form
    {
        public GameServer Server { get; set; }
        //棋子大小
        private int itemSize = 36;
        //棋盘与背板的间距
        private int padding = 0;

        //棋盘大小 
        private int boardSize = 0;
        //游戏画布
        private Bitmap bmp = null;
        //游戏结束
        private bool IsGameOver = true;

        //自己的昵称
        public string SelfName = null;

        //是否可以再次落棋子
        public bool CanPlay = false;


        //图片缓存
        private Dictionary<string, Image> imageCache = null;

        //五子棋核心算法对象
        private GobangCore core = new GobangCore();

        public bool IsBlack = true;

        public FrmGame()
        {
            InitializeComponent();
            padding = itemSize;
            this.boardSize = itemSize * 14 + padding * 2;
            this.pictureBox1.Width = boardSize;
            this.pictureBox1.Height = boardSize;

            imageCache = new Dictionary<string, Image>()
            {
                {"baizi",Resources.baizi },
                {"heizi",Resources.heizi }
            };
        }

        //绘制棋盘
        private void DrawBoard()
        {
            bmp = new Bitmap(boardSize, boardSize);
            using (var gp = Graphics.FromImage(bmp))
            {
                //纹理刷
                TextureBrush brush = new TextureBrush(Properties.Resources.board2);
                //棋盘背板
                gp.FillRectangle(brush, new Rectangle(0, 0, boardSize, boardSize));

                //线条笔
                Pen pen = new Pen(Color.Black, 4);
                //棋盘边框
                gp.DrawRectangle(pen, new Rectangle(itemSize / 2, itemSize / 2, boardSize - itemSize, boardSize - itemSize));

                pen.Width = 2;
                //棋盘线条
                for (int i = 0; i < 15; i++)
                {
                    gp.DrawLine(pen, new Point(padding, padding + itemSize * i), new Point(padding + itemSize * 14, padding + itemSize * i));
                    gp.DrawLine(pen, new Point(padding + itemSize * i, padding), new Point(padding + itemSize * i, padding + itemSize * 14));
                }
                //基准点
                gp.FillEllipse(Brushes.Black, new Rectangle(padding + itemSize * 3 - 5, padding + itemSize * 3 - 5, 10, 10));
                gp.FillEllipse(Brushes.Black, new Rectangle(padding + itemSize * 11 - 5, padding + itemSize * 3 - 5, 10, 10));
                gp.FillEllipse(Brushes.Black, new Rectangle(padding + itemSize * 3 - 5, padding + itemSize * 11 - 5, 10, 10));
                gp.FillEllipse(Brushes.Black, new Rectangle(padding + itemSize * 11 - 5, padding + itemSize * 11 - 5, 10, 10));
                gp.FillEllipse(Brushes.Black, new Rectangle(padding + itemSize * 7 - 5, padding + itemSize * 7 - 5, 10, 10));
            }
            this.pictureBox1.Image = bmp;
        }

        //鼠标落棋子
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!IsGameOver && CanPlay)//游戏未结束
            {
                
                //鼠标左键点击,且点在棋盘范围内
                if (e.Button == MouseButtons.Left
                    && e.X >= padding - itemSize / 2 && e.X < boardSize - padding / 2
                    && e.Y >= padding - itemSize / 2 && e.Y < boardSize - padding / 2)
                {
                    //根据点击像素位置换算二维数组行,列
                    int c = (int)Math.Round(((double)(e.X - padding) / (double)itemSize));
                    int r = (int)Math.Round(((double)(e.Y - padding) / (double)itemSize));
                    if (core.gameMap[r, c] == ChessState.Empty)
                    {
                        //目标落子位置是空位
                        using (var gp = Graphics.FromImage(bmp))
                        {
                            DrawChess(gp, r, c, IsBlack);
                            Server.Send("falling:" + r + "," + c + "," + IsBlack.ToString());
                            CanPlay = false;
                        }
                    }
                }
            }
        }

        private void DrawChess(Graphics gp,int r,int c,bool isblack)
        {
            if (core.gameMap[r, c] == ChessState.Empty)
            {
                var image = isblack ? imageCache["heizi"] : imageCache["baizi"];
                gp.DrawImage(image, padding + c * itemSize - itemSize / 2, padding + r * itemSize - itemSize / 2, itemSize, itemSize);
                this.pictureBox1.Invoke(new Action(pictureBox1.Refresh));

                //落子后改变游戏地图相应位置的棋子状态
                var state = (isblack ? ChessState.Black : ChessState.White);
                //落子
                core.FallingChess(r, c, state);

                if (core.IsWin())
                {
                    IsGameOver = true;
                    MessageBox.Show(state.ToString() + " Win");
                }
            }
        }

        //窗体加载
        private void Form1_Load(object sender, EventArgs e)
        {
            BoardCenterAlign();
            DrawBoard();
            Server.Transmit += new Action<string>(Server_Transmit);
            CanPlay = IsBlack;
        }

        //处理指远程指令
        void Server_Transmit(string obj)
        {
            if (obj != null)
            {
                int index = obj.IndexOf(":");
                if (index > -1)
                {
                    string msgType = obj.Substring(0, index);
                    string msgContent = obj.Substring(index + 1);
                    switch (msgType)
                    {
                        case "wjoin":
                            this.lblWPlayer.Invoke(new Action<string>(SetWPlayerName), msgContent);
                            Server.Send("bjoin:" + SelfName);
                            IsGameOver = false;
                            MessageBox.Show(msgContent +"已进入,游戏已开始");
                            break;
                        case "bjoin":
                            this.lblWPlayer.Invoke(new Action<string>(SetBPlayerName),msgContent);
                            IsGameOver = false;
                            MessageBox.Show(msgContent + "已进入,游戏已开始");
                            break;
                        case "falling":
                            Falling(msgContent);
                            CanPlay = true;
                            break;

                    }
                }
            }
        }

        #region 指令处理

        //bjoin 黑方加入
        public void SetBPlayerName(string name)
        {
            this.lblBPlayer.Text = name;
        }

        //wjoin 白方加入
        public void SetWPlayerName(string name)
        {
            this.lblWPlayer.Text = name;
        }

        //falling 落棋子
        public void Falling(string msg)
        {
            using (var gp = Graphics.FromImage(bmp))
            {
                var info = msg.Split(',');
                int r = int.Parse(info[0]);
                int c = int.Parse (info[1]);
                bool isblack = bool.Parse(info[2]);
                //目标落子位置是空位
                DrawChess(gp, r, c, isblack);
            }
        }

        #endregion

        //窗体大小改变
        private void Form1_Resize(object sender, EventArgs e)
        {
            BoardCenterAlign();
        }

        //棋盘居中
        private void BoardCenterAlign()
        {
            this.pictureBox1.Location = new Point((this.Width - pictureBox1.Width) / 2, (this.ClientSize.Height - pictureBox1.Height) / 2);
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {


        }

        private void picStart_Click(object sender, EventArgs e)
        {
            //if (IsGameOver)
            //{
            //    DrawBoard();
            //    IsGameOver = false;
            //    core.ClearMap();
            //  //  CanPlay = IsBlack;
            //    //Server.Send("restart:true");
            //}
        }

        private void FrmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server.Stop();
            Application.Exit();
        }






    }
}
