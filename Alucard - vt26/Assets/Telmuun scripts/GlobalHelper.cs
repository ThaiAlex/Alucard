using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Telmuun su24

// En hjälparklass som innehåller globala metoder
public static class GlobalHelper
{
    // Skapar ett unikt ID baserat på objektets scen och position
    public static string GenerateUniqueID(GameObject obj)
    {
        // Returnerar en textsträng som exempel "SampleScene_3_4"
        return $"{obj.scene.name}_{obj.transform.position.x}_{obj.transform.position.y}"; // Exempel: Chest_3_4
    }
}
