using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Laba4_N17
{
    internal class MatrMake
    {
        int nRow, //количество строк
        nColumn; //количество столбцов
        int[,] matrix; // обрабатываемая матрица
        public MatrMake(int n)
        {
            nRow = n; // на входе матрица квадратная
            nColumn = n;
            matrix = new int[n, n];
        }
        //заполнение матрицы из DataGridView
        public void GridToMatrix(DataGridView dgv)
        {
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nColumn; j++)
                {
                    if (!int.TryParse(dgv.Rows[i].Cells[j].Value.ToString(), out matrix[i, j]))
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }
        //вывод матрицы в DataGridView
        public void MatrixToGrid(DataGridView dgv)
        {
            //установка размеров
            int i;
            DataTable matr = new DataTable("matr");
            DataColumn[] cols = new DataColumn[nColumn];
            for (i = 0; i < nColumn; i++)
            {
                cols[i] = new DataColumn(i.ToString());
                matr.Columns.Add(cols[i]);
            }
            for (i = 0; i < nRow; i++)
            {
                DataRow newRow;
                newRow = matr.NewRow();
                matr.Rows.Add(newRow);
            }
            dgv.DataSource = matr;
            for (i = 0; i < nColumn; i++)
                dgv.Columns[i].Width = 30;
            // занесение значений
            for (i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nColumn; j++)
                {
                    dgv.Rows[i].Cells[j].Value = matrix[i, j].ToString();
                }
            }
        }

        public bool DelColumn()
        {
            int i, j, maxSum = 0, curSum = 0;
            bool[] index = new bool[nColumn];
            for (i = 0; i < nColumn; i++)
            {
                for (j = 0; j < nRow; j++)
                {
                    curSum += matrix[j, i];
                }
                if (curSum > maxSum)
                {
                    maxSum = curSum;
                    Array.Clear(index, 0, nColumn);
                    index[i] = true;
                }
                else 
                {
                    if (curSum == maxSum)
                    {
                        index[i] = true;
                    }
                }
                curSum = 0;
            }
            i = 0;
            foreach (bool item in index)
            {
                if (item)
                {
                    nColumn--;
                    for (j = i; j < nColumn; j++)
                    {
                        for (int q = 0; q < nRow; q++)
                        {
                            matrix[q, j] = matrix[q, j + 1];
                        }
                    }                                         
                }
                else i++;
            }
            return nColumn == 0;
            /*while (i < n_col && t < p)
            {
                if (index[t])
                {
                    for (j = i; j < n_col - 1; j++)
                    {
                        for (int q = 0; q < n_str; q++)
                        {
                            matrix[q, j] = matrix[q, j + 1];
                        }
                    }
                    n_col--;
                    *//*k--;
                    p++;*//*
                }
                else i++;
                t++;
            }*/
        }

        // удаление строк, содержащих нули
        /*public bool DelStr()//true, если результат пустая матрица
        {
            int i, j;
            bool ok;
            i = 0;
            while (i < n_str)
            {
                ok = true;
                for (j = 0; j < n_col && ok; j++)
                    if (matrix[i, j] == 0)
                        ok = false;
                if (!ok)
                {
                    //удалить i строку
                    for (int k = i; k < n_str - 1; k++)
                        for (j = 0; j < n_col; j++)
                            matrix[k, j] = matrix[k + 1, j];
                    n_str--;
                }
                else i++;
            }
            if (n_str == 0)
                return true;
            else
                return false;
        }*/
    }
}
