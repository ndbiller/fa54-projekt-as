using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class EditPresenter : BasePresenter
    {
        private IEditView editView;

        public EditPresenter(IEditView editView)
        {
            this.editView = editView;
        }
    }
}
