using Grid.Models;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Grid
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}


		public static Database.SADBContext sa = new Database.SADBContext();
		public static Database.IMCDBContext imc = new Database.IMCDBContext();
		private static ObservableCollection<LiveRecord> liveRecords;
		public static ObservableCollection<LiveRecord> LiveRecords
		{
			get
			{
				if (liveRecords == null)
				{
					liveRecords = new ObservableCollection<LiveRecord>();

					//Add Live Records for customer table where latitude is valid
					foreach (var rec in sa.customers
						.Where(c => c.latitude != 0 && c.latitude != null && c.longitude != 0 && c.longitude != null)
						.Where(c=>(c.size == 0 || c.size == 0.07m || c.size >=1) && c.size<=699))
					{
						liveRecords.Add(new LiveRecord(rec));
					}

					//And again for markcust table
					foreach (var rec in sa.markcusts
						.Where(c => c.latitude != 0 && c.latitude != null && c.longitude != 0 && c.longitude != null)
						.Where(c => (c.size == 0 || c.size == 0.07m || c.size >= 1) && c.size <= 699))
					{
						liveRecords.Add(new LiveRecord(rec));
					}
				}
				return liveRecords;
			}
		}

		private bool mapModeToggler = false;
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (!mapModeToggler)
			{
				MainMap.Mode = new AerialMode();
				mapModeToggler = true;
			}
			else
			{
				MainMap.Mode = new RoadMode();
				mapModeToggler = false;
			}
		}


		private double? latTop;
		public double LatTop
		{
			get
			{
				if (latTop == null)
				{
					var x = LiveRecords
						.Where(r => r.Status == "9")
						.Select(r => r.Latitude)
						.Max();
					latTop = x;
				}
				return (double)latTop;
			}
		}

		private double? latBottom;
		public double LatBottom
		{
			get
			{
				if (latBottom == null)
				{
					var x = LiveRecords
						.Where(r => r.Status == "9")
						.Select(r => r.Latitude)
						.Min();
					latBottom = x;
				}
				return (double)latBottom;
			}
		}

		private double? lonLeft;
		public double LonLeft
		{
			get
			{
				if (lonLeft == null)
				{
					var x = LiveRecords
						.Where(r => r.Status == "9")
						.Select(r => r.Longitude)
						.Min();
					lonLeft = x;
				}
				return (double)lonLeft;
			}
		}

		private double? lonRight;
		public double LonRight
		{
			get
			{
				if (lonRight == null)
				{
					var x = LiveRecords
						.Where(r => r.Status == "9")
						.Select(r => r.Longitude)
						.Max();
					lonRight = x;
				}
				return (double)lonRight;
			}
		}

		public double LatCenter { get => (LatTop + LatBottom) / 2; }
		public double LonCenter { get => (LonLeft + LonRight) / 2; }

		public Location Center
		{
			get => new Location
			{
				Latitude = LatCenter,
				Longitude = LonCenter
			};
		}

		private int divLat;
		public int DivLat
		{
			get
			{
				if (divLat < 0) return 0;
				return divLat;
			}
			set
			{
				divLat = value;

			}
		}
		public int SectLat { get => DivLat + 1; }

		private int divLon;
		public int DivLon
		{
			get
			{
				if (divLon < 0) return 0;
				return divLon;
			}
			set
			{
				divLon = value;
			}
		}

		private void Btn_ApplyDivisions_Click(object sender, RoutedEventArgs e)
		{
			blocks = null;
			var forceCalc = Blocks.ToString();
			DrawGrid();
		}
		private void Btn_ClearDivisions_Click(object sender, RoutedEventArgs e)
		{
			DeleteBlock("block");
		}

		public int SectLon { get => DivLon + 1; }


		private ObservableCollection<Models.Block> blocks;
		public ObservableCollection<Models.Block> Blocks
		{
			get
			{
				if (blocks == null)
				{
					blocks = new ObservableCollection<Models.Block>();
					var latRange = Math.Abs(LatTop - LatBottom);
					var lonRange = Math.Abs(LonLeft - LonRight);
					for (int i = 0; i < DivLon + 1; i++)
					{
						for (int j = 0; j < DivLat + 1; j++)
						{
							var block = new Models.Block();
							block.LatTop = LatTop - (j * latRange / SectLat);
							block.LatBottom = LatTop - ((j + 1) * latRange / SectLat);
							block.LonLeft = LonLeft + (i * lonRange / SectLon);
							block.LonRight = LonLeft + ((i + 1) * lonRange / SectLon);
							blocks.Add(block);
						}
					}
				}
				return blocks;
			}
		}


		public bool showGrid;
		public bool ShowGrid
		{
			get
			{
				return showGrid;
			}
			set
			{
				if (value == false)
				{
					Hide();
				}
				else
				{
					RevealBlock("Grid");
				}
				showGrid = value;
			}
		}
		private void DrawGrid()
		{
			int i = 0;
			foreach (var b in Blocks)
			{
				i++;
				MapPolygon polygon = new MapPolygon();
				polygon.Name = "block" + i.ToString();
				polygon.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
				polygon.StrokeThickness = 1;
				polygon.Locations = b.LocationCellection;
				MainMap.Children.Add(polygon);
			}
		}

		public bool showBlock = true;
		public bool ShowBlock
		{
			get
			{
				return showBlock;
			}
			set
			{
				if (value == false)
				{
					HideBlock("block");
				}
				else
				{
					RevealBlock("block");
				}
				showBlock = value;
			}
		}

		private double gridOpacity;
		public double GridOpacity
		{
			get
			{
				return gridOpacity;
			}
			set
			{
				gridOpacity = value;
				AlterOpacity("block", value);
			}
		}

		#region Density
		private double densityOpacity;
		public double DensityOpacity
		{
			get { return densityOpacity; }
			set
			{
				densityOpacity = value;
				AlterOpacity("density", value);
			}
		}

		public bool showDensity = true;
		public bool ShowDensity
		{
			get
			{
				return showDensity;
			}
			set
			{
				if (value == false)
				{
					HideBlock("density");
				}
				else
				{
					RevealBlock("density");
				}
				showDensity = value;
			}
		}

		public double TopPercent_Density { get; set; }

		private void btn_FillDensity_Click(object sender, RoutedEventArgs e)
		{
			DrawDensity();
		}

		private void btn_ClearDensity_Click(object sender, RoutedEventArgs e)
		{
			DeleteBlock("density");
		}

		private void DrawDensity()
		{
			int i = 0;
			var selectionFormula = (int)Math.Ceiling(Blocks.Count() * (Slider_TopPercent_Density.Value) / 100d);
			var topRecords = Blocks
				.OrderByDescending(block => block.Density.GetDoubleResult())
				.Take(selectionFormula);
			var allRecords = Blocks
					.OrderByDescending(block => block.Density.GetDoubleResult()).ToList();
			var max = allRecords.Select(r => r.Density.GetDoubleResult()).Max();
			var min = allRecords.Select(r => r.Density.GetDoubleResult()).Min();
			foreach (var b in topRecords)
			{
				i++;
				MapPolygon polygon = new MapPolygon();
				polygon.Name = "density" + i.ToString();
				polygon.Fill = new Gradiator(min,max,b.Density.GetDoubleResult()).SolidColorBrush;

				DensityOpacity = 0.3;
				polygon.Locations = b.LocationCellection;
				polygon.Visibility = ShowDensity == true ? Visibility.Visible : Visibility.Hidden;
				MainMap.Children.Add(polygon);
			}

		}
		#endregion

		#region Penetration
		private double penetrationOpacity;
		public double PenetrationOpacity
		{
			get { return penetrationOpacity; }
			set
			{
				penetrationOpacity = value;
				AlterOpacity("penetration", value);
			}
		}
		public bool showPenetration = true;
		public bool ShowPenetration
		{
			get
			{
				return showPenetration;
			}
			set
			{
				if (value == false)
				{
					HideBlock("penetration");
				}
				else
				{
					RevealBlock("penetration");
				}
				showPenetration = value;
			}
		}
		public double TopPercent_Penetration { get; set; }
		private void btn_FillPenetration_Click(object sender, RoutedEventArgs e)
		{
			DrawPenetration();
		}

		private void btn_ClearPenetration_Click(object sender, RoutedEventArgs e)
		{
			DeleteBlock("penetration");
		}
		private void DrawPenetration()
		{
			int i = 0;
			var selectionFormula = (int)Math.Ceiling(Blocks.Count() * (Slider_TopPercent_Penetration.Value) / 100d);
			var topRecords = Blocks
				.OrderByDescending(block => block.Penetration.GetDoubleResult())
				.Take(selectionFormula);
			var allRecords = Blocks
					.OrderByDescending(block => block.Penetration.GetDoubleResult()).ToList();
			var max = allRecords.Select(r => r.Penetration.GetDoubleResult()).Max();
			var min = allRecords.Select(r => r.Penetration.GetDoubleResult()).Min();
			foreach (var b in topRecords)
			{
				i++;
				MapPolygon polygon = new MapPolygon();
				polygon.Name = "penetration" + i.ToString();
				polygon.Fill = new Gradiator(min,max,b.Penetration.GetDoubleResult()).SolidColorBrush;

				PenetrationOpacity = 0.3;
				polygon.Locations = b.LocationCellection;
				polygon.Visibility = ShowPenetration == true ? Visibility.Visible : Visibility.Hidden;
				MainMap.Children.Add(polygon);
			}

		}
		#endregion

		#region Penetration124
		private double penetration124Opacity;
		public double Penetration124Opacity
		{
			get { return penetration124Opacity; }
			set
			{
				penetration124Opacity = value;
				AlterOpacity("penetration124", value);
			}
		}
		public bool showPenetration124 = true;
		public bool ShowPenetration124
		{
			get
			{
				return showPenetration124;
			}
			set
			{
				if (value == false)
				{
					HideBlock("penetration124");
				}
				else
				{
					RevealBlock("penetration124");
				}
				showPenetration124 = value;
			}
		}
		public double TopPercent_Penetration124 { get; set; }
		private void btn_FillPenetration124_Click(object sender, RoutedEventArgs e)
		{
			DrawPenetration124();
		}

		private void btn_ClearPenetration124_Click(object sender, RoutedEventArgs e)
		{
			DeleteBlock("penetration124");
		}
		private void DrawPenetration124()
		{
			int i = 0;
			var selectionFormula = (int)Math.Ceiling(Blocks.Count() * (Slider_TopPercent_Penetration124.Value) / 100d);
			var topRecords = Blocks
				.OrderByDescending(block => block.Penetration124.GetDoubleResult())
				.Take(selectionFormula);
			var allRecords = Blocks
					.OrderByDescending(block => block.Penetration124.GetDoubleResult()).ToList();
			var max = allRecords.Select(r => r.Penetration124.GetDoubleResult()).Max();
			var min = allRecords.Select(r => r.Penetration124.GetDoubleResult()).Min();
			foreach (var b in topRecords)
			{
				i++;
				MapPolygon polygon = new MapPolygon();
				polygon.Name = "penetration124" + i.ToString();
				polygon.Fill = new Gradiator(min, max, b.Penetration124.GetDoubleResult()).SolidColorBrush;

				Penetration124Opacity = 0.3;
				polygon.Locations = b.LocationCellection;
				polygon.Visibility = ShowPenetration124 == true ? Visibility.Visible : Visibility.Hidden;
				MainMap.Children.Add(polygon);
			}

		}
		#endregion

		#region PenetrationLargeLawn
		private double penetrationLargeLawnOpacity;
		public double PenetrationLargeLawnOpacity
		{
			get { return penetrationLargeLawnOpacity; }
			set
			{
				penetrationLargeLawnOpacity = value;
				AlterOpacity("penetrationLargeLawn", value);
			}
		}
		public bool showPenetrationLargeLawn = true;
		public bool ShowPenetrationLargeLawn
		{
			get
			{
				return showPenetrationLargeLawn;
			}
			set
			{
				if (value == false)
				{
					HideBlock("penetrationLargeLawn");
				}
				else
				{
					RevealBlock("penetrationLargeLawn");
				}
				showPenetrationLargeLawn = value;
			}
		}
		public double TopPercent_PenetrationLargeLawn { get; set; }
		private void btn_FillPenetrationLargeLawn_Click(object sender, RoutedEventArgs e)
		{
			DrawPenetrationLargeLawn();
		}

		private void btn_ClearPenetrationLargeLawn_Click(object sender, RoutedEventArgs e)
		{
			DeleteBlock("penetrationLargeLawn");
		}
		private void DrawPenetrationLargeLawn()
		{
			int i = 0;
			var selectionFormula = (int)Math.Ceiling(Blocks.Count() * (Slider_TopPercent_PenetrationLargeLawn.Value) / 100d);
			var topRecords = Blocks
				.OrderByDescending(block => block.PenetrationLargeLawn.GetDoubleResult())
				.Take(selectionFormula);
			var allRecords = Blocks
					.OrderByDescending(block => block.PenetrationLargeLawn.GetDoubleResult()).ToList();
			var max = allRecords.Select(r => r.PenetrationLargeLawn.GetDoubleResult()).Max();
			var min = allRecords.Select(r => r.PenetrationLargeLawn.GetDoubleResult()).Min();
			foreach (var b in topRecords)
			{
				i++;
				MapPolygon polygon = new MapPolygon();
				polygon.Name = "penetrationLargeLawn" + i.ToString();
				polygon.Fill = new Gradiator(min, max, b.PenetrationLargeLawn.GetDoubleResult()).SolidColorBrush;

				PenetrationLargeLawnOpacity = 0.3;
				polygon.Locations = b.LocationCellection;
				polygon.Visibility = ShowPenetrationLargeLawn == true ? Visibility.Visible : Visibility.Hidden;
				
				MainMap.Children.Add(polygon);
			}

		}
		#endregion

		#region Unmeasured
		private double unmeasuredOpacity;
		public double UnmeasuredOpacity
		{
			get { return unmeasuredOpacity; }
			set
			{
				unmeasuredOpacity = value;
				AlterOpacity("unmeasured", value);
			}
		}
		public bool showUnmeasured = true;
		public bool ShowUnmeasured
		{
			get
			{
				return showUnmeasured;
			}
			set
			{
				if (value == false)
				{
					HideBlock("unmeasured");
				}
				else
				{
					RevealBlock("unmeasured");
				}
				showUnmeasured = value;
			}
		}
		public double TopPercent_Unmeasured { get; set; }
		private void btn_FillUnmeasured_Click(object sender, RoutedEventArgs e)
		{
			DrawUnmeasured();
		}

		private void btn_ClearUnmeasured_Click(object sender, RoutedEventArgs e)
		{
			DeleteBlock("unmeasured");
		}
		private void DrawUnmeasured()
		{
			int i = 0;
			var selectionFormula = (int)Math.Ceiling(Blocks.Count() * (Slider_TopPercent_Unmeasured.Value) / 100d);
			var topRecords = Blocks
				.OrderByDescending(block => block.Unmeasured.GetDoubleResult())
				.Take(selectionFormula);
			var allRecords = Blocks
					.OrderByDescending(block => block.Unmeasured.GetDoubleResult()).ToList();
			var max = allRecords.Select(r => r.Unmeasured.GetDoubleResult()).Max();
			var min = allRecords.Select(r => r.Unmeasured.GetDoubleResult()).Min();
			foreach (var b in topRecords)
			{
				i++;
				MapPolygon polygon = new MapPolygon();
				polygon.Name = "unmeasured" + i.ToString();
				polygon.Fill = new Gradiator(min, max, b.Unmeasured.GetDoubleResult()).SolidColorBrush;

				UnmeasuredOpacity = 0.3;
				polygon.Locations = b.LocationCellection;
				polygon.Visibility = ShowUnmeasured == true ? Visibility.Visible : Visibility.Hidden;
				polygon.ToolTip = b.Unmeasured.GetDoubleResult().ToString();
				MainMap.Children.Add(polygon);
			}

		}
		#endregion

		#region AverageSize
		private double averageSizeOpacity;
		public double AverageSizeOpacity
		{
			get { return averageSizeOpacity; }
			set
			{
				averageSizeOpacity = value;
				AlterOpacity("averageSize", value);
			}
		}
		public bool showAverageSize = true;
		public bool ShowAverageSize
		{
			get
			{
				return showAverageSize;
			}
			set
			{
				if (value == false)
				{
					HideBlock("averageSize");
				}
				else
				{
					RevealBlock("averageSize");
				}
				showAverageSize = value;
			}
		}
		public double TopPercent_AverageSize { get; set; }
		private void btn_FillAverageSize_Click(object sender, RoutedEventArgs e)
		{
			DrawAverageSize();
		}

		private void btn_ClearAverageSize_Click(object sender, RoutedEventArgs e)
		{
			DeleteBlock("averageSize");
		}
		private void DrawAverageSize()
		{
			int i = 0;
			var selectionFormula = (int)Math.Ceiling(Blocks.Count() * (Slider_TopPercent_AverageSize.Value) / 100d);

			var allRecords = Blocks
				.OrderByDescending(block => block.AverageSize.GetDoubleResult()).ToList();


			var max = allRecords.Select(r => r.AverageSize.GetDoubleResult()).Max();
			var min = allRecords.Select(r => r.AverageSize.GetDoubleResult()).Min();

			var topRecords = allRecords
				.Take(selectionFormula);
			foreach (var b in topRecords)
			{
				i++;
				MapPolygon polygon = new MapPolygon();
				polygon.Name = "averageSize" + i.ToString();
				polygon.Fill = new Gradiator(min, max, b.AverageSize.GetDoubleResult()).SolidColorBrush;

				AverageSizeOpacity = 0.3;
				polygon.Locations = b.LocationCellection;
				polygon.Visibility = ShowAverageSize == true ? Visibility.Visible : Visibility.Hidden;
				polygon.ToolTip = b.AverageSize.GetDoubleResult().ToString();
				MainMap.Children.Add(polygon);
			}

		}
		#endregion




		private void HideBlock(string blockType)
		{
			foreach (var poly in MainMap.Children)
			{
				if (poly.GetType() == typeof(MapPolygon))
				{
					var pgon = (MapPolygon)poly;
					if (pgon.Name.Contains(blockType))
					{
						pgon.Visibility = Visibility.Collapsed;
					}
				}
			}
		}

		private void RevealBlock(string blockType)
		{
			foreach (var poly in MainMap.Children)
			{
				if (poly.GetType() == typeof(MapPolygon))
				{
					var pgon = (MapPolygon)poly;
					if (pgon.Name.Contains(blockType))
					{
						pgon.Visibility = Visibility.Visible;
					}
				}
			}
		}

		private void DeleteBlock(string blockType)
		{
			List<UIElement> targets = new List<UIElement>();
			foreach (var poly in MainMap.Children)
			{
				if (poly.GetType() == typeof(MapPolygon))
				{
					var pgon = (MapPolygon)poly;
					if (pgon.Name.Contains(blockType))
					{
						targets.Add(pgon);
					}
				}
			}

			foreach (var t in targets) MainMap.Children.Remove(t);
		}

		private void AlterOpacity(string blockType, double value)
		{
			foreach (var b in MainMap.Children)
			{
				if (b.GetType() == typeof(MapPolygon))
				{
					var p = (MapPolygon)b;
					if (p.Name.Contains(blockType))
					{
						p.Opacity = value;
					}
				}
			}
		}


	}
}
