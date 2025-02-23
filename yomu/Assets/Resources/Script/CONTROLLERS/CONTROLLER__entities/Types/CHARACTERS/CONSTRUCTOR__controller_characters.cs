using System;

public unsafe static class CONSTRUCTOR__controller_characters {


        public static CONTROLLER__characters Construct( Character[] _characters ){

                CONTROLLER__characters construtor = new CONTROLLER__characters();
                CONTROLLER__characters.instance = construtor;

                return construtor;


        }


}