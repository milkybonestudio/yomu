


// trocar para Ponto_localizaodr?
public class Posicao {


        // public int continente_id;
        // public int reino_id;
        // public int estado_id;
        

        public short regiao_id; // fixo 
        public byte trecho_id; // catedral // cada trecho pode mudar mas o numero de trechos é fixo 
        public byte cidade_no_trecho_id; // qual cidade esta nesse trecho

        public byte zona_id; // zona leste da catedral
        public byte local_id; // dormitorio_feminino
        public byte area_id; // nara room 
        public byte ponto_id; // ponto

        public long posicao_id = 0;


        #if UNITY_EDITOR


                public string regiao_nome = "NAO COLOCADO"; 
                public string trecho_nome = "NAO COLOCADO"; 
                public string cidade_no_trecho_nome = "NAO COLOCADO"; 

                public string zona_nome = "NAO COLOCADO"; 
                public string local_nome = "NAO COLOCADO";
                public string area_nome = "NAO COLOCADO"; 
                public string ponto_nome = "NAO COLOCADO";


        #endif



        // estado => conjunto de cidades/ regioes 
        //           cidades => regioes povoadas 
        // 


}

