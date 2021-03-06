﻿using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.Vbe.Interop;
using CommandBarButtonClickEvent = Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler;


namespace Rubberduck.UI.ToDoItems
{
    public class ToDoItemsMenu : Menu
    {
        private readonly IToDoExplorerWindow _userControl;
        private readonly ToDoExplorerDockablePresenter _presenter; //if presenter goes out of scope, so does it's toolwindow Issue #169
        private CommandBarButton _todoItemsButton;

        public ToDoItemsMenu(VBE vbe, AddIn addIn, IToDoExplorerWindow view, ToDoExplorerDockablePresenter presenter)
            :base(vbe, addIn)
        {
            _userControl = view;
            _presenter = presenter;
        }

        public void Initialize(CommandBarPopup menu)
        {
            const int clipboardWithCheck = 837;
            _todoItemsButton = AddButton(menu, "&ToDo Items", false, new CommandBarButtonClickEvent(OnShowTaskListButtonClick), clipboardWithCheck);
        }

        private void OnShowTaskListButtonClick(CommandBarButton ctrl, ref bool CancelDefault)
        {
            _presenter.Show();
        }

        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing && _userControl != null)
            {
                var uc = (UserControl)_userControl;
                uc.Dispose();
            }

            disposed = true;

            base.Dispose();
        }
    }
}
