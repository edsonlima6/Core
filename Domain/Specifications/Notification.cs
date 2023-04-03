using System.Collections.Generic;

namespace Domain.Specifications;

public class Notification
{
    public string Message { get; set; }
    public string TypeMessage { get; set; }

}

public class DomainNotification
{
    public DomainNotification()
    {
        Notifications = new List<Notification>();
    }
    public List<Notification> Notifications { get; private set; }

    public void AddNotification(string message, string type)
    {
        Notifications.Add(new Notification{ Message =  message, TypeMessage = type});
    }

    public void CleanNotification() => Notifications.Clear();

    public bool HasNotification() =>  (Notifications.Count > 0);

    
}
