using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FiveGameTest.Network;
using System.Net;


namespace FiveGameTest
{
    public partial class FrmWelcome : Form
    {
        public FrmWelcome()
        {
            InitializeComponent();
        }

        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入昵称");
                return;
            }
            try
            {
                //游戏服务器对象
                GameServer server = new GameServer();
                //开启服务器,等待白方玩家进入
                server.StartListen();
                //创建游戏主画面
                FrmGame frmGame = new FrmGame();
                //关联服务器引用,以便发送游戏指令
                frmGame.Server = server;
                //设置玩家自身昵称
                frmGame.SelfName = txtName.Text;
                //显示昵称
                frmGame.SetBPlayerName(txtName.Text);
                //创建游戏的玩家为黑方
                frmGame.IsBlack = true;
                //设计主界面标题
                frmGame.Text = "等待玩家进入.....[服务器名称:]" + Dns.GetHostName();
                //进入主界面
                frmGame.Show();
                //欢迎界面隐藏
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入昵称");
                return;
            }
            if (txtHostIP.Text.Trim() == "")
            {
                MessageBox.Show("请输入服务器名称");
                return;
            }
            try
            {
                //游戏客户端对象
                GameServer client = new GameServer();
                //连接服务器
                if (client.Connect(txtHostIP.Text))
                {
                    //创建游戏主画面
                    FrmGame frmGame = new FrmGame();
                    //关联服务器引用,以便发送游戏指令
                    frmGame.Server = client;
                    //设置玩家自身昵称
                    frmGame.SetWPlayerName(txtName.Text);
                    //进入游戏的玩家为白方
                    frmGame.IsBlack = false;
                    //进入主界面
                    frmGame.Show();
                    //发送白方进入指令
                    client.Send("wjoin:" + txtName.Text);
                    //开启接收指令
                    client.Recive();
                    //欢迎界面隐藏
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmWelcome_Load(object sender, EventArgs e)
        {
        }
    }
}
