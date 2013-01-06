using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;

namespace Mosaic.Business
{
    public class ImageMapGenerator
    {
        private string SourceFileUrl;
        private string SourceImageFile;

        public ImageMapGenerator(string sourceFileUrl)
        {
            SourceFileUrl = sourceFileUrl;            
            SourceImageFile = Directory.GetFiles(SourceImageDirectory).FirstOrDefault();

            if (!File.Exists(SourceImageFile))
            {
                throw new Exception("Error resolving source image");
            }
        }

        public MapGrid CreateImageMap(string width, string height)
        {
            return GenerateMap(SourceImageFile, Convert.ToInt32(width), Convert.ToInt32(height));
        }

        public static MapGrid GenerateMap(string filePath, int cellWidth, int cellHeight)
        {
            Bitmap image = new Bitmap(filePath);
            int imageHeight = image.Height;
            int imageWidth = image.Width;           
            int columnCount = image.Width / cellWidth;
            int rowCount = image.Height / cellHeight;

            MapGrid grid = new MapGrid();
            grid.CellWidth = cellWidth;
            grid.CellHeight = cellHeight;            
            grid.ColumnCount = columnCount;
            grid.RowCount = rowCount;


            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    int posX = col * cellWidth;
                    int posY = row * cellHeight;

                    try
                    {                        
                        Bitmap cellImage = new Bitmap(cellWidth, cellHeight,image.PixelFormat);
                        if ((row != (rowCount - 1)) && (col != (columnCount - 1)))
                        {
                            // loop down a row
                            for(int i =0; i < cellHeight; i++) 
                            {
                                for(int j=0; j < cellWidth; j++)
                                {
                                    var pixelColor = image.GetPixel(posX + j, posY + i);
                                    cellImage.SetPixel(j, i, pixelColor);
                                }
                            }
                            
                        }
                        else
                        {
                            int cellEdgeHeight = cellHeight;
                            int cellEdgeWidth = cellWidth;

                            if (row == (rowCount - 1))
                            {
                                cellEdgeHeight = imageHeight - (row * cellHeight);
                            }

                            if (col == (columnCount - 1))
                            {
                                cellEdgeWidth = imageWidth - (col * cellWidth);
                            }
                        }
                        var cellAverage = ImageLibraryGenerator.GetAverageColorFromBitmap(cellImage);
                        grid.AddCell(new MapCell(posX, posY, cellAverage.ToString(), cellAverage));
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
            
            return grid;
        }

        public void WriteXmlMapToFile(string xmlString)
        {
            using (TextWriter textWriter = new StreamWriter(ConfigurationManager.AppSettings["ImageMapXmlOutputPath"]))
            {
                textWriter.Write(xmlString);
            }
        } 
    }   
}
