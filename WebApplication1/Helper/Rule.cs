﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Helper
{
    public class Rule
    {
        public int[,] myTable;
        private int[,] scores = new int[15, 15];

        public bool Referee( int posY,int posX, int player)
        {
            int[,] direct = new int[4, 2] { { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 } };  //YX
            for (int I = 0; I < 4; I++)
            {
                for (int J = -4; J <= 0; J++)
                {
                    int sum = 0;
                    for (int K = 0; K < 5; K++)
                    {
                        if ((posX + J * direct[I,0] + K * direct[I,0] >= 0) && (posX + J * direct[I,0] + K * direct[I,0] < 15) && (posY + J * direct[I,1] + K * direct[I,1] >= 0) && (posY + J * direct[I,1] + K * direct[I,1] < 15))
                        {
                            sum += myTable[(posY + J * direct[I, 1] + K * direct[I, 1]),(posX + J * direct[I,0] + K * direct[I,0])];
                        }
                    }
                    if (sum == player * 5)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void ResetGame()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    myTable[i,j] = 0;
                }
            }
        }
    }
}