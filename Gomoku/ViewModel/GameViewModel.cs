using Cells;
using Model.Data;
using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ViewModel
{
    public class GameViewModel
    {
        public GameBoardViewModel Board { get; }
        private ICell<IGame> game;
        public ICell<Stone> CurrentPlayer { get; }
        public ICell<string> Winner { get; }


        public GameViewModel(IGame game)
        {
            this.game = Cell.Create(game);
            this.CurrentPlayer = this.game.Derive(g => 
            {
                if (g.IsGameOver) return null;
                return g.CurrentPlayer;
            });
            this.Board = new GameBoardViewModel(this.game);

            this.Winner = this.game.Derive(g =>
            {
                if (g.IsGameOver)
                {
                    if(g.Winner == null)
                    {
                        return "Tie";
                    }
                    return g.Winner.ToString();
                }
                return null;
            });
        }
    }

}
