using UnityEngine;
using System.Collections;

namespace BigRogue {
    public struct Coordinate {

        public Vector3Int coordinate3D;


        public Coordinate(Vector3Int coordinate) {
            this.coordinate3D = coordinate;
        }

        public Coordinate(Vector3 position) {
            this.coordinate3D = new Vector3Int((int)position.x, (int)(position.y*2), (int)position.z);
        }

        public int x { get { return coordinate3D.x; } }
        public int y { get { return coordinate3D.y; } }
        public int z { get { return coordinate3D.z; } }

        public Vector2Int coordinate2D {
            get {
                return new Vector2Int(x, z);
            }
        }

        public float height {
            get { return coordinate3D.y * 0.5f; }
        }

        public Vector3 localPosition {
            get {
                return new Vector3(x, height, z);
            }
        }

    }
}
