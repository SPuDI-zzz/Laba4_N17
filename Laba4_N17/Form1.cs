using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Требования.
Реализовать как Windows Application.
Размер матрицы вводится с формы.
Значения матрицы задаются в DataGridView.
Преобразованная матрица выводится в DataGridView результата.
Работа с матрицей должна быть реализована в собственном классе.
Компоненты графического интерфейса используются только для
отображения, а обработка выполняется с использованием внутренних
структур данных.
Задана целочисленная квадратная матрица n * n
17.Удалить столбцы, сумма элементов которых максимальна.*/

namespace Laba4_N17
{
    public partial class Form1 : Form
    {
        int n;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxMain_TextChanged(object sender, EventArgs e)
        {
            //установка размера матрицы и DataGridView
            if (int.TryParse(textBoxMain.Text, out n) && n < 25 && n > 0)
            {
                buttonTask.Visible = true;
                int i;
                DataTable matr = new DataTable("matr");
                DataColumn[] cols = new DataColumn[n];
                for (i = 0; i < n; i++)
                {
                    cols[i] = new DataColumn(i.ToString());
                    matr.Columns.Add(cols[i]);
                }
                for (i = 0; i < n; i++)
                {
                    DataRow newRow;
                    newRow = matr.NewRow();
                    matr.Rows.Add(newRow);
                }
                dataGridViewMain.DataSource = matr;
                for (i = 0; i < n; i++)
                    dataGridViewMain.Columns[i].Width = 30;               
            }
            else
            {   
                buttonTask.Visible=false;
                dataGridViewMain.DataSource = null;
            }
        }
        // обработка матрицы
        private void buttonTask_Click(object sender, EventArgs e)
        {
            dataGridViewRes.Visible = false;
            MatrMake mt = new MatrMake(n);
            mt.GridToMatrix(dataGridViewMain);
            if (mt.DelColumn())
            {
                MessageBox.Show("У всех столбцов максимальная сумма");
            }
            else
            {
                dataGridViewRes.Visible = true;
                mt.MatrixToGrid(dataGridViewRes);
            }
            

            /*if (mt.DelStr())
                MessageBox.Show("Все строки содержат нули");
            else
            {
                dataGridViewRes.Visible = true;
                mt.MatrixToGrid(dataGridViewRes);
            }*/
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            textBoxMain.Focus();
            //dataGridViewMain.ColumnHeadersHeight = 30;
        }
    }
}
