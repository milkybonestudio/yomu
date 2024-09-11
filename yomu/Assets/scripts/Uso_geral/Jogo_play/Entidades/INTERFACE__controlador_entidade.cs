using System.Runtime.InteropServices;



public interface INTERFACE__controlador_entidade {

        public string Pegar_nome(){ throw new System.Exception( "nao foi implementado Pegar_nome"); }
        public Tipo_entidade Pegar_tipo(){ throw new System.Exception( $"nao foi implementado Update no controlador { Pegar_nome() }"); }
        public void Update(){ throw new System.Exception( $"nao foi implementado Update no controlador{ Pegar_nome() }" );}
        public void Carregar_entidades( Localizador_entidade[] _localizadores ){ throw new System.Exception( $"nao foi implementado Carregar_entidades no controlador{ Pegar_nome() }" );}

   
}





[StructLayout(LayoutKind.Explicit)]        
public struct Localizador_entidade{

        [FieldOffset(0)]
        public byte a_1;

        [FieldOffset(0)]
        public byte a_2;

        [FieldOffset(0)]
        public byte a_3;

        [FieldOffset(0)]
        public byte a_4;
        
        [FieldOffset(0)]
        public int indentificador;

}





