﻿using System;
using Microsoft.Vbe.Interop;

namespace Rubberduck.UI.CodeInspections
{
    public class QuickFixEventArgs : EventArgs
    {
        private readonly Action<VBE> _quickFix;

        public QuickFixEventArgs(Action<VBE> quickFix)
        {
            _quickFix = quickFix;
        }

        public Action<VBE> QuickFix
        {
            get { return _quickFix; }
        }
    }
}