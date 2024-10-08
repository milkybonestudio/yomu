using UnityEngine;
using System;

public static class TOOL__device {


        public static void Instanciate_device( Dispositivo _device,  GameObject _local_para_anexar ){


                // --- VERIFICACOES
                if( _device.dispositivo_prefab == null )
                    { throw new Exception( $"Tentou Anexar o dipositivo { _device.interface_dispositivo.Pegar_nome() } mas o prefab estava null"); }


                _device.dispositivo_game_object = GameObject.Instantiate( _device.dispositivo_prefab );
                _device.dispositivo_game_object.name = _device.dispositivo_prefab.name;

                if( _device.dispositivo_game_object.name != ( _device.interface_dispositivo.Pegar_nome() + "_dispositivo" ) )
                    { throw new Exception( $"Prefab estava com o nome errado no container. Estava: { _device.dispositivo_game_object.name }" ); }


                SUPPORT__device_parent.Anexar_dispositivo( _local_para_anexar, _device );

                
                // --- CONSTROI OS OBJETOS

                _device.dados_dispositivo.Get_data_from_prefab();

            return;


        }



        

}