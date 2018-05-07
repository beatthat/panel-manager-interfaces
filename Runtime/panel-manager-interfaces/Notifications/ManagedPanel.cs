using UnityEngine;

namespace BeatThat
{
	public struct ManagedPanel 
	{
		public ManagedPanel(GameObject p, GameObject manager = null)
		{
			this.panelGO = p;
			this.manager = manager;
		}

		/// <summary>
		/// A ref to the panel instance that will be opened
		/// </summary>
		/// <value>The presenter.</value>
		public GameObject panelGO { get; private set; }

		/// <summary>
		/// The GameObject acting as window manager for the active panel (if any)
		/// </summary>
		/// <value>The manager.</value>
		public GameObject manager { get; private set; }

		public bool anyActivePanel { get { return this.panelGO != null; } }

	}

}
