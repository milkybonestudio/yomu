


public class Modificador_personagem_conversa {



        public void Modificar_emocoes( Personagem _personagem, float[] _adicionais_emocoes  ){


            
                _personagem.gerenciador_estado_mental.Adicionar_modificadores_emocionais( _adicionais_emocoes );

                return;


        }
	

}
