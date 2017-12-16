using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


public enum RotateType { OY, OZ, OX };

namespace RotateImage
{
    class myRotate
    {
        /// <summary>
        /// угол поворота
        /// </summary>
        public float Angle;

        private System.Drawing.Drawing2D.Matrix rotatematrix = new System.Drawing.Drawing2D.Matrix();

        public static myRotate Rotate = new myRotate();

        /// <summary>
        /// тип поворота
        /// обнуляемый тип
        /// </summary>
        public RotateType? type = null;

        /// <summary>
        /// константа для преобразования градусов ->  радианы
        /// </summary>
        public static readonly float ToRadian = (float)(Math.PI / 180);


        private myRotate()
        {

        }
        /// <summary>
        /// поворот изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void my_pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (type == null) throw new ArgumentNullException("нужно задать тип поворота");

            e.Graphics.Clear(Color.White);


            if (((PictureBox)sender).Image != null)
            {

                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

                // линейное преобразование сдвиг начала координат на вектр ( x/2 , y/2)
                e.Graphics.TranslateTransform(((PictureBox)sender).Width / 2, ((PictureBox)sender).Height / 2);

                switch (type)
                {

                    case RotateType.OZ:
                        {
                            // поворот изображения на заданный угол
                            e.Graphics.RotateTransform(Angle);

                            // рисование изображения  в центре pictureBox
                            if (((PictureBox)sender).Image.Width < ((PictureBox)sender).Width / 2F && ((PictureBox)sender).Image.Height < ((PictureBox)sender).Height / 2F)
                            {
                                e.Graphics.DrawImage(((PictureBox)sender).Image, -((PictureBox)sender).Image.Width / 2F,
                                    -((PictureBox)sender).Image.Height / 2F);
                            }
                            else
                            {
                                e.Graphics.DrawImage(((PictureBox)sender).Image, -2 * ((PictureBox)sender).Width / 6F, -2 * ((PictureBox)sender).Height / 6F,
                                2 * ((PictureBox)sender).Width / 3F, 2 * ((PictureBox)sender).Height / 3F);
                            }
                            break;
                        }
                    case RotateType.OY:
                        {

                            this.rotatematrix = new System.Drawing.Drawing2D.Matrix((float)Math.Cos(ToRadian * this.Angle), 0, 0, 1, 0, 0);




                            e.Graphics.MultiplyTransform(this.rotatematrix, System.Drawing.Drawing2D.MatrixOrder.Prepend);

                            // рисование изображения  в центре pictureBox
                            if (((PictureBox)sender).Image.Width < ((PictureBox)sender).Width / 2F && ((PictureBox)sender).Image.Height < ((PictureBox)sender).Height / 2F)
                            {
                                e.Graphics.DrawImage(((PictureBox)sender).Image, -((PictureBox)sender).Image.Width / 2F,
                                    -((PictureBox)sender).Image.Height / 2F);
                            }
                            else
                            {
                                e.Graphics.DrawImage(((PictureBox)sender).Image, -2 * ((PictureBox)sender).Width / 6F, -2 * ((PictureBox)sender).Height / 6F,
                                ((PictureBox)sender).Width / 2F, 2 * ((PictureBox)sender).Height / 3F);
                            }


                            break;
                        }
                    case RotateType.OX:
                        {
                            this.rotatematrix = new System.Drawing.Drawing2D.Matrix(1, 0, 0, (float)Math.Cos(ToRadian * this.Angle), 0, 0);



                            e.Graphics.MultiplyTransform(this.rotatematrix, System.Drawing.Drawing2D.MatrixOrder.Prepend);

                            // рисование изображения  в центре pictureBox
                            if (((PictureBox)sender).Image.Width < ((PictureBox)sender).Width / 2F && ((PictureBox)sender).Image.Height < ((PictureBox)sender).Height / 2F)
                            {
                                e.Graphics.DrawImage(((PictureBox)sender).Image, -((PictureBox)sender).Image.Width / 2F,
                                    -((PictureBox)sender).Image.Height / 2F);
                            }
                            else
                            {
                                e.Graphics.DrawImage(((PictureBox)sender).Image, -2 * ((PictureBox)sender).Width / 6F, -2 * ((PictureBox)sender).Height / 6F,
                                ((PictureBox)sender).Width / 2F, 2 * ((PictureBox)sender).Height / 3F);
                            }
                            break;
                        }

                        // сдвиг начала координат в первоначальное положение
                        

                }
                e.Graphics.TranslateTransform(-((PictureBox)sender).Width / 2, -((PictureBox)sender).Height / 2);
            }
        }
    }
}
