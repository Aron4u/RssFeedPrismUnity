using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewsBrowser.Views
{
  /// <summary>
  /// Interaction logic for WebBrowserExt.xaml
  /// </summary>
  public partial class WebBrowserExt : UserControl
  {
    public WebBrowserExt()
    {
      InitializeComponent();
      this.WB.Loaded += WB_Loaded;
    }

    void WB_Loaded(object sender, RoutedEventArgs e)
    {
      HideScriptErrors(this.WB, true);

    }

    public void HideScriptErrors(WebBrowser wb, bool Hide)
    {
      FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
      if (fiComWebBrowser == null) return;
      object objComWebBrowser = fiComWebBrowser.GetValue(wb);
      if (objComWebBrowser == null) return;
      objComWebBrowser.GetType().InvokeMember(
      "Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });
    }

    public Uri NewsSite
    {
      get { return (Uri)GetValue(NewsSiteProperty); }
      set { SetValue(NewsSiteProperty, value); }
    }

    // Using a DependencyProperty as the backing store for NewsSite.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty NewsSiteProperty =
        DependencyProperty.Register("NewsSite", typeof(Uri), typeof(WebBrowserExt), new PropertyMetadata(OnNewsSiteChanged));

    private static void OnNewsSiteChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((WebBrowserExt)d).WB.Source = e.NewValue as Uri;
    }
  }
}
