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
        /// <summary>
        /// 平差计算函数
        /// </summary>
        /// <param name="myDGV 存放数据的表格"></param>
        /// <param name="known 存放已知信息的文本框"></param>
        /// <param name="model 存放模型参数的文本框"></param>
        /// <param name="outdata 存放平差结果的文本框"></param>
        public static void CalAdjustValue(DataGridView myDGV,RichTextBox known, RichTextBox model, RichTextBox outdata)
        {
            int rowsNum=myDGV.Rows.Count-1;                         // 观测值数量
            string[] StartEndPoint=new string[rowsNum*2];        // 观测路线起止点
            double[,] L=new double[rowsNum,1];                        // 观测值矩阵
            double[,] l=new double[rowsNum,1];                         // 常数项矩阵
            double[,] d = new double[rowsNum,1];                      // 误差方程常数
            double[,] V = new double[rowsNum, 1];                     // 改正数矩阵
            double[,] P = new double[rowsNum, rowsNum];         // 权值矩阵

            /**********初始化信息**********/
            // 定义已知点信息矩阵
            string[] TurePoint = new string[rowsNum];                  // 已知点点号
            string[] TempPoint = new string[rowsNum];                // 临时文件
            double[] TureValue = new double[rowsNum];              // 已知点高程
            int TureNum = 0;                                                          // 已知点数量
            // 初始化L、P、已知点矩阵
            calP_L(rowsNum, ref StartEndPoint, myDGV, ref P, ref L, ref TurePoint, ref TempPoint, ref TureValue, ref TureNum);

            // 获取线路上所有点号
            string[] AllPoints = StartEndPoint.Distinct().ToArray(); // 获取所有点（从起止点中剔除重复点）
            int AllPointsNum = AllPoints.Length;                          // 所有点数量
            int t = AllPointsNum - TureNum;                                 // 必要观测数t

            // 初始化未知点
            double[,] X = new double[t, 1];                                  // 未知数近似值
            string[] XPoint = new string[t];                                   // 未知点点号
            int XNum = 0;                                                              // 未知点数量
            for (int i = 0; i < AllPoints.Length; i++)
            { // 将所有点中不在已知点矩阵中的放入未知点矩阵
                if (!TurePoint.Contains(AllPoints[i]))
                {
                    XPoint[XNum] = AllPoints[i];
                    XNum++;
                }
            }

            /**********构建参数近似值矩阵**********/
            calX(rowsNum, ref TurePoint, ref TureValue, TureNum, StartEndPoint,ref X, XPoint, XNum, L);

            /**********构建B矩阵**********/
            // 定义B矩阵
            double[,] B = new double[rowsNum, t];
            // 构建B矩阵
            calB(rowsNum, XNum, XPoint, StartEndPoint, ref B);

            /**********构建d矩阵**********/
            calD(rowsNum, TempPoint, StartEndPoint, TureValue, ref d);

            /**********解法方程**********/
            double sigma = 0;                                             // 单位权中误差
            double[,] XValue = new double[t, 1];                 // 法方程解矩阵
            double[,] X_adjust = new double[t, 1];                          // 法方程解
            double[,] L_adjust = new double[rowsNum, 1];                          // 法方程解
            calMatrix(B, rowsNum, t, P, X, d, L, ref l, ref V, ref sigma, ref XValue, ref X_adjust, ref L_adjust);

            // 输出结果
            printKnow(known, TempPoint, TureValue, X, XPoint, rowsNum, t,TureNum);
            printModel(model, B, P, l, rowsNum, t);
            printOut(outdata, XValue, V, X_adjust, L_adjust, rowsNum, t, sigma);
        }

        /// <summary>
        /// 初始化L、P矩阵和已知点信息
        /// </summary>
        /// <param name="rowsNum"></param>
        /// <param name="StartEndPoint"></param>
        /// <param name="myDGV"></param>
        /// <param name="P"></param>
        /// <param name="L"></param>
        /// <param name="TurePoint"></param>
        /// <param name="TempPoint"></param>
        /// <param name="TureValue"></param>
        /// <param name="TureNum"></param>
        public static void calP_L(int rowsNum,ref string[] StartEndPoint, DataGridView myDGV,ref double[,] P,ref double[,] L,
            ref string[] TurePoint,ref string[] TempPoint, ref double[] TureValue,ref int TureNum)
        {
            // 初始化P矩阵
            for (int i = 0; i < rowsNum; i++)
            {
                for (int j = 0; j < rowsNum; j++)
                {
                    P[i, j] = 0;
                }
            }
            // 读取L、P和已知点信息 
            for (int i = 0; i < rowsNum; i++)
            {
                // 存放路线的起止点，起点在前rowsNum个，终点在后rowsNum个
                StartEndPoint[i] = Convert.ToString(myDGV.Rows[i].Cells[1].Value);
                StartEndPoint[i + rowsNum] = Convert.ToString(myDGV.Rows[i].Cells[2].Value);

                L[i, 0] = Convert.ToDouble(myDGV.Rows[i].Cells[3].Value);
                P[i, i] = 1 / Convert.ToDouble(myDGV.Rows[i].Cells[4].Value);
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

        }
        /// <summary>
        /// 计算参数近似值矩阵
        /// </summary>
        /// <param name="rowsNum"></param>
        /// <param name="TurePoint"></param>
        /// <param name="TureValue"></param>
        /// <param name="TureNum"></param>
        /// <param name="StartEndPoint"></param>
        /// <param name="X"></param>
        /// <param name="XPoint"></param>
        /// <param name="XNum"></param>
        /// <param name="L"></param>
        public static void calX(int rowsNum, ref string[] TurePoint, ref double[] TureValue,int TureNum,string[] StartEndPoint,
            ref double[,] X, string[] XPoint,int XNum, double[,] L)
        {
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
        }
        /// <summary>
        /// 计算B矩阵
        /// </summary>
        /// <param name="rowsNum"></param>
        /// <param name="XNum"></param>
        /// <param name="XPoint"></param>
        /// <param name="StartEndPoint"></param>
        /// <param name="B"></param>
        public static void calB(int rowsNum, int XNum, string[] XPoint, string[] StartEndPoint, ref double[,] B)
        {
            for (int i = 0; i < rowsNum; i++)
            {
                for (int j = 0; j < XNum; j++)
                {
                    if (StartEndPoint[i] == XPoint[j])
                        B[i, j] = -1;
                    if (StartEndPoint[i + rowsNum] == XPoint[j])
                        B[i, j] = 1;
                    if (StartEndPoint[i] != XPoint[j] &&
                        StartEndPoint[i + rowsNum] != XPoint[j])
                        B[i, j] = 0;
                }
            }
        }
        /// <summary>
        /// 计算d矩阵
        /// </summary>
        /// <param name="rowsNum"></param>
        /// <param name="TempPoint"></param>
        /// <param name="StartEndPoint"></param>
        /// <param name="TureValue"></param>
        /// <param name="d"></param>
        public static void calD(int rowsNum, string[] TempPoint, string[] StartEndPoint, double[] TureValue,ref double[,] d)
        {
            for (int i = 0; i < rowsNum; i++)
            {//（通过查找已知点矩阵）计算误差方程d矩阵
                int IdStartInTure = Array.IndexOf(TempPoint, StartEndPoint[i]);
                int IdEndInTure = Array.IndexOf(TempPoint, StartEndPoint[i + rowsNum]);
                if (IdStartInTure == -1 && IdEndInTure == -1)
                    d[i, 0] = 0;
                else if (IdStartInTure != -1 && IdEndInTure == -1)
                    d[i, 0] = -TureValue[IdStartInTure];
                else if (IdStartInTure == -1 && IdEndInTure != -1)
                    d[i, 0] = TureValue[IdEndInTure];
            }
        }
        /// <summary>
        /// 矩阵运算
        /// </summary>
        /// <param name="B"></param>
        /// <param name="rowsNum"></param>
        /// <param name="t"></param>
        /// <param name="P"></param>
        /// <param name="X"></param>
        /// <param name="d"></param>
        /// <param name="L"></param>
        /// <param name="l"></param>
        /// <param name="V"></param>
        /// <param name="sigma"></param>
        /// <param name="XValue"></param>
        /// <param name="X_adjust"></param>
        /// <param name="L_adjust"></param>
        public static void calMatrix(double[,] B, int rowsNum,int t, double[,] P, double[,] X, double[,] d, double[,] L, ref double[,] l,
            ref double[,] V,ref double sigma,ref double[,] XValue,ref double[,] X_adjust, ref double[,] L_adjust)
        {
            Matrix B0;                                                           // 定义矩阵运算变量
            double[,] BT = new double[t, rowsNum];           // BT
            double[,] BTP = new double[t, rowsNum];         // BT*P
            double[,] Nbb = new double[t, t];                      // N=BT*P*B
            double[,] invNbb = new double[t, t];                 // N_-1

            // 解法方程
            B0 = new Matrix(B);
            B0.MatrixInver(B, ref BT);                                  // B转置
            B0.MatrixMultiply(BT, P, ref BTP);                      // BT*P
            B0.MatrixMultiply(BTP, B, ref Nbb);
            invNbb = B0.MatrixOpp(Nbb);

            // 计算常数项l矩阵 l=L-B*X-d
            double[,] BX0 = new double[rowsNum, 1];
            double[,] U = new double[t, 1];                         // U=BT*P*l

            B0.MatrixMultiply(B, X, ref BX0);
            for (int i = 0; i < rowsNum; i++)
            {
                l[i, 0] = L[i, 0] - BX0[i, 0] - d[i, 0];
            } 
            B0.MatrixMultiply(BTP, l, ref U);
            B0.MatrixMultiply(invNbb, U, ref XValue);          // 法方程的解：N-1*U

            // 解改正数与精度评价
            double[,] Bx = new double[rowsNum, 1];
            B0.MatrixMultiply(B, XValue, ref Bx);
            for (int i = 0; i < rowsNum; i++)
            {
                V[i, 0] = Bx[i, 0] - l[i, 0];
                sigma = sigma + V[i, 0] * P[i, i] * V[i, 0];
            }
            sigma = sigma / (rowsNum - t);
            sigma = Math.Round(Math.Sqrt(sigma), 6);

            // 解参数平差值
            B0.MatrixAdd(X, XValue, ref X_adjust);
            // 解观测值平差值
            B0.MatrixAdd(V, L, ref L_adjust);
        }



        /// <summary>
        /// 输出已知信息
        /// </summary>
        /// <param name="known 输出结果的文本框"></param>
        /// <param name="TempPoint 已知点点号"></param>
        /// <param name="TureValue 已知点高程"></param>
        /// <param name="X 未知点近似值"></param>
        /// <param name="XPoint 未知点点号"></param>
        /// <param name="n 观测值数量"></param>
        /// <param name="t 必要观测数"></param>
        /// <param name="TureNum 已知点数量"></param>
        public static void printKnow(RichTextBox known, string[] TempPoint, double[] TureValue, double[,] X, string[] XPoint,int n,int t,int TureNum)
        {
            known.Text = "";
            known.Text = "观测值数量="+n.ToString()+"\n";
            known.Text += "必要观测数=" + t.ToString() + "\n";
            known.Text += "\n";

            known.Text += "已知点数量=" + TureNum.ToString() + "\n"+ "已知点高程值(m)：\n";
            for(int i = 0; i < TureNum; i++)
                known.Text += TempPoint[i]+ ":" + Math.Round(TureValue[i],6).ToString() + "\n";
            known.Text += "\n";

            known.Text += "未知点数量=" + XPoint.Length.ToString() + "\n" + "未知点近似值(m)：\n";
            for (int i = 0; i < XPoint.Length; i++) 
                known.Text += XPoint[i] + ":" + Math.Round(X[i,0], 6).ToString() + "\n";
        }

        /// <summary>
        /// 输出模型参数
        /// </summary>
        /// <param name="model 存放输出的文本框"></param>
        /// <param name="B B矩阵"></param>
        /// <param name="P P矩阵"></param>
        /// <param name="l l矩阵 l=L-B*X-d"></param>
        /// <param name="n 观测值数量"></param>
        /// <param name="t 必要观测数"></param>
        public static void printModel(RichTextBox model, double[,] B, double[,] P, double[,] l,int n,int t)
        {
            model.Text = "";
            model.Text = "B矩阵：\n";
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<t; j++)
                {
                    model.Text += Math.Round(B[i,j],6).ToString() + " ";
                }
                model.Text += "\n";
            }

            model.Text += "\nP矩阵：\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    model.Text += Math.Round(P[i, j],6).ToString() + " ";
                }
                model.Text += "\n";
            }

            model.Text += "\nl矩阵：\n";
            for (int i = 0; i < n; i++)
                    model.Text += Math.Round(l[i, 0],6).ToString() + "\n";
        }

        /// <summary>
        /// 输出平差结果
        /// </summary>
        /// <param name="outData 存放输出的文本框"></param>
        /// <param name="XValue 法方程解"></param>
        /// <param name="V 观测值改正数"></param>
        /// <param name="X_adjust 参数平差值"></param>
        /// <param name="L_adjust 观测值平差值"></param>
        /// <param name="n 观测值数量"></param>
        /// <param name="t 必要观测数"></param>
        /// <param name="sigma 单位权中误差"></param>
        public static void printOut(RichTextBox outData, double[,] XValue, double[,] V, 
            double[,] X_adjust, double[,] L_adjust, int n, int t,double sigma)
        {
            outData.Text = "";
            outData.Text = "法方程解(mm)：\n";
            for( int i = 0; i < t; i++)
                outData.Text += Math.Round((XValue[i, 0]*1000),6).ToString() + "\n";
            outData.Text += "\n改正数(mm)：\n";
            for(int i = 0; i < n; i++)
                outData.Text += Math.Round((V[i, 0] * 1000),6).ToString() + "\n";
            outData.Text += "\n参数平差值(m)：\n";
            for(int j = 0; j < t; j++)
                outData.Text += Math.Round(X_adjust[j, 0],6).ToString() + "\n";
            outData.Text += "\n观测值平差值(m)：\n";
            for (int j = 0; j < n; j++)
                outData.Text += Math.Round(L_adjust[j, 0],6) .ToString() + "\n";
            outData.Text += "\n单位权中误差(mm)=" + Math.Round((sigma*1000),6).ToString()+ "\n";
        }
    }
}
