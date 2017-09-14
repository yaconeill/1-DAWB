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
public class Cambiomoneda {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Banco caja1 = new Banco(100, "EURO");
        Banco caja2 = new Banco(100, "LIBRA");
        caja1.cambio(((float)0.5));
        caja1.visualiza();
        caja1.Suma(50, "LIBRA");
        caja1.visualiza();
        caja2.cambio(((float)0.5));
        caja2.visualiza();
        caja2.Suma(50, "EURO");
        caja2.visualiza();
    }
    
}
