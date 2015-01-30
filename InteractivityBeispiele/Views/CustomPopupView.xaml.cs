using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace InteractivityBeispiele.Views
{
  /// <summary>
  /// Interaction logic for CustomPopupView.xaml
  /// </summary>
  public partial class CustomPopupView : UserControl, IInteractionRequestAware
  {
    public CustomPopupView()
    {
      InitializeComponent();
    }

    public Action FinishInteraction { get; set; }
    public INotification Notification { get; set; }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if (FinishInteraction != null) FinishInteraction();
    }

  }
}
