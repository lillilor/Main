/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package minefield;

import java.awt.Dimension;
import java.awt.Image;
import java.io.IOException;
import java.util.Random;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.imageio.ImageIO;
import javax.swing.ImageIcon;

/**
 *
 * @author lilli
 */
public class Tile extends javax.swing.JToggleButton
{
    int     i;
    int     j;
    int     state;
    boolean pressed;
    boolean bomb;
    
    public int getI()
    {
        return i;
    }
    
    public int getState()
    {
        return this.state;
    }
    
    public void setState(int _val)
    {
        this.state = _val;
    }
    
    public int getJ()
    {
        return j;
    }
    
    public boolean getPressed()
    {
        return pressed;
    }
    
    public boolean isBomb()
    {
        return bomb;
    }
    
    public void setPressed(boolean _pressed, int _mines)
    {
        pressed = _pressed;

        this.setImage(_mines);
    }

    public boolean canBePressed()
    {
        return (this.getPressed() == false);
    }
    
    public Tile(int _width, int _height, int _i, int _j, int _columns, int _rows, int _bombPercent)
    { 
        super();
        
        int     randomNum;
        double  val;

        i       = _i;
        j       = _j;
        state   = 0;
        pressed = false;
        
        randomNum = new Random().nextInt((_columns * _rows));
        val = (double) ((double)randomNum / (double)(_columns * _rows));

        //_bombPercent % of the tile is safe
        bomb    = ( (val * 100) > (100 - _bombPercent));  
    }
    
    public void initImage()
    {
        try
        {
            Image img = ImageIO.read(getClass().getResource("/resources/tile.png"));
            this.setIcon(new ImageIcon(img));
        }
        catch (IOException ex)
        {
            System.out.println(ex);
        }
    }
    
    public void setBombImage()
    {
        try
        {
            Image img = ImageIO.read(getClass().getResource("/resources/tileBomb.png"));
            this.setIcon(new ImageIcon(img));
        } catch (IOException ex)
        {
            Logger.getLogger(Tile.class.getName()).log(Level.SEVERE, null, ex);
        }      
    }
    
    public void setMarkTile()
    {
        String iconsPath;
        
        switch(this.state)
        {
            case 0:
                iconsPath = "/resources/tile.png";
                
                break;
            
            case 1:
                iconsPath = "/resources/markedTile.png";
                break;
            
            case 2:
                iconsPath = "/resources/flaggedTile.png";
                break;
                
            default:
              iconsPath = "/resources/tile.png";  
        }
        try
        {
           Image img = ImageIO.read(getClass().getResource(iconsPath));
           this.setIcon(new ImageIcon(img)); 
        } catch (IOException ex)
        {
            Logger.getLogger(Tile.class.getName()).log(Level.SEVERE, null, ex);
        }      
    }
    
    public void setImage(int _mines)
    {
        String iconsPath;
        
        try
        {
            if(this.isBomb())
            {
                iconsPath = "/resources/tileBomb.png";
            }
            else
            {
                if(this.getPressed())
                {

                    if(_mines > 0)
                    {
                        iconsPath = "/resources/"+String.format("%d",_mines)+".png";
                    }
                    else
                    {
                        iconsPath = "/resources/pressedTile.png";
                    }  
                }
                else
                {
                    iconsPath = "/resources/tile.png";  
                }
            }
            
            Image img = ImageIO.read(getClass().getResource(iconsPath));
            this.setIcon(new ImageIcon(img));
        } 
        catch (IOException ex)
        {
            System.out.println(ex);
        }
    }

    public static Tile construct(int _width, int _height, int _i, int _j, int _columns, int _rows, int _bombPercent)
    {
        String tileName = String.format("Tile_%d_%d",_j , _i);
        Tile theTile = new Tile(_width, _height, _i, _j,_columns,_rows, _bombPercent);
        theTile.setSize(_width, _height);
        theTile.setName(tileName);
        theTile.setLocation((_i*_width) - (4*_i), (_j*_height)-(4*_j));
        theTile.setMinimumSize(new Dimension(_width,_height));
        theTile.initImage();

        return theTile;
    }
}
