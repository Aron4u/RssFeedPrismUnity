using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;

namespace NewsBrowser.ViewModels
{
  public class ViewModelBase:BindableBase,INavigationAware, IActiveAware
  {
    public virtual bool IsNavigationTarget(NavigationContext navigationContext)
    {
      return true;
    }

    public virtual void OnNavigatedFrom(NavigationContext navigationContext)
    {
      
    }

    public virtual void OnNavigatedTo(NavigationContext navigationContext)
    {
     
    }

    public bool IsActive { get; set; }

    public event EventHandler IsActiveChanged;
  }
}
