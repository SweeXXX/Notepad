using System.IO;
namespace __NotePad
{
    public partial class Form1 : Form
    {
        public string filename;
        public bool isFileChanged;
        public Form1()
        {
            InitializeComponent();

            Init();

        }
        public void Init()
        {
            filename = string.Empty;
            isFileChanged = false;

        }

        #region File 
        public void CreateNewDocument(object sender, EventArgs e) // ������� ����� ��������, ������� ���������� ����
        {
            NeedSave(sender, e);
            isFileChanged = false;
            richTextBox1.Text = String.Empty;
            filename = String.Empty;
        }

        


        private void SaveFile(string _filename)
        {
            if (_filename == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _filename = saveFileDialog1.FileName;
                }
            }
            try
            {
                StreamWriter sw = new StreamWriter(_filename);
                sw.Write(richTextBox1.Text);
                sw.Close();
                filename = _filename;
                isFileChanged = false;
                Text = filename;
            }
            catch
            {
                MessageBox.Show("�� �������!");

            }
        }
        public void Save(object sender, EventArgs e) 
        {
            SaveFile(filename);                          
        }
        // ���������. ���� � �����. ����� ��� ���� ����,
        // �� ����� ������ ������������� ����,
        // ����� ���� ��������� ���� � ���������� ����
        public void SaveAs(object sender, EventArgs e) // ��������� � ��������� ����
        {
            SaveFile("");
        }
        public void OpenFile(object sender, EventArgs e)// ������� ��������� ��������� ����
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                    filename = openFileDialog1.FileName;
                    Text = filename;
                }
                catch
                {
                    MessageBox.Show("������! �������� ������� ������ ���� �����", "������!", MessageBoxButtons.OKCancel);
                }
            }
        }

        
        private void Fuck(object sender, EventArgs e) // �� ����)) 
        {
            var mb = MessageBox.Show("F**k", "F**k", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (mb == DialogResult.OK)
                Application.Exit();
        }
        private void Exit(object sender, EventArgs e)// ����� �� ��������
        {
            Application.Exit();
        } 

        private void Print(object sender, EventArgs e) // ���������� ���� � �������
        {
            this.richTextBox1.Text += DateTime.Now;
        }


        #endregion File

        // ^ ������ "����"
        private void mButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�� �0�))");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("��� � ��������))");

        }




        #region Settings
        private void ChangeToDark(object sender, EventArgs e)
        {

            richTextBox1.BackColor = Color.Black;
            richTextBox1.ForeColor = Color.White;

        }
        private void ChangeToWhite(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;
        }
        #endregion Settings
        
        // ^ ������ "���������"

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (!isFileChanged)
            {
                this.Text = Text.Replace("*", "");
                isFileChanged = true;
                this.Text = "*" + Text;
            }

        }
        // ��������� "*" � ������ ����� �����, ���� ���� �� ��������
        

        private void ShriftChange(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText != null)
                    richTextBox1.Font = fontDialog.Font;
            }
        }

        //^ "����������" ��������� ������

        private void NeedSave(object sender, EventArgs e)
        {
            if (isFileChanged)
            {
                DialogResult dialogResult = MessageBox.Show("������ ��������� ���������?", "����������", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.Yes)
                {
                    SaveFile(filename);
                }
            }
        } //���������� �����

        #region "�orrection"
        public void CopyText()
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }
        public void CutText()
        {
            Clipboard.SetText(richTextBox1.SelectedText);
            richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.SelectionStart, richTextBox1.SelectionLength);
        }
        public void PasteText()
        {
            richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.SelectionStart) + Clipboard.GetText() + richTextBox1.Text.Substring(richTextBox1.SelectionStart, richTextBox1.TextLength-richTextBox1.SelectionStart);
        }
        private void CopyClick(object sender, EventArgs e)
        {
            try
            {
                CopyText();
            }
            catch { }
            
        }

        private void CutClick(object sender, EventArgs e)
        {
            try
            {
                CutText();
            }
            catch
            {

            }
        }

        private void PasteClick(object sender, EventArgs e)
        {
            PasteText();
        }
        #endregion "�orrection"

        /* ^ ������ */


        //private void OnFormClosed(object sender, FormClosedEventArgs e)
        //{
        //    NeedSave(sender, e);
        //}

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            NeedSave(sender, e);
        } // �������� �����

        #region Fond
        private void BoldClick(object sender, EventArgs e)
        {
            if(richTextBox1.SelectedText != String.Empty && richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectionFont = new Font(Font, FontStyle.Bold);
            }
        }

        private void ItalicClick(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != String.Empty && richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectionFont = new Font(Font, FontStyle.Italic);
            }
        }
        private void ToRed(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != String.Empty && richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectionColor = Color.Red;
            }
        }
        private void ToBlack(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != String.Empty && richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectionColor = Color.Black;
            }
        }
        private void ToBlue(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != String.Empty && richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectionColor = Color.Blue;
            }


        }
        private void ToWhite(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != String.Empty && richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectionColor = Color.White;
            }
        }
        private void ToGray(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != String.Empty && richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectionColor = Color.Gray;
            }
        }
        private void ToGreen(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != String.Empty && richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectionColor = Color.Green;
            }
        }

        private void Size_Click(object sender, EventArgs e)
        {
            if(float.TryParse(Size.Text, out var size))
            {
                richTextBox1.SelectionFont = new Font(FontFamily.GenericSansSerif, size);
            }
        }



        #endregion Fond

        // ^ "���������" ��������� ������

        
        #region Help
        private void GetHelp(object sender, EventArgs e)
        {
            MessageBox.Show("��� ������ ������� ��������� �� WinForms." +
                "������������ richTextBox.���� ������ � �������, ������� ����� �� ����� �� ����) ���� ������ " +
                "�������� ���������� ����, �� �������� ���������." +
                "����� ������ ����� ������� ��� ������ ����������. ��� �������� ��������, ����������� ;)\n� ���������� ����, ��))", "����������", MessageBoxButtons.OK);


        }
        private void OnCrazy(object sender, EventArgs e)
        {
            MessageBox.Show("� � ����� �������� ��������� �������������, " +
                "��� � ��� ����� �� ���  ��� ���������� ���������� ��� �������� " +
                "�� ���������� �  ���������� ����� �� ������, ��� ��� �����, ��� " +
                "���� ��� ���������  �������, � � ����� ��� ������ ������ - �����," +
                " ������������� �  ��� ���� ��������, �� ������� � ���������� ������," +
                " �� ����������  �������� ������������ ������� � �� ��� ����� " +
                "��������������" +
                " �����������  ��������, ���������� �������, ���� �� ��������, " +
                "���� ������ - ����������  �����, ���� ����� - ����������� �������," +
                " ���������? � �� ��� ����� ��  ����� ��� ����, ��� ������� ������," +
                " ��� ��� �������������, ���  ���� ���� � ���� �������� �������� " +
                "� �������� ����� �������, ��  ������������ ����� �� ��������� �" +
                " ����, ���������? � ��� ����� �� ���  ����� �������� ������, " +
                "�����������, �� ��� ��� ��� ����� �����������,  ������� �� " +
                "���� ������� �� � ������ ����������, ��� ����� ������ " +
                "������  ������-������ �������������� ��� ������, " +
                "� ��� ��� ����������� ������,  ���, ����� ������, " +
                "������, ����� ��� ���������, ��� ������, ������  ����������� " +
                "��� ��� ����������, �������, ���������, � �� ���� ����� ���  ��� " +
                "����� ����� ���� ���������� ��� ���� � ���� � ����� � ������  ���� " +
                "���� ���, � �� ��� �����-��... ��� �� ����� �� ���� �����, �� ����  ����," +
                " �� ���� ��������, ���, �� ��� �����. � ��� �� ����  ������� ����������� " +
                "����������, � ����� ������, � ����� �������, � �����  ���� �������, " +
                "���������, ���, � ���-�� ��� �������� ������, ��� ����,  ��� �����." +
                " � ��������� ���� ��������� ��������. ���-�� � ��� ������  ������� " +
                "��������, ���-�� � ������ ��� ������� �����, ���, �����, ���-��  ���" +
                " ������ ������� �����, ��� �� ���� ����, ���������? ��� ����� " +
                "�����  ������� ���������� �������������, ����������� ���������." +
                " �� ���� �����  �� ������, ������� �� ����� ���� , �� � " +
                "���� ���� ��� �� �����  ������� ���������� � ������� " +
                "������������, ��������������, ������ ���� �  �����, " +
                "������ � ���� �������������. ���� � ����� ��� ����� ������ " +
                "�����  ���� ���� � ����, � ��� ����� ����� �����, ���� ���� ����, " +
                "��������� �� ���, � ���� �� ������ ���� ���� �������� ����� ����������, ��� �� ������." +
                " �� � � ��, � ��� ��� �������� ������,�������� ������, �������������� � �������������, ��� " +
                "���� ����������� � ��������� � ��� �����������, � ������� � �������������, �����, " +
                "��������, ���������, � ���� ����������� ���������� ���������, ����������� �� �� � �� " +
                "���, ���������, ��� � ��, � ���� ���� �������. ��� ��� � ��� ���������� �����������, � �� " +
                "���� �������������� � ������ �����-��, ��� � ��� �������, ���������, �� �� ����� " +
                "��� ������ �����������, ��� ���� �� �����. �� ���� ��, ��� �������, ����� �������, ��� " +
                "��� ���� ����� ��������, ��� �������, ������� ����� ������� � ����� �����, ������� �����, " +
                "���� ���� �����, �������, ����� ����� �������, ������ ��� �� �����, �� �-�� ���� " +
                "��������� �������, � ��� �� ���� - ���� ��, ������ ��� � ��� �� ���� � ���� �������, " +
                "��� ���� �������, ��� ���������� ���� ��������� ��� ����������, �� ���� ��� ���� �� ���, " +
                "��� � ��, ������� �����, ������, �����, � � ����� ������������ ���������� ������� " +
                "������� �� ������ ������ ����� ����. " +
                "��, ������, � � �����. " +
                "", "������� � ����", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }


        #endregion Help

        // ^ �������
    }
}