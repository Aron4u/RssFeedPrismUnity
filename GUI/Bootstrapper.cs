using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System.Reflection;
using System.Globalization;

namespace GUI
{
  public class Bootstrapper : UnityBootstrapper
  {
    public Bootstrapper()
    {
      ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
      {
        var viewName = viewType.FullName;
        viewName = viewName.Replace(".Views.", ".ViewModels.");
        var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
        var viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);
        var t = Type.GetType(viewModelName);
        return t;
      });

      ViewModelLocationProvider.SetDefaultViewModelFactory(type =>
      {
        return Container.Resolve(type);
      });

    }

    protected override System.Windows.DependencyObject CreateShell()
    {
      return Container.Resolve<Shell>();
    }

    protected override void InitializeShell()
    {
      base.InitializeShell();
      App.Current.MainWindow =(Window) Shell;
      App.Current.MainWindow.Show();
    }

    protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
    {
      var catalog = new DirectoryModuleCatalog { ModulePath = @".\Modules" };
      return catalog;

    }
  }
}
