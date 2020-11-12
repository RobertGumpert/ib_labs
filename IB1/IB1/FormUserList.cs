using IB1.Models;
using IB1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IB1
{
    public partial class FormUserList : Form
    {
        private int selectedRow = -1;
        private AccessService accessService;

        public AccessService AccessService
        {
            set
            {
                accessService = value;
                FilledDataGridView();
            }
        }

        public FormUserList()
        {
            InitializeComponent();
        }

        public void FilledDataGridView() {
            dataGridViewList.DataSource = accessService.GetUsers().Users;
            dataGridViewList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewList.Columns[3].Visible = false;
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            var dialog = new DialogAddUser();
            dialog.AccessService = accessService;
            if (dialog.ShowDialog() == DialogResult.No)
            {
                Clear("При добавлении пользователя произошла ошибка");
            }
            else {
                dataGridViewList.DataSource = null;
                FilledDataGridView();
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (selectedRow == -1)
            {
                Clear("Выберите строку");
            }
            else
            {
                try
                {
                    var user = accessService.FindUser(dataGridViewList.Rows[selectedRow].Cells["UserName"].Value.ToString());
                    var dialog = new DialogUpdateUserProperty();
                    dialog.SeletedUser = user;
                    dialog.AccessService = accessService;
                    if (dialog.ShowDialog() == DialogResult.No)
                    {
                        Clear("При изменении прав произошла ошибка");
                    }
                }
                catch (Exception)
                {
                    Clear("Произошла оишбка выбора пользователя");
                }            
            }
        }

        private void Clear(String message)
        {
            labelError.Text = message;
            labelError.Visible = true;
        }

        private void dataGridViewList_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewList.SelectedCells.Count == 1)
            {
                selectedRow = dataGridViewList.SelectedCells[0].RowIndex;
                Clear("Строка " + selectedRow.ToString());
            }
        }
    }
}
