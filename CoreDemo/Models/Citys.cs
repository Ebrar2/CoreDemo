namespace CoreDemo.Models
{
	public class Citys
	{
		public Citys(int id, string cityName, bool status)
		{
			this.id = id;
			this.cityName = cityName;
			this.status = status;
		}

		public int id { get; set; }
		public string cityName { get; set; }
		public bool status { get; set; }

	
	}
}
