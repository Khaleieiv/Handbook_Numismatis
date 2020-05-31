using System;
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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }
        // кнопка закрытия
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        // метод для добавления комментариев 
        public void AddBtn_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;
            if (main != null)
            {
                if (tbName.Text == "" || tbComment.Text == "")
                {
                    MessageBox.Show("Вы не заполнили все поля!");

                }
                else
                {
                    string name = tbName.Text;
                    string coment = tbComment.Text;
                    main.Comment.Rows.Add(name, coment);
                }

            }
        }
    }
}
