using UnityEngine;

namespace BeatThat
{
	public struct ClosePanel 
	{
		public ClosePanel(object p, bool showLast)
		{
			this.panelGO = p as GameObject?? (p is Component)? (p as Component).gameObject: null;
			this.showLast = showLast;
		}
			
		public GameObject panelGO { get; private set; }

		public bool showLast { get; private set; }

	}
}
