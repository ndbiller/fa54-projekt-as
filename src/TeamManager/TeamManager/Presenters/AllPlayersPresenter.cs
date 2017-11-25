using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class AllPlayersPresenter : BasePresenter
    {
        private IAllPlayersView allPlayersView;

        public AllPlayersPresenter(IAllPlayersView allPlayersView)
        {
            this.allPlayersView = allPlayersView;
        }

        public void DeletePlayer()
        {
            // TODO: Implement delete player.   
            
        }

        public void BindPlayersData()
        {
            // TODO: Get all players from database and bind data to the view.

        }

        public void UpdateView()
        {

        }
    }
}
