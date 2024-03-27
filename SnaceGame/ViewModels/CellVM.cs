using Prism.Mvvm;
using SnaceGame.Models;
namespace SnaceGame.ViewModels
{
    internal class CellVM : BindableBase
    {
        // создаём координаты для змейки
        public int Row { get; }
        public int Column { get; }
        
        private CellType _cellTupe = CellType.None;

        public CellType CellType
        {
            get => _cellTupe; 
            set {
                _cellTupe = value;
                RaisePropertyChanged(nameof(CellType));
            }
        }

        public CellVM(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
