using BeatThat;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace BeatThat
{
	/// <summary>
	/// Argument object used to tell a PanelManager to either open or close a Panel.
	/// 
	/// Generally passed via Notification, e.g.
	/// 
	/// <code>
	/// PanelNotifications.Open(new ChangePanel(myPanelObj));
	/// </code>
	/// </summary>
	public struct ChangePanel 
	{
//		public static ChangePanel Create(object p, object model = null, bool push = false, bool noScrim = false, bool controlsOwnPosition = false)
//		{
//			IDictionary<string, object> opts = null;
//
//			if(push) {
//				opts = new Dictionary<string, object> ();
//				OPT_PUSH.Set(true, opts);
//			}
//				
//			if(noScrim) {
//				opts = opts?? new Dictionary<string, object>();
//				OPT_NO_SCRIM.Set(true, opts);
//			}
//
//			if(controlsOwnPosition) {
//				opts = opts?? new Dictionary<string, object>();
//				OPT_CONTROLS_OWN_POSITION.Set(true, opts);
//			}
//
//			if(model != null) {
//				opts = opts?? new Dictionary<string, object>();
//				OPT_MODEL.Set(model, opts);
//			}
//
//			return new ChangePanel(p, opts);
//		}

		/// <summary>
		/// Create a ChangePanel object with (optional) options dictionary.
		/// </summary>
		/// <param name="panel">
		/// Generally will work with a UnityEngine.GameObject, UnityEngine.Component, or System.Type.
		/// </param>
		/// <param name="options">
		/// Options interpretted by the PanelManager.
		/// Common options are provided in ChangePanelOptions class.
		/// Other options may also be supported by different PanelManager implementations.
		/// </param>
		public ChangePanel(object panel, IDictionary<string, object> options = null)
		{
			this.panel = (panel is Type)? null: panel;
			this.panelGO = panel as GameObject?? (panel is Component)? (panel as Component).gameObject: null;

			// TODO: look for controller for type when GameObject passed?
			this.panelType = (panel as Type)?? (Type)((panel != null)? panel.GetType(): null);
			this.options = options;
		}

		/// <summary>
		/// Shortcut for creating a ChangePanel where the panel property will be a System.Type 
		/// (to be resolved by the PanelManager)
		/// </summary>
		public static ChangePanel OfType<T>(IDictionary<string, object> options = null)
		{
			return new ChangePanel(typeof(T), options);
		}


		/// <summary>
		/// Convenience op for when the panel property of a ChangePanel object gets resolved (say from a System.Type).
		/// Returns a new ChangePanel because of struct semantics.
		/// </summary>
		public ChangePanel ResolvedPanel(object p)
		{
			return new ChangePanel(p, this.options);
		}

		public IDictionary<string, object> options { get; private set; }

		/// <summary>
		/// Use Panel type instead of instance
		/// for panels where it's assumed their manager can find or create them.
		/// </summary>
		public Type panelType { get; private set; }

		/// <summary>
		/// A ref to the panel instance that will be opened
		/// </summary>
		/// <value>The presenter.</value>
		public object panel { get; private set; }

		/// <summary>
		/// The GameObject of the panel
		/// </summary>
		public GameObject panelGO { get; private set; }

		/// <summary>
		/// When set to true, should indicate that the new panel should open *over*
		/// any currently open panel as opposed to closing the current panel.
		/// 
		/// The value of this property really lives in the options dictionary.
		/// This is really a convenience getter for ChangePanelOptions.OPT_PUSH option.
		/// </summary>
		public bool push { get { return ChangePanelOptions.OPT_PUSH.Get(this.options); } }

		/// <summary>
		/// Signal to panel manager that no scrim should display behind the new panel.
		/// 
		/// The value of this property really lives in the options dictionary.
		/// This is really a convenience getter for ChangePanelOptions.OPT_NO_SCRIM option.
		/// </summary>
		/// <value><c>true</c> if no scrim; otherwise, <c>false</c>.</value>
		public bool noScrim { get { return ChangePanelOptions.OPT_NO_SCRIM.Get(this.options); } }

		/// <summary>
		/// Signal to panel manager that that it should NOT reposition the panel 
		/// (e.g. set it to local position [0,0,0] as it would for most popup windows).
		/// 
		/// Sometimes useful when a panel is something like a dropdown menu.
		/// 
		/// The value of this property really lives in the options dictionary.
		/// This is really a convenience getter for ChangePanelOptions.OPT_CONTROLS_OWN_POSITION option.
		/// </summary>
		/// <value><c>true</c> if no scrim; otherwise, <c>false</c>.</value>
		public bool controlsOwnPosition { get { return ChangePanelOptions.OPT_CONTROLS_OWN_POSITION.Get(this.options); }  }

	}
}
