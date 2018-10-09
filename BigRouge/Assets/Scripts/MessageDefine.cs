
using UnityEngine;

namespace BigRogue {

    /// <summary>
    /// 切换状态
    /// </summary>
    public class ButtonClickMessage : Message {

        public Actor actor;

        public ButtonClickMessage(MessageCode messageID, Actor actor):base(messageID) {
            this.actor = actor;
        }




    }


    

}


