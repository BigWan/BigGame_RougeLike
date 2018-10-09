using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace BigRogue.PathFinding {

    public static class Vector3IntUtil   {

        static Vector3Int[] edgeOffset = new Vector3Int[] {
           new Vector3Int(0,0,1),
           new Vector3Int(1,0,0),
           new Vector3Int(0,0,-1),
           new Vector3Int(-1,0,0),
        };

        static Vector3Int[] cornerOffset = new Vector3Int[] {
            new Vector3Int(1,0,1),
            new Vector3Int(1,0,-1),
            new Vector3Int(-1,0,-1),
            new Vector3Int(-1,0,1)
        };

        public static List<Vector3Int> GetEdgeNeighbours(this Vector3Int center) {
            List<Vector3Int> result = new List<Vector3Int>();
            for (int i = 0; i < edgeOffset.Length; i++) {
                result.Add(edgeOffset[i]+ center);
            }
            return result;
        }

        public static List<Vector3Int> GetCornerNeighbours(this Vector3Int center) {
            List<Vector3Int> result = new List<Vector3Int>();
            for (int i = 0; i < cornerOffset.Length; i++) {
                result.Add(edgeOffset[i] + center);
            }
            return result;
        }

        public static List<Vector3Int> GetNeightbours(this Vector3Int center,bool allowDiagonal) {

            List<Vector3Int> result = new List<Vector3Int>();

            for (int i = 0; i < edgeOffset.Length; i++) {
                result.Add(edgeOffset[i] + center);
            }

            if(!allowDiagonal) return result;

            for (int i = 0; i < cornerOffset.Length; i++) {
                result.Add(cornerOffset[i]+ center);
            }

            return result;
        }

    }
}
