using cova.ui.common;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace cova.ui
{
    public class BaseTextView : BaseView<BaseTextView.ViewModel>
    {
        public class ViewModel : BaseViewModel
        {
            public readonly StringReactiveProperty Text = new StringReactiveProperty(null);

            public ViewModel()
            {
                Text.AddTo(m_disposable);
            }
        }


        [SerializeField] private TextMeshProUGUI m_text = null;


        /// <summary>
        /// 初期化メソッド
        /// </summary>
        /// <param name="viewModel"></param>
        /// <typeparam name="T"></typeparam>
        public override void Initialize(ViewModel viewModel)
        {
            Assert.IsNotNull(viewModel, "[BaseTextView] viewModel is NULL");
            viewModel.AddTo(m_disposable);

            viewModel.Text.Subscribe(msg =>
            {
                m_text.text = msg;
            }).AddTo(m_disposable);
        }
    }
}

