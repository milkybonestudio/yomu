using System.Collections.Generic;
using UnityEngine;


public struct CONTAINER__UI_components {

        public static CONTAINER__UI_components Construct( Device _device ){

            CONTAINER__UI_components manager = default;

                manager.UI_components_dic = new Dictionary<string, UI_component>();
                manager.device = _device;

            return manager;

        }


        public delegate bool Get_minimun_resources();
        
        private Device device;
        private Dictionary<string,UI_component> UI_components_dic;
        
        public void Add( UI_component _UI, string _path_to_UI_in_structure ){

            if( _path_to_UI_in_structure == null )
                { CONTROLLER__errors.Throw( $"Did not put <Color=lightBlue>path_to_UI</Color> in the UI <Color=lightBlue>{ _UI.name }</Color>" ); }

            // ** NOVO
            _UI.structure = device.structure;
            _UI._path_to_UI_in_structure = _path_to_UI_in_structure;
            
            UI_components_dic.Add( _path_to_UI_in_structure, _UI );

        }
        

        public void Update(){ foreach( UI_component UI in UI_components_dic.Values ){ UI.Update(); } }
        

        // --- CONTROLLERS 

        // ** STATE

            public void Activate_all_UIs(){ foreach( UI_component UI in UI_components_dic.Values ){ UI.Activate(); } }
            public void Deactivate_all_UIs(){ foreach( UI_component UI in UI_components_dic.Values ){ UI.Deactivate(); } }
            public void Create_all_UIs(){ foreach( UI_component UI in UI_components_dic.Values ){ UI.Create(); } }
            public void Destroy_all_UIs(){ foreach( UI_component UI in UI_components_dic.Values ){ UI.Destroy(); } }
            public void Delete_all_UIs(){ foreach( UI_component UI in UI_components_dic.Values ){ UI.Delete(); } }


        // ** CONTENT


        public void Go_to_content_level_all_UIs( Content_level _content ){ foreach( UI_component UI in UI_components_dic.Values ){ UI.Go_to_content_level( _content ); } }
        public void Instanciate_content_all_UIs(){ foreach( UI_component UI in UI_components_dic.Values ){ UI.Instanciate_content(); } }

        public bool Check_all_UIs_content_level( Content_level _content ){

            foreach( UI_component UI in UI_components_dic.Values ){ 

                if( !!!( UI.Got_content_level( _content ) ) )
                    { return false; }

            }

            return true;

        }


}