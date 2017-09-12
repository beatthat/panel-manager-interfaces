using UnityEngine;
using System.Collections.Generic;

namespace BeatThat
{
	/// <summary>
	/// Manages display depth of a gameobect's children
	/// </summary>
	public interface PanelDisplayController 
	{
		/// <summary>
		/// Updates the display depth of a list of transforms (children of the controller)
		/// so that the last element in the provided list is in front
		/// </summary>
		/// <param name="displayList">Transforms which should be the children of the controller's transform.</param>
		void UpdateDisplayList(IEnumerable<Transform> displayList);
	}
}
