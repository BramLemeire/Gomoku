using Cells;
using Model.Data;
using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class GameBoardViewModel
    {
        private ICell<IGameBoard> board;
        private ICell<IGame> game;

        public GameBoardViewModel(ICell<IGame> game)
        {
            this.game = game;
            this.board = game.Derive(g => g.Board);
        }

        public IEnumerable<GameBoardRowViewModel> Rows
        {
            get
            {
                List<GameBoardRowViewModel> rows = new List<GameBoardRowViewModel>();
                for (int i = 0; i < board.Value.Height; i++)
                {
                    rows.Add(new GameBoardRowViewModel(game, i));
                }
                return rows;
            }
        }

        public IEnumerable<GameBoardSquareViewModel> Row(IGameBoard board, int row)
        {
            List<GameBoardSquareViewModel> rowList = new List<GameBoardSquareViewModel>();
            for (int i = 0; i < board.Width; i++)
            {
                var position = new Vector2D(i, row);
                rowList.Add(new GameBoardSquareViewModel(game, position));
            }
            return rowList;
        }
    }

}
