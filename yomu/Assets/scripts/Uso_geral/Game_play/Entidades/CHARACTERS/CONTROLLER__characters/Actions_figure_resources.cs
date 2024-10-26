using System;

public struct Actions_figure_resources {

        public Action instanciate;
        public Action pre_load;
        public Action activate;

        public static Actions_figure_resources Create( Action _instanciate, Action _pre_load, Action _activate ){ 
            
            Actions_figure_resources actions = new Actions_figure_resources();                    

                actions.instanciate = _instanciate;
                actions.pre_load = _pre_load;
                actions.activate = _activate;

            return actions; 

        } 


}
