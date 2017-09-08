using BeatThat.App;
using BeatThat;

namespace BeatThat
{
	/// <summary>
	/// Notification helpers for opening and closing panels, generally observed/handled by a PanelManager.
	/// </summary>
	public static class PanelNotifications  
	{
		[NotificationType]
		public const string OPEN = "PANEL_OPEN";

		public static void Open(object panel)
		{
			Open(new ChangePanel(panel));
		}

		public static void Open<T>()
		{
			var r = ChangePanel.OfType<T>();
			Open(r);
		}

		public static void Open(ChangePanel panelRequest)
		{
			NotificationBus.SendWBody<ChangePanel>(OPEN, panelRequest);
		}

		[NotificationType]
		public const string CLOSE = "PANEL_CLOSE";

		public static void Close(object panel = null, bool showLast = false)
		{
			NotificationBus.SendWBody<ClosePanel>(CLOSE, new ClosePanel(panel, showLast));
		}

		[NotificationType]
		public const string ACTIVE_MODAL_WINDOW_CHANGED = "ACTIVE_PANEL_CHANGED";
		public static void ActiveModalWindowChanged(ManagedPanel p, NotificationReceiverOptions opts = NotificationReceiverOptions.DontRequireReceiver)
		{
			NotificationBus.SendWBody<ManagedPanel>(ACTIVE_MODAL_WINDOW_CHANGED, p, opts);
		}
	}
}
