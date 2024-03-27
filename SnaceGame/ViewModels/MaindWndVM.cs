using Prism.Commands;
using SnaceGame.Models;
using SnaceGame.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnaceGame.ViewModels
{
    internal class MaindWndVM : BindaleBase
    {
        // делаем флаг для старта 
        private  bool _continueGame;

        public bool ContinueGame
        {
            get => _continueGame; 
            private set 
            { 
                _continueGame = value;
                RaisePropertyChanged(nameof(ContinueGame));
                if (__continueGame) SnaceGo(); 
            }
        }

        private void SnaceGo()
        {
            throw new NotImplementedException();
        }

        // хранение данных для ячеек 
        public List <List<CellVM>> AllCells { get; } = new List<List<CellVM>>();
        //
        private void RaisePropertyChanged(string v)
        {
            throw new NotImplementedException();
        }
        //

        // делаем кнопку старт/стоп
        public DelegateCommand StartStopCooldown { get; }
        // флаг для направления 
        public MoveDirection _currentMoveDirection = MoveDirection.Right; // при начале игры змейка идет в право 
        private int _rowCount = 10;
        private int _columnCount = 10;

        private Snake _snake;
        private int __rowCount;
        private int __columnCount;
        private bool __continueGame;

        public MaindWndVM()
        {
            StartStopCooldown = new DelegateCommand(() => ContinueGame = !ContinueGame);
            for (int row = 0; row <_rowCount; row++)
            {
                var rowList = new List<CellVM>();
                for (int column = 0; column  < _columnCount; column ++)
                {
                    // сщздаём саму ячейку
                    var cell = new CellVM(row, column);
                    rowList.Add(cell);
                }
                AllCells.Add(rowList);
            }

            _snake = new Snake(AllCells, AllCells[__rowCount / 2][__columnCount / 2]);
        }
        // делаем так чтобы во время игры змейка не блокалась
        private async Task SnakeGo()
        {
            while (ContinueGame)
            {
                await Task.Delay(300);
                try
                {
                    _snake.Move(_currentMoveDirection);
                }
                catch(Exception ex)
                {
                    ContinueGame = false;
                    MessageBox.Show(ex.Message);    
                }
            }
        }
    }
}
