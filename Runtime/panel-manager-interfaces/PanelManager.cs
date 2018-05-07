using BeatThat;
using System;
using UnityEngine;

namespace BeatThat
{
	/// <summary>
	/// Manages opening and closing a collection of panels.
	/// </summary>
	public interface PanelManager 
	{
		/// <summary>
		/// Gets the active panel if any or returns NULL if none
		/// </summary>
		GameObject activePanel { get; }
		
		/// <summary>
		/// True if there is currently an active panel
		/// </summary>
		bool hasActivePanel { get; }
		
		bool isActivePanelInOrTransitioningIn { get; }

		[Obsolete("this should be configured where needed")]bool allowChangeToSelf { get; set; }
		
		/// <summary>
		/// Closes the panel if it is the active panel
		/// </summary>
		void ClosePanel(GameObject p, bool showPreviousPanel = true);

		/// <summary>
		/// Closes the panel of type if it is the active panel
		/// </summary>
		void ClosePanel(Type p, bool showPreviousPanel = true);
		
		/// <summary>
		/// Closes the active panel if any.
		/// </summary>
		void ClosePanel(bool showPreviousPanel = true);
		
		/// <summary>
		/// Brings in a new panel. Closes the active panel first (if any).
		/// For IPresenters that require a model, 
		/// caller MUST ensure p.model is set before making this call.
		/// </summary>
		/// <param name='req'>Request object contains the panel to open or otherwise info to open a panel</param>
		/// <param name='skipTransitions'>Skip transitions if true</param>
		/// <param name='showPreviousPanel'>If changing to null (close active panel if any), 
		/// set TRUE to force the behavioir of popping one panel instead of closing all</param>
		void ChangePanel(ChangePanel req, bool skipTransitions = false, bool showPreviousPanel = false);
		
	}
}
