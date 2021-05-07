using System.Collections.Generic;

namespace Factory.Models
{
	public class Machine
	{
		public int MachineId { get; set; }
		public string Name { get; set; }
		public int EngineerId { get; set; }
		public virtual ICollection<EngineerMachine> Engineers { get; }

		public Machine()
		{
			this.Engineers = new HashSet<EngineerMachine>();
		}
	}
}