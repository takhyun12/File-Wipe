using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace File_Wipe_1._0.Source
{
    class Wipe
    {
        FileInfo fi = null;
        FileStream fs = null;
        byte[] ByteArray = null;
        public Wipe(string FilePath)
        {
            fi = new FileInfo(FilePath);
        }
        public delegate void ProcessEventHandler(int Current);
        public event ProcessEventHandler runPer;
        public void British_HMG_IS5_BaseLine(string FilePath)
        {
            try
            {
                ByteArray = new byte[fi.Length];
                runPer(0);
                Application.DoEvents();
                for (int i = 0; i < fi.Length; i++)
                {
                    ByteArray[i] = 0x0;
                    runPer((int)(((float)i / (float)(fi.Length - 1.0)) * 100.0));
                }
                RunBuffer(FilePath, ByteArray);
                fi.Delete();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void British_HMG_IS5_Enhanced(string FilePath)
        {
            try
            {
                ByteArray = new byte[fi.Length];
                runPer(0);
                Application.DoEvents();
                int n = 0;
                for (int c = 1; c < 4; c++)
                {
                    switch (c)
                    {
                        case 1:
                            for (int i = 0; i < fi.Length; i++)
                            {
                                ByteArray[i] = 0x0;
                                runPer((int)(((float)n / (float)((fi.Length - 1.0) * 3.0)) * 100.0));
                                n++;
                            }
                            RunBuffer(FilePath, ByteArray);
                            ByteArray = new byte[fi.Length];
                            break;
                        case 2:
                            for (int i = 0; i < fi.Length; i++)
                            {
                                ByteArray[i] = 0x0;
                                runPer((int)(((float)n / (float)((fi.Length - 1.0) * 3.0)) * 100.0));
                                n++;
                            }
                            RunBuffer(FilePath, ByteArray);
                            ByteArray = new byte[fi.Length];
                            break;
                        case 3:
                            switch (RandomBuffer(n))
                            {
                                case true:
                                    break;
                            }
                            RunBuffer(FilePath, ByteArray);
                            ByteArray = new byte[fi.Length];
                            break;
                    }
                }
                // 예방사항으로 파일의 생성시간을 숨긴다
                DateTime dt = new DateTime(2037, 1, 1, 0, 0, 0);
                File.SetCreationTime(FilePath, dt);
                File.SetLastAccessTime(FilePath, dt);
                File.SetLastWriteTime(FilePath, dt);
                File.SetCreationTimeUtc(FilePath, dt);
                File.SetLastAccessTime(FilePath, dt);
                File.SetLastWriteTimeUtc(FilePath, dt);

                // filename에서 디렉토리 명만 추출한다
                string dirname = Regex.Replace(FilePath, @"\\[^\\]*?$", @"");
                string filename = FilePath.Substring(dirname.Length + 1);

                // 파일명을 SHA1으로 해시한다
                SHA1 sha = new SHA1CryptoServiceProvider();
                byte[] data = new byte[1000];
                char[] filenameArray = filename.ToCharArray();
                Buffer.BlockCopy(filenameArray, 0, data, 0, Math.Min(filenameArray.Length * 2, data.Length));
                byte[] Hash = sha.ComputeHash(data);

                // 해시한 값을 base64로 인코딩한다 (SHA1 해시값은 파일명으로 쓸 수가 없으므로)
                string base64 = Convert.ToBase64String(Hash);
                base64 = Regex.Replace(base64, @"/", @"_");

                // 파일명 변경
                string newPath = dirname + @"\" + base64;
                try
                {
                    File.Move(FilePath, newPath);
                    File.Delete(FilePath);
                    File.Delete(newPath);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                }

                //fi.Delete();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RunBuffer(string FilePath, byte[] Buffer)
        {
            fs = new FileStream(FilePath, FileMode.Open,
                FileAccess.Write, FileShare.None);
            fs.Write(Buffer, 0, Buffer.Length);
            fs.Flush();
            fs.Close();
        }
        private bool RandomBuffer(int n)
        {
            ByteArray = new byte[fi.Length];
            Application.DoEvents();
            for (int i = 0; i < fi.Length; i++)
            {
                ByteArray[i] = RandomByte();
                runPer((int)(((float)n / (float)((fi.Length - 1.0) * 3.0)) * 100.0));
                n++;
            }
            return true;
        }
        private byte RandomByte()
        {
            byte Minimo = 0;
            byte maximo = 255;
            Random Rnd = new Random();
            byte ResultRnd = (byte)(Rnd.Next(Minimo, maximo));
            return ResultRnd;
        }
    }
}
