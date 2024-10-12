using System;
using System.IO;
using UnityEngine;

public static class CONSTRUCTOR__device {


        public static Dispositivo Construct( INTERFACE__dispositivo _interface ){


                Dispositivo device = new Dispositivo();

                    device.interface_dispositivo = _interface;

                    device.nome_dispositivo = _interface.Get_name();
                    device.path_folder_prefab = _interface.Get_main_folder();

                    // --- PEGAR PREFAB

                    string prefab_path = Path.Combine( "Devices", device.path_folder_prefab, ( device.nome_dispositivo + "_dispositivo" ) );

                    //Debug.Log( $"Path: { prefab_path }");
                    
                    device.dispositivo_prefab =  Resources.Load<GameObject>( prefab_path );

                    if( device.dispositivo_prefab == null )
                        { throw new System.Exception( $"tentou carregar o prefab do dispositivo { device.nome_dispositivo } no path <color=white><b>{ prefab_path }</b></color> do resources mas nao foi encontrado" ); }

            
                    // --- CRIA MODULOS
                    device.gerenciador_imagens = new GERENCIADOR__imagens_dispositivo( device );
                    device.gerenciador_audios = new GERENCIADOR__audios_dispositivo( device );
                    device.dados_dispositivo = new GERENCIADOR__dados_dispositivo( device );

                    // --- DECLARE THINGS
                    _interface.Declare_components( device );

                return device;


        }



}