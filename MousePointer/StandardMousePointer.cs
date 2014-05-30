using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Threading;

namespace Ifp.Validation.WPF.MousePointer
{
    class StandardMousePointer : IDisposable
    {
        readonly Cursor _StartCursor;
        public StandardMousePointer()
        {
            _StartCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = null;
            Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                Mouse.OverrideCursor = null
            ), DispatcherPriority.Loaded);
        }

        public void Dispose()
        {
            Mouse.OverrideCursor = _StartCursor;
        }
    }
}
