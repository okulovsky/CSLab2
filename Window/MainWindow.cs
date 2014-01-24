using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lab2
{
	public class MainWindow : Form
	{
		Bitmap originalBmp;
        Photo originalPhoto;
		PictureBox original;
		PictureBox processed;
		ComboBox filtersSelect;
		Panel parametersPanel;
		List<NumericUpDown> parametersControls;
		Button apply;
		
		public MainWindow ()
		{
			original=new PictureBox();
			Controls.Add (original);
			
            processed=new PictureBox();
			Controls.Add(processed);
			
            filtersSelect=new ComboBox();
			filtersSelect.DropDownStyle = ComboBoxStyle.DropDownList;
			filtersSelect.SelectedIndexChanged+=FilterChanged;
			Controls.Add (filtersSelect);

            apply=new Button();
			apply.Text="Применить";
			apply.Enabled=false;
			apply.Click+=Process;
			Controls.Add (apply);

            Text="Photoshop pre-alpha release";
			FormBorderStyle = FormBorderStyle.FixedDialog;

            Menu = new MainMenu(new[] {
                new MenuItem("Открыть JPG",new EventHandler(OpenJPEG)),
                new MenuItem("Открыть MyFormat",new EventHandler(OpenMyFormat)),
                new MenuItem("Сохранить MyFormat",new EventHandler(SaveMyFormat))
             });

            LoadBitmap((Bitmap)Image.FromFile("cat.jpg"));
		}

        public void LoadBitmap(Bitmap bmp)
        {
            originalBmp = bmp;
            originalPhoto = Convertors.Bitmap2Photo(bmp);

            original.Image = originalBmp;
            original.Left = 0;
            original.Top = 0;
            original.ClientSize = originalBmp.Size;

            processed.Left = 0;
            processed.Top = original.Bottom;
            processed.Size = original.Size;

            filtersSelect.Left = original.Right + 10;
            filtersSelect.Top = 20;
            filtersSelect.Width = 200;
            filtersSelect.Height = 20;


            ClientSize = new Size(filtersSelect.Right + 20, processed.Bottom);

            apply.Left = ClientSize.Width - 100;
            apply.Top = ClientSize.Height - 50;
            apply.Width = 80;
            apply.Height = 40;

            FilterChanged(null, EventArgs.Empty);
        }

        void OpenJPEG(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            dlg.Filter = "(*.jpg) JPEG files|*.jpg";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            var bmp = (Bitmap)Image.FromFile(dlg.FileName);
            LoadBitmap(bmp);
        }

        void OpenMyFormat(object sender, EventArgs e)
        {
            var ph = Files.Open();
            if (ph == null) return;
            var bmp = Convertors.Photo2Bitmap(ph);
            LoadBitmap(bmp);
        }

        void SaveMyFormat(object sender, EventArgs e)
        {
            Files.Save(originalPhoto);
        }
        		
		public void AddFilter(IFilter filter)
		{
			filtersSelect.Items.Add(filter);
			if (filtersSelect.SelectedIndex==-1)
			{
				filtersSelect.SelectedIndex=0;
				apply.Enabled=true;
			}
		}
		
		void FilterChanged(object sender, EventArgs e)
		{
			var filter=(IFilter)filtersSelect.SelectedItem;
			if (filter==null) return;
			if (parametersPanel!=null) Controls.Remove (parametersPanel);
			parametersControls=new List<NumericUpDown>();
			parametersPanel=new Panel();
			parametersPanel.Left=filtersSelect.Left;
			parametersPanel.Top=filtersSelect.Bottom+10;
			parametersPanel.Width=filtersSelect.Width;
			parametersPanel.Height=ClientSize.Height-parametersPanel.Top;
			
			int y=0;
			
			foreach(var param in filter.GetParameters ())
			{
				var label=new Label();
				label.Left=0;
				label.Top=y;
				label.Width=parametersPanel.Width-50;
				label.Height=20;
				label.Text=param.Name;
				parametersPanel.Controls.Add (label);
				
				var box=new NumericUpDown();
				box.Left=label.Right;
				box.Top=y;
				box.Width=50;
				box.Height=20;
				box.Value=(decimal)param.DefaultValue;
				box.Increment=(decimal)param.Increment/3;
				box.Maximum=(decimal)param.MaxValue;
				box.Minimum=(decimal)param.MinValue;
                box.DecimalPlaces = 2;
				parametersPanel.Controls.Add (box);
				y+=label.Height+5;
				parametersControls.Add(box);
			}
			Controls.Add (parametersPanel);
		}
		
		
		void Process(object sender, EventArgs empty)
		{
			var data=parametersControls.Select(z=>(double)z.Value).ToArray();
			var filter=(IFilter)filtersSelect.SelectedItem;
			Photo result=null;
     		result=filter.Process(originalPhoto,data);
	        var resultBmp=Convertors.Photo2Bitmap (result);
			processed.Image=resultBmp;
		}

        
	}
}
