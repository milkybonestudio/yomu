using System;



public static class Finalize_req_support {


    public static Pedido_para_finalizar Create_new_finalize_req(){
            
            Pedido_para_finalizar req = CONTROLLER__system_requests.instancia.pedido_para_finalizar;

            if( req != null )
                { throw new Exception( $"tentou criar uma nova Pedido_para_finalizar mas ainda tinha uma pedido" ); }
                
            
            Pedido_para_finalizar nova_Pedido_para_finalizar = new Pedido_para_finalizar();
            CONTROLLER__system_requests.instancia.pedido_para_finalizar = nova_Pedido_para_finalizar;

            return nova_Pedido_para_finalizar;

    }

    public static Pedido_para_finalizar Get_finalize_req( bool _need_exist ){


        if( _need_exist && CONTROLLER__system_requests.instancia.pedido_para_finalizar == null )
            { throw new Exception( "Tentou pegar uma copia do pointer transicao req, mas ela estava null" ); }

        return CONTROLLER__system_requests.instancia.pedido_para_finalizar;

    }


    public static Pedido_para_finalizar Take_finalize_req( bool _need_exist ){


            if( _need_exist && CONTROLLER__system_requests.instancia.pedido_para_finalizar == null )
                { throw new Exception( "Tentou pegar transicao req, mas ela estava null" ); }
            
            Pedido_para_finalizar retorno = CONTROLLER__system_requests.instancia.pedido_para_finalizar; 
            CONTROLLER__system_requests.instancia.pedido_para_finalizar = null;
            
            return retorno;

    }


}