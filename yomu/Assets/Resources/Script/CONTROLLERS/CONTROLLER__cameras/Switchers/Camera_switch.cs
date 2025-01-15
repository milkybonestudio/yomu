

public abstract class Camera_switch {

        public Camera_switch(){

                controller_cameras = CONTROLLER__cameras.instance;

        }

        public CONTROLLER__cameras controller_cameras;

        public abstract void Start();

            public abstract bool Update();

            
        public abstract void Finish(); // ** encerra mesmo na transicao

        public virtual void Prepare_resources(){}


}