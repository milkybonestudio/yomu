

public unsafe struct PROGRAM_DATA__login {


        // ** GLOBAL

        public PROGRAM_DATA__login* pointer;

        public LOGIN_DATA__global global;

        public LOGIN_DATA__persistent persistent;
        public LOGIN_DATA__temporary temporary;
        public LOGIN_DATA__creation creation;


        public LOGIN_DATA__standart Get__STANDART(){ 


                LOGIN_DATA__standart ret = default;

                    ret.global     = &( pointer->global);
                    ret.creation   = &( pointer->creation.standart);
                    ret.temporary  = &( pointer->temporary.standart);
                    ret.persistent = &( pointer->persistent.standart);

                return ret;


        }



        
        public void Define_type( Login_type _type ){

                global.persistent.type = _type;

        }

        public static void Construct( PROGRAM_DATA__login* _data ){

            _data->global.persistent.type = Login_type.standart;

        }


}










