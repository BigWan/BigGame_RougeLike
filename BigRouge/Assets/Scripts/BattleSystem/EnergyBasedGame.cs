using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BigRogue.BattleSystem {

    public class EnergyBasedGame : MonoBehaviour{

        /// <summary>
        /// 需要处理的有能量的Entity
        /// </summary>
        public List<Entity> entities;


        public void Start() {
            
        }


        public void Load() { }

        

        public void Tick() { }



        private void FixedUpdate() {
            Tick();
        }



        public void AddEntity(Entity e) { }

        public void RemoveEntity(Entity e) { }

        public void HasEntity(Entity e) { }

    }
}
