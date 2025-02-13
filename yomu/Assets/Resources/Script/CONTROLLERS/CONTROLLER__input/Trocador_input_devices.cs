using UnityEngine;


public static class Trocador_input_devices {


        public static void Mudar_input_device( Input_device_type _novo_input ){


                Garantir_tipo_valido( _novo_input );
                
                switch( _novo_input ){

                    case Input_device_type.keyboard_AND_mouse: Trocador_input_devices.Trocar_input_para_keyboard_AND_mouse(); break;
                    case Input_device_type.mobile: Trocador_input_devices.Trocar_input_para_mobile(); break;
                    case Input_device_type.game_pad: Trocador_input_devices.Trocar_input_para_game_pad(); break;

                }

        }


        private static void Garantir_tipo_valido( Input_device_type _novo_input ){


            if( _novo_input == CONTROLLER__input.Pegar_instancia().input_device_atual )
                { throw new System.Exception( $"Tentou trocar o tipo de device de input mas já estava como <Color=lime>{ _novo_input }</Color>." ); }

            if( _novo_input == Input_device_type.nada )
                { throw new System.Exception( "Tentou trocar o tipo de device para nada" ); }

            if( _novo_input == Input_device_type.keyboard_AND_mouse )
                { Garantir( _novo_input, DeviceType.Desktop, DeviceType.Unknown, DeviceType.Unknown ); }

            if( _novo_input == Input_device_type.mobile )
                { Garantir( _novo_input, DeviceType.Handheld, DeviceType.Unknown, DeviceType.Unknown ); }

            if( _novo_input == Input_device_type.game_pad )
                { Garantir( _novo_input, DeviceType.Console, DeviceType.Desktop, DeviceType.Handheld ); }

        }


        private static void Garantir( Input_device_type _input,  DeviceType _opcao_1, DeviceType _opcao_2 , DeviceType _opcao_3 ){


                DeviceType tipo = CONTROLLER__application_information.Get_instance().device;

                if( tipo == _opcao_1 )
                    { return; }

                if( tipo == _opcao_2 )
                    { return; }

                if( tipo == _opcao_3 )
                    { return; }

                throw new System.Exception( $"Tentou trocar para o input { _input } mas o sistema é tipo { tipo }" );

        }



        public static void Trocar_input_para_keyboard_AND_mouse(){


        }

        public static void Trocar_input_para_mobile(){

            

        }

        public static void Trocar_input_para_game_pad(){

            

        }



}