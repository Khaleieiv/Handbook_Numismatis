using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Handbook_numismatist
{
    public partial class MainForm : Form
    {
        Handbook list;
        public MainForm(ref Handbook list)
        {
            InitializeComponent();
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Comment". При необходимости она может быть перемещена или удалена.
            this.commentTableAdapter.Fill(this.databaseDataSet.Comment);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.infCollector". При необходимости она может быть перемещена или удалена.
            this.infCollectorTableAdapter.Fill(this.databaseDataSet.infCollector);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.myCollection". При необходимости она может быть перемещена или удалена.
            this.myCollectionTableAdapter.Fill(this.databaseDataSet.myCollection);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Сollector". При необходимости она может быть перемещена или удалена.
            this.сollectorTableAdapter.Fill(this.databaseDataSet.Сollector);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Allcoin". При необходимости она может быть перемещена или удалена.
            this.allcoinTableAdapter.Fill(this.databaseDataSet.Allcoin);
            this.commentTableAdapter.Fill(this.databaseDataSet.Comment);
        }

        //Метод фильтрация по названию
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == allcoinBindingSource)
            {              
                allcoinBindingSource.Filter = "[Название] LIKE'" + textBox2.Text + "%'";
            }
        }
        // Кнопка выхода
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Метод поиска для монет
        private void Search_Click(object sender, EventArgs e)
        {
            if (textBoxValueToSearch.Text == "")
            {
                MessageBox.Show("Вы не чего не ввели!");

            }
            else
            {
                string formattedValue = textBoxValueToSearch.Text;

                bool cellFound = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.FormattedValue.ToString() == formattedValue)
                        {
                            dataGridView1.CurrentCell = cell;
                            cellFound = true;
                            break;
                        }
                    }
                    if (cellFound) break;
                }
            }
        }
        // Кнопка перехода для добавления комментраия
        private void Add_Click_1(object sender, EventArgs e)
        {
            AddForm af = new AddForm();
            af.Owner = this;
            af.Show();
        }
        // Метод поиска для коллекционеров
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Вы не чего не ввели!");

            }
            else
            {
                string formattedValue = textBox1.Text;

                bool cellFound = false;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.FormattedValue.ToString() == formattedValue)
                        {
                            dataGridView2.CurrentCell = cell;
                            cellFound = true;
                            break;
                        }
                    }

                    if (cellFound) break;
                }
            }
        }
        // Метод для показа изображений     
        int clickeditem = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (++clickeditem > 9) clickeditem = 0;
            changePicture();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (--clickeditem < 0) clickeditem = 9;
            changePicture();
        }
        void changePicture()
        {
            switch (clickeditem)
            {
                case 1:
                    pictureBox1.Image = global::Handbook_numismatist.Properties.Resources._1krona;
                    MessageBox.Show("Это монета называеться '1 Крона'");
                    break;
                case 2:
                    pictureBox1.Image = global::Handbook_numismatist.Properties.Resources._1kop;
                    MessageBox.Show("Это монета называеться '1 Копейка'");
                    break;
                case 3:
                    pictureBox1.Image = global::Handbook_numismatist.Properties.Resources._70_year;
                    MessageBox.Show("Это монета называеться '70 лет Победы'");
                    break;
                case 4:
                    pictureBox1.Image = global::Handbook_numismatist.Properties.Resources._1cher1923r;
                    MessageBox.Show("Это монета называеться '1 Червонец'");
                    break;
                case 5:
                    pictureBox1.Image = global::Handbook_numismatist.Properties.Resources.Khokei;
                    MessageBox.Show("Это монета называеться 'Хоккей'");
                    break;
                case 6:
                    pictureBox1.Image = global::Handbook_numismatist.Properties.Resources.Korolenko;
                    MessageBox.Show("Это монета называеться 'Владимир Короленко'");
                    break;
                case 7:
                    pictureBox1.Image = global::Handbook_numismatist.Properties.Resources.Salamandra;
                    MessageBox.Show("Это монета называеться 'Саламандра'");
                    break;
                case 8:
                    pictureBox1.Image = global::Handbook_numismatist.Properties.Resources.Skyth_gold;
                    MessageBox.Show("Это монета называеться 'Скифское золото'");
                    break;
                case 9:
                    pictureBox1.Image = global::Handbook_numismatist.Properties.Resources.Sofiivka;
                    MessageBox.Show("Это монета называеться 'Софиевка'");
                    break;
            }
        }
        // Метод открытия файла с коментариями
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream mystr = null;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if((mystr = openFileDialog1.OpenFile()) != null)
                {
                    StreamReader myread = new StreamReader(mystr);
                    string[] str;
                    int num = 0;
                    try
                    {
                        string[] str1 = myread.ReadToEnd().Split('\n');
                        num = str1.Count();
                        Comment.RowCount = num;
                        for(int i = 0; i < num; i++)
                        {
                            str = str1[i].Split('^');
                            for(int j = 0; j < Comment.ColumnCount; j++)
                                try
                                {
                                    string data = str[j].Replace("[etot_simvol]", "^");
                                    Comment.Rows[i].Cells[j].Value = data;
                                }
                                catch { }
                        }
                    }
                    catch ( Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myread.Close();
                    }
                }
            }
        }
        // Метод сохранения файла с коментариями
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter myWriter = new StreamWriter(myStream);                  
                    try
                    {
                        for (int i = 0; i < Comment.RowCount -1; i++)
                        {
                            for (int j = 0; j < Comment.ColumnCount; j++)
                            {
                                string data = Comment.Rows[i].Cells[j].Value.ToString().Replace("^", "[etot_simvol]");
                                    myWriter.Write(data + "^");

                                }
                            myWriter.WriteLine();
                                
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myWriter.Close();
                    }
                }
            }
        }
        // Метод для удаления комментраиев
        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            int ind = Comment.SelectedCells[0].RowIndex;
            Comment.Rows.RemoveAt(ind);
        }

    }
}

