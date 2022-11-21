using cova.ui.common;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace cova.ui
{
    public class BaseButton : BaseView<BaseButton.ViewModel>
    {
        public class ViewModel : BaseViewModel
        {
            public readonly BoolReactiveProperty IsInteractable = new BoolReactiveProperty(true);
            public readonly ReactiveProperty<Sprite> ButtonImage = new ReactiveProperty<Sprite>(null);

            public Subject<Unit> OnButtonClicked = new Subject<Unit>();

            public ViewModel()
            {
                IsInteractable.AddTo(m_disposable);
                ButtonImage.AddTo(m_disposable);

                OnButtonClicked.AddTo(m_disposable);
            }
        }

        [SerializeField] private Button m_button = null;
        [SerializeField] private Image m_buttonImg = null;


        /// <summary>
        /// 初期化メソッド
        /// </summary>
        /// <param name="viewModel"></param>
        /// <typeparam name="T"></typeparam>
        public override void Initialize(ViewModel viewModel)
        {
            Assert.IsNotNull(viewModel, "[BaseTextView] viewModel is NULL");
            Assert.IsNotNull(m_button, "[BaseTextView] m_button is NULL");
            Assert.IsNotNull(m_buttonImg, "[BaseTextView] m_buttonImg is NULL");
            viewModel.AddTo(m_disposable);

            viewModel.IsInteractable.Subscribe(isInteractable =>
            {
                m_button.interactable = isInteractable;
            }).AddTo(m_disposable);
            
            viewModel.ButtonImage.Subscribe(sprite =>
            {
                m_buttonImg.sprite = sprite;
            }).AddTo(m_disposable);
            
            
            m_button.OnClickAsObservable().Subscribe(_ => {viewModel.OnButtonClicked.OnNext(Unit.Default); }).AddTo(m_disposable);

        }
    }
}

