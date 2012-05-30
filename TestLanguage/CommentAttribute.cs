using System;

namespace TestLanguage
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method, Inherited=true)]
	public class CommentAttribute : Attribute
	{
		private string text;
		
		public string Text { get {return text;} }
		
		public string Author { get; set; }
		
		public CommentAttribute (string text) 
		{ 
			this.text = text; 
		}
		
		[Comment("t")]
		public void M1()
		{
			
		}
		
		[CommentAttribute("t", Author = "a")]
		public void M2()
		{
			
		}
	}
}
