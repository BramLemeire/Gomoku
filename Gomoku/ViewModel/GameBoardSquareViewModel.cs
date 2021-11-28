using Cells;
using Model.Data;
using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class GameBoardSquareViewModel
    {
        public ICell<Stone> Owner { get; }

        public ICommand PutStone { get; }

        public ICell<bool> Captured { get; }
        public ICell<bool> WinningStone { get; }

        public GameBoardSquareViewModel(ICell<IGame> game, Vector2D position)
        {
            ICell<bool> isValidMove = game.Derive(g =>
            {
                if (g.IsGameOver) return false;
                return g.IsValidMove(position);
            });

            this.Owner = game.Derive(g => g.Board[position]);
            this.PutStone = new CellCommand(isValidMove, () =>
            {
                game.Value = game.Value.PutStone(position);
            });

            this.Captured = game.Derive(g =>
            {
                if (g.IsGameOver) return false;
                else
                {
                    ISet<Vector2D> capturedPositions = game.Value.CapturedPositions;
                    return capturedPositions.Contains(position);
                }
            });

            this.WinningStone = game.Derive(g =>
            {
                if (!g.IsGameOver) return false;
                else
                {
                    ISet<Vector2D> winningPositions = game.Value.WinningPositions;
                    return winningPositions.Contains(position);
                }
            });
        }
    }

}
