using SnaceGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// сщздаём змейку 
namespace SnaceGame.Models
{
    internal class Snake
    {
        public Queue<CellVM> SnakeCells { get;} = new Queue<CellVM>();
        private List<List<CellVM>> _allCells;
        private CellVM _start;
        private object nextCell;

        public Snake( List<List<CellVM>> allCells, CellVM start)
        {

            _start = start;
            _allCells = allCells;
            _start.CellType = CellType.Snake;
            SnakeCells.Enqueue(start);
            
            
        }
        // делаем так чтобы змейка была бесконечной 
        public void Move(MoveDirection direction)
        {
            var LeaderCell = SnakeCells.Peek();
            int nextRow = LeaderCell.Row;
            int nextColumn = LeaderCell.Column;
            switch (direction)
            {
                case MoveDirection.Left: // если идем в верх меняем колонку 
                    nextColumn--;
                    break;
                case MoveDirection.Right: //
                    nextColumn++;
                    break;
                case MoveDirection.Up: // если идём в верх меняем срочку на -
                    nextRow--;
                    break;
                case MoveDirection.Down:// если идём вниз то страка в +
                    nextRow++;
                    break;
                default:
                    break;

            }
            //делаем новую ячейку 
            var nextCell = _allCells[nextRow][nextColumn];// сначала получаем строку а потом забираем колонку 
            switch (nextCell?.CellType)
            {
                case CellType.None:
                    nextCell.CellType = CellType.Snake; //меняем первое на второе 
                    SnakeCells.Dequeue().CellType = CellType.None;//убираем и возращаем объект в начало очереди 
                    SnakeCells.Enqueue(nextCell); //в начало очереди 
                    break;
                case CellType.Food:
                    nextCell.CellType = CellType.Snake;
                    SnakeCells.Enqueue(nextCell);
                    break;
                case CellType.Snake:
                    break;
                default :
                    throw new Exception("Game over");
            }
        }

        internal void Move(object currentMoveDirection)
        {
            throw new NotImplementedException();
        }
    }
}
