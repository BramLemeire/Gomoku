using Cells;
using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class PlayScreenViewModel : ScreenViewModel
    {
        public GameViewModel Game { get; }

        public PlayScreenViewModel(ICell<ScreenViewModel> currentScreen, IGame game) : base(currentScreen)
        {
            SwitchToSettingsScreen = new ActionCommand(() => CurrentScreen.Value = new SettingsScreenViewModel(this.CurrentScreen));
            NewPlayScreen = new ActionCommand(() => CurrentScreen.Value = new PlayScreenViewModel(this.CurrentScreen, game));

            this.Game = new GameViewModel(game);
        }

        public ICommand SwitchToSettingsScreen { get; }
        public ICommand NewPlayScreen { get; }
    }
}
