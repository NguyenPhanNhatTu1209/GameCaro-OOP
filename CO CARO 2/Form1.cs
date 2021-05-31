using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CO_CARO_2
{
    
    public partial class fmCoCaro : Form
    {
        public static int ChieuRongBanCo;
        public static int ChieuCaoBanCo;
        private Graphics grp;
        private C_DieuKhien DieuKhien;
        private fmLuatChoi LuatChoi;
        
        int vt ;
        public fmCoCaro()
        {

            InitializeComponent();
            //vẽ nên pnlBanCo
            grp = pnlBanCo.CreateGraphics();
            
            //lấy chiều rộng và chiều cao pnBanCo để vẽ bàn cờ
            ChieuCaoBanCo = pnlBanCo.Height;
            ChieuRongBanCo = pnlBanCo.Width;

            //khởi tạo đối tượng điều khiển trò chơi
            DieuKhien = new C_DieuKhien();

            LuatChoi = new fmLuatChoi();
            DieuKhien.CheDoChoi = -1;
        }

        private void pnlBanCo_Paint(object sender, PaintEventArgs e)
        {
            if (DieuKhien.SanSang)
            {
                //vẽ bàn cờ
                DieuKhien.veBanCo(grp);
                //vẽ lại các quân cờ trong stack
                DieuKhien.veLaiQuanCo(grp);
            }
        }

        private void chơiVớiNgườiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DieuKhien.choiVoiNguoi(grp);
            grp.Clear(pnlBanCo.BackColor);
            Image image = new Bitmap(Properties.Resources.b);
            pnlBanCo.BackgroundImage = image;
            progressBar1.Value = 0;
            timer1.Start();
            //xóa tất cả các hình đã vẽ trên panel chỉ giữ lại màu nền panel
        }

        private void pnlBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            if (DieuKhien.SanSang)
            {
                
                //loại bỏ trường hợp người chơi kích vào giữa đường kẻ vạch
                if (e.Location.Y % C_OCo.CHIEU_CAO != 0 && e.Location.X % C_OCo.CHIEU_RONG != 0 && DieuKhien.MangOCo[e.Location.Y / C_OCo.CHIEU_CAO, e.Location.X / C_OCo.CHIEU_RONG].SoHuu==0)
                {
                    
                        //chơi với người
                        if (DieuKhien.CheDoChoi == 7)
                        {

                            timer1.Start();
                            progressBar1.Value = 0;
                            //đánh cờ với tọa độ chuột khi lick vào panel bàn cờ
                            DieuKhien.danhCo(grp, e.Location.X, e.Location.Y);
                            if (DieuKhien.kiemTraChienThang1(grp))
                            {
                                progressBar1.Value = 0;
                                timer1.Stop();
                            }
                            //sau khi đánh cờ thì kiểm tra chiến thắng luôn
                            DieuKhien.kiemTraChienThang(grp);
                        }
                        //chơi với máy
                        if (DieuKhien.CheDoChoi == 0)
                        {
                            timer1.Start();
                            progressBar1.Value = 0;
                            //người chơi đánh
                            DieuKhien.danhCo(grp, e.Location.X, e.Location.Y);
                            if (DieuKhien.kiemTraChienThang1(grp))
                            {
                                progressBar1.Value = 0;
                                timer1.Stop();
                            }
                            //kiểm tra người chơi chưa chiến thắng thì cho máy đánh
                            if (!DieuKhien.kiemTraChienThang(grp))
                            {
                                //máy đánh

                                DieuKhien.mayDanh0(grp);
                                if (DieuKhien.kiemTraChienThang1(grp))
                                {
                                    progressBar1.Value = 0;
                                    timer1.Stop();
                                }
                                DieuKhien.kiemTraChienThang(grp);


                            }
                        }
                        if (DieuKhien.CheDoChoi == 1)
                        {
                            timer1.Start();
                            progressBar1.Value = 0;
                            //người chơi đánh
                            DieuKhien.danhCo(grp, e.Location.X, e.Location.Y);
                            if (DieuKhien.kiemTraChienThang1(grp))
                            {
                                progressBar1.Value = 0;
                                timer1.Stop();
                            }
                            //kiểm tra người chơi chưa chiến thắng thì cho máy đánh
                            if (!DieuKhien.kiemTraChienThang(grp))
                            {
                                //máy đánh

                                DieuKhien.mayDanh1(grp);
                                if (DieuKhien.kiemTraChienThang1(grp))
                                {
                                    progressBar1.Value = 0;
                                    timer1.Stop();
                                }
                                DieuKhien.kiemTraChienThang(grp);


                            }
                        }
                        if (DieuKhien.CheDoChoi == 2)
                        {
                            timer1.Start();
                            progressBar1.Value = 0;
                            //người chơi đánh
                            DieuKhien.danhCo(grp, e.Location.X, e.Location.Y);
                            if (DieuKhien.kiemTraChienThang1(grp))
                            {
                                progressBar1.Value = 0;
                                timer1.Stop();
                            }
                            //kiểm tra người chơi chưa chiến thắng thì cho máy đánh
                            if (!DieuKhien.kiemTraChienThang(grp))
                            {
                                //máy đánh

                                DieuKhien.mayDanh2(grp);
                                if (DieuKhien.kiemTraChienThang1(grp))
                                {
                                    progressBar1.Value = 0;
                                    timer1.Stop();
                                }
                                DieuKhien.kiemTraChienThang(grp);


                            }
                        }
                        if (DieuKhien.CheDoChoi == 3)
                        {
                            timer1.Start();
                            progressBar1.Value = 0;
                            //người chơi đánh
                            DieuKhien.danhCo(grp, e.Location.X, e.Location.Y);
                            if (DieuKhien.kiemTraChienThang1(grp))
                            {
                                progressBar1.Value = 0;
                                timer1.Stop();
                            }
                            //kiểm tra người chơi chưa chiến thắng thì cho máy đánh
                            if (!DieuKhien.kiemTraChienThang(grp))
                            {
                                //máy đánh

                                DieuKhien.mayDanh3(grp);
                                if (DieuKhien.kiemTraChienThang1(grp))
                                {
                                    progressBar1.Value = 0;
                                    timer1.Stop();
                                }
                                DieuKhien.kiemTraChienThang(grp);


                            }
                        }
                        if (DieuKhien.CheDoChoi == 4)
                        {
                            timer1.Start();
                            progressBar1.Value = 0;
                            //người chơi đánh
                            DieuKhien.danhCo(grp, e.Location.X, e.Location.Y);
                            if (DieuKhien.kiemTraChienThang1(grp))
                            {
                                progressBar1.Value = 0;
                                timer1.Stop();
                            }
                            //kiểm tra người chơi chưa chiến thắng thì cho máy đánh
                            if (!DieuKhien.kiemTraChienThang(grp))
                            {
                                //máy đánh

                                DieuKhien.mayDanh4(grp);
                                if (DieuKhien.kiemTraChienThang1(grp))
                                {
                                    progressBar1.Value = 0;
                                    timer1.Stop();
                                }
                                DieuKhien.kiemTraChienThang(grp);


                            }
                        }
                        if (DieuKhien.CheDoChoi == 5)
                        {
                            timer1.Start();
                            progressBar1.Value = 0;
                            //người chơi đánh
                            DieuKhien.danhCo(grp, e.Location.X, e.Location.Y);
                            if (DieuKhien.kiemTraChienThang1(grp))
                            {
                                progressBar1.Value = 0;
                                timer1.Stop();
                            }
                            //kiểm tra người chơi chưa chiến thắng thì cho máy đánh
                            if (!DieuKhien.kiemTraChienThang(grp))
                            {
                                //máy đánh

                                DieuKhien.mayDanh5(grp);
                                if (DieuKhien.kiemTraChienThang1(grp))
                                {
                                    progressBar1.Value = 0;
                                    timer1.Stop();
                                }
                                DieuKhien.kiemTraChienThang(grp);


                            }
                        }
                    
                }
            }
        }

        private void chơiVớiMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void luậtChơiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fmCoCaro_Load(object sender, EventArgs e)
        {
            
            
                list_FileNhac.Items.Add("Tên file nhạc");
            
           
        }

        private void thêmNhạcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int non = 0;
            if (list_FileNhac.Items.Count == 1)
            {
                non = 1;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                foreach (String filename in openFileDialog1.FileNames)
                {
                    list_FileNhac.Items.Add(filename);
                }
            }
            if (axWindowsMediaPlayer1.status.Contains("Stop"))
            {
             
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
           
            try
            {
                if (non != 0)
                {
                    axWindowsMediaPlayer1.URL = list_FileNhac.Items[1].ToString();

                }
            }
            catch
            {

            }
        }

        private void thôngTinToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LuatChoi.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                vt = list_FileNhac.SelectedIndex;
                if (vt != 0)                {
                    axWindowsMediaPlayer1.URL = list_FileNhac.Items[vt].ToString();
                    list_FileNhac.ClearSelected();
                }
            }
            catch
            {

            }
        }

        private void level0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DieuKhien.choiVoiMay0(grp);

            grp.Clear(pnlBanCo.BackColor);
            Image image = new Bitmap(Properties.Resources.b);
            pnlBanCo.BackgroundImage = image;
            progressBar1.Value = 0;
            timer1.Start();
            //xóa tất cả các hình đã vẽ trên panel chỉ giữ lại màu nền panel
        }

        private void level1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DieuKhien.choiVoiMay1(grp);

            grp.Clear(pnlBanCo.BackColor);
            Image image = new Bitmap(Properties.Resources.b);
            pnlBanCo.BackgroundImage = image;
            progressBar1.Value = 0;
            timer1.Start();
            //xóa tất cả các hình đã vẽ trên panel chỉ giữ lại màu nền panel
        }

        private void level5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DieuKhien.choiVoiMay5(grp);
            grp.Clear(pnlBanCo.BackColor);
            Image image = new Bitmap(Properties.Resources.b);
            pnlBanCo.BackgroundImage = image;
            progressBar1.Value = 0;
            timer1.Start();
        }

        private void level2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DieuKhien.choiVoiMay2(grp);
            grp.Clear(pnlBanCo.BackColor);
            Image image = new Bitmap(Properties.Resources.b);
            pnlBanCo.BackgroundImage = image;
            progressBar1.Value = 0;
            timer1.Start();
        }

        private void level3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DieuKhien.choiVoiMay3(grp);
            grp.Clear(pnlBanCo.BackColor);
            Image image = new Bitmap(Properties.Resources.b);
            pnlBanCo.BackgroundImage = image;
            progressBar1.Value = 0;
            timer1.Start();
        }

        private void level4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DieuKhien.choiVoiMay4(grp);
            grp.Clear(pnlBanCo.BackColor);
            Image image = new Bitmap(Properties.Resources.b);
            pnlBanCo.BackgroundImage = image;
            progressBar1.Value = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if (progressBar1.Value >= progressBar1.Maximum && (DieuKhien.CheDoChoi == 2 || DieuKhien.CheDoChoi== 0 
                || DieuKhien.CheDoChoi ==1 || DieuKhien.CheDoChoi == 3 || DieuKhien.CheDoChoi == 4 || DieuKhien.CheDoChoi == 5))
            {
                timer1.Stop();
                MessageBox.Show("Kết Thúc Thời Gian Máy Thắng");
                DieuKhien.SanSang = false;
            }
            if (progressBar1.Value >= progressBar1.Maximum && DieuKhien.CheDoChoi == 7)
            {
                timer1.Stop();
                if (DieuKhien._luotDi == 1)
                    MessageBox.Show("Hết Thời Gian Quân Xanh Thắng");
                else
                    MessageBox.Show("Hết Thời Gian Quân Đỏ Thắng");
                DieuKhien.SanSang = false;
            }
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            if (DieuKhien.SanSang==true )
            {
                grp.DrawImage(Properties.Resources.c, 0, 0);
                timer1.Stop();
                DieuKhien.SanSang = false;
            }
        }

        private void btn_Resume_Click(object sender, EventArgs e)
        {
            if (DieuKhien.SanSang == false && (DieuKhien.CheDoChoi == 0||DieuKhien.CheDoChoi==1||DieuKhien.CheDoChoi == 2||DieuKhien.CheDoChoi==3||DieuKhien.CheDoChoi==4
                || DieuKhien.CheDoChoi==5||DieuKhien.CheDoChoi==7)&&DieuKhien.kiemTraChienThang1(grp)==false&&progressBar1.Value<progressBar1.Maximum)  { 
                grp.Clear(pnlBanCo.BackColor);
                pnlBanCo.BackgroundImage = new Bitmap(Properties.Resources.b);
                DieuKhien.veBanCo(grp);
                //vẽ lại các quân cờ trong stack
                DieuKhien.veLaiQuanCo(grp);
                timer1.Start();
                DieuKhien.SanSang = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
