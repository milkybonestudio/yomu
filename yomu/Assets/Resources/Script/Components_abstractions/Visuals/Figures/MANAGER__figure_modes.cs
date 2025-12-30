

using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public struct Pair_key_value<TKey, TValue>{

        public TKey key;
        public TValue value;

}


public struct MANAGER__figure_modes {

        public static MANAGER__figure_modes Construct( Figure _figure ){

            MANAGER__figure_modes manager = default;

                manager.modes_dic = new Dictionary<Figure_mode, FIGURE_MODE>();
                manager.figure = _figure;

            return manager;

        }

        private Dictionary<Figure_mode, FIGURE_MODE> modes_dic;
        private Figure figure;

        private bool changed;


        public bool Mode_exist( Figure_mode _mode ){

            return modes_dic.ContainsKey( _mode );

        }


        public void Delete_all(){

            Guarantee_pairs();
        
            foreach( Pair_key_value<Figure_mode, FIGURE_MODE> pair in pairs ){ 
                pair.value.Delete(); 
            }

        }


        public void Add( FIGURE_MODE _mode ){ changed = true; modes_dic.Add( _mode.visual_figure, _mode ); }
        public void Remove( FIGURE_MODE _mode ){ changed = true; modes_dic.Remove( _mode.visual_figure ); }

        public FIGURE_MODE Get( Figure_mode _mode ){ return modes_dic[ _mode ]; }


        public void Update(){

            Guarantee_pairs();

            if( pairs.Length == 0 )
                { Console.Log( Figure.teste, "----Do not have any modes" ); return; }

            Console.Log( Figure.teste, "----Update modes:" );
        
            foreach( Pair_key_value<Figure_mode, FIGURE_MODE> pair in pairs ){ 
                pair.value.Update(); 
            }

        }

        public void Change_content_levels( Content_level _content ){

            Guarantee_pairs();

            foreach( FIGURE_MODE mode in modes ){

                mode.Change_content_level( _content );

            }

        }


        public void Change_content_levels( Content_level[] _content_levels ){

            Guarantee_pairs();

            foreach( FIGURE_MODE mode in modes ){
                mode.Change_content_level( _content_levels[ ( int ) mode.visual_figure ] );
            }

        }



        public bool Got_content_level( Content_level _content ){


            foreach( FIGURE_MODE mode in modes ){

                if( !!!( mode.Got_content_level( _content ) ) ) 
                    { 
                        Console.Log( mode.name + " was not rady"  );
                        Console.Log( mode.current_content );
                        Console.Log( mode.final_content );
                        return false; 
                    }
                
            }

            return true;

        }


        

        private Pair_key_value<Figure_mode, FIGURE_MODE>[] pairs;
        private FIGURE_MODE[] modes;


        public FIGURE_MODE[] Get_values(){ 
            
            Guarantee_pairs();

            return modes;

        }

        private void Guarantee_pairs(){


            if( changed || pairs == null )
                { 
                    
                    changed = false;
                    var keys = modes_dic.Keys.ToArray();

                    pairs = new Pair_key_value<Figure_mode, FIGURE_MODE>[ keys.Length ];
                    modes = new FIGURE_MODE[ keys.Length ];

                    for( int i = 0 ; i < pairs.Length; i++ ){
                        pairs[ i ].key = keys[ i ];
                        pairs[ i ].value = modes_dic[ keys[ i ] ];
                        modes[ i ] = pairs[ i ].value;
                    }
                }

        }



        public void Guarantee_all_state( Figure_mode_state _state ){

            Guarantee_pairs();

            foreach( FIGURE_MODE mode in modes ){

                if( mode.state != _state ) 
                    { CONTROLLER__errors.Throw( $"All the states need to be <Color=lightBlue>{ _state }</Color> in the figure <Color=lightBlue>{ figure.name }</Color> but the mode <Color=lightBlue>{ mode.name }</Color> was <Color=lightBlue>{ mode.state }</Color>" ); }
                
            }




        }

}