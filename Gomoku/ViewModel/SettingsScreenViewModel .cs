using Cells;
using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class SettingsScreenViewModel : ScreenViewModel
    {
        public ICell<int> BoardSize { get; }
        public ICell<bool> Capturing { get; }

        public int MaxBoardSize
        {
            get
            {
                return IGame.MaximumBoardSize;
            }
        }

        public int MinBoardSize
        {
            get
            {
                return IGame.MinimumBoardSize;
            }
        }

        public SettingsScreenViewModel(ICell<ScreenViewModel> currentScreen) : base(currentScreen)
        {
            this.BoardSize = Cell.Create(IGame.MinimumBoardSize);
            this.Capturing = Cell.Create(false);
            SwitchToPlayScreen = new ActionCommand(() =>
            {
                if (this.BoardSize.Value > IGame.MaximumBoardSize)
                {
                    this.BoardSize.Value = IGame.MaximumBoardSize;
                }
                if (this.BoardSize.Value < IGame.MinimumBoardSize)
                {
                    this.BoardSize.Value = IGame.MinimumBoardSize;
                }
                IGame game = IGame.Create(this.BoardSize.Value, this.Capturing.Value);
                CurrentScreen.Value = new PlayScreenViewModel(this.CurrentScreen, game);
            });
        }

        public ICommand SwitchToPlayScreen { get; }
    }
}
