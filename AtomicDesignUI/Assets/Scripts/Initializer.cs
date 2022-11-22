using System.Collections;
using System.Collections.Generic;
using cova.ui;
using UniRx;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private BaseButtonView m_view = null;
    protected readonly CompositeDisposable m_disposable = new CompositeDisposable();

    // Start is called before the first frame update
    void Start()
    {
        var model = new BaseButtonModel().AddTo(m_disposable);
        var vm = new BaseButtonView.ViewModel().AddTo(m_disposable);
        
        model.Bind(m_view, vm);
    }
    public virtual void Dispose()
    {
        if (m_disposable.IsDisposed) return;
        m_disposable.Dispose();
    }
}
