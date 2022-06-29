using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixClass;

namespace AdjustValue
{
    internal class AdjustValue
    {
        public static void CalAdjustValue(DataGridView myDGV,RichTextBox known, RichTextBox model, RichTextBox outdata)
        {
            int rowsNum=myDGV.Rows.Count-1;                         // 观测值数量
            string[] StartEndPoint=new string[rowsNum*2];        // 观测路线起止点
            double[,] L=new double[rowsNum,1];                        // 观测值矩阵
            double[,] l=new double[rowsNum,1];                         // 常数项矩阵
            double[,] d = new double[rowsNum,1];                      // 误差方程常数
            double[,] V = new double[rowsNum, 1];                     // 改正数矩阵
            double[,] P = new double[rowsNum, rowsNum];         // 权值矩阵

            for (int i = 0; i < rowsNum; i++)
            {
                for (int j = 0; j < rowsNum; j++)
                {
                    P[i, j] = 0;
                }
            }

            // 定义已知点信息
            string[] TurePoint = new string[rowsNum];                  // 已知点点号
            string[] TempPoint = new string[rowsNum];                // 临时文件
            double[] TureValue = new double[rowsNum];              // 已知点高程
            int TureNum = 0;                                                          // 已知点数量

            // 读取L、P和已知点信息 
            for (int i=0; i<rowsNum; i++)
            {
                // 存放路线的起止点，起点在前rowsNum个，终点在后rowsNum个
                StartEndPoint[i]= Convert.ToString(myDGV.Rows[i].Cells[1].Value);
                StartEndPoint[i+rowsNum] = Convert.ToString(myDGV.Rows[i].Cells[2].Value);

                L[i,0]=Convert.ToDouble(myDGV.Rows[i].Cells[3].Value);
                P[i,i]= 1/Convert.ToDouble(myDGV.Rows[i].Cells[4].Value);
                // 获取已知点信息
                if (Convert.ToString(myDGV.Rows[i].Cells[5].Value) != "")
                {
                    string[] strings = Convert.ToString(myDGV.Rows[i].Cells[5].Value).Split('=');
                    TurePoint[TureNum] = strings[0];
                    TempPoint[TureNum] = strings[0];
                    TureValue[TureNum] = Convert.ToDouble(strings[1]);
                    TureNum++;
                }
            }

            // 获取线路上所有点号
            string[] AllPoints=StartEndPoint.Distinct().ToArray();
            int AllPointsNum = AllPoints.Length;
            int t = AllPointsNum - TureNum;                         // 必要观测数t

            // 定义参数近似值矩阵
            double[,] X = new double[t, 1];
            string[] XPoint = new string[t];
            double[,] XValue = new double[t, 1];                          // 法方程解
            int XNum = 0;
            for (int i = 0; i < AllPoints.Length; i++)
            {
                if (!TurePoint.Contains(AllPoints[i]))
                {
                    XPoint[XNum] = AllPoints[i];
                    XNum++;
                }
            }
            // 构建参数近似值矩阵
            int k = 0;              // 用于判断是否计算所有未知参数
            for (int i = 0; i < rowsNum; i++)
            {
                // （通过查找TurePoints矩阵）判断路线起止点是否已知高程值
                int IdStartInTure = Array.IndexOf(TurePoint, StartEndPoint[i]);
                int IdEndInTure = Array.IndexOf(TurePoint, StartEndPoint[i + rowsNum]);
                if (IdStartInTure == -1 && IdEndInTure == -1)
                {
                    continue;       // 均未知 ，则跳过
                }
                else if (IdStartInTure != -1 && IdEndInTure == -1)
                {// 若起点已知，计算终点高程近似值，并将终点纳入TurePoints矩阵
                    int IDInX = Array.IndexOf(XPoint, StartEndPoint[i + rowsNum]);
                    X[IDInX, 0] = TureValue[IdStartInTure] + L[i, 0];
                    TurePoint[IDInX + TureNum] = StartEndPoint[i + rowsNum];
                    TureValue[IDInX + TureNum] = TureValue[IdStartInTure] + L[i, 0];
                    k++;
                }
                else if (IdStartInTure == -1 && IdEndInTure != -1)
                {// 若终点已知，计算起点高程近似值，并将起点纳入TurePoints矩阵
                    int IDInX = Array.IndexOf(XPoint, StartEndPoint[i]);
                    X[IDInX, 0] = TureValue[IdEndInTure] - L[i, 0];
                    TurePoint[IDInX + TureNum] = StartEndPoint[i];
                    TureValue[IDInX + TureNum] = TureValue[IdEndInTure] - L[i, 0];
                    k++;
                }
                if (k >= XNum) break;  // 当未知点均被计算时，结束循环
            }

            // 定义B矩阵及转置、BY*P
            double[,] B = new double[rowsNum, t];
            double[,] BT = new double[t, rowsNum];
            double[,] BTP = new double[t, rowsNum];
            // 构建B矩阵
            for(int i = 0; i < rowsNum; i++)
            {
                for(int j=0; j < XNum; j++)
                {
                    if (StartEndPoint[i] == XPoint[j])
                        B[i, j] = -1;
                    if (StartEndPoint[i+rowsNum] == XPoint[j])
                        B[i, j] = 1;
                    if (StartEndPoint[i] != XPoint[j] &&
                        StartEndPoint[i + rowsNum] != XPoint[j])
                        B[i, j] = 0;
                }
            }

            // 构建d矩阵
            for (int i = 0; i < rowsNum; i++)
            {//（通过查找已知点矩阵）计算误差方程d矩阵
                int IdStartInTure = Array.IndexOf(TempPoint, StartEndPoint[i]);
                int IdEndInTure = Array.IndexOf(TempPoint, StartEndPoint[i + rowsNum]);
                if (IdStartInTure == -1 && IdEndInTure == -1)
                    d[i, 0] = 0;
                else if (IdStartInTure != -1 && IdEndInTure == -1)
                    d[i,0]= -TureValue[IdStartInTure];
                else if (IdStartInTure == -1 && IdEndInTure != -1)
                    d[i, 0] = TureValue[IdEndInTure];
            }

            // 解法方程
            Matrix B0;                                                          // 定义矩阵运算变量
            B0 = new Matrix(B);
            B0.MatrixInver(B, ref BT);                                  // B转置
            B0.MatrixMultiply(BT, P, ref BTP);                      // BT*P
            double[,] Nbb = new double[t, t];                      // N=BT*P*B
            B0.MatrixMultiply(BTP, B, ref Nbb);
            double[,] invNbb = new double[t, t];                 // N_-1
            invNbb = B0.MatrixOpp(Nbb);
            // 计算常数项l矩阵 l=L-B*X-d
            double[,] BX0 = new double[rowsNum, 1];
            B0.MatrixMultiply(B, X, ref BX0);
            for(int i = 0; i < rowsNum; i++)
            {
                l[i, 0] = L[i, 0] - BX0[i, 0] - d[i,0];
            }
            double[,] U = new double[t, 1];                         // U=BT*P*l
            B0.MatrixMultiply(BTP, l, ref U);
            B0.MatrixMultiply(invNbb, U, ref XValue);          // 法方程的解：N-1*U

            // 解改正数与精度评价
            double sigma = 0;                                             // 单位权中误差
            double[,] Bx = new double[rowsNum, 1];
            B0.MatrixMultiply(B, XValue, ref Bx);
            for (int i = 0; i < rowsNum; i++)
            {
                V[i, 0] = Bx[i, 0] - l[i, 0];
                sigma = sigma + V[i, 0] * P[i, i] * V[i, 0];
            }
            sigma = sigma / (rowsNum - t);          // ！！！！！单位权中误差有问题可能

            // 解参数平差值
            double[,] X_adjust = new double[t, 1];                          // 法方程解
            B0.MatrixAdd(X, XValue, ref X_adjust);
            // 解观测值平差值
            double[,] L_adjust = new double[rowsNum, 1];                          // 法方程解
            B0.MatrixAdd(V, L, ref L_adjust);

            printKnow(known, TempPoint, TureValue, X, XPoint, rowsNum, t,TureNum);
            printModel(model, B, P, l, rowsNum, t);
            printOut(outdata, XValue, V, X_adjust, L_adjust, rowsNum, t, sigma);
        }

        public static void printKnow(RichTextBox known, string[] TempPoint, double[] TureValue, double[,] X, string[] XPoint,int n,int t,int TureNum)
        {
            known.Text = "";
            known.Text = "观测值数量="+n.ToString()+"\n";
            known.Text += "必要观测数=" + t.ToString() + "\n";
            known.Text += "\n";
            known.Text += "已知点数量=" + TureNum.ToString() + "\n"+ "已知点高程值(m)：\n";
            for(int i = 0; i < TureNum; i++)
                known.Text += TempPoint[i]+ ":" + TureValue[i].ToString() + "\n";
            known.Text += "\n";
            known.Text += "未知点数量=" + XPoint.Length.ToString() + "\n" + "未知点近似值(m)：\n";
            for (int i = 0; i < XPoint.Length; i++) 
                known.Text += XPoint[i] + ":" + X[i,0].ToString() + "\n";
        }
        public static void printModel(RichTextBox model, double[,] B, double[,] P, double[,] l,int n,int t)
        {
            model.Text = "";
            model.Text = "B矩阵：\n";
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<t; j++)
                {
                    model.Text += Math.Round(B[i,j],2).ToString() + " ";
                }
                model.Text += "\n";
            }
            model.Text += "\nP矩阵：\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    model.Text += Math.Round(P[i, j],2).ToString() + " ";
                }
                model.Text += "\n";
            }
            model.Text += "\nl矩阵：\n";
            for (int i = 0; i < n; i++)
                    model.Text += l[i, 0].ToString() + "\n";
        }
        public static void printOut(RichTextBox outData, double[,] XValue, double[,] V, 
            double[,] X_adjust, double[,] L_adjust, int n, int t,double sigma)
        {
            outData.Text = "";
            outData.Text = "法方程解(mm)：\n";
            for( int i = 0; i < t; i++)
                outData.Text += (XValue[i, 0]*1000).ToString() + "\n";
            outData.Text += "\n改正数(mm)：\n";
            for(int i = 0; i < n; i++)
                outData.Text += (V[i, 0] * 1000).ToString() + "\n";
            outData.Text += "\n参数平差值(m)：\n";
            for(int j = 0; j < t; j++)
                outData.Text +=X_adjust[j, 0].ToString() + "\n";
            outData.Text += "\n观测值平差值(m)：\n";
            for (int j = 0; j < n; j++)
                outData.Text += L_adjust[j, 0] .ToString() + "\n";
            outData.Text += "\n单位权中误差(mm)=" + (sigma*1000).ToString()+ "\n（单位权中误差有问题可能）";
        }
    }
}
