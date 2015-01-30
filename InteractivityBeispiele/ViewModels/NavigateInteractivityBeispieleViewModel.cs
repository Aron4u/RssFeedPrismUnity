using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using MVVM_Utilities;

namespace InteractivityBeispiele.ViewModels
{
  public class NavigateInteractivityBeispieleViewModel:ViewModelBase
  {
    public DelegateCommand MessageBoxCommand { get; set; }
    public DelegateCommand ConfirmationCommand { get; set; }
    public DelegateCommand CustomPopupCommand { get; set; }

    public InteractionRequest<INotification> NotificationRequest { get; set; }
    public InteractionRequest<IConfirmation> ConfirmationRequest { get; set; }
    public InteractionRequest<INotification> CustomPopupRequest { get; set; }

    private string statustext="leer";

    public string Statustext
    {
      get { return statustext; }
      set { this.SetProperty<string>(ref statustext, value); }
    }


    public NavigateInteractivityBeispieleViewModel()
    {
      MessageBoxCommand = new DelegateCommand(ShowMessageBox);
      ConfirmationCommand = new DelegateCommand(ShowConfirmation);

      CustomPopupCommand = new DelegateCommand(ShowCustomPopup);

      NotificationRequest = new InteractionRequest<INotification>();
      ConfirmationRequest = new InteractionRequest<IConfirmation>();

      CustomPopupRequest = new InteractionRequest<INotification>();
    }

    private void ShowCustomPopup()
    {
      CustomPopupRequest.Raise(new Notification { Title = "Custom Popup", Content = "was auch immer" }, r => Statustext = "aha");
    }

    private void ShowConfirmation()
    {
      ConfirmationRequest.Raise(new Confirmation() { Title = "Wollen Sie wirklich", Content = "Das ist gefährlich" }, r => Statustext = r.Confirmed ? "geht klar" : "lieber nicht");
    }

    private void ShowMessageBox()
    {
      NotificationRequest.Raise(new Notification() { Title = "Beispieltitel", Content = "Inhalt der MessageBox" }, r => Statustext = "Gemeldet");
    }

  }
}
