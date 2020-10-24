using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Cell
    {

        private string _expression;
        public string Expression
        {
            get
            {
                return _expression;
            }
            set
            {
                _expression = value;
            }
        }
        private double _value;
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        private int _row;
        public int Row
        {
            get
            {
                return _row;
            }
            set
            {
                _row = value;
            }
        }
        private int _col;
        public int Col
        {
            get
            {
                return _col;
            }
            set
            {
                _col = value;
            }
        }
        public List<string> cellsDependentFromIt = new List<string>();

        public List<string> cellsItDependsOn= new List<string>();
        public Cell() { }
        public Cell(string cellName, int row, int col)
        {
            _expression = "";
            _value = 0;
            this._name = cellName;
            this._row = row;
            this._col = col;
        }
    }
}
