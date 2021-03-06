using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatrixClass;

namespace AdjustValue
{
    internal class ParamFour
    {
        /// <summary>
        /// 最小二乘法计算四参数
        /// </summary>
        /// <param name="OldPoints 旧坐标"></param>
        /// <param name="Newpoints 新坐标"></param>
        /// <param name="PointCount 转换点的个数"></param>
        /// <param name="rota 旋转参数"></param>
        /// <param name="scale 比例因子"></param>
        /// <param name="dx x的平移量"></param>
        /// <param name="dy y的平移量"></param>
        public static void Param4(DataGridView myDGV, Point2D[] OldPoints, Point2D[] Newpoints,int n,
            ref double[,] param,ref double rota, ref double scale, ref double dx, ref double dy, ref double p)
        {
            int pointCount = n;

            // 定义矩阵运算变量
            Matrix B;                                                                   // 矩阵运算
            double[,] B0 = new double[2 * pointCount, 4];        // 系数矩阵 B
            double[,] L0 = new double[2 * pointCount, 1];         // 坐标差 常数项 L
            double[,] BT = new double[4, 2 * pointCount];        // B的转置
            double[,] N = new double[4, 4];                               // BT*P*B=N
            double[,] Ninv = new double[4, 4];                          // N的逆矩阵
            double[,] BTL = new double[4, 1];                           // BT*P*L
            
            // 初始化变量
            for (int i = 0; i < pointCount; i++)
            {
                B0[2 * i, 0] = 1;
                B0[2 * i, 1] = 0;
                B0[2 * i, 2] = OldPoints[i].X;
                B0[2 * i, 3] = -OldPoints[i].Y;

                B0[2 * i + 1, 0] = 0;
                B0[2 * i + 1, 1] = 1;
                B0[2 * i + 1, 2] = OldPoints[i].Y;
                B0[2 * i + 1, 3] = OldPoints[i].X;
            }
            for(int j = 0; j < pointCount; j++)
            {
                L0[2 * j, 0] = Newpoints[j].X - OldPoints[j].X;
                L0[2 * j+1, 0] = Newpoints[j].Y - OldPoints[j].Y;
            }

            // 矩阵运算
            B = new Matrix(B0);
            B.MatrixInver(B0, ref BT);                                  // 转置
            B.MatrixMultiply(BT, B0, ref N);                        // 矩阵乘法
            Ninv = B.MatrixOpp(N);                                    // 矩阵求逆
            B.MatrixMultiply(BT, L0, ref BTL);
            B.MatrixMultiply(Ninv, BTL, ref param);

            double u = 1.0,v=0;
            dx = param[0, 0];
            dy = param[1, 0];
            u = u + param[2, 0];         // param[3,0] = scale * cos(rote) -1
            v = v + param[3, 0];         // param[4,0] = scale * sin(rote)

            // 整理四参数，保留六位小数
            rota = Math.Atan(v / u);
            scale = u / Math.Cos(rota);
            dx = Math.Round(dx, 6);
            dy = Math.Round(dy, 6);
            rota = Math.Round(rota / Math.PI * 180, 6);
            scale = Math.Round(scale, 6);

            calAcc(myDGV,OldPoints, Newpoints, n, param, ref p);
        }


        /// <summary>
        /// 平面点位中误差计算
        /// </summary>
        /// <param name="OldPoints 旧坐标"></param>
        /// <param name="Newpoints 新坐标"></param>
        /// <param name="n 计算点的数量"></param>
        /// <param name="param 计算参数"></param>
        /// <param name="p 平面点位中误差"></param>
        public static void calAcc(DataGridView myDGV ,Point2D[] OldPoints, Point2D[] Newpoints, int n, double[,] param,ref double p)
        {
            int pointCount = n;

            // 定义矩阵运算变量
            Matrix B;                                                                    // 矩阵运算
            double u = 1.0, v = 0,dx,dy;
            dx = param[0, 0];
            dy = param[1, 0];
            u = u + param[2, 0];         // param[3,0] = scale * cos(rote) -1
            v = v + param[3, 0];         // param[4,0] = scale * sin(rote)

            double tempx, tempy;
            
            p=0;
            for(int i = 0; i < pointCount; i++)
            {// 残差计算
                tempx = Newpoints[i].X-(OldPoints[i].X * u - v * OldPoints[i].Y+dx);
                tempy = Newpoints[i].Y-(OldPoints[i].X * v + u * OldPoints[i].Y + dy);
                p+=tempx*tempx + tempy*tempy;
            }
            // 平面点位中误差
            p =Math.Sqrt (p / (n - 1))*1000;
            p = Math.Round(p, 6);       // 保留6位小数
            //if (i >= n)
            //{
            //    //myDGV[3, i].Value = Convert.ToString(OldPoints[i].X * u - v * OldPoints[i].Y + dx);
            //    //myDGV[4, i].Value = Convert.ToString(OldPoints[i].X * v + u * OldPoints[i].Y + dy);
            //    myDGV.Rows[i].Cells[3].Value = OldPoints[i].X * u - v * OldPoints[i].Y + dx;
            //    myDGV.Rows[i].Cells[4].Value = OldPoints[i].X * v + u * OldPoints[i].Y + dy;
            //}
        }

        public static void calCoord(DataGridView myDGV, double[,] param)
        {
            int n = myDGV.Rows.Count - 1;         // 点的数量
            int newPointNum = 0;                    // 重合点数量
            for (int i = 0; i < n; i++)                 // 初始化
            {
                if (Convert.ToString(myDGV.Rows[i].Cells[3].Value) != "")
                {
                    newPointNum++;
                }
            }
            double tempx, tempy;
            double u = 1.0, v = 0, dx, dy;
            dx = param[0, 0];
            dy = param[1, 0];
            u = u + param[2, 0];         // param[3,0] = scale * cos(rote) -1
            v = v + param[3, 0];         // param[4,0] = scale * sin(rote)

            for(int i=newPointNum; i<n; i++)
            {
                tempx = Convert.ToDouble(myDGV.Rows[i].Cells[1].Value) * u - v * Convert.ToDouble(myDGV.Rows[i].Cells[2].Value) + dx;
                tempy= Convert.ToDouble(myDGV.Rows[i].Cells[1].Value) * v + u * Convert.ToDouble(myDGV.Rows[i].Cells[2].Value) + dy;
                myDGV.Rows[i].Cells[3].Value = 
                    Math.Round(tempx,4);
                myDGV.Rows[i].Cells[4].Value =
                    Math.Round(tempy, 4);
            }
        }

        /// <summary>
        /// 四参数相关变量初始化
        /// </summary>
        /// <param name="myDGV 存放数据的表格"></param>
        /// <param name="rota 旋转因子"></param>
        /// <param name="scale 缩放因子"></param>
        /// <param name="dx x方向平移量"></param>
        /// <param name="dy y方向平移量"></param>
        public static void calPara(DataGridView myDGV,ref double[,]  param,ref double rota, ref double scale, ref double dx, ref double dy,ref double p)
        {
            // 当表格中点的数量小于2时，弹出警告
            if (myDGV == null || myDGV.Rows.Count <= 1)
            {
                MessageBox.Show("导入行数不能小于2！");
                return;
            }

            int  n= myDGV.Rows.Count-1;         // 点的数量
            Point2D[] p1 = new Point2D[n];      // 旧坐标点
            Point2D[] p2 = new Point2D[n];      // 新坐标点
            int newPointNum = 0;                    // 重合点数量
            for (int i = 0; i < n; i++)                 // 初始化
            {
               
                p1[i].X = Convert.ToDouble(myDGV.Rows[i].Cells[1].Value);
                p1[i].Y = Convert.ToDouble(myDGV.Rows[i].Cells[2].Value);
                if (Convert.ToString(myDGV.Rows[i].Cells[3].Value) != "")
                {
                    p2[i].X = Convert.ToDouble(myDGV.Rows[i].Cells[3].Value);
                    p2[i].Y = Convert.ToDouble(myDGV.Rows[i].Cells[4].Value);
                    newPointNum++;
                }
            }
            
            // 调用Param4函数进行计算
            Param4(myDGV,p1, p2, newPointNum, ref param,ref rota, ref scale, ref dx, ref dy,ref p);

        }

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="myDGV 存放数据的表格"></param>
        public static void InputAdjustData(DataGridView myDGV)
        {
            // 打开存放数据的文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            // 定义文件流变量
            StreamReader reader = new StreamReader(openFileDialog.FileName);
            // 读取第一行，并读入DGV表头
            string sr = reader.ReadLine();
            if (sr != null)
            {
                string[] strings = sr.Split(',', ' ','\t');
                for (int i = 0; i < strings.Length; i++)
                {// 读入表头
                    DataGridViewColumn Column = new DataGridViewColumn();
                    Column.HeaderText = strings[i];
                    Column.CellTemplate = new DataGridViewTextBoxCell();
                    myDGV.Columns.Add(Column);
                }
                // 逐行读取，存入表格DGV中
                while (!reader.EndOfStream)
                {
                    string[] strings1 = reader.ReadLine().Split(',', ' ','\t');
                    int id = myDGV.Rows.Add();
                    for (int j = 0; j < strings1.Length ; j++)
                    {
                        myDGV[j, id].Value = strings1[j];
                        
                    }
                }
                reader.Close();
            }
        }

        /// <summary>
        /// 导出表格中的数据
        /// </summary>
        /// <param name="myDGV 存放数据的表格"></param>
        public static void OutPara(DataGridView myDGV)
        {
            // 打开文件并读取路径
            string outFilePath = "";
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Title = "导出TXT结果";
            SaveFileDialog1.Filter = "导出TXT结果 (*.txt)|*.txt";
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string saveFilename = SaveFileDialog1.FileName;
                if (!string.IsNullOrEmpty(saveFilename))
                {
                    outFilePath = SaveFileDialog1.FileName;
                }
            }
            if (outFilePath == "")
            {
                MessageBox.Show("导出路径不存在！");
                return;
            }
            if (myDGV == null || myDGV.Rows.Count == 0)
            {
                MessageBox.Show("导出行数不能为空！");
                return;
            }

            // 逐行读取，每行中的数据通过,隔开
            FileStream fileStream = new FileStream(outFilePath, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                //添加列名 
                for (int j = 0; j < myDGV.Columns.Count; j++)
                {
                    strBuilder.Append(myDGV.Columns[j].HeaderText.ToString() + ",");
                }
                streamWriter.WriteLine(strBuilder.ToString());
                //添加每行数据
                for (int i = 0; i < myDGV.Rows.Count-1; i++)
                {
                    strBuilder = new StringBuilder();
                    for (int j = 0; j < myDGV.Columns.Count; j++)
                    {
                        strBuilder.Append(myDGV.Rows[i].Cells[j].Value.ToString() + ",");
                    }
                    streamWriter.WriteLine(strBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                streamWriter.Close();
                fileStream.Close();
            }
        }

    }
}
