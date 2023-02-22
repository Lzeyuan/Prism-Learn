namespace Prism_Learn.Common.Models
{
    public class TodoDto : BaseDto
    {
		private string title;

		public string Title {
			get { return title; }
			set { title = value; }
		}

		private string content;

		public string Content {
			get { return content; }
			set { content = value; }
		}

		private int status;

		public int Status {
			get { return status; }
			set { status = value; }
		}

	}
}
