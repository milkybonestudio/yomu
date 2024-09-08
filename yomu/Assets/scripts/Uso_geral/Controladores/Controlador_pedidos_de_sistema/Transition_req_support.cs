using System;

public static class Transition_req_support {


    public static Req_transicao Create_new_transition_req(){
            
            Req_transicao req = Controlador_pedidos_sistema.instancia.req_transicao;

            if( req != null )
                { throw new Exception( $"tentou criar uma nova req_transicao mas ainda tinha uma transicao para o bloco { req.novo_bloco }" ); }
                
            
            Req_transicao nova_req_transicao = new Req_transicao();
            Controlador_pedidos_sistema.instancia.req_transicao = nova_req_transicao;

            return nova_req_transicao;

    }

    public static Req_transicao Get_transition_req( bool _need_exist ){


        if( _need_exist && Controlador_pedidos_sistema.instancia.req_transicao == null )
            { throw new Exception( "Tentou pegar uma copia do pointer transicao req, mas ela estava null" ); }

        return Controlador_pedidos_sistema.instancia.req_transicao;

    }


    public static Req_transicao Take_transition_req( bool _need_exist ){


            if( _need_exist && Controlador_pedidos_sistema.instancia.req_transicao == null )
                { throw new Exception( "Tentou pegar transicao req, mas ela estava null" ); }
            
            Req_transicao retorno = Controlador_pedidos_sistema.instancia.req_transicao; 
            Controlador_pedidos_sistema.instancia.req_transicao = null;

            return retorno;

    }





}