using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class UnsignedPlayersPresenter : BasePresenter
    {
        private IUnsignedPlayersView unsignedPlayersView;

        public UnsignedPlayersPresenter(IUnsignedPlayersView unsignedPlayersView)
        {
            this.unsignedPlayersView = unsignedPlayersView;
        }

        public void DeletePlayer()
        {
            // TODO: Implement delete player.
        }

        public void BindPlayersData()
        {
            // TODO: Get all unsigned players from database and bind data to the view.

        }

    }
}
