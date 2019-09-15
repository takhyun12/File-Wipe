using File_Wipe_1._0.Source;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace File_Wipe_1._0
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void file_btn_Click(object sender, EventArgs e)
        {
            if (this.ofdFile.ShowDialog() == DialogResult.OK)
            {
                string[] files = { this.ofdFile.FileName };
                file_lv.Items.Clear(); // 재사용을 위해 리스트를 초기화합니다.
                this.file_tb.Text = files[0];
                Get_List(files); // 파일을 리스팅합니다.
            }
        }


        public static List<string> folder_list = new List<string> { }; // 폴더를 삭제하기 위한 리스팅
        int file_count = 0; // 삭제할 파일의 총량
        Wipe wipe = null; 
        private void wipe_btn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.file_tb.Text))
            {
                MessageBox.Show("삭제할 파일을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.file_btn.Focus();
                return;
            }
            if (file_lv.Items.Count != 0) // 리스트가 비어있지 않으면 완전삭제 알고리즘 수행
            {
                if (MessageBox.Show("정말로 모두 완전삭제 할까요?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (file_count == 0) // 최초 1회만 수행하도록 함
                        file_count = file_lv.Items.Count; // 삭제대상 파일의 숫자를 변수에 넣음

                    foreach (ListViewItem item in file_lv.Items)
                    {
                        string file_path = item.SubItems[1].Text + @"\" + item.SubItems[0].Text; // 파일경로와 파일명을 더해 완전한 경로를 만든다.
                        folder_list.Add(item.SubItems[1].Text); // 삭제할 폴더리스트를 만듭니다. 

                        wipe = new Wipe(file_path);
                        wipe.runPer += new Wipe.ProcessEventHandler(WipeStatus);
                        wipe.British_HMG_IS5_Enhanced(file_path);

                        file_lv.Items.Remove(file_lv.Items[0]); // 완전삭제를 진행한 아이템은 리스트에서 제거합니다.
                        file_tb.Text = ""; 
                    }
                }
            }
        }

        private void WipeStatus(int Current)
        {
            switch (Current)
            {
                case 0:
                    this.wiping_progressbar.Value = Current;
                    break;
                default:
                    this.wiping_progressbar.Value = Current;
                    if (Current == 100)
                    {
                        this.wiping_progressbar.Value = 0;
                    }
                    break;
            }
            Application.DoEvents();
        }

        private void file_lv_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            file_lv.Items.Clear(); // 재사용을 위해 리스트를 초기화합니다.
            Get_List(files); // 파일을 리스팅합니다.
        }

        private void file_lv_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
        }

        int fCount = 0; // 폴더삭제를 위한 숫자형 변수
        private void Get_List(string[] files)
        {
            try
            {
                foreach (string file in files)
                {
                    FileAttributes fileAttr = File.GetAttributes(file); // 파일속성을 가져옴
                    if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory) // 파일이 아니라 디렉토리이면,
                    {
                        string[] fileInDirectory = Directory.GetFiles(file, "*", SearchOption.AllDirectories);  //  디렉토리안에 있는 파일들을 변수에 담는다.(하위 디렉토리 모두 포함)
                        fCount = Directory.GetFiles(file, "*", SearchOption.AllDirectories).Length; // 파일 갯수 확인

                        if (fCount == 0) // 폴더안에 파일의 갯수가 0이면
                        {
                            if (MessageBox.Show("폴더가 비어있습니다. 바로 삭제할까요?", "자가 보안점검 프로그램", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                Directory.Delete(file, true); // 폴더를 모두 지운다
                        }
                        else
                        {
                            Get_List(fileInDirectory);
                        }
                    }
                    else
                    {
                        FileInfo finfo = new FileInfo(file); // 파일정보를 가져옴
                        ListViewItem lvi = new ListViewItem(finfo.Name); // 파일명
                        lvi.SubItems.Add(finfo.DirectoryName); // 파일경로
                        lvi.SubItems.Add(finfo.LastAccessTimeUtc.ToString()); // 최종 수정일시

                        int filesize = Convert.ToInt32(finfo.Length / 1024);
                        if (filesize <= 0) // 1KB 미만의 파일일 시 
                            lvi.SubItems.Add("1KB"); // 파일크기 칼럼에 1KB를 입력
                        else
                        {
                            if (filesize.ToString().Length <= 3) // MB 미만의 파일일 시
                                lvi.SubItems.Add(filesize.ToString() + "KB"); // KB단위로 변환
                            else
                                lvi.SubItems.Add((filesize / 1024).ToString() + "MB"); // MB단위로 변환
                        }
                        file_lv.Items.Add(lvi); // 리스트에 추가합니다.
                        file_tb.Text = finfo.Name; // 입력박스에 추가합니다.
                    }
                }
            }
            catch { }
        }

    }
}
