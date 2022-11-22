using System;
using UniRx;

namespace cova.ui.common
{
    /// <summary>
    /// Model の基底クラス
    /// </summary>
    public abstract class BaseModel<TView, TViewModel> : IDisposable
    where TViewModel: BaseViewModel
    where TView: BaseView<TViewModel>
    {
        protected readonly CompositeDisposable m_disposable = new CompositeDisposable();

        /// <summary>
        /// 連動
        /// </summary>
        /// <param name="view"></param>
        /// <param name="viewModel"></param>
        public abstract void Bind(TView view, TViewModel viewModel);
        
        public virtual void Dispose()
        {
            if (m_disposable.IsDisposed) return;
            m_disposable.Dispose();
        }
    }
}