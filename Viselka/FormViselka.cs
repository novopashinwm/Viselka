using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Viselka
{
    public partial class FormViselka : Form
    {
        string abc = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        string word;
        int errors;
        Button[] button_keys ;

        static Random rand = new Random();
        char hider = '*';

        public FormViselka()
        {
            InitializeComponent();
            InitKeys();
            InitGame();
        }

        void InitKeys()
        {
            button_keys = new Button[abc.Length];
            int x, y;
            int button_w = panelKeys.Width / 11;
            int button_h = panelKeys.Height / 3;
            for (int j = 0; j < abc.Length; j++)
            {
                button_keys[j] = new Button();
                x = j % 11;
                y = j / 11;
                button_keys[j].Location = new Point(x* button_w, y * button_h);                
                button_keys[j].Size = new System.Drawing.Size(button_w-2, button_h-4);
                button_keys[j].TabIndex = j;
                button_keys[j].Tag = j;
                button_keys[j].Text = abc.Substring(j, 1);
                button_keys[j].Click += new EventHandler(button_Click);
                panelKeys.Controls.Add(button_keys[j]);
            }
        }

        void InitGame() 
        {
            errors = 0;
            for (int j = 0; j < abc.Length; j++)
                button_keys[j].Visible = true;
            ChooseWord();
            ShowPicture(0);
        }

        private void ChooseWordFromFile()
        {
            string[] lines =  File.ReadAllLines("slova.txt", Encoding.UTF8);
            word = lines[rand.Next (0,lines.Length)];
            labelWord.Text = word;
        }

        void ChooseWord() 
        {
            string[] nl =  { Environment.NewLine };
            string[] lines = Properties.Resources.slova.Split(nl
                , StringSplitOptions.RemoveEmptyEntries);
            do
                word = lines[rand.Next(0, lines.Length)];
            while (word.Length < 5);
            labelWord.Text = new string(hider, word.Length);
        }

        private void button_Click(object sender, EventArgs e)
        {
            int letter_nr = int.Parse(((Button)sender).Tag.ToString());
            HideLetter(letter_nr);
            if (word.IndexOf(abc[letter_nr]) >= 0)
            {
                //Если выбранная буква есть
                // показываем все буквы в слове
                string show_word = "";
                for (int k = 0; k < labelWord.Text.Length; k++)
                    if (labelWord.Text[k] == hider)
                        if (word[k] == abc[letter_nr])
                            show_word += abc[letter_nr];
                        else
                            show_word += hider;
                    else
                        show_word += labelWord.Text[k];
                labelWord.Text = show_word;
                if (show_word.IndexOf(hider) == -1) 
                {
                    ShowWin();
                    InitGame();
                }
            }
            else 
            {
                errors++;
                ShowPicture(errors);
                if (errors >= 7)
                {
                    ShowLose();
                    InitGame();
                }
            }
            if (txtList.Visible)
                runViselkaHelper();
        }

        private void runViselkaHelper()
        {
            txtList.Text = "";
            int[] used = new int[abc.Length];
            string[] nl = { Environment.NewLine };
            
            string[] words = Properties.Resources.slova.Split(nl
                , StringSplitOptions.RemoveEmptyEntries);
            string m = labelWord.Text;
            StringBuilder list = new StringBuilder();
            int total = 0;
            foreach (string w in words)
            {
                if (w.Length != m.Length) continue;
                bool ok = true;
                for (int j = 0; j < w.Length; j++)
                {
                    if (m[j] == hider)
                    {
                        if (isLetterFree(w[j]))
                            continue;
                        else
                        {
                            ok = false;
                            break;
                        }
                    }
                    else
                        if (w[j] == m[j])
                            continue;
                        else
                        {
                            ok = false;
                            break;
                        }                       
                }
                if (!ok) continue;
                for (int k = 0; k < abc.Length; k++)
                    if (w.Contains(abc[k]))
                        used[k]++;
                total++;
                list.AppendLine(w);
            }
            int  maxk=0, max=0;
            for (int k = 0; k < abc.Length; k++)
			    if (isLetterFree(abc[k]))
                    if (used[k] > max)
                    {
                        maxk = k;
                        max = used[k];
                    }
            
            txtList.Text = 
                "Найдено слов:" + total.ToString() + Environment.NewLine
                + "Лучшая буква: " + abc[maxk] + Environment.NewLine
                + "Использована: " + max+ Environment.NewLine
                + list.ToString();
        }

        private bool isLetterFree(char c)
        {
            int k = abc.IndexOf(c);
            return button_keys[k].Visible;
        }

        private void ShowLose()
        {
            MessageBox.Show("К сожалению вас повесили!" + Environment.NewLine +
                "Это было слово '" + word + "'.", "Вы проиграли!");
        }

        void ShowWin() {
            MessageBox.Show("Поздравляю! Вы угадали слово!" , "Вы выиграли!");
        }

        private void ShowPicture(int nr)
        {
            switch (nr) {
                case 0: picStep.Image = Properties.Resources.step0; break;
                case 1: picStep.Image = Properties.Resources.step1; break;
                case 2: picStep.Image = Properties.Resources.step2; break;
                case 3: picStep.Image = Properties.Resources.step3; break;
                case 4: picStep.Image = Properties.Resources.step4; break;
                case 5: picStep.Image = Properties.Resources.step5; break;
                case 6: picStep.Image = Properties.Resources.step6; break;
                case 7: picStep.Image = Properties.Resources.step7; break;
                default: picStep.Image = null; break;
            }
        }

        private void HideLetter(int letter_nr)
        {
            button_keys[letter_nr].Visible = false;
        }

        private void labelWord_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right )
            {
                txtList.Visible = !txtList.Visible;
                if (txtList.Visible)
                    runViselkaHelper();
                else
                    txtList.Text = "";
            }
        }
    }
}
