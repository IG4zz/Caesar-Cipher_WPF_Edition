using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;

namespace Caesar_Cipher.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для CryptionView.xaml
    /// </summary>
    public partial class CryptionView : UserControl
    {
        bool ValidCharFound(string str)//
        {
            bool valid = true;// 

            foreach (char c in str)    //  искать символ c в строке str
            {
                string Temp = c.ToString();
                if (Regex.IsMatch(Temp, @"[-0-9,]"))
                {
                    valid = true;    //  то результат=истина
                }
                else
                {
                    valid = false;  //  иначе ложь
                    break;
                }
            }
            return valid;
        }

        public CryptionView()
        {
            InitializeComponent();
        }


        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new();
            helpWindow.Show();
        }

        private void btn_Crypt_Click(object sender, RoutedEventArgs e)
        {
            if (KeyTextBox.Text != null && KeyTextBox.Text != "")
            {
                if (ValidCharFound(KeyTextBox.Text))
                {
                    int Key = Convert.ToInt32(KeyTextBox.Text); //  (Ключ должен быть в пределах значений алфавита)
                    if (Key > -33 && Key < 33)
                    {
                        string Text = Convert.ToString(CryptionTextBox.Text.ToLower()); //   храню фразу, которую буду шифровать
                        string Crypt = ""; //   храню результат шифрования
                        string Space = " ";
                        string Comma = ",";
                        string Dot = ".";
                        string Dash = "-";
                        string ExclamationMark = "!";
                        string QuestionMark = "?";
                        string RusAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"; //  русский алфавит

                        //    цикл перебора букв шифруемого слова

                        for (int i = 0; i < Text.Length; i++)
                        {
                            // цикл сравнения каждой буквы с алфавитом

                            for (int j = 0; j < RusAlphabet.Length; j++)
                            {
                                if (Text[i] == RusAlphabet[j]) //   в случае совпадения, создаю переменную, где храню номер буквы со сдвигом
                                {
                                    int EndPosition = j + Key; //  номер буквы + сдвиг по ключу

                                    while (EndPosition <= RusAlphabet.Length) //   проверка того, чтобы новая буква не уходила за рамки алфавита
                                    {
                                        EndPosition += RusAlphabet.Length;
                                    }

                                    while (EndPosition >= RusAlphabet.Length) // проверка того, чтобы новая буква не уходила за рамки алфавита
                                    {
                                        EndPosition -= RusAlphabet.Length;
                                    }

                                    Crypt += RusAlphabet[EndPosition]; // заношу зашифрованную букву в переменную, для ее хранения
                                }
                            }

                            if (Text[i] == Convert.ToChar(Space))
                            {
                                Crypt += Space;
                            }

                            if (Text[i] == Convert.ToChar(Comma))
                            {
                                Crypt += Comma;
                            }

                            if (Text[i] == Convert.ToChar(Dot))
                            {
                                Crypt += Dot;
                            }

                            if (Text[i] == Convert.ToChar(Dash))
                            {
                                Crypt += Dash;
                            }

                            if (Text[i] == Convert.ToChar(ExclamationMark))
                            {
                                Crypt += ExclamationMark;
                            }

                            if (Text[i] == Convert.ToChar(QuestionMark))
                            {
                                Crypt += QuestionMark;
                            }
                        }

                        EncryptionTextBox.Text = Crypt;
                    }
                    else
                        MessageBox.Show("Некорректное значение ключа шифрования!" +
                           "\nКлюч может принимать значения от -32 до 32", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else
                    MessageBox.Show("Укажите числовые значения в поле Ключ шифрования!", "Ошибка",
                       MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
                MessageBox.Show("Значение Ключа шифрования отсутствует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btn_Enrypt_Click(object sender, RoutedEventArgs e)
        {
            if (KeyTextBox.Text != null && KeyTextBox.Text != "")
            {
                if (ValidCharFound(KeyTextBox.Text))
                {
                    int Key = Convert.ToInt32(KeyTextBox.Text); //(Ключ должен быть в пределах значений алфавита)
                    if (Key > -33 && Key < 33)
                    {
                        string Text = Convert.ToString(EncryptionTextBox.Text.ToLower()); // храню фразу, которую буду шифровать
                        string Crypt = ""; // храню результат шифрования
                        string Space = " ";
                        string Comma = ",";
                        string Dot = ".";
                        string Dash = "-";
                        string ExclamationMark = "!";
                        string QuestionMark = "?";
                        string RusAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"; // русский алфавит

                        // цикл перебора букв шифруемого слова

                        for (int i = 0; i < Text.Length; i++)
                        {
                            // цикл сравнения каждой буквы с алфавитом

                            for (int j = 0; j < RusAlphabet.Length; j++)
                            {

                                if (Text[i] == RusAlphabet[j]) // в случае совпадения, создаю переменную, где храню номер буквы со сдвигом
                                {
                                    int EndPosition = j - Key; // номер буквы + сдвиг по ключу

                                    while (EndPosition <= RusAlphabet.Length) // чтобы новая буква не уходила за рамки алфавита
                                    {
                                        EndPosition += RusAlphabet.Length;
                                    }

                                    while (EndPosition >= RusAlphabet.Length) // чтобы новая буква не уходила за рамки алфавита
                                    {
                                        EndPosition -= RusAlphabet.Length;
                                    }

                                    Crypt += RusAlphabet[EndPosition]; // заношу зашифрованную букву в переменную, для ее хранения
                                }
                            }

                            if (Text[i] == Convert.ToChar(Space))
                            {
                                Crypt += Space;
                            }

                            if (Text[i] == Convert.ToChar(Comma))
                            {
                                Crypt += Comma;
                            }

                            if (Text[i] == Convert.ToChar(Dot))
                            {
                                Crypt += Dot;
                            }

                            if (Text[i] == Convert.ToChar(Dash))
                            {
                                Crypt += Dash;
                            }

                            if (Text[i] == Convert.ToChar(ExclamationMark))
                            {
                                Crypt += ExclamationMark;
                            }

                            if (Text[i] == Convert.ToChar(QuestionMark))
                            {
                                Crypt += QuestionMark;
                            }
                        }

                        CryptionTextBox.Text = Crypt;
                    }
                    else
                        MessageBox.Show("Некорректное значение ключа шифрования!" +
                           "\nКлюч может принимать значения от -32 до 32", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                    MessageBox.Show("Укажите числовые значения в поле Ключ шифрования!", "Ошибка",
                       MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Значение Ключа шифрования отсутствует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btn_OpenEncrypt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                CryptionTextBox.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void btn_SaveEncrypt_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Crypt";
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, CryptionTextBox.Text);
        }

        private void btn_ClearEncrypt_Click(object sender, RoutedEventArgs e)
        {
            CryptionTextBox.Text = "";
        }

        private void btn_OpenCrypt_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Crypt";
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, EncryptionTextBox.Text);
        }

        private void btn_SaveCrypt_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Crypt";
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)                
            File.WriteAllText(saveFileDialog.FileName, EncryptionTextBox.Text);
        }

        private void btn_ClearCrypt_Click(object sender, RoutedEventArgs e)
        {
            EncryptionTextBox.Text = "";
        }
    }
}
