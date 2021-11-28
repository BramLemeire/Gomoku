using Cells;
using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class MainViewModel
    {
        public ICell<ScreenViewModel> CurrentScreen { get; }

        public MainViewModel()
        {
            CurrentScreen = Cell.Create<ScreenViewModel>(null);

            var game = IGame.Create(IGame.MinimumBoardSize, false);
            var firstScreen = new PlayScreenViewModel(CurrentScreen, game);

            CurrentScreen.Value = firstScreen;
        }
    }

}
