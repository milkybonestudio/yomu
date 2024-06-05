





public class Estado_mental {

    

        public Emocao_base[] emocoes_mais_fortes = new Emocao_base[ 8 ];
        
    
        public float felicidade = 500f; 
        public float tristeza = 500f;
        
        public float coragem = 500f; 
        public float medo = 500f; 
        
        public float afeto = 500f;     
        public float nojo = 500f; 
        
        public float previsibilidade = 500f; 
        public float instabilidade = 500f;  






        public void Modificar_felicidade( float valor ){

        
    
        }
        
        
        public void Modificar_medo( float valor ){
        
                Modificar_felicidade( - valor );
                medo = ( 1000 - felicidade );
            
        }


}
