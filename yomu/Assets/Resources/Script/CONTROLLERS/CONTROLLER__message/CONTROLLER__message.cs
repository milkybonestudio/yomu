

public class CONTROLLER__message {

        
        public static CONTROLLER__message instance;
        public static CONTROLLER__message Get_instance(){ return instance; }



        public bool is_showing_message_system;


        

        public void Show_massage( Type_message _type, string _message ){

                Message message = new Message();
                message.message = _message;
                message.type = _type;

                switch( _type ){

                    case Type_message.system_error: Activate_system_error( _message ); break;
                    case Type_message.system_info: Activate_system_info( _message );break;
                    default: throw new System.Exception("a");

                }

                // Dispositivo.Ativar_metodo( ( int ) Messages_method.activate_message, new object[]{ message } );
                return;

        }


        public void Activate_system_info( string _message ){}
        public void Activate_system_error( string _message ){

            // ** precisa esperar o dispositivo ficar mais maduro
                
            Message message = new Message();
            
            message.message = _message;
            message.type = Type_message.system_error;


        }

        public enum Messages_method {

            activate_message, 
            
        }

        public class Message {

                public string message;
                public Type_message type;

        }


}
