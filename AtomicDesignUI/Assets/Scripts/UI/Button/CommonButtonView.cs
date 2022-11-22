using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace cova.ui
{
    public class CommonButtonView : BaseButtonView
    {
        public new class ViewModel : BaseButtonView.ViewModel
        {
            public readonly BaseTextView.ViewModel textViewModel = new BaseTextView.ViewModel();

            public ViewModel() : base()
            {
                textViewModel.AddTo(m_disposable);
            }
        }

        [SerializeField] protected BaseTextView m_text = null;


        /// <summary>
        /// 初期化メソッド
        /// </summary>
        /// <param name="viewModel"></param>
        /// <typeparam name="T"></typeparam>
        public void Initialize(ViewModel viewModel)
        {
            base.Initialize(viewModel);
            Assert.IsNotNull(viewModel, "[LabeledButton] viewModel is NULL");
            Assert.IsNotNull(m_text, "[LabeledButton] m_text is NULL");
            viewModel.AddTo(m_disposable);

            m_text.Initialize(viewModel.textViewModel);
        }
    }
}

