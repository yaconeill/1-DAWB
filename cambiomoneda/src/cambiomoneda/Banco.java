/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cambiomoneda;

/**
 *
 * @author yaconeill
 */
public class Banco {
    // monedas:  EURO  y  LIBRA
    private float dinero;
    private String moneda;
    private float EL, LE;    
    
    public Banco(float canti, String mon)
    {
        dinero = canti;
        moneda = mon;
    }    
    
    public void cambio(float EL_)
    {
        float valor = 1;
        EL = EL_;
        LE = valor / EL_;
    }   
    
    public void Suma(float canti, String mon)
    {
        if(moneda.equals(mon))
        {
            dinero = dinero + canti;
        }
        else if(moneda.equals("EURO"))
        {
            dinero = dinero + LE * canti;
        }
        else
        {
            dinero = dinero + EL * canti;
        }
        visualiza();
    }   
    
    public void visualiza()
    {
        System.out.printf(" Dinero:  %f,  Moneda:  %s \n",
                                               dinero, moneda);
    }   
    
    public float Dinero()
    {
        return(dinero);
    }
}
