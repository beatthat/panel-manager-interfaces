using BeatThat.App;
using BeatThat;
using UnityEngine;

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
			var go = panel as GameObject ?? (panel as Component != null) ? (panel as Component).gameObject : null;
			NotificationBus.SendWBody<ClosePanel>(CLOSE, new ClosePanel {
				panelGO = go,
				showLast = showLast
			});
		}

		public static void Close<T>(bool showLast = false)
		{
			NotificationBus.SendWBody<ClosePanel>(CLOSE, new ClosePanel {
				panelType = typeof(T),
				showLast = showLast
			});
		}

		[NotificationType]
		public const string ACTIVE_MODAL_WINDOW_CHANGED = "ACTIVE_PANEL_CHANGED";
		public static void ActiveModalWindowChanged(ManagedPanel p, NotificationReceiverOptions opts = NotificationReceiverOptions.DontRequireReceiver)
		{
			NotificationBus.SendWBody<ManagedPanel>(ACTIVE_MODAL_WINDOW_CHANGED, p, opts);
		}
	}
}
