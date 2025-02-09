﻿using System;
namespace BowlingBall
{
    public class Game
    {
       public  int[] roll = new int[21];
        public int[] frames = new int[10];
        public int presentframeIndex=0;
        public int finalscore=0;

        public void RollSinglePin(int pins)
        {
            roll[presentframeIndex]=pins;
            presentframeIndex++;
        }
        public void RollMultiplePin(int []pins)
        {
            for(int i=0;i<pins.Length;i++)
            {
                roll[presentframeIndex]=pins[i];
                presentframeIndex++;
            }
        }
        public bool Strike(int presentframeIndex)
        {
            if(roll[presentframeIndex]==10)
            return true;
            else
            return false;
        }
        public bool Spare(int pins)
        {
                if(roll[pins]+roll[pins+1]==10)
                return true;
                else
                return false;
        }
        public int GetScore()
        {
            
            int index=0;
            for(int frame_index=0;frame_index<10;frame_index++)
            {
                if(Spare(index))
                {
                    finalscore+=10+roll[index+2];
                    index+=2;
                }
                else if(Strike(index))
                {
                     finalscore+=10+roll[index+1]+roll[index+2];
                    index++;
                }
                else
                {
                     finalscore+=roll[index]+roll[index+1];
                    index+=2;
                }
            }
            return finalscore;
        
        }

    }
}

