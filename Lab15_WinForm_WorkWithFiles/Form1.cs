using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab15_WinForm_WorkWithFiles
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    [Serializable]
    public partial class Form1 : Form
    {
        static string[] arr = new string[0];
        static int sw;
        static int index;
        Random rnd = new Random();
        static public event CollectionHandler CollectionChanged;

        public Form1()
        {
            InitializeComponent();
            ArrayAdd("№, ФИО, Размер кредита, Тип кредита, Срок;");
            Vvod.KeyDown += ClavFunc;
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            Info.Text = "";
            Info.ForeColor = Color.Black;
            CollectionChanged += JournalEvents.CollectionChanged;
        }

        private void CreateArr_Click(object sender, EventArgs e)
        {
            sw = 1;
            Info.Text = "Введите строку, нажмите Enter, чтобы добавить в массив";
            Info.Visible = true;
            Info.Enabled = true;
            Vvod.Visible = true;
            Vvod.Enabled = true;
        }
        private void AddRandom_Click(object sender, EventArgs e)
        {
            Vvod.Enabled = false;
            Vvod.Visible = false;
            string[] Names = { "Губанов Николай Сергеевич", "Курлин Денис Николаевич", "Денисов Андрей Борисович", "Сайферов Юрий Николаевич", "Николайчук Юрий Сергеевич" };
            string[] Summa = { "1200000", "300500", "228337", "5000000", "100000" };
            string[] Type = { "Потребительский", "Ипотечный", "Коммерческий", "Банковский", "Ломбардный" };
            string[] Time = { "5 лет", "9 месяцев", "2 года", "3 месяца", "6 лет" };
            ArrayAdd(Names[rnd.Next(5)] + ", " + Summa[rnd.Next(5)] + ", " + Type[rnd.Next(5)] + ", " + Time[rnd.Next(5)] + ";");
            Info.Text = "Объект добавлен!";
            Info.Visible = true;
            Info.Enabled = true;
        }
        private void delete_Click(object sender, EventArgs e)
        {
            sw = 0;
            Info.Text = "";
            Info.Visible = true;
            Info.Enabled = true;
            Vvod.Visible = true;
            Vvod.Enabled = true;
            TextInfo2(Info);
        }
        private void correct_Click(object sender, EventArgs e)
        {
            sw = 2;
            Info.Text = "";
            Info.Visible = true;
            Info.Enabled = true;
            Vvod.Visible = true;
            Vvod.Enabled = true;
            TextInfo2(Info);
        }
        private void show_Click(object sender, EventArgs e)
        {
            Info.Visible = true;
            Info.Enabled = true;
            Vvod.Visible = false;
            Vvod.Enabled = false;
            TextInfo(Info);
        }
        private void Save_Click(object sender, EventArgs e)
        {
            Info.Visible = true;
            Info.Enabled = true;
            Vvod.Visible = false;
            Vvod.Enabled = false;
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "*.txt| *.txt";
            saveFileDialog1.ShowDialog();
            File.WriteAllLines(saveFileDialog1.FileName, arr);
            Info.Text = "Файл сохранён!";
        }
        private void Open_Click(object sender, EventArgs e)
        {
            Info.Visible = true;
            Info.Enabled = true;
            Vvod.Visible = false;
            Vvod.Enabled = false;
            openFileDialog1.Filter = "*.txt| *.txt";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            arr = File.ReadAllText(openFileDialog1.FileName).Split('\n');
            DeleteLastEmpty();
            TextInfoAdd(Info, arr);
        }
        private void LINQbutton_Click(object sender, EventArgs e)
        {
            sw = 5;
            Info.Text = "";
            Info.Visible = true;
            Info.Enabled = true;
            Vvod.Visible = true;
            Vvod.Enabled = true;
            TextInfo5(Info);
        }
        private void SaveBinary_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "*.bin| *.bin";
            saveFileDialog1.ShowDialog();
            FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
            formatter.Serialize(fs, arr);
            fs.Close();
            Info.Visible = true;
            Info.Enabled = true;
            Vvod.Visible = false;
            Vvod.Enabled = false;
            Info.Text = "Объект сериализован, файл сохранён!";
        }
        private void Deser_Click(object sender, EventArgs e)
        {
            Info.Visible = true;
            Info.Enabled = true;
            Vvod.Visible = false;
            Vvod.Enabled = false;
            openFileDialog1.Filter = "*.bin| *.bin";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
            arr = (string[])formatter.Deserialize(fs);
            fs.Close();
            TextInfoAdd(Info, arr);
        }

        static void ArrayAdd(string newStr)
        {
            string[] tmp = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                tmp[i] = arr[i];
            }
            arr = new string[arr.Length + 1];
            for (int i = 0; i < tmp.Length; i++)
            {
                arr[i] = tmp[i];
            }
            arr[arr.Length - 1] = newStr;
            OnCollctionChaged(newStr, new CollectionHandlerEventArgs("add", newStr));
        }
        static void ArrayAddnoEvents(string newStr)
        {
            string[] tmp = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                tmp[i] = arr[i];
            }
            arr = new string[arr.Length + 1];
            for (int i = 0; i < tmp.Length; i++)
            {
                arr[i] = tmp[i];
            }
            arr[arr.Length - 1] = newStr;
        }
        static void DeleteFromArr(int index)
        {
            sw = 0;
            if (index == 1 && arr.Length != 1)
            {
                OnCollctionChaged(index, new CollectionHandlerEventArgs("delete", arr[1]));
                string[] tmp = new string[arr.Length - 1];
                tmp[0] = arr[0];
                for (int i = 1; i < arr.Length - 1; i++)
                {
                    tmp[i] = arr[i + 1];
                }
                arr = new string[arr.Length - 1];
                for (int i = 0; i < tmp.Length; i++)
                {
                    arr[i] = tmp[i];
                }
            }
            else
            {
                if (index == arr.Length - 1 && arr.Length != 1)
                {
                    OnCollctionChaged(index, new CollectionHandlerEventArgs("delete", arr[arr.Length - 1]));
                    DeleteLastEmpty();
                }
                else
                {
                    if ((index < arr.Length - 1 && index > 1) && arr.Length != 1)
                    {
                        OnCollctionChaged(index, new CollectionHandlerEventArgs("delete", arr[index]));
                        string[] tmp = new string[arr.Length];
                        Array.Copy(arr, tmp, arr.Length);
                        arr = new string[0];
                        for (int i = 0; i < tmp.Length; i++)
                        {
                            if (i != index)
                                ArrayAddnoEvents(tmp[i]);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
        static void DeleteLastEmpty()
        {
            string[] tmp = new string[arr.Length - 1];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                tmp[i] = arr[i];
            }
            arr = new string[arr.Length - 1];
            for (int i = 0; i < tmp.Length; i++)
            {
                arr[i] = tmp[i];
            }
        }
        static string[] Res2()
        {
            var res2 = (from st in arr where st.Contains("5000000") select st).ToArray();
            if (res2.Length == 0)
            {
                res2 = (from st in arr where st.Contains("1200000") select st).ToArray();
                if (res2.Length == 0)
                {
                    res2 = (from st in arr where st.Contains("300500") select st).ToArray();
                    if (res2.Length == 0)
                    {
                        res2 = (from st in arr where st.Contains("228337") select st).ToArray();
                        if (res2.Length == 0)
                        {
                            res2 = (from st in arr where st.Contains("100000") select st).ToArray();
                        }
                    }
                }
            }
            return res2;
        }

        static void TextInfoAdd(Label Info, string[] input)
        {
            Info.Text = "Данные из файла:";
            Info.Text += $"\n{arr[0]}";
            for (int i = 1; i < input.Length; i++)
                Info.Text += $"\n{i}) {input[i]}";
        }
        static void TextInfo(Label Info)
        {
            Info.Text = "Данные:";
            Info.Text += $"\n{arr[0]}";
            for (int i = 1; i < arr.Length; i++)
                Info.Text += $"\n{i}) {arr[i]}";
        }
        static void TextInfo2(Label Info)
        {
            if (sw == 0)
                Info.Text = "Введите номер элемента, который хотите удалить, нажмите Enter\n\nДанные:";
            else
                if (sw == 2)
                Info.Text = "Введите номер элемента, который хотите откоректировать, нажмите Enter\n\nДанные:";
            Info.Text += $"\n{arr[0]}";
            for (int i = 1; i < arr.Length; i++)
                Info.Text += $"\n{i}) {arr[i]}";
        }
        static void TextInfo3(Label Info)
        {
            if (sw == 0)
                Info.Text = "Элемент удалён!\n\nДанные:";
            else
                if (sw == 2)
                Info.Text = "Элемент отредактирован!\n\nДанные:";
            Info.Text += $"\n{arr[0]}";
            for (int i = 1; i < arr.Length; i++)
                Info.Text += $"\n{i}) {arr[i]}";
        }
        static void TextInfo4(Label Info, int i)
        {
            Info.Text = "Введите строку, которая заменит текущую:";
            Info.Text += $"\n{arr[0]}";
            Info.Text += $"\n{i}) {arr[i]}";
            sw = 3;
            index = i;
        }
        static void TextInfo5(Label Info)
        {
            Info.Text = "Данные:";
            Info.Text += "\nВведите вид кредита, есть: Потребительский, Ипотечный, Коммерческий, Банковский, Ломбардный";
            Info.Text += $"\n{arr[0]}";
            for (int i = 1; i < arr.Length; i++)
                Info.Text += $"\n{i}) {arr[i]}";
        }
        static void TextInfoLINQ(Label Info, string s, string[] res, string[] res2)
        {
            Info.Text = $"Люди с {s} типом кредита:";
            for (int i = 0; i < res.Length; i++)
                Info.Text += $"\n{i + 1}) {res[i]}";
            Info.Text += "\n\nСамая большая сумма кредита у:";
            for (int i = 0; i < res2.Length; i++)
                Info.Text += $"\n{i + 1}) {res2[i]}";
            File.WriteAllText("LINQ_Result.txt", Info.Text);
        }
        private void Vvod_TextChanged(object sender, EventArgs e)
        {
            if (sw == 1)
                Info.Text = "Введите строку, нажмите Enter, чтобы добавить в массив";
        }

        void ClavFunc(object source, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                switch (sw)
                {
                    case 0:
                        DeleteFromArr(int.Parse(Vvod.Text));
                        Vvod.Text = "";
                        Info.Text = "";
                        TextInfo3(Info);
                        break;
                    case 1:
                        ArrayAdd(Vvod.Text);
                        Vvod.Text = "";
                        Info.Text = "Объект добавлен!";
                        break;
                    case 2:
                        Info.Text = "";
                        TextInfo4(Info, int.Parse(Vvod.Text));
                        Vvod.Text = "";
                        break;
                    case 3:
                        OnCollctionChaged(index, new CollectionHandlerEventArgs("change", arr[index] + " на " + Vvod.Text));
                        arr[index] = Vvod.Text;
                        Vvod.Text = "";
                        Info.Text = "";
                        sw = 2;
                        TextInfo3(Info);
                        break;
                    case 5:
                        var res = (from arr in arr where arr.Contains(Vvod.Text) == true select arr).ToArray();
                        Info.Text = "";
                        TextInfoLINQ(Info, Vvod.Text, res, Res2());
                        Vvod.Text = "";
                        break;
                }
            }
        }
        static public void OnCollctionChaged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionChanged != null)
                CollectionChanged(source, args);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}