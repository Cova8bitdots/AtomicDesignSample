using System;
using UniRx;

namespace cova.ui.common
{
    /// <summary>
    /// ViewModel の基底クラス
    /// </summary>
    public abstract class BaseViewModel : IDisposable
    {
        protected readonly CompositeDisposable m_disposable = new CompositeDisposable();

        public virtual void Dispose()
        {
            if (m_disposable.IsDisposed) return;
            m_disposable.Dispose();
        }
    }
}