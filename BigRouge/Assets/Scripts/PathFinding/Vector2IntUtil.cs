using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace BigRogue.PathFinding {

    public static class Vector2IntUtil   {

        static Vector2Int[] edgeOffset = new Vector2Int[] {
            Vector2Int.up,Vector2Int.right,Vector2Int.down,Vector2Int.left
        };

        static Vector2Int[] cornerOffset = new Vector2Int[] {
            new Vector2Int(1,1),
            new Vector2Int(1,-1),
            new Vector2Int(-1,-1),
            new Vector2Int(-1,1)
        };

        public static List<Vector2Int> GetNeightbours(this Vector2Int center,bool isIgnoreCorner) {

            List<Vector2Int> result = new List<Vector2Int>();

            for (int i = 0; i < edgeOffset.Length; i++) {
                result.Add(edgeOffset[i]);
            }

            if(isIgnoreCorner) return result;

            for (int i = 0; i < cornerOffset.Length; i++) {
                result.Add(cornerOffset[i]);
            }

            return result;
        }

    }
}
