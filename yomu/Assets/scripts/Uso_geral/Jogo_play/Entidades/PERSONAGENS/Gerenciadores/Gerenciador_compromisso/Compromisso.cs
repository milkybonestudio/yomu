using System;



public class Compromisso {


    public Evento evento;
    // quando colocar em um personagem cada um vai ter um proprio. 
    // quando for colocar um evento o personagem tem lidar se ele vai ou nao 

    // 0  => ignora => nao acha importante 
    // 1  => cumpre  => vai 
    // -1 =>  nao cumpre => nao vai por algum motivo e é importante 
    public Del_personagem_TO_int verificar_ida;


    public Action< Personagem > lidar_cumprir = ( Personagem _per ) => { throw new Exception( "nao foi colocado fn evento personagem "  ); };
    public Action< Personagem > lidar_nao_cumprir = ( Personagem _per ) => { throw new Exception( "nao foi colocado fn evento personagem "   ); };
    public Action< Personagem > lidar_ignorar = ( Personagem _per ) => { throw new Exception( "nao foi colocado fn evento personagem "   ); };


}