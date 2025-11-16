

public enum Damage_stage {

    not_start,
    rolling_numbers, // **  "fix + ( numero que fica mudando )"
    rng_calculation, // ** vai parar e definir
    got_number, // ** espera alguns milisegundos para iniciar a animacao
    animation, // ** just 1 frame 
    finished,

}