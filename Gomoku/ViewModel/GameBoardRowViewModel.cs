using Cells;
using Model.Data;
using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class GameBoardRowViewModel
    {
        public IEnumerable<GameBoardSquareViewModel> Squares { get; }

        public GameBoardRowViewModel(ICell<IGame> game, int y)
        {
            List<GameBoardSquareViewModel> squares = new List<GameBoardSquareViewModel>();
            for (int i = 0; i < game.Value.Board.Width; i++)
            {
                var position = new Vector2D(i, y);
                squares.Add(new GameBoardSquareViewModel(game, position));
            }
            this.Squares = squares;
        }
    }

}
