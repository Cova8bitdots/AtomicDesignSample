using cova.ui.common;
using UniRx;

namespace cova.ui
{
    /// <summary>
    /// Button Model の基底クラス
    /// </summary>
    public class BaseButtonModel : BaseModel<BaseButtonView, BaseButtonView.ViewModel> 
    {
        /// <summary>
        /// 連動
        /// </summary>
        /// <param name="view"></param>
        /// <param name="viewModel"></param>
        public override void Bind(BaseButtonView view, BaseButtonView.ViewModel viewModel)
        {
            view.Initialize(viewModel);
            view.AddTo(m_disposable);
        }
    }
}