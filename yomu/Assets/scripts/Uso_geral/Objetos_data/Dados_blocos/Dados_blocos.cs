
using System;
using UnityEngine;
 




public class Dados_blocos {


        public static Dados_blocos instancia;
        public static Dados_blocos Pegar_instancia(){ return instancia; }
        public static Dados_blocos Construir(){ instancia = new Dados_blocos(); return instancia;}



        public void Iniciar(){}


        public Req_transicao req_transicao = null ;
        public Req_mudar_UI req_mudar_UI = null ;
        public Req_mudar_input req_mudar_input= null ;



        public Plataforma_START plataforma_START = new Plataforma_START();
        public Plataforma_RETURN plataforma_RETURN = new Plataforma_RETURN();


        public Visual_novel_START visual_novel_START = new Visual_novel_START();
        public Visual_novel_RETURN visual_novel_RETURN = new Visual_novel_RETURN();


        public Jogo_START jogo_START = new Jogo_START();
        public Jogo_RETURN jogo_RETURN = new Jogo_RETURN();



        public void Colocar_nova_req( Req_transicao _req_transicao){

            if(this.req_transicao != null) throw new ArgumentException("foi colocado 2 reqs ao mesmo tempo. req 1 estava indo para: " + Convert.ToString(this.req_transicao.novo_bloco) + ", req 2 estava querendo ir para: " + Convert.ToString(_req_transicao.novo_bloco));
            this.req_transicao = _req_transicao;
            return;


        }



}
