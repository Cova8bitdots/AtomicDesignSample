using cova.ui.common;
using UniRx;

namespace cova.ui
{
    /// <summary>
    /// ViewModel の基底クラス
    /// </summary>
    public class BaseButtonModel : BaseModel<BaseButton, BaseButton.ViewModel> 
    {
        /// <summary>
        /// 連動
        /// </summary>
        /// <param name="view"></param>
        /// <param name="viewModel"></param>
        public override void Bind(BaseButton view, BaseButton.ViewModel viewModel)
        {
            view.Initialize(viewModel);
            view.AddTo(m_disposable);
        }
    }
}