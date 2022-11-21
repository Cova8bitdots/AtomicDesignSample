using System;
using UniRx;
using UnityEngine;

namespace cova.ui.common
{

    public abstract class BaseView<TViewModel> : MonoBehaviour, IDisposable where TViewModel : BaseViewModel
    {
        protected readonly CompositeDisposable m_disposable = new CompositeDisposable();

        /// <summary>
        /// 初期化メソッド
        /// </summary>
        /// <param name="viewModel"></param>
        /// <typeparam name="T"></typeparam>
        public abstract void Initialize(TViewModel viewModel);

        public virtual void Dispose()
        {
            if (m_disposable.IsDisposed) return;
            m_disposable.Dispose();
        }
    }
}
