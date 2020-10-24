using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private bool _isCreated;
        private int _rowNumber;
        private int _colNumber;
        public static Dictionary<string, Cell> cellNameToCellObject = new Dictionary<string, Cell>();

        public Form1()
        {
            InitializeComponent();
            CreateDGV(6, 12);
        }

        private void CreateDGV(int cols, int rows)
        {
            _rowNumber = 0;
            _colNumber = 0;
            for (int i = 0; i < cols; ++i)
            {
                string colname = Base26System.Convert(i); //A, B, ... , Z, AA, AB ...
                dataGrid.Columns.Add(colname, colname);
                dataGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                ++_colNumber;
            }

            for (int i =0; i < rows; ++i)
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].HeaderCell.Value = i.ToString();
                ++_rowNumber;
            }

            for (int i = 0; i < _rowNumber; ++i) //add to dictionary
            {
                for (int j = 0; j < _colNumber; ++j)
                {
                    string cellName = Base26System.Convert(j) + i.ToString(); //A + 3 = A3
                    Cell cell = new Cell(cellName, i, j);
                    cellNameToCellObject.Add(cellName, cell);
                }
            }
            _isCreated = true;
        }

        private bool FindLoopDependencies(Cell current, Cell initial)
        {
            if (current.cellsItDependsOn.Contains(initial.Name))
            {
                return true;
            }
            foreach (string cellname in current.cellsItDependsOn)
            {
                if (FindLoopDependencies(cellNameToCellObject[cellname], initial))
                {
                    return true;
                }
            }
            return false;
        }

        private void RecalculateDependentCells(Cell changedCell)
        {
            foreach(string dependentCell in changedCell.cellsDependentFromIt)
            {
                cellNameToCellObject[dependentCell].Value = Calculator.Evaluate(cellNameToCellObject[dependentCell].Expression);
                dataGrid[cellNameToCellObject[dependentCell].Col, cellNameToCellObject[dependentCell].Row].Value = cellNameToCellObject[dependentCell].Value.ToString();
                RecalculateDependentCells(cellNameToCellObject[dependentCell]);
            }
        }

        private bool CheckCellsInExpression(Cell cell)
        {
            foreach (string everycell in cellNameToCellObject.Keys) //видаляємо клітину зі списків інших клітин
            {
                if (cellNameToCellObject[everycell].cellsDependentFromIt.Contains(cell.Name))
                    cellNameToCellObject[everycell].cellsDependentFromIt.Remove(cell.Name);
            }
            cellNameToCellObject[cell.Name].cellsItDependsOn.Clear(); //видаляємо всі залежності клітни від інших клітин
            Regex regex = new Regex(@"[A-Z]+([0-9]+)");  //регулярний вираз, що задає формат імені клітини
            cell.Expression = FormulaTextBox.Text;
            MatchCollection matches = regex.Matches(cell.Expression); //клітини, від яких залежить значення поточної
            if (matches.Count > 0)  
            {
                foreach (Match match in matches)
                {
                    if (cellNameToCellObject.ContainsKey(match.ToString())) //клітина з виразу існує у таблиці
                    {
                        cellNameToCellObject[match.ToString()].cellsDependentFromIt.Add(cell.Name); //додаємо до залежностей поточної клітини
                    }
                    else // помилка, клітина з ім'ям, що є у виразі, ще не існує
                    {
                        foreach(Match cellmatch in matches) //видаляємо те, що додали до залежностей(бо потім очистимо клітину)
                        {
                            if(cellNameToCellObject.ContainsKey(cellmatch.ToString())) //не всі ще могли додатися
                                cellNameToCellObject[cellmatch.ToString()].cellsDependentFromIt.Remove(cell.Name);
                        }
                        MessageBox.Show("Ви ввели у вираз комірку " + match.ToString() + ", що не існує\nОчищую поточну комірку...", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cell.Expression = "";
                        return false;
                    }
                    cellNameToCellObject[cell.Name].cellsItDependsOn.Add(match.ToString());
                }

                if (FindLoopDependencies(cell, cell))//вже додалися усі, але серед них є взаємозалежні,
                {
                    MessageBox.Show("З'вилися циклічні залежності через вираз у поточній комірці\nОчищую ії...", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cell.Expression = "";
                    cell.cellsItDependsOn.Clear(); // тому очищуємо/...
                    foreach (Match cellmatch in matches) 
                    {
                        cellNameToCellObject[cellmatch.ToString()].cellsDependentFromIt.Remove(cell.Name);
                    }
                    return false;
                }
            }
            return true;
        }
        private bool CalculateCellValue(Cell cell)
        {
            try
            {
                cell.Value = Calculator.Evaluate(cell.Expression);
            }
            catch(FormatException)
            {
                MessageBox.Show("Неприпустиме використання операторів у виразі\n\n" +
                    "Формат запису можна подивитися у меню 'Справка'\n" +
                    "або нажавши кнопу 'F1'\n" +
                    "Очищую поточну комірку...","Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cell.Expression = "";
                return false;
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Непідтримувані символи у виразі\n\n" +
                    "Формат запису можна подивитися у меню 'Справка'\n" +
                    "або нажавши кнопу 'F1'\n" +
                    "Очищую поточну комірку...", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cell.Expression = "";
                return false;
            }
            catch(DivideByZeroException)  
            {
                MessageBox.Show("Ділення на 0 у виразі\n\n" +
                    "Формат запису можна подивитися у меню 'Справка'\n" +
                    "або нажавши кнопу 'F1'\n" + 
                    "Очищую поточну комірку...", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cell.Expression = "";
                return false;
            }
            catch(Exception e) //про всяк випадок
            {
                MessageBox.Show(e.Message);
            }
            return true;
        }
        
        private void dataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string cellName = Base26System.Convert(e.ColumnIndex) + e.RowIndex.ToString();
            if (!_isCreated)
            { 
                return;
            }

            if(cellNameToCellObject[cellName].Expression != "")
            {
                FormulaTextBox.Text = cellNameToCellObject[cellName].Expression;   //cell expression to a FormulaBox
                dataGrid[e.ColumnIndex, e.RowIndex].Value = cellNameToCellObject[cellName].Value.ToString();  //cell value to a grid cell
            }
            else
            {
                FormulaTextBox.Text = "";   //no expression -> no text in FormulaBox
            }
            this.ActiveControl = FormulaTextBox;
            FormulaTextBox.Focus();
            FormulaTextBox.SelectionStart = FormulaTextBox.Text.Length;
        }

        private void FormulaTextBox_Leave(object sender, EventArgs e)  //end of cell expression editing
        {
            //current cell name
            string cellName = Base26System.Convert(dataGrid.CurrentCell.ColumnIndex) + dataGrid.CurrentCell.RowIndex.ToString();
            if (CheckCellsInExpression(cellNameToCellObject[cellName]))  //no recursion and cells in expression exist
            {
                if (CalculateCellValue(cellNameToCellObject[cellName])) //calculating expression for a cell + handling exceptions
                {
                    RecalculateDependentCells(cellNameToCellObject[cellName]);
                    return;
                }
            }
            dataGrid[cellNameToCellObject[cellName].Col, cellNameToCellObject[cellName].Row].Value = "";
        }

        private void rowsAddButton_Click(object sender, EventArgs e)
        {
            ++dataGrid.RowCount;
            dataGrid.Rows[_rowNumber].HeaderCell.Value = _rowNumber.ToString();
            for (int j = 0; j < _colNumber; ++j)   //для кожної колонки до словника додається клітина з ім`ям "Останній рядок"+"Колонка"
            {
                string cellName = Base26System.Convert(j) + _rowNumber.ToString(); //A + 3 = A3
                Cell cell = new Cell(cellName, _rowNumber, j);
                cellNameToCellObject.Add(cellName, cell);
            }
            ++_rowNumber;
        }
        private void columnsAddButton_Click(object sender, EventArgs e)
        {
            string colname = Base26System.Convert(_colNumber); //A, B, ... , Z, AA, AB ...
            dataGrid.Columns.Add(colname, colname);
            dataGrid.Columns[_colNumber].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int j = 0; j < _rowNumber; ++j)  //для кожного рядка до словника додається клітина з ім`ям "Рядок"+"Остання колонка"
            {
                string cellName = Base26System.Convert(_colNumber) + j.ToString(); //A + 3 = A3
                Cell cell = new Cell(cellName, j, _colNumber);
                cellNameToCellObject.Add(cellName, cell);
            }
            ++_colNumber;
        }

        private void rowsDeleteButton_Click(object sender, EventArgs e)
        {
            if(_rowNumber == 1)
            {
                MessageBox.Show("Це останній рядок...", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int last_rowNumber = _rowNumber - 1;
            for (int i = 0; i < _colNumber; ++i)
            {
                string cellToDeleteName = Base26System.Convert(i) + last_rowNumber.ToString();
                if(cellNameToCellObject[cellToDeleteName].Expression != "")
                {
                    DialogResult result = MessageBox.Show("Деякі з комірок рядка, який Ви хочете видалити, непусті\n" +
                        "Все одно видалити?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(result == DialogResult.No)
                    {
                        return;
                    }
                }
                if (cellNameToCellObject[cellToDeleteName].cellsDependentFromIt.Count != 0)
                {
                    MessageBox.Show("Деякі комірки таблиці беруть значення з комірок рядка, який Ви хочете видалити", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            for (int i = 0; i < _colNumber; ++i)
            {
                string cellToDeleteName = Base26System.Convert(i) + last_rowNumber.ToString();
                cellNameToCellObject.Remove(cellToDeleteName);
                foreach (string everycell in cellNameToCellObject.Keys) //для кожної видаленої клітини видаляютсья записи у інших клітинах про залежність перших від останніх
                {
                    if (cellNameToCellObject[everycell].cellsDependentFromIt.Contains(cellToDeleteName))
                        cellNameToCellObject[everycell].cellsDependentFromIt.Remove(cellToDeleteName);
                }
            }
            dataGrid.Rows.RemoveAt(last_rowNumber);
            --_rowNumber;
        }

        private void columnsDeleteButton_Click(object sender, EventArgs e)
        {
            if (_colNumber == 1)
            {
                MessageBox.Show("Це остання колонка...", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int last_colNumber = _colNumber - 1;
            for (int i = 0; i < _rowNumber; ++i)
            {
                string cellToDeleteName = Base26System.Convert(last_colNumber) + i.ToString();
                if (cellNameToCellObject[cellToDeleteName].Expression != "")
                {
                    DialogResult result = MessageBox.Show("Деякі з комірок столбця, який Ви хочете видалити, непусті\n" +
                        "Все одно видалити?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
                if (cellNameToCellObject[cellToDeleteName].cellsDependentFromIt.Count != 0)
                {
                    MessageBox.Show("Деякі комірки таблиці беруть значення з комірок столбця, який Ви хочете видалити", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            for (int i = 0; i < _rowNumber; ++i)
            {
                string cellToDeleteName = Base26System.Convert(last_colNumber) + i.ToString();
                cellNameToCellObject.Remove(cellToDeleteName);
                foreach (string everycell in cellNameToCellObject.Keys)//для кожної видаленої клітини видаляютсья записи у інших клітинах про залежність перших від останніх
                {
                    if (cellNameToCellObject[everycell].cellsDependentFromIt.Contains(cellToDeleteName))
                        cellNameToCellObject[everycell].cellsDependentFromIt.Remove(cellToDeleteName);
                }
            }
            dataGrid.Columns.RemoveAt(last_colNumber);
            --_colNumber;
        }

        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "MyTableSavedFile|*.tbl";
                saveFileDialog.Title  = "Save .tbl file";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            FileStream fs = (FileStream)saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(_colNumber);
            sw.WriteLine(_rowNumber);

            foreach (Cell cell in cellNameToCellObject.Values)
            {
                sw.WriteLine(cell.Col);
                sw.WriteLine(cell.Row);
                sw.WriteLine(cell.Expression);
                sw.WriteLine(cell.Value);

                sw.WriteLine(cell.cellsItDependsOn.Count);
                foreach (string cellName in cell.cellsItDependsOn)
                {
                    sw.WriteLine(cellName);
                }

                sw.WriteLine(cell.cellsDependentFromIt.Count);
                foreach (string cellName in cell.cellsDependentFromIt)
                {
                    sw.WriteLine(cellName);
                }
            }
            sw.Close();
            fs.Close();
            MessageBox.Show("Таблиця успішно збережена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MyTableSavedFile|*.tbl";
            openFileDialog.Title  = "Open a .tbl file";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            StreamReader sr = new StreamReader(openFileDialog.FileName);
            cellNameToCellObject.Clear();
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            _isCreated = false;
            int.TryParse(sr.ReadLine(), out int cols);
            int.TryParse(sr.ReadLine(), out int rows);
            CreateDGV(cols, rows);
            string A0expr;
            for(int r = 0; r < rows; ++r)
            {
                for (int c = 0; c < cols; ++c)
                {
                    int colNum = Convert.ToInt32(sr.ReadLine());
                    int rowNum = Convert.ToInt32(sr.ReadLine());
                    string currentCellName = Base26System.Convert(colNum) + rowNum.ToString();
                    string expression = sr.ReadLine();
                    if (c == 0 || r == 0)
                    {
                        A0expr = expression;
                    }
                    double value = Convert.ToDouble(sr.ReadLine());

                    if(expression != "")
                    {
                        cellNameToCellObject[currentCellName].Expression = expression;
                        cellNameToCellObject[currentCellName].Value = value;
                    }
                    int itDependOnCount = Convert.ToInt32(sr.ReadLine());
                    for(int i = 0; i < itDependOnCount; ++i)
                    {
                        string cellItDependsOn = sr.ReadLine();
                        cellNameToCellObject[currentCellName].cellsItDependsOn.Add(cellItDependsOn);
                    }

                    int dependentFromItCount = Convert.ToInt32(sr.ReadLine());
                    for(int i = 0; i < dependentFromItCount; ++i)
                    {
                        string dependentCell = sr.ReadLine();
                        cellNameToCellObject[currentCellName].cellsDependentFromIt.Add(dependentCell);
                    }
                    if(expression != "")
                    {
                        dataGrid[colNum, rowNum].Value = value;
                    }
                }
            }
            FormulaTextBox.Text = cellNameToCellObject["A0"].Expression;
            sr.Close();
        }
        private void MenuStripFileSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void MenuStripFileOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Незбережена таблиця буде втрачена. Спочатку зберегти її?", "Увага!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                MenuStripFileSave.PerformClick();
                OpenFile();
            }
            else if(result == DialogResult.No)
            {
                OpenFile();

            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Незбережена таблиця буде втрачена." +
                " Спочатку зберегти її?", "Увага!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                MenuStripFileSave.PerformClick();
            }
            else if (result == DialogResult.No)
            {
             
            }
            else if(result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            
        }

        private void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    
}
