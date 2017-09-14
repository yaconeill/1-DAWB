/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cambiomoneda;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author yaconeill
 */
public class BancoTest {
    Banco caja1, caja2;
    float [] EntradaBase = {50F,100F,150F,200F,400F};
    float [] EntradaEuro = {50F,100F,150F,200F,400F,300F,100F,250F,50F,250F};
    //---------------------------------------------------
    float [] SalidaEuro2 = {2250F,2350F,2500F,2700F,3100F,3400F,3500F,3750F,3800F,4050F};
    //---------------------------------------------------
    float [] SalidaEuro = {500F,700F,1000F,1400F,2200F};
    float [] SalidaLibra = {225F,275F,350F,450F,650F};
    
    public BancoTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
        caja1 = new Banco(100, "EURO");
        caja2 = new Banco(100, "LIBRA");
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of cambio method, of class Banco.
     */
    @Test
    public void testCambio() {
        System.out.println("cambio");
        float EL_ = 0.5F;   
        caja1.cambio(EL_);        
        caja2.cambio(EL_);
    }

    /**
     * Test of Suma method, of class Banco.
     */
    @Test
    public void testSuma() {
        System.out.println("Suma");
        float canti = 0.0F;
        String mon = "";
        Banco instance = null;
        instance.Suma(canti, mon);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of visualiza method, of class Banco.
     */
    @Test
    public void testVisualiza() {
        System.out.println("visualiza");
        Banco instance = null;
        instance.visualiza();
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of Dinero method, of class Banco.
     */
    @Test
    public void testDinero() {
        System.out.println("Dinero");
        Banco instance = null;
        float expResult = 0.0F;
        float result = instance.Dinero();
        assertEquals(expResult, result, 0.0);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }
    
}
